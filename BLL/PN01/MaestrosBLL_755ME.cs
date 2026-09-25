using System.Text.RegularExpressions;
using BE;
using DAL;
using INT;
using SER.Composite;

namespace BLL
{
    // Maestros: alta/baja de Consorcio, Unidad Funcional y Consorcista
    public class MaestrosBLL_755ME
    {
        // patentes que identifican a un gestor de consorcios (directas o por familia)
        private static readonly TipoPatente[] _patentesDeGestor_755ME =
        {
            TipoPatente.AnularExpensa_755ME, TipoPatente.RegistrarPago_755ME, TipoPatente.ObtenerMorosidad_755ME,
            TipoPatente.GenerarLiquidacion_755ME, TipoPatente.EmitirEstadoCuenta_755ME, TipoPatente.GenerarOrdenPago_755ME,
            TipoPatente.RegistrarEgreso_755ME, TipoPatente.RevisarComposicion_755ME, TipoPatente.ObtenerEstadoFondo_755ME,
            TipoPatente.GestGastos_755ME
        };

        private readonly ConsorcioDAL_755ME _consorcioDAL = new ConsorcioDAL_755ME();
        private readonly UnidadFuncionalDAL_755ME _ufDAL = new UnidadFuncionalDAL_755ME();
        private readonly ConsorcistaDAL_755ME _consorcistaDAL = new ConsorcistaDAL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        // ---------- Consorcio ----------

        public List<ConsorcioBE_755ME> ObtenerTodosLosConsorcios_755ME()
        {
            return _consorcioDAL.ObtenerTodos_755ME();
        }

        // solo usuarios con alguna patente de PN01 (directa o por familia)
        public List<Usuario> ObtenerUsuariosGestores_755ME()
        {
            PermisoBLL permisoBLL = new PermisoBLL();
            List<Usuario> usuarios = new UsuarioBLL().GetAll().ToList();
            List<Usuario> gestores = new List<Usuario>();
            foreach (Usuario u in usuarios)
            {
                permisoBLL.CompletarPermisosDeUsuario(u);
                if (TienePatenteDeGestor_755ME(u.Permisos)) gestores.Add(u);
            }
            return gestores;
        }

        private static bool TienePatenteDeGestor_755ME(IEnumerable<IPermiso> permisos)
        {
            foreach (IPermiso p in permisos)
            {
                if (p is PermisoCompuesto pc)
                {
                    if (_patentesDeGestor_755ME.Contains(pc.Permiso)) return true;
                    if (TienePatenteDeGestor_755ME(pc.ObtenerHijos)) return true;
                }
            }
            return false;
        }

        public int GuardarConsorcio_755ME(ConsorcioBE_755ME consorcio)
        {
            ValidarConsorcio_755ME(consorcio);
            bool esNuevo = consorcio.IdConsorcio_755ME == 0;
            if (esNuevo)
            {
                _consorcioDAL.Insertar_755ME(consorcio);
            }
            else
            {
                _consorcioDAL.Actualizar_755ME(consorcio);
            }
            RecalcularDvhConsorcio_755ME(consorcio.IdConsorcio_755ME);
            _bitacora.RegistrarDeUsuarioActual(esNuevo ? "Alta de consorcio" : "Modificacion de consorcio", consorcio.IdConsorcio_755ME.ToString(), consorcio.Nombre_755ME);
            return consorcio.IdConsorcio_755ME;
        }

        private static void ValidarConsorcio_755ME(ConsorcioBE_755ME consorcio)
        {
            if (string.IsNullOrWhiteSpace(consorcio.Nombre_755ME) || string.IsNullOrWhiteSpace(consorcio.Direccion_755ME))
            {
                throw new ArgumentException("Debe completar nombre y direccion");
            }
            if (consorcio.CantidadUnidades_755ME <= 0)
            {
                throw new ArgumentException("La cantidad de unidades debe ser mayor a cero");
            }
            if (consorcio.IdGestor_755ME == Guid.Empty)
            {
                throw new ArgumentException("Debe seleccionar un gestor");
            }
        }

        public void InactivarConsorcio_755ME(int idConsorcio)
        {
            if (_consorcioDAL.ContarUnidadesActivas_755ME(idConsorcio) > 0)
            {
                throw new InvalidOperationException("No se puede inactivar un consorcio con unidades funcionales activas");
            }
            CambiarActivoConsorcio_755ME(idConsorcio, false);
        }

        public void ReactivarConsorcio_755ME(int idConsorcio)
        {
            CambiarActivoConsorcio_755ME(idConsorcio, true);
        }

        private void CambiarActivoConsorcio_755ME(int idConsorcio, bool activo)
        {
            ConsorcioBE_755ME consorcio = _consorcioDAL.ObtenerPorId_755ME(idConsorcio);
            consorcio.Activo_755ME = activo;
            int dvh = _verificador.CalcularDVH(consorcio);
            _consorcioDAL.ActualizarActivo_755ME(idConsorcio, activo, dvh);
            ActualizarDvvConsorcio_755ME();
            _bitacora.RegistrarDeUsuarioActual(activo ? "Reactivar consorcio" : "Inactivar consorcio", idConsorcio.ToString(), consorcio.Nombre_755ME);
        }

        private void RecalcularDvhConsorcio_755ME(int idConsorcio)
        {
            ConsorcioBE_755ME consorcio = _consorcioDAL.ObtenerPorId_755ME(idConsorcio);
            int dvh = _verificador.CalcularDVH(consorcio);
            _consorcioDAL.ActualizarDvh_755ME(idConsorcio, dvh);
            ActualizarDvvConsorcio_755ME();
        }

        private void ActualizarDvvConsorcio_755ME()
        {
            _verificador.ActualizarDVV("CONSORCIO", _consorcioDAL.ObtenerTodos_755ME().Cast<IVerificable>().ToList());
        }

        // ---------- Unidad Funcional ----------

        public List<UnidadFuncionalBE_755ME> ObtenerUnidadesPorConsorcio_755ME(int idConsorcio)
        {
            return _ufDAL.ObtenerPorConsorcio_755ME(idConsorcio);
        }

        public int GuardarUnidad_755ME(UnidadFuncionalBE_755ME uf)
        {
            if (string.IsNullOrWhiteSpace(uf.Numero_755ME) || string.IsNullOrWhiteSpace(uf.Tipo_755ME))
            {
                throw new ArgumentException("Debe completar numero y tipo");
            }
            if (uf.Coeficiente_755ME <= 0)
            {
                throw new ArgumentException("El coeficiente debe ser mayor a cero");
            }
            List<UnidadFuncionalBE_755ME> unidadesDelConsorcio = _ufDAL.ObtenerPorConsorcio_755ME(uf.IdConsorcio_755ME);
            bool repetido = unidadesDelConsorcio
                .Any(u => u.IdUnidadFuncional_755ME != uf.IdUnidadFuncional_755ME && string.Equals(u.Numero_755ME.Trim(), uf.Numero_755ME.Trim(), StringComparison.OrdinalIgnoreCase));
            if (repetido)
            {
                throw new ArgumentException("Ya existe una unidad funcional con ese numero en el consorcio");
            }
            bool esNueva = uf.IdUnidadFuncional_755ME == 0;
            if (esNueva)
            {
                // no deja cargar mas unidades que CantidadUnidades
                ConsorcioBE_755ME consorcio = _consorcioDAL.ObtenerPorId_755ME(uf.IdConsorcio_755ME);
                if (unidadesDelConsorcio.Count >= consorcio.CantidadUnidades_755ME)
                {
                    throw new InvalidOperationException("El consorcio " + consorcio.Nombre_755ME + " ya tiene registradas sus " +
                        consorcio.CantidadUnidades_755ME + " unidades funcionales");
                }
                uf.Activa_755ME = true;
                _ufDAL.Insertar_755ME(uf);
            }
            else
            {
                _ufDAL.Actualizar_755ME(uf);
            }
            _bitacora.RegistrarDeUsuarioActual(esNueva ? "Alta de unidad funcional" : "Modificacion de unidad funcional", uf.IdUnidadFuncional_755ME.ToString(), uf.Numero_755ME);
            return uf.IdUnidadFuncional_755ME;
        }

        public void InactivarUnidad_755ME(int idUF)
        {
            if (_ufDAL.ContarExpensasPendientes_755ME(idUF) > 0)
            {
                throw new InvalidOperationException("No se puede inactivar una unidad funcional con expensas pendientes o vencidas");
            }
            _ufDAL.ActualizarActiva_755ME(idUF, false);
            _bitacora.RegistrarDeUsuarioActual("Inactivar unidad funcional", idUF.ToString());
        }

        public void ReactivarUnidad_755ME(int idUF)
        {
            _ufDAL.ActualizarActiva_755ME(idUF, true);
            _bitacora.RegistrarDeUsuarioActual("Reactivar unidad funcional", idUF.ToString());
        }

        // ---------- Consorcista ----------

        public List<ConsorcistaBE_755ME> ObtenerTodosLosConsorcistas_755ME()
        {
            return _consorcistaDAL.ObtenerTodos_755ME();
        }

        public int GuardarConsorcista_755ME(ConsorcistaBE_755ME consorcista)
        {
            if (string.IsNullOrWhiteSpace(consorcista.Nombre_755ME) || string.IsNullOrWhiteSpace(consorcista.Apellido_755ME))
            {
                throw new ArgumentException("Debe completar nombre y apellido");
            }
            if (!Regex.IsMatch(consorcista.DNI_755ME ?? "", @"^\d{7,8}$"))
            {
                throw new ArgumentException("El DNI debe tener 7 u 8 digitos");
            }
            bool esNuevo = consorcista.IdConsorcista_755ME == 0;
            if (esNuevo)
            {
                consorcista.Activo_755ME = true;
                _consorcistaDAL.Insertar_755ME(consorcista);
            }
            else
            {
                _consorcistaDAL.Actualizar_755ME(consorcista);
            }
            _bitacora.RegistrarDeUsuarioActual(esNuevo ? "Alta de consorcista" : "Modificacion de consorcista", consorcista.IdConsorcista_755ME.ToString(), consorcista.Nombre_755ME + " " + consorcista.Apellido_755ME);
            return consorcista.IdConsorcista_755ME;
        }

        public void InactivarConsorcista_755ME(int idConsorcista)
        {
            if (_consorcistaDAL.EsPropietarioDeUnidadActiva_755ME(idConsorcista))
            {
                throw new InvalidOperationException("No se puede inactivar un consorcista propietario de una unidad funcional activa");
            }
            _consorcistaDAL.ActualizarActivo_755ME(idConsorcista, false);
            _bitacora.RegistrarDeUsuarioActual("Inactivar consorcista", idConsorcista.ToString());
        }

        public void ReactivarConsorcista_755ME(int idConsorcista)
        {
            _consorcistaDAL.ActualizarActivo_755ME(idConsorcista, true);
            _bitacora.RegistrarDeUsuarioActual("Reactivar consorcista", idConsorcista.ToString());
        }

        // ---------- Propietario de unidad funcional ----------

        public List<UnidadFuncionalBE_755ME> ObtenerTodasLasUnidades_755ME()
        {
            return _ufDAL.ObtenerTodas_755ME();
        }

        public List<UnidadFuncionalBE_755ME> ObtenerUnidadesDelPropietario_755ME(int idConsorcista)
        {
            return _ufDAL.ObtenerUnidadesDelPropietario_755ME(idConsorcista);
        }

        // una unidad solo puede tener 1 propietario: hay que quitar el actual antes de asignar otro
        public void AsignarPropietario_755ME(int idUnidadFuncional, int idConsorcista)
        {
            int? propietarioActual = _ufDAL.ObtenerIdPropietarioActual_755ME(idUnidadFuncional);
            if (propietarioActual == idConsorcista) return;
            if (propietarioActual.HasValue)
            {
                throw new InvalidOperationException("La unidad funcional ya tiene un propietario asignado; quítelo antes de asignar uno nuevo");
            }
            _ufDAL.AsignarPropietario_755ME(idUnidadFuncional, idConsorcista);
            _bitacora.RegistrarDeUsuarioActual("Asignar propietario de unidad funcional", idUnidadFuncional.ToString(), "Consorcista " + idConsorcista);
        }

        // no deja una unidad con expensas pendientes o vencidas sin propietario
        public void QuitarPropietario_755ME(int idUnidadFuncional, int idConsorcista)
        {
            if (_ufDAL.ContarExpensasPendientes_755ME(idUnidadFuncional) > 0)
            {
                throw new InvalidOperationException("No se puede quitar el propietario de una unidad funcional con expensas pendientes o vencidas");
            }
            _ufDAL.QuitarPropietario_755ME(idUnidadFuncional, idConsorcista);
            _bitacora.RegistrarDeUsuarioActual("Quitar propietario de unidad funcional", idUnidadFuncional.ToString(), "Consorcista " + idConsorcista);
        }
    }
}

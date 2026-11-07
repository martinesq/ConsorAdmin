using BE;
using DAL;
using INT;
using SER.Composite;

namespace BLL
{
    public class ConsorcioBLL_755ME
    {
        // patentes que identifican a un gestor de consorcios (directas o por familia)
        private static readonly TipoPatente[] _patentesDeGestor_755ME =
        {
            TipoPatente.AnularExpensa_755ME, TipoPatente.RegistrarPago_755ME, TipoPatente.ReporteGestion_755ME,
            TipoPatente.GenerarLiquidacion_755ME, TipoPatente.GenerarOrdenPago_755ME, TipoPatente.RegistrarEgreso_755ME,
            TipoPatente.GestGastos_755ME, TipoPatente.FormalizarSolicitud_755ME, TipoPatente.AsignarProveedor_755ME,
            TipoPatente.CargarPrestacion_755ME, TipoPatente.AprobarPrestacion_755ME
        };

        private readonly ConsorcioDAL_755ME _consorcioDAL = new ConsorcioDAL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        // consorcios activos del gestor logueado con al menos una unidad activa
        public List<ConsorcioBE_755ME> ObtenerConsorciosAsignados_755ME()
        {
            return _consorcioDAL.ObtenerConsorciosConUnidadesActivas_755ME();
        }

        public ConsorcioBE_755ME ObtenerPorId_755ME(int idConsorcio)
        {
            return _consorcioDAL.ObtenerPorId_755ME(idConsorcio);
        }

        // ---------- Mantenimiento de consorcios ----------

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
    }
}

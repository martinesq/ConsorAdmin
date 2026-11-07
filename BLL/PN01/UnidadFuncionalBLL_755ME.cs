using BE;
using DAL;
using INT;
using SER;

namespace BLL
{
    public class UnidadFuncionalBLL_755ME
    {
        private readonly UnidadFuncionalDAL_755ME _ufDAL = new UnidadFuncionalDAL_755ME();
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        public List<UnidadFuncionalBE_755ME> ObtenerUnidadesActivas_755ME(int idConsorcio)
        {
            return _ufDAL.ObtenerUnidadesActivas_755ME(idConsorcio);
        }

        public UnidadFuncionalBE_755ME ObtenerPorId_755ME(int idUF)
        {
            return _ufDAL.ObtenerPorId_755ME(idUF);
        }

        // busqueda del historial, siempre dentro de un consorcio: si no la encuentra lanza ExcepcionUnidadNoEncontrada_755ME
        public UnidadFuncionalBE_755ME BuscarPorId_755ME(string id, int idConsorcio)
        {
            if (!int.TryParse(id, out int idUF))
            {
                throw new ExcepcionUnidadNoEncontrada_755ME("El Id debe ser un numero");
            }
            try
            {
                UnidadFuncionalBE_755ME unidad = _ufDAL.ObtenerPorId_755ME(idUF);
                if (unidad.IdConsorcio_755ME == idConsorcio) return unidad;
            }
            catch (InvalidOperationException)
            {
                // no existe: se avisa igual que si fuera de otro consorcio
            }
            throw new ExcepcionUnidadNoEncontrada_755ME("No se encontro la unidad funcional con Id " + id + " en este consorcio");
        }

        public UnidadFuncionalBE_755ME ObtenerPorNumero_755ME(string numero, int idConsorcio)
        {
            UnidadFuncionalBE_755ME? unidad = _ufDAL.ObtenerPorNumero_755ME(numero, idConsorcio);
            if (unidad == null)
            {
                throw new ExcepcionUnidadNoEncontrada_755ME("No se encontro la unidad funcional con numero " + numero + " en este consorcio");
            }
            return unidad;
        }

        public ConsorcistaBE_755ME ObtenerDatosPropietario_755ME(int idUF)
        {
            return _ufDAL.ObtenerDatosPropietario_755ME(idUF);
        }

        // no se puede dejar sin propietario ni inactivar una unidad que debe expensas
        public bool TieneExpensasPendientes_755ME(int idUF)
        {
            return _ufDAL.ContarExpensasPendientes_755ME(idUF) > 0;
        }

        // ---------- Mantenimiento de unidades ----------

        public List<UnidadFuncionalBE_755ME> ObtenerUnidadesPorConsorcio_755ME(int idConsorcio)
        {
            return _ufDAL.ObtenerPorConsorcio_755ME(idConsorcio);
        }

        public List<UnidadFuncionalBE_755ME> ObtenerTodasLasUnidades_755ME()
        {
            return _ufDAL.ObtenerTodas_755ME();
        }

        public List<UnidadFuncionalBE_755ME> ObtenerUnidadesDelPropietario_755ME(int idConsorcista)
        {
            return _ufDAL.ObtenerUnidadesDelPropietario_755ME(idConsorcista);
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
            // redondea a 2 decimales para que el DVH coincida al releer de la base
            uf.Coeficiente_755ME = Math.Round(uf.Coeficiente_755ME, 2, MidpointRounding.AwayFromZero) + 0.00m;
            bool esNueva = uf.IdUnidadFuncional_755ME == 0;
            if (esNueva)
            {
                // no deja cargar mas unidades que CantidadUnidades
                ConsorcioBE_755ME consorcio = _consorcioBLL.ObtenerPorId_755ME(uf.IdConsorcio_755ME);
                if (unidadesDelConsorcio.Count >= consorcio.CantidadUnidades_755ME)
                {
                    throw new InvalidOperationException("El consorcio " + consorcio.Nombre_755ME + " ya tiene registradas sus " +
                        consorcio.CantidadUnidades_755ME + " unidades funcionales");
                }
                uf.Activa_755ME = true;
                _ufDAL.Insertar_755ME(uf, _verificador.CalcularDVH(uf));
            }
            else
            {
                // la modificacion no toca Activa, se toma la de la base. La restauracion si la cambia
                if (!uf.EsRestauracion_755ME)
                {
                    uf.Activa_755ME = _ufDAL.ObtenerPorId_755ME(uf.IdUnidadFuncional_755ME).Activa_755ME;
                }
                _ufDAL.Actualizar_755ME(uf, _verificador.CalcularDVH(uf));
            }
            ActualizarDvvUnidad_755ME();
            string actividad = esNueva ? "Alta de unidad funcional" : uf.EsRestauracion_755ME ? "Restauracion de unidad funcional" : "Modificacion de unidad funcional";
            _bitacora.RegistrarDeUsuarioActual(actividad, uf.IdUnidadFuncional_755ME.ToString(), uf.Numero_755ME);
            return uf.IdUnidadFuncional_755ME;
        }

        // vuelve a la version elegida con el guardado normal: el trigger agrega la version nueva
        public void RestaurarVersion_755ME(UnidadFuncionalHistBE_755ME version)
        {
            UnidadFuncionalBE_755ME vigente = _ufDAL.ObtenerPorId_755ME(version.IdUnidadFuncional_755ME);
            if (string.Equals(vigente.Numero_755ME, version.Numero_755ME, StringComparison.OrdinalIgnoreCase)
                && string.Equals(vigente.Tipo_755ME, version.Tipo_755ME, StringComparison.OrdinalIgnoreCase)
                && vigente.Coeficiente_755ME == version.Coeficiente_755ME
                && vigente.Activa_755ME == version.Activa_755ME)
            {
                throw new InvalidOperationException("La version elegida es igual a la vigente");
            }
            if (vigente.Activa_755ME && !version.Activa_755ME && TieneExpensasPendientes_755ME(vigente.IdUnidadFuncional_755ME))
            {
                throw new InvalidOperationException("No se puede restaurar una version inactiva: la unidad funcional tiene expensas pendientes o vencidas");
            }
            GuardarUnidad_755ME(new UnidadFuncionalBE_755ME
            {
                IdUnidadFuncional_755ME = vigente.IdUnidadFuncional_755ME,
                IdConsorcio_755ME = vigente.IdConsorcio_755ME,
                Numero_755ME = version.Numero_755ME,
                Tipo_755ME = version.Tipo_755ME,
                Coeficiente_755ME = version.Coeficiente_755ME,
                Activa_755ME = version.Activa_755ME,
                EsRestauracion_755ME = true
            });
        }

        public void InactivarUnidad_755ME(int idUF)
        {
            if (TieneExpensasPendientes_755ME(idUF))
            {
                throw new InvalidOperationException("No se puede inactivar una unidad funcional con expensas pendientes o vencidas");
            }
            CambiarActiva_755ME(idUF, false);
            _bitacora.RegistrarDeUsuarioActual("Inactivar unidad funcional", idUF.ToString());
        }

        public void ReactivarUnidad_755ME(int idUF)
        {
            CambiarActiva_755ME(idUF, true);
            _bitacora.RegistrarDeUsuarioActual("Reactivar unidad funcional", idUF.ToString());
        }

        private void CambiarActiva_755ME(int idUF, bool activa)
        {
            UnidadFuncionalBE_755ME uf = _ufDAL.ObtenerPorId_755ME(idUF);
            uf.Activa_755ME = activa;
            _ufDAL.ActualizarActiva_755ME(idUF, activa, _verificador.CalcularDVH(uf));
            ActualizarDvvUnidad_755ME();
        }

        private void ActualizarDvvUnidad_755ME()
        {
            _verificador.ActualizarDVV("UNIDAD_FUNCIONAL", _ufDAL.ObtenerTodas_755ME().Cast<IVerificable>().ToList());
        }
    }
}

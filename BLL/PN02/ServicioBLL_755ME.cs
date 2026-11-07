using BE;
using DAL;
using INT;

namespace BLL
{
    // ciclo de vida del servicio: ABM (Formalizar solicitud) + CU006 a CU008, y el pago en CU005
    public class ServicioBLL_755ME
    {
        private readonly ServicioDAL_755ME _servicioDAL = new ServicioDAL_755ME();
        private readonly ProveedorBLL_755ME _proveedorBLL = new ProveedorBLL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        // ---------- ABM: Formalizar solicitud de servicio (no es CU) ----------

        // idUnidadFuncional es null cuando el servicio es para un area comun
        public ServicioBE_755ME FormalizarSolicitud_755ME(int idConsorcio, string categoria, string descripcion, int? idUnidadFuncional)
        {
            ServicioBE_755ME servicio = new ServicioBE_755ME
            {
                IdConsorcio_755ME = idConsorcio,
                Categoria_755ME = categoria,
                Descripcion_755ME = descripcion,
                IdUnidadFuncional_755ME = idUnidadFuncional,
                // el costo real se conoce recien en CU007
                Costo_755ME = 0.00m,
                Estado_755ME = "Pendiente de asignacion"
            };
            _servicioDAL.Insertar_755ME(servicio, _verificador.CalcularDVH(servicio));
            ActualizarDvvServicio_755ME();
            _bitacora.RegistrarDeUsuarioActual("Formalizar solicitud de servicio", servicio.IdServicio_755ME.ToString(), categoria + " " + descripcion);
            return servicio;
        }

        // ---------- CU006: Asignar proveedor ----------

        public List<ServicioBE_755ME> ObtenerPendientesDeAsignacion_755ME(int idConsorcio)
        {
            return _servicioDAL.ObtenerPendientesDeAsignacion_755ME(idConsorcio);
        }

        public ServicioBE_755ME AsignarProveedor_755ME(int idServicio, int idProveedor, int plazoEstimado)
        {
            ServicioBE_755ME servicio = _servicioDAL.ObtenerPorId_755ME(idServicio);
            servicio.IdProveedor_755ME = idProveedor;
            servicio.PlazoEstimado_755ME = plazoEstimado;
            servicio.FechaAsignacion_755ME = DateTime.Now.Date;
            servicio.Estado_755ME = "Asignado";
            int dvh = _verificador.CalcularDVH(servicio);
            _servicioDAL.AsignarProveedor_755ME(idServicio, idProveedor, plazoEstimado, servicio.FechaAsignacion_755ME.Value, dvh);
            servicio.DVH = dvh;
            ActualizarDvvServicio_755ME();
            _bitacora.RegistrarDeUsuarioActual("Asignar proveedor al servicio", idServicio.ToString(),
                "Proveedor " + idProveedor + ", plazo " + plazoEstimado + " dias");
            return servicio;
        }

        // ---------- CU007: Cargar prestacion del proveedor ----------

        // completa el nombre del proveedor para mostrarlo en el listado
        public List<ServicioBE_755ME> ObtenerPendientesDeCarga_755ME(int idConsorcio)
        {
            List<ServicioBE_755ME> servicios = _servicioDAL.ObtenerPendientesDeCarga_755ME(idConsorcio);
            CompletarNombreProveedor_755ME(servicios);
            return servicios;
        }

        public ServicioBE_755ME CargarPrestacion_755ME(int idServicio, DateTime fecha, string descripcionTrabajo, decimal costo, string numeroFactura, string archivoAdjunto)
        {
            if (costo <= 0)
            {
                throw new ArgumentException("El costo debe ser mayor a cero");
            }
            ServicioBE_755ME servicio = _servicioDAL.ObtenerPorId_755ME(idServicio);
            // la base guarda solo la fecha y 2 decimales, asi el DVH coincide al releer
            servicio.FechaPrestacion_755ME = fecha.Date;
            servicio.DescripcionTrabajo_755ME = descripcionTrabajo;
            servicio.Costo_755ME = Math.Round(costo, 2, MidpointRounding.AwayFromZero) + 0.00m;
            servicio.NumeroFactura_755ME = numeroFactura;
            servicio.ArchivoAdjunto_755ME = archivoAdjunto;
            servicio.Estado_755ME = "Prestado";
            _servicioDAL.CargarPrestacion_755ME(servicio, _verificador.CalcularDVH(servicio));
            ActualizarDvvServicio_755ME();
            _bitacora.RegistrarDeUsuarioActual("Cargar prestacion del proveedor", idServicio.ToString(),
                servicio.Costo_755ME.ToString("F2") + " " + numeroFactura);
            return servicio;
        }

        // ---------- CU008: Aprobar prestacion ----------

        // completa el nombre del proveedor para mostrarlo en el listado
        public List<ServicioBE_755ME> ObtenerPendientesDeAprobacion_755ME(int idConsorcio)
        {
            List<ServicioBE_755ME> servicios = _servicioDAL.ObtenerPendientesDeAprobacion_755ME(idConsorcio);
            CompletarNombreProveedor_755ME(servicios);
            return servicios;
        }

        private void CompletarNombreProveedor_755ME(List<ServicioBE_755ME> servicios)
        {
            foreach (ServicioBE_755ME s in servicios)
            {
                if (s.IdProveedor_755ME.HasValue)
                {
                    s.NombreProveedor_755ME = _proveedorBLL.ObtenerPorId_755ME(s.IdProveedor_755ME.Value).Nombre_755ME;
                }
            }
        }

        public ServicioBE_755ME AprobarPrestacion_755ME(int idServicio)
        {
            ServicioBE_755ME servicio = CambiarEstado_755ME(idServicio, "Aprobado", null);
            _bitacora.RegistrarDeUsuarioActual("Aprobar prestacion", idServicio.ToString(), "Aprobado, costo " + servicio.Costo_755ME.ToString("F2"));
            return servicio;
        }

        public ServicioBE_755ME RechazarPrestacion_755ME(int idServicio, string motivo)
        {
            ServicioBE_755ME servicio = CambiarEstado_755ME(idServicio, "Rechazado", motivo);
            _bitacora.RegistrarDeUsuarioActual("Rechazar prestacion", idServicio.ToString(), motivo);
            return servicio;
        }

        private ServicioBE_755ME CambiarEstado_755ME(int idServicio, string estado, string? motivoRechazo)
        {
            ServicioBE_755ME servicio = _servicioDAL.ObtenerPorId_755ME(idServicio);
            servicio.Estado_755ME = estado;
            servicio.MotivoRechazo_755ME = motivoRechazo ?? "";
            int dvh = _verificador.CalcularDVH(servicio);
            _servicioDAL.ActualizarEstado_755ME(idServicio, estado, motivoRechazo, dvh);
            servicio.DVH = dvh;
            ActualizarDvvServicio_755ME();
            return servicio;
        }

        // ---------- CU005 (PN01): Registrar egreso ----------

        public List<ServicioBE_755ME> ObtenerServiciosAprobadosPendientes_755ME(int idConsorcio)
        {
            return _servicioDAL.ObtenerServiciosAprobadosPendientes_755ME(idConsorcio);
        }

        // devuelve el servicio pagado: EgresoBLL usa su categoria como rubro del gasto
        public ServicioBE_755ME MarcarPagado_755ME(int idServicio)
        {
            ServicioBE_755ME servicio = _servicioDAL.ObtenerPorId_755ME(idServicio);
            servicio.Estado_755ME = "Pagado";
            _servicioDAL.MarcarPagado_755ME(idServicio, _verificador.CalcularDVH(servicio));
            ActualizarDvvServicio_755ME();
            return servicio;
        }

        // ---------- RF15: reporte de servicios ----------

        public List<ServicioBE_755ME> ObtenerPorConsorcio_755ME(int idConsorcio)
        {
            List<ServicioBE_755ME> servicios = _servicioDAL.ObtenerPorConsorcio_755ME(idConsorcio);
            CompletarNombreProveedor_755ME(servicios);
            return servicios;
        }

        public List<ServicioBE_755ME> ObtenerPorProveedor_755ME(int idProveedor)
        {
            return _servicioDAL.ObtenerPorProveedor_755ME(idProveedor);
        }

        private void ActualizarDvvServicio_755ME()
        {
            _verificador.ActualizarDVV("SERVICIO", _servicioDAL.ObtenerTodos_755ME().Cast<IVerificable>().ToList());
        }
    }
}

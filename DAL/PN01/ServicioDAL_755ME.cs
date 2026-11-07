using System.Data;
using BE;

namespace DAL
{
    public class ServicioDAL_755ME
    {
        private static ServicioBE_755ME Mapear_755ME(DataRow fila)
        {
            ServicioBE_755ME s = new ServicioBE_755ME();
            s.IdServicio_755ME = Convert.ToInt32(fila["IdServicio"]);
            s.IdConsorcio_755ME = Convert.ToInt32(fila["IdConsorcio"]);
            s.IdProveedor_755ME = fila["IdProveedor"] == DBNull.Value ? (int?)null : Convert.ToInt32(fila["IdProveedor"]);
            s.IdUnidadFuncional_755ME = fila["IdUnidadFuncional"] == DBNull.Value ? (int?)null : Convert.ToInt32(fila["IdUnidadFuncional"]);
            s.Categoria_755ME = fila["Categoria"].ToString() ?? "";
            s.Descripcion_755ME = fila["Descripcion"].ToString() ?? "";
            s.Estado_755ME = fila["Estado"].ToString() ?? "";
            s.PlazoEstimado_755ME = fila["PlazoEstimado"] == DBNull.Value ? (int?)null : Convert.ToInt32(fila["PlazoEstimado"]);
            s.FechaAsignacion_755ME = fila["FechaAsignacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(fila["FechaAsignacion"]);
            s.FechaPrestacion_755ME = fila["FechaPrestacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(fila["FechaPrestacion"]);
            s.DescripcionTrabajo_755ME = fila["DescripcionTrabajo"].ToString() ?? "";
            s.Costo_755ME = Convert.ToDecimal(fila["Costo"]);
            s.NumeroFactura_755ME = fila["NumeroFactura"].ToString() ?? "";
            s.ArchivoAdjunto_755ME = fila["ArchivoAdjunto"].ToString() ?? "";
            s.MotivoRechazo_755ME = fila["MotivoRechazo"].ToString() ?? "";
            s.DVH = fila["DVH"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DVH"]);
            return s;
        }

        private static List<ServicioBE_755ME> MapearLista_755ME(DataTable tabla)
        {
            List<ServicioBE_755ME> lista = new List<ServicioBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        private static List<ServicioBE_755ME> ObtenerPorEstado_755ME(int idConsorcio, string estado)
        {
            return MapearLista_755ME(AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM SERVICIO WHERE IdConsorcio=@con AND Estado=@estado ORDER BY IdServicio",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio), AccesoDatos_755ME.Parametro_755ME("@estado", estado)));
        }

        public ServicioBE_755ME ObtenerPorId_755ME(int idServicio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM SERVICIO WHERE IdServicio=@id",
                AccesoDatos_755ME.Parametro_755ME("@id", idServicio));
            if (tabla.Rows.Count == 0) throw new InvalidOperationException("No existe el servicio " + idServicio);
            return Mapear_755ME(tabla.Rows[0]);
        }

        public List<ServicioBE_755ME> ObtenerTodos_755ME()
        {
            return MapearLista_755ME(AccesoDatos_755ME.Consultar_755ME("SELECT * FROM SERVICIO ORDER BY IdServicio"));
        }

        // ---------- CU006: Formalizar solicitud ----------

        public List<ServicioBE_755ME> ObtenerPorConsorcio_755ME(int idConsorcio)
        {
            return MapearLista_755ME(AccesoDatos_755ME.Consultar_755ME("SELECT * FROM SERVICIO WHERE IdConsorcio=@con ORDER BY IdServicio",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio)));
        }

        public List<ServicioBE_755ME> ObtenerPorProveedor_755ME(int idProveedor)
        {
            return MapearLista_755ME(AccesoDatos_755ME.Consultar_755ME("SELECT * FROM SERVICIO WHERE IdProveedor=@prov ORDER BY IdServicio",
                AccesoDatos_755ME.Parametro_755ME("@prov", idProveedor)));
        }

        public int Insertar_755ME(ServicioBE_755ME servicio, int dvh)
        {
            servicio.DVH = dvh;
            servicio.IdServicio_755ME = AccesoDatos_755ME.Insertar_755ME(
                "INSERT INTO SERVICIO (IdConsorcio, IdUnidadFuncional, Categoria, Descripcion, Costo, Estado, DVH) " +
                "VALUES (@con, @uf, @cat, @desc, @costo, @estado, @dvh)",
                AccesoDatos_755ME.Parametro_755ME("@con", servicio.IdConsorcio_755ME), AccesoDatos_755ME.Parametro_755ME("@uf", servicio.IdUnidadFuncional_755ME),
                AccesoDatos_755ME.Parametro_755ME("@cat", servicio.Categoria_755ME), AccesoDatos_755ME.Parametro_755ME("@desc", servicio.Descripcion_755ME),
                AccesoDatos_755ME.Parametro_755ME("@costo", servicio.Costo_755ME), AccesoDatos_755ME.Parametro_755ME("@estado", servicio.Estado_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh));
            return servicio.IdServicio_755ME;
        }

        // ---------- CU007: Asignar proveedor ----------

        public List<ServicioBE_755ME> ObtenerPendientesDeAsignacion_755ME(int idConsorcio)
        {
            return ObtenerPorEstado_755ME(idConsorcio, "Pendiente de asignacion");
        }

        public void AsignarProveedor_755ME(int idServicio, int idProveedor, int plazoEstimado, DateTime fechaAsignacion, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME(
                "UPDATE SERVICIO SET IdProveedor=@prov, PlazoEstimado=@plazo, FechaAsignacion=@fecha, Estado='Asignado', DVH=@dvh WHERE IdServicio=@id",
                AccesoDatos_755ME.Parametro_755ME("@prov", idProveedor), AccesoDatos_755ME.Parametro_755ME("@plazo", plazoEstimado),
                AccesoDatos_755ME.Parametro_755ME("@fecha", fechaAsignacion.Date), AccesoDatos_755ME.Parametro_755ME("@dvh", dvh),
                AccesoDatos_755ME.Parametro_755ME("@id", idServicio));
        }

        // ---------- CU008: Cargar prestacion ----------

        public List<ServicioBE_755ME> ObtenerPendientesDeCarga_755ME(int idConsorcio)
        {
            return ObtenerPorEstado_755ME(idConsorcio, "Asignado");
        }

        public void CargarPrestacion_755ME(ServicioBE_755ME servicio, int dvh)
        {
            servicio.DVH = dvh;
            AccesoDatos_755ME.EjecutarNoQuery_755ME(
                "UPDATE SERVICIO SET FechaPrestacion=@fecha, DescripcionTrabajo=@trabajo, Costo=@costo, NumeroFactura=@factura, " +
                "ArchivoAdjunto=@archivo, Estado=@estado, DVH=@dvh WHERE IdServicio=@id",
                AccesoDatos_755ME.Parametro_755ME("@fecha", servicio.FechaPrestacion_755ME), AccesoDatos_755ME.Parametro_755ME("@trabajo", servicio.DescripcionTrabajo_755ME),
                AccesoDatos_755ME.Parametro_755ME("@costo", servicio.Costo_755ME), AccesoDatos_755ME.Parametro_755ME("@factura", servicio.NumeroFactura_755ME),
                AccesoDatos_755ME.Parametro_755ME("@archivo", servicio.ArchivoAdjunto_755ME), AccesoDatos_755ME.Parametro_755ME("@estado", servicio.Estado_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", servicio.IdServicio_755ME));
        }

        // ---------- CU009: Aprobar prestacion ----------

        public List<ServicioBE_755ME> ObtenerPendientesDeAprobacion_755ME(int idConsorcio)
        {
            return ObtenerPorEstado_755ME(idConsorcio, "Prestado");
        }

        public void ActualizarEstado_755ME(int idServicio, string estado, string? motivoRechazo, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE SERVICIO SET Estado=@estado, MotivoRechazo=@motivo, DVH=@dvh WHERE IdServicio=@id",
                AccesoDatos_755ME.Parametro_755ME("@estado", estado), AccesoDatos_755ME.Parametro_755ME("@motivo", motivoRechazo),
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idServicio));
        }

        // ---------- CU005 (PN01): Registrar egreso ----------

        public List<ServicioBE_755ME> ObtenerServiciosAprobadosPendientes_755ME(int idConsorcio)
        {
            return ObtenerPorEstado_755ME(idConsorcio, "Aprobado");
        }

        public void MarcarPagado_755ME(int idServicio, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE SERVICIO SET Estado='Pagado', DVH=@dvh WHERE IdServicio=@id",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idServicio));
        }

        public void ActualizarDvh_755ME(int idServicio, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE SERVICIO SET DVH=@dvh WHERE IdServicio=@id",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idServicio));
        }
    }
}

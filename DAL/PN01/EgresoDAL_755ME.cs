using System.Data;
using BE;

namespace DAL
{
    public class EgresoDAL_755ME
    {
        private static EgresoBE_755ME Mapear_755ME(DataRow fila)
        {
            EgresoBE_755ME e = new EgresoBE_755ME();
            e.IdEgreso_755ME = Convert.ToInt32(fila["IdEgreso"]);
            e.IdConsorcio_755ME = Convert.ToInt32(fila["IdConsorcio"]);
            e.IdServicio_755ME = fila["IdServicio"] == DBNull.Value ? (int?)null : Convert.ToInt32(fila["IdServicio"]);
            e.IdProveedor_755ME = fila["IdProveedor"] == DBNull.Value ? (int?)null : Convert.ToInt32(fila["IdProveedor"]);
            e.Concepto_755ME = fila["Concepto"].ToString() ?? "";
            e.Monto_755ME = Convert.ToDecimal(fila["Monto"]);
            e.Fecha_755ME = Convert.ToDateTime(fila["Fecha"]);
            e.DVH = fila["DVH"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DVH"]);
            return e;
        }

        public void GuardarEgreso_755ME(EgresoBE_755ME egreso, int dvh)
        {
            egreso.DVH = dvh;
            egreso.IdEgreso_755ME = AccesoDatos_755ME.Insertar_755ME(
                "INSERT INTO EGRESO (IdConsorcio, IdServicio, IdProveedor, Concepto, Monto, Fecha, DVH) " +
                "VALUES (@con, @serv, @prov, @concepto, @monto, @fecha, @dvh)",
                AccesoDatos_755ME.Parametro_755ME("@con", egreso.IdConsorcio_755ME), AccesoDatos_755ME.Parametro_755ME("@serv", egreso.IdServicio_755ME),
                AccesoDatos_755ME.Parametro_755ME("@prov", egreso.IdProveedor_755ME), AccesoDatos_755ME.Parametro_755ME("@concepto", egreso.Concepto_755ME),
                AccesoDatos_755ME.Parametro_755ME("@monto", egreso.Monto_755ME), AccesoDatos_755ME.Parametro_755ME("@fecha", egreso.Fecha_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh));
        }

        // id < 0 = -idConsorcio; los egresos son por consorcio, con id >= 0 devuelve lista vacia
        public List<EgresoBE_755ME> ObtenerEgresos_755ME(int id)
        {
            if (id >= 0) return new List<EgresoBE_755ME>();
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM EGRESO WHERE IdConsorcio=@con ORDER BY Fecha",
                AccesoDatos_755ME.Parametro_755ME("@con", -id));
            List<EgresoBE_755ME> lista = new List<EgresoBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public List<EgresoBE_755ME> ObtenerEgresosPorPeriodo_755ME(DateTime periodo)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM EGRESO WHERE YEAR(Fecha)=@anio AND MONTH(Fecha)=@mes ORDER BY Fecha",
                AccesoDatos_755ME.Parametro_755ME("@anio", periodo.Year), AccesoDatos_755ME.Parametro_755ME("@mes", periodo.Month));
            List<EgresoBE_755ME> lista = new List<EgresoBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public decimal ObtenerTotalEgresado_755ME(int idConsorcio)
        {
            object? r = AccesoDatos_755ME.Escalar_755ME("SELECT ISNULL(SUM(Monto),0) FROM EGRESO WHERE IdConsorcio=@con",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            return Convert.ToDecimal(r);
        }

        public List<EgresoBE_755ME> ObtenerTodos_755ME()
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM EGRESO ORDER BY IdEgreso");
            List<EgresoBE_755ME> lista = new List<EgresoBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public void ActualizarDvh_755ME(int idEgreso, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE EGRESO SET DVH=@dvh WHERE IdEgreso=@id",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idEgreso));
        }
    }
}

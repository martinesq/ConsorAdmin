using System.Data;
using BE;

namespace DAL
{
    public class PagoDAL_755ME
    {
        private static PagoBE_755ME Mapear_755ME(DataRow fila)
        {
            PagoBE_755ME p = new PagoBE_755ME();
            p.IdPago_755ME = Convert.ToInt32(fila["IdPago"]);
            p.IdExpensa_755ME = Convert.ToInt32(fila["IdExpensa"]);
            p.Monto_755ME = Convert.ToDecimal(fila["Monto"]);
            p.FechaPago_755ME = Convert.ToDateTime(fila["FechaPago"]);
            p.MedioPago_755ME = fila["MedioPago"].ToString() ?? "";
            p.NumeroComprobante_755ME = fila["NumeroComprobante"].ToString() ?? "";
            p.DVH = fila["DVH"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DVH"]);
            return p;
        }

        // pagos ya imputados a una expensa (para calcular el saldo)
        public List<PagoBE_755ME> ObtenerPorExpensa_755ME(int idExpensa)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM PAGO WHERE IdExpensa=@id ORDER BY FechaPago",
                AccesoDatos_755ME.Parametro_755ME("@id", idExpensa));
            List<PagoBE_755ME> lista = new List<PagoBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public bool TienePagosImputados_755ME(int idExpensa)
        {
            object? r = AccesoDatos_755ME.Escalar_755ME("SELECT COUNT(*) FROM PAGO WHERE IdExpensa=@id",
                AccesoDatos_755ME.Parametro_755ME("@id", idExpensa));
            return Convert.ToInt32(r) > 0;
        }

        public void GuardarPago_755ME(PagoBE_755ME pago, int dvh)
        {
            pago.DVH = dvh;
            pago.IdPago_755ME = AccesoDatos_755ME.Insertar_755ME(
                "INSERT INTO PAGO (IdExpensa, Monto, FechaPago, MedioPago, NumeroComprobante, DVH) VALUES (@exp, @monto, @fecha, @medio, @comp, @dvh)",
                AccesoDatos_755ME.Parametro_755ME("@exp", pago.IdExpensa_755ME), AccesoDatos_755ME.Parametro_755ME("@monto", pago.Monto_755ME),
                AccesoDatos_755ME.Parametro_755ME("@fecha", pago.FechaPago_755ME), AccesoDatos_755ME.Parametro_755ME("@medio", pago.MedioPago_755ME),
                AccesoDatos_755ME.Parametro_755ME("@comp", pago.NumeroComprobante_755ME), AccesoDatos_755ME.Parametro_755ME("@dvh", dvh));
        }

        // id < 0 = -idConsorcio, id >= 0 = unidad funcional
        public List<PagoBE_755ME> ObtenerPagos_755ME(int id)
        {
            DataTable tabla = id < 0
                ? AccesoDatos_755ME.Consultar_755ME(
                    "SELECT p.* FROM PAGO p INNER JOIN EXPENSA e ON e.IdExpensa=p.IdExpensa " +
                    "INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional=e.IdUnidadFuncional " +
                    "WHERE u.IdConsorcio=@con ORDER BY p.FechaPago",
                    AccesoDatos_755ME.Parametro_755ME("@con", -id))
                : AccesoDatos_755ME.Consultar_755ME(
                    "SELECT p.* FROM PAGO p INNER JOIN EXPENSA e ON e.IdExpensa=p.IdExpensa " +
                    "WHERE e.IdUnidadFuncional=@uf ORDER BY p.FechaPago",
                    AccesoDatos_755ME.Parametro_755ME("@uf", id));
            List<PagoBE_755ME> lista = new List<PagoBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public List<PagoBE_755ME> ObtenerPagosPorPeriodo_755ME(DateTime periodo)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT p.* FROM PAGO p INNER JOIN EXPENSA e ON e.IdExpensa=p.IdExpensa WHERE e.Periodo=@periodo",
                AccesoDatos_755ME.Parametro_755ME("@periodo", periodo.Date));
            List<PagoBE_755ME> lista = new List<PagoBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        // total recaudado historico del consorcio (lo usa el saldo de CU007)
        public decimal ObtenerTotalRecaudado_755ME(int idConsorcio)
        {
            object? r = AccesoDatos_755ME.Escalar_755ME(
                "SELECT ISNULL(SUM(p.Monto),0) FROM PAGO p INNER JOIN EXPENSA e ON e.IdExpensa=p.IdExpensa " +
                "INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional=e.IdUnidadFuncional WHERE u.IdConsorcio=@con",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            return Convert.ToDecimal(r);
        }

        public List<PagoBE_755ME> ObtenerTodos_755ME()
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM PAGO ORDER BY IdPago");
            List<PagoBE_755ME> lista = new List<PagoBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public void ActualizarDvh_755ME(int idPago, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE PAGO SET DVH=@dvh WHERE IdPago=@id",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idPago));
        }
    }
}

using System.Data;
using BE;

namespace DAL
{
    public class OrdenPagoDAL_755ME
    {
        private static OrdenDePagoBE_755ME Mapear_755ME(DataRow fila)
        {
            OrdenDePagoBE_755ME o = new OrdenDePagoBE_755ME();
            o.IdOrdenPago_755ME = Convert.ToInt32(fila["IdOrdenPago"]);
            o.IdExpensa_755ME = Convert.ToInt32(fila["IdExpensa"]);
            o.NumeroOrden_755ME = Convert.ToInt32(fila["NumeroOrden"]);
            o.Monto_755ME = Convert.ToDecimal(fila["Monto"]);
            o.FechaVencimiento_755ME = Convert.ToDateTime(fila["FechaVencimiento"]);
            o.Estado_755ME = fila["Estado"].ToString() ?? "";
            o.PropietarioSnapshot_755ME = fila["PropietarioSnapshot"].ToString() ?? "";
            o.DVH = fila["DVH"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DVH"]);
            return o;
        }

        public List<OrdenDePagoBE_755ME> ObtenerTodas_755ME()
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM ORDEN_PAGO ORDER BY IdOrdenPago");
            List<OrdenDePagoBE_755ME> lista = new List<OrdenDePagoBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public void ActualizarDvh_755ME(int idOrdenPago, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE ORDEN_PAGO SET DVH=@dvh WHERE IdOrdenPago=@id",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idOrdenPago));
        }

        public void GuardarOrdenPago_755ME(OrdenDePagoBE_755ME orden, int dvh)
        {
            orden.DVH = dvh;
            orden.IdOrdenPago_755ME = AccesoDatos_755ME.Insertar_755ME(
                "INSERT INTO ORDEN_PAGO (IdExpensa, NumeroOrden, Monto, FechaVencimiento, Estado, PropietarioSnapshot, DVH) " +
                "VALUES (@exp, @num, @monto, @venc, @estado, @snap, @dvh)",
                AccesoDatos_755ME.Parametro_755ME("@exp", orden.IdExpensa_755ME), AccesoDatos_755ME.Parametro_755ME("@num", orden.NumeroOrden_755ME),
                AccesoDatos_755ME.Parametro_755ME("@monto", orden.Monto_755ME), AccesoDatos_755ME.Parametro_755ME("@venc", orden.FechaVencimiento_755ME),
                AccesoDatos_755ME.Parametro_755ME("@estado", orden.Estado_755ME), AccesoDatos_755ME.Parametro_755ME("@snap", orden.PropietarioSnapshot_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh));
        }

        // Siguiente numero correlativo de orden de pago (usado por OrdenPagoBLL.ArmarTalon_755ME).
        public int ObtenerProximoNumero_755ME()
        {
            object? r = AccesoDatos_755ME.Escalar_755ME("SELECT ISNULL(MAX(NumeroOrden),0)+1 FROM ORDEN_PAGO");
            return Convert.ToInt32(r);
        }
    }
}

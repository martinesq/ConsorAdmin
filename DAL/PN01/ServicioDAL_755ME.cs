using System.Data;
using BE;

namespace DAL
{
    public class ServicioDAL_755ME
    {
        public List<ServicioBE_755ME> ObtenerServiciosAprobadosPendientes_755ME(int idConsorcio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM SERVICIO WHERE IdConsorcio=@con AND Estado='Aprobado' ORDER BY IdServicio",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            List<ServicioBE_755ME> lista = new List<ServicioBE_755ME>();
            foreach (DataRow fila in tabla.Rows)
            {
                ServicioBE_755ME s = new ServicioBE_755ME();
                s.IdServicio_755ME = Convert.ToInt32(fila["IdServicio"]);
                s.IdConsorcio_755ME = Convert.ToInt32(fila["IdConsorcio"]);
                s.IdProveedor_755ME = fila["IdProveedor"] == DBNull.Value ? (int?)null : Convert.ToInt32(fila["IdProveedor"]);
                s.Categoria_755ME = fila["Categoria"].ToString() ?? "";
                s.Descripcion_755ME = fila["Descripcion"].ToString() ?? "";
                s.Costo_755ME = Convert.ToDecimal(fila["Costo"]);
                s.Estado_755ME = fila["Estado"].ToString() ?? "";
                lista.Add(s);
            }
            return lista;
        }

        public void MarcarPagado_755ME(int idServicio)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE SERVICIO SET Estado='Pagado' WHERE IdServicio=@id",
                AccesoDatos_755ME.Parametro_755ME("@id", idServicio));
        }
    }
}

using System.Data;
using BE;

namespace DAL
{
    // solo lectura: la tabla la escriben los triggers
    public class UnidadFuncionalHistDAL_755ME
    {
        private static UnidadFuncionalHistBE_755ME Mapear_755ME(DataRow fila)
        {
            UnidadFuncionalHistBE_755ME h = new UnidadFuncionalHistBE_755ME();
            h.IdHistorico_755ME = Convert.ToInt32(fila["IdHistorico"]);
            h.IdUnidadFuncional_755ME = Convert.ToInt32(fila["IdUnidadFuncional"]);
            h.IdConsorcio_755ME = Convert.ToInt32(fila["IdConsorcio"]);
            h.Numero_755ME = fila["Numero"].ToString() ?? "";
            h.Tipo_755ME = fila["Tipo"].ToString() ?? "";
            h.Coeficiente_755ME = Convert.ToDecimal(fila["Coeficiente"]);
            h.Activa_755ME = Convert.ToBoolean(fila["Activa"]);
            h.Fecha_755ME = Convert.ToDateTime(fila["Fecha"]);
            h.Hora_755ME = (TimeSpan)fila["Hora"];
            h.Act_755ME = Convert.ToBoolean(fila["Act"]);
            h.Operacion_755ME = fila["Operacion"].ToString() ?? "";
            return h;
        }

        // IdHistorico desempata los cambios hechos dentro del mismo segundo
        public List<UnidadFuncionalHistBE_755ME> ObtenerHistorialPorUnidad_755ME(int idUnidadFuncional)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM UNIDAD_FUNCIONAL_C WHERE IdUnidadFuncional=@idUnidadFuncional ORDER BY Fecha DESC, Hora DESC, IdHistorico DESC",
                AccesoDatos_755ME.Parametro_755ME("@idUnidadFuncional", idUnidadFuncional));
            List<UnidadFuncionalHistBE_755ME> lista = new List<UnidadFuncionalHistBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public UnidadFuncionalHistBE_755ME? ObtenerVersionVigente_755ME(int idUnidadFuncional)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM UNIDAD_FUNCIONAL_C WHERE IdUnidadFuncional=@idUnidadFuncional AND Act=1",
                AccesoDatos_755ME.Parametro_755ME("@idUnidadFuncional", idUnidadFuncional));
            return tabla.Rows.Count == 0 ? null : Mapear_755ME(tabla.Rows[0]);
        }

        public UnidadFuncionalHistBE_755ME? ObtenerVersionVigenteAFecha_755ME(int idUnidadFuncional, DateTime fecha)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT TOP 1 * FROM UNIDAD_FUNCIONAL_C WHERE IdUnidadFuncional=@idUnidadFuncional AND Fecha<=@fecha ORDER BY Fecha DESC, Hora DESC, IdHistorico DESC",
                AccesoDatos_755ME.Parametro_755ME("@idUnidadFuncional", idUnidadFuncional), AccesoDatos_755ME.Parametro_755ME("@fecha", fecha.Date));
            return tabla.Rows.Count == 0 ? null : Mapear_755ME(tabla.Rows[0]);
        }
    }
}

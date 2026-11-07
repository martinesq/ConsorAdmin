using System.Data;
using BE;

namespace DAL
{
    public class GastoDAL_755ME
    {
        private static GastoBE_755ME Mapear_755ME(DataRow fila)
        {
            GastoBE_755ME g = new GastoBE_755ME();
            g.IdGasto_755ME = Convert.ToInt32(fila["IdGasto"]);
            g.IdConsorcio_755ME = Convert.ToInt32(fila["IdConsorcio"]);
            g.Descripcion_755ME = fila["Descripcion"].ToString() ?? "";
            g.Monto_755ME = Convert.ToDecimal(fila["Monto"]);
            g.Periodo_755ME = Convert.ToDateTime(fila["Periodo"]);
            g.Rubro_755ME = fila["Rubro"].ToString() ?? "";
            g.DVH = fila["DVH"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DVH"]);
            return g;
        }

        // periodos del consorcio con gastos y sin liquidar
        public List<DateTime> ObtenerPeriodosConGastos_755ME(int idConsorcio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT DISTINCT g.Periodo FROM GASTO g WHERE g.IdConsorcio=@con AND NOT EXISTS " +
                "(SELECT 1 FROM EXPENSA e INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional=e.IdUnidadFuncional " +
                "WHERE u.IdConsorcio=@con AND e.Periodo=g.Periodo) ORDER BY g.Periodo",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            List<DateTime> lista = new List<DateTime>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Convert.ToDateTime(fila["Periodo"]));
            return lista;
        }

        // solo recibe el periodo, la BLL filtra por consorcio
        public List<GastoBE_755ME> ObtenerGastosPorPeriodo_755ME(DateTime periodo)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM GASTO WHERE Periodo=@periodo ORDER BY IdGasto",
                AccesoDatos_755ME.Parametro_755ME("@periodo", periodo.Date));
            List<GastoBE_755ME> lista = new List<GastoBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public List<GastoBE_755ME> ObtenerPorConsorcio_755ME(int idConsorcio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM GASTO WHERE IdConsorcio=@con ORDER BY Periodo DESC, IdGasto DESC",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            List<GastoBE_755ME> lista = new List<GastoBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public int Insertar_755ME(GastoBE_755ME gasto, int dvh)
        {
            gasto.DVH = dvh;
            gasto.IdGasto_755ME = AccesoDatos_755ME.Insertar_755ME(
                "INSERT INTO GASTO (IdConsorcio, Descripcion, Monto, Periodo, Rubro, DVH) VALUES (@con, @desc, @monto, @periodo, @rubro, @dvh)",
                AccesoDatos_755ME.Parametro_755ME("@con", gasto.IdConsorcio_755ME), AccesoDatos_755ME.Parametro_755ME("@desc", gasto.Descripcion_755ME),
                AccesoDatos_755ME.Parametro_755ME("@monto", gasto.Monto_755ME), AccesoDatos_755ME.Parametro_755ME("@periodo", gasto.Periodo_755ME.Date),
                AccesoDatos_755ME.Parametro_755ME("@rubro", gasto.Rubro_755ME), AccesoDatos_755ME.Parametro_755ME("@dvh", dvh));
            return gasto.IdGasto_755ME;
        }

        public List<GastoBE_755ME> ObtenerTodos_755ME()
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM GASTO ORDER BY IdGasto");
            List<GastoBE_755ME> lista = new List<GastoBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public void ActualizarDvh_755ME(int idGasto, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE GASTO SET DVH=@dvh WHERE IdGasto=@id",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idGasto));
        }
    }
}

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BE;

namespace DAL
{
    public class ExpensaDAL_755ME
    {
        private static ExpensaBE_755ME Mapear_755ME(DataRow fila)
        {
            ExpensaBE_755ME e = new ExpensaBE_755ME();
            e.IdExpensa_755ME = Convert.ToInt32(fila["IdExpensa"]);
            e.IdUnidadFuncional_755ME = Convert.ToInt32(fila["IdUnidadFuncional"]);
            e.Periodo_755ME = Convert.ToDateTime(fila["Periodo"]);
            e.Monto_755ME = Convert.ToDecimal(fila["Monto"]);
            e.FechaVencimiento_755ME = Convert.ToDateTime(fila["FechaVencimiento"]);
            e.HonorarioAplicado_755ME = Convert.ToDecimal(fila["HonorarioAplicado"]);
            e.CoeficienteAplicado_755ME = Convert.ToDecimal(fila["CoeficienteAplicado"]);
            e.RecargoPorMora_755ME = Convert.ToDecimal(fila["RecargoPorMora"]);
            e.Estado_755ME = fila["Estado"].ToString() ?? "";
            e.MotivoAnulacion_755ME = fila["MotivoAnulacion"] == DBNull.Value ? null : fila["MotivoAnulacion"].ToString();
            e.DVH = fila["DVH"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DVH"]);
            return e;
        }

        // hace falta la entidad completa para calcular el DVH antes de anular
        public ExpensaBE_755ME ObtenerPorId_755ME(int idExpensa)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM EXPENSA WHERE IdExpensa=@id",
                AccesoDatos_755ME.Parametro_755ME("@id", idExpensa));
            if (tabla.Rows.Count == 0) throw new InvalidOperationException("No existe la expensa " + idExpensa);
            return Mapear_755ME(tabla.Rows[0]);
        }

        public List<ExpensaBE_755ME> ObtenerExpensasPendientesOVencidas_755ME(int idConsorcio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT e.* FROM EXPENSA e INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional=e.IdUnidadFuncional " +
                "WHERE u.IdConsorcio=@con AND e.Estado IN ('Pendiente','Vencida') ORDER BY e.FechaVencimiento",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            List<ExpensaBE_755ME> lista = new List<ExpensaBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        // Expensas con saldo ('Pendiente' o 'PagadaParcial') cuya fecha de vencimiento ya paso (anterior a hoy).
        public List<ExpensaBE_755ME> ObtenerPendientesConVencimientoCumplido_755ME()
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM EXPENSA WHERE Estado IN ('Pendiente','PagadaParcial') AND FechaVencimiento<@hoy",
                AccesoDatos_755ME.Parametro_755ME("@hoy", DateTime.Now.Date));
            List<ExpensaBE_755ME> lista = new List<ExpensaBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        // CU001: anulacion, con motivo y DVH nuevos.
        public void ActualizarEstado_755ME(int idExpensa, string estado, string motivo, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME(
                "UPDATE EXPENSA SET Estado=@estado, MotivoAnulacion=@motivo, DVH=@dvh WHERE IdExpensa=@id",
                AccesoDatos_755ME.Parametro_755ME("@estado", estado), AccesoDatos_755ME.Parametro_755ME("@motivo", motivo),
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idExpensa));
        }

        // CU002: cambio de estado por pago (el DVH lo recalcula la BLL)
        public void ActualizarEstado_755ME(int idExpensa, string estado)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE EXPENSA SET Estado=@estado WHERE IdExpensa=@id",
                AccesoDatos_755ME.Parametro_755ME("@estado", estado), AccesoDatos_755ME.Parametro_755ME("@id", idExpensa));
        }

        // Expensa pendiente o vencida mas antigua de la unidad, o null si no tiene.
        public ExpensaBE_755ME? ObtenerExpensaPendiente_755ME(int idUF)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT TOP 1 * FROM EXPENSA WHERE IdUnidadFuncional=@uf AND Estado IN ('Pendiente','Vencida','PagadaParcial') ORDER BY FechaVencimiento",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF));
            return tabla.Rows.Count == 0 ? null : Mapear_755ME(tabla.Rows[0]);
        }

        // todas las expensas pendientes o vencidas de la unidad (el gestor elige cual cobrar)
        public List<ExpensaBE_755ME> ObtenerExpensasPendientes_755ME(int idUF)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM EXPENSA WHERE IdUnidadFuncional=@uf AND Estado IN ('Pendiente','Vencida','PagadaParcial') ORDER BY FechaVencimiento",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF));
            List<ExpensaBE_755ME> lista = new List<ExpensaBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public List<ExpensaBE_755ME> ObtenerExpensasVencidasImpagas_755ME(int idConsorcio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT e.* FROM EXPENSA e INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional=e.IdUnidadFuncional " +
                "WHERE u.IdConsorcio=@con AND e.Estado='Vencida' ORDER BY e.FechaVencimiento",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            List<ExpensaBE_755ME> lista = new List<ExpensaBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        // deuda de la unidad del periodo anterior (para el recargo por mora)
        public List<ExpensaBE_755ME> ObtenerDeudaVencidaPeriodoAnterior_755ME(int idConsorcio, DateTime periodo)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT e.* FROM EXPENSA e INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional=e.IdUnidadFuncional " +
                "WHERE u.IdConsorcio=@con AND e.Periodo<@periodo AND e.Estado='Vencida' ORDER BY e.Periodo DESC",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio), AccesoDatos_755ME.Parametro_755ME("@periodo", periodo.Date));
            List<ExpensaBE_755ME> lista = new List<ExpensaBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        // Mayor fecha de vencimiento de las expensas (no anuladas) de periodos anteriores al indicado, o null si no hay.
        public DateTime? ObtenerUltimoVencimientoPeriodosAnteriores_755ME(int idConsorcio, DateTime periodo)
        {
            object? r = AccesoDatos_755ME.Escalar_755ME(
                "SELECT MAX(e.FechaVencimiento) FROM EXPENSA e INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional=e.IdUnidadFuncional " +
                "WHERE u.IdConsorcio=@con AND e.Periodo<@periodo AND e.Estado<>'Anulada'",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio), AccesoDatos_755ME.Parametro_755ME("@periodo", periodo.Date));
            return r == null || r == DBNull.Value ? null : Convert.ToDateTime(r);
        }

        public void GuardarExpensas_755ME(List<ExpensaBE_755ME> expensas)
        {
            foreach (ExpensaBE_755ME e in expensas)
            {
                e.IdExpensa_755ME = AccesoDatos_755ME.Insertar_755ME(
                    "INSERT INTO EXPENSA (IdUnidadFuncional, Periodo, Monto, FechaVencimiento, HonorarioAplicado, " +
                    "CoeficienteAplicado, RecargoPorMora, Estado, DVH) VALUES (@uf, @periodo, @monto, @venc, @hon, @coef, @recargo, @estado, @dvh)",
                    AccesoDatos_755ME.Parametro_755ME("@uf", e.IdUnidadFuncional_755ME), AccesoDatos_755ME.Parametro_755ME("@periodo", e.Periodo_755ME.Date),
                    AccesoDatos_755ME.Parametro_755ME("@monto", e.Monto_755ME), AccesoDatos_755ME.Parametro_755ME("@venc", e.FechaVencimiento_755ME.Date),
                    AccesoDatos_755ME.Parametro_755ME("@hon", e.HonorarioAplicado_755ME), AccesoDatos_755ME.Parametro_755ME("@coef", e.CoeficienteAplicado_755ME),
                    AccesoDatos_755ME.Parametro_755ME("@recargo", e.RecargoPorMora_755ME), AccesoDatos_755ME.Parametro_755ME("@estado", e.Estado_755ME),
                    AccesoDatos_755ME.Parametro_755ME("@dvh", e.DVH));
            }
        }

        // id >= 0: unidad funcional, id < 0: todo el consorcio (-idConsorcio)
        public List<ExpensaBE_755ME> ObtenerExpensas_755ME(int id)
        {
            DataTable tabla = id < 0
                ? AccesoDatos_755ME.Consultar_755ME(
                    "SELECT e.* FROM EXPENSA e INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional=e.IdUnidadFuncional " +
                    "WHERE u.IdConsorcio=@con ORDER BY e.Periodo",
                    AccesoDatos_755ME.Parametro_755ME("@con", -id))
                : AccesoDatos_755ME.Consultar_755ME("SELECT * FROM EXPENSA WHERE IdUnidadFuncional=@uf ORDER BY Periodo",
                    AccesoDatos_755ME.Parametro_755ME("@uf", id));
            List<ExpensaBE_755ME> lista = new List<ExpensaBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        // unidades con expensa pendiente o vencida y sin orden de pago vigente
        public List<UnidadFuncionalBE_755ME> ObtenerUnidadesConExpensaSinOrden_755ME(int idConsorcio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT DISTINCT u.* FROM UNIDAD_FUNCIONAL u INNER JOIN EXPENSA e ON e.IdUnidadFuncional=u.IdUnidadFuncional " +
                "WHERE u.IdConsorcio=@con AND e.Estado IN ('Pendiente','Vencida') AND NOT EXISTS " +
                "(SELECT 1 FROM ORDEN_PAGO o WHERE o.IdExpensa=e.IdExpensa AND o.Estado='Vigente') ORDER BY u.Numero",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            List<UnidadFuncionalBE_755ME> lista = new List<UnidadFuncionalBE_755ME>();
            foreach (DataRow fila in tabla.Rows)
            {
                UnidadFuncionalBE_755ME u = new UnidadFuncionalBE_755ME();
                u.IdUnidadFuncional_755ME = Convert.ToInt32(fila["IdUnidadFuncional"]);
                u.IdConsorcio_755ME = Convert.ToInt32(fila["IdConsorcio"]);
                u.Numero_755ME = fila["Numero"].ToString() ?? "";
                u.Tipo_755ME = fila["Tipo"].ToString() ?? "";
                u.Coeficiente_755ME = Convert.ToDecimal(fila["Coeficiente"]);
                u.Activa_755ME = Convert.ToBoolean(fila["Activa"]);
                lista.Add(u);
            }
            return lista;
        }

        // Expensa liquidada pendiente de cobro mas reciente de la unidad, pendiente de orden de pago.
        public ExpensaBE_755ME ObtenerExpensaLiquidada_755ME(int idUF)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT TOP 1 e.* FROM EXPENSA e WHERE e.IdUnidadFuncional=@uf AND e.Estado IN ('Pendiente','Vencida') AND NOT EXISTS " +
                "(SELECT 1 FROM ORDEN_PAGO o WHERE o.IdExpensa=e.IdExpensa AND o.Estado='Vigente') ORDER BY e.Periodo DESC",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF));
            if (tabla.Rows.Count == 0) throw new InvalidOperationException("La unidad funcional " + idUF + " no tiene expensa liquidada pendiente de orden de pago");
            return Mapear_755ME(tabla.Rows[0]);
        }

        public List<ExpensaBE_755ME> ObtenerExpensasLiquidadas_755ME(int idUF)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM EXPENSA WHERE IdUnidadFuncional=@uf AND Estado<>'Anulada' ORDER BY Periodo DESC",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF));
            List<ExpensaBE_755ME> lista = new List<ExpensaBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        // composicion reconstruida por consorcio y periodo (no hay tabla de detalle)
        public ComposicionExpensaBE_755ME ObtenerComposicion_755ME(int idExpensa)
        {
            DataTable filaExpensa = AccesoDatos_755ME.Consultar_755ME(
                "SELECT e.Periodo, e.HonorarioAplicado, e.CoeficienteAplicado, e.RecargoPorMora, u.IdConsorcio " +
                "FROM EXPENSA e INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional=e.IdUnidadFuncional WHERE e.IdExpensa=@id",
                AccesoDatos_755ME.Parametro_755ME("@id", idExpensa));
            if (filaExpensa.Rows.Count == 0) throw new InvalidOperationException("No existe la expensa " + idExpensa);
            DataRow datos = filaExpensa.Rows[0];
            ComposicionExpensaBE_755ME comp = new ComposicionExpensaBE_755ME();
            comp.HonorarioAplicado_755ME = Convert.ToDecimal(datos["HonorarioAplicado"]);
            comp.Coeficiente_755ME = Convert.ToDecimal(datos["CoeficienteAplicado"]);
            comp.RecargoPorMora_755ME = Convert.ToDecimal(datos["RecargoPorMora"]);
            comp.Gastos_755ME = new GastoDAL_755ME().ObtenerGastosPorPeriodo_755ME(Convert.ToDateTime(datos["Periodo"]))
                .Where(g => g.IdConsorcio_755ME == Convert.ToInt32(datos["IdConsorcio"])).ToList();
            return comp;
        }

        public List<DateTime> ObtenerPeriodosLiquidados_755ME(int idConsorcio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT DISTINCT e.Periodo FROM EXPENSA e INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional=e.IdUnidadFuncional " +
                "WHERE u.IdConsorcio=@con ORDER BY e.Periodo",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            List<DateTime> lista = new List<DateTime>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Convert.ToDateTime(fila["Periodo"]));
            return lista;
        }

        public List<ExpensaBE_755ME> ObtenerTodas_755ME()
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM EXPENSA ORDER BY IdExpensa");
            List<ExpensaBE_755ME> lista = new List<ExpensaBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public void ActualizarDvh_755ME(int idExpensa, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE EXPENSA SET DVH=@dvh WHERE IdExpensa=@id",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idExpensa));
        }
    }
}

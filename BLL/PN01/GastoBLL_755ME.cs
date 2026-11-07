using BE;
using DAL;

namespace BLL
{
    // RF01: ABM simple de gastos
    public class GastoBLL_755ME
    {
        private readonly GastoDAL_755ME _gastoDAL = new GastoDAL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        // ExpensaBLL se crea dentro de cada metodo porque tambien usa esta BLL

        // periodos del consorcio con gastos y sin liquidar
        public List<DateTime> ObtenerPeriodosConGastos_755ME(int idConsorcio)
        {
            return _gastoDAL.ObtenerPeriodosConGastos_755ME(idConsorcio);
        }

        public List<GastoBE_755ME> ObtenerGastosPorPeriodo_755ME(DateTime periodo)
        {
            return _gastoDAL.ObtenerGastosPorPeriodo_755ME(periodo);
        }

        public List<GastoBE_755ME> ObtenerPorConsorcio_755ME(int idConsorcio)
        {
            return _gastoDAL.ObtenerPorConsorcio_755ME(idConsorcio);
        }

        // CU005: todo egreso se recupera en expensas; va al mes del egreso o al primero siguiente sin liquidar
        public GastoBE_755ME GenerarGastoDeEgreso_755ME(int idConsorcio, string descripcion, string rubro, decimal monto, DateTime fecha)
        {
            List<DateTime> liquidados = new ExpensaBLL_755ME().ObtenerPeriodosLiquidados_755ME(idConsorcio);
            DateTime periodo = new DateTime(fecha.Year, fecha.Month, 1);
            while (liquidados.Any(p => p.Year == periodo.Year && p.Month == periodo.Month))
            {
                periodo = periodo.AddMonths(1);
            }
            GastoBE_755ME gasto = new GastoBE_755ME
            {
                IdConsorcio_755ME = idConsorcio,
                // la columna admite 200 caracteres
                Descripcion_755ME = descripcion.Length > 200 ? descripcion.Substring(0, 200) : descripcion,
                Rubro_755ME = rubro,
                Monto_755ME = monto,
                Periodo_755ME = periodo
            };
            GuardarGasto_755ME(gasto);
            return gasto;
        }

        public int Insertar_755ME(GastoBE_755ME gasto)
        {
            if (string.IsNullOrWhiteSpace(gasto.Descripcion_755ME) || string.IsNullOrWhiteSpace(gasto.Rubro_755ME))
            {
                throw new ArgumentException("Debe completar descripcion y rubro");
            }
            if (gasto.Monto_755ME <= 0)
            {
                throw new ArgumentException("El monto debe ser mayor a cero");
            }
            // no deja cargar gastos de un periodo ya liquidado
            bool periodoYaLiquidado = new ExpensaBLL_755ME().ObtenerPeriodosLiquidados_755ME(gasto.IdConsorcio_755ME)
                .Any(p => p.Year == gasto.Periodo_755ME.Year && p.Month == gasto.Periodo_755ME.Month);
            if (periodoYaLiquidado)
            {
                throw new InvalidOperationException("El periodo " + gasto.Periodo_755ME.ToString("MM/yyyy") +
                    " ya tiene una liquidacion de expensas generada; no se pueden cargar mas gastos para ese periodo");
            }
            return GuardarGasto_755ME(gasto);
        }

        private int GuardarGasto_755ME(GastoBE_755ME gasto)
        {
            // la base guarda 2 decimales y solo la fecha, asi el DVH coincide al releer
            gasto.Monto_755ME = Math.Round(gasto.Monto_755ME, 2, MidpointRounding.AwayFromZero) + 0.00m;
            gasto.Periodo_755ME = gasto.Periodo_755ME.Date;
            int id = _gastoDAL.Insertar_755ME(gasto, _verificador.CalcularDVH(gasto));
            _verificador.ActualizarDVV("GASTO", _gastoDAL.ObtenerTodos_755ME().Cast<INT.IVerificable>().ToList());
            _bitacora.RegistrarDeUsuarioActual("Alta de gasto", id.ToString(), gasto.Descripcion_755ME + " " + gasto.Monto_755ME.ToString("F2"));
            return id;
        }
    }
}

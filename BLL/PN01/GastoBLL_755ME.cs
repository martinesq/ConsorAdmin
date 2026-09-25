using BE;
using DAL;

namespace BLL
{
    // RF01: ABM simple de gastos
    public class GastoBLL_755ME
    {
        private readonly GastoDAL_755ME _gastoDAL = new GastoDAL_755ME();
        private readonly ConsorcioDAL_755ME _consorcioDAL = new ConsorcioDAL_755ME();
        private readonly ExpensaDAL_755ME _expensaDAL = new ExpensaDAL_755ME();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        public List<ConsorcioBE_755ME> ObtenerConsorciosAsignados_755ME()
        {
            return _consorcioDAL.ObtenerConsorciosConUnidadesActivas_755ME();
        }

        public List<GastoBE_755ME> ObtenerPorConsorcio_755ME(int idConsorcio)
        {
            return _gastoDAL.ObtenerPorConsorcio_755ME(idConsorcio);
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
            bool periodoYaLiquidado = _expensaDAL.ObtenerPeriodosLiquidados_755ME(gasto.IdConsorcio_755ME)
                .Any(p => p.Year == gasto.Periodo_755ME.Year && p.Month == gasto.Periodo_755ME.Month);
            if (periodoYaLiquidado)
            {
                throw new InvalidOperationException("El periodo " + gasto.Periodo_755ME.ToString("MM/yyyy") +
                    " ya tiene una liquidacion de expensas generada; no se pueden cargar mas gastos para ese periodo");
            }
            int id = _gastoDAL.Insertar_755ME(gasto);
            _bitacora.RegistrarDeUsuarioActual("Alta de gasto", id.ToString(), gasto.Descripcion_755ME + " " + gasto.Monto_755ME.ToString("F2"));
            return id;
        }
    }
}

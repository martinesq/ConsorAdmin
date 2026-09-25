using BE;
using DAL;

namespace BLL
{
    // CU009 y el saldo que usa CU007
    public class FondoBLL_755ME
    {
        private readonly ConsorcioDAL_755ME _consorcioDAL = new ConsorcioDAL_755ME();
        private readonly EgresoDAL_755ME _egresoDAL = new EgresoDAL_755ME();
        private readonly ExpensaDAL_755ME _expensaDAL = new ExpensaDAL_755ME();
        private readonly PagoDAL_755ME _pagoDAL = new PagoDAL_755ME();

        public List<ConsorcioBE_755ME> ObtenerConsorciosAsignados_755ME()
        {
            return _consorcioDAL.ObtenerConsorciosConUnidadesActivas_755ME();
        }

        public List<DateTime> ObtenerPeriodosLiquidados_755ME(int idConsorcio)
        {
            return _expensaDAL.ObtenerPeriodosLiquidados_755ME(idConsorcio);
        }

        // saldo en vivo (recaudado menos egresado), lo usa CU007 para validar fondos
        public decimal ObtenerSaldoDisponible_755ME(int idConsorcio)
        {
            return _pagoDAL.ObtenerTotalRecaudado_755ME(idConsorcio) - _egresoDAL.ObtenerTotalEgresado_755ME(idConsorcio);
        }

        // las DAL solo reciben el periodo, asi que se filtra por consorcio aca
        public EstadoFondoBE_755ME? ObtenerEstadoFondo_755ME(int idConsorcio, DateTime periodo)
        {
            HashSet<int> idsExpensaDelConsorcio = _expensaDAL.ObtenerExpensas_755ME(-idConsorcio).Select(e => e.IdExpensa_755ME).ToHashSet();
            List<PagoBE_755ME> pagos = _pagoDAL.ObtenerPagosPorPeriodo_755ME(periodo).Where(p => idsExpensaDelConsorcio.Contains(p.IdExpensa_755ME)).ToList();
            List<EgresoBE_755ME> egresos = _egresoDAL.ObtenerEgresosPorPeriodo_755ME(periodo).Where(g => g.IdConsorcio_755ME == idConsorcio).ToList();

            if (pagos.Count == 0 && egresos.Count == 0) return null;

            decimal totalRecaudado = pagos.Sum(p => p.Monto_755ME);
            decimal totalEgresado = egresos.Sum(g => g.Monto_755ME);
            return new EstadoFondoBE_755ME
            {
                Periodo_755ME = periodo,
                TotalRecaudado_755ME = totalRecaudado,
                TotalEgresado_755ME = totalEgresado,
                SaldoDisponible_755ME = totalRecaudado - totalEgresado
            };
        }
    }
}

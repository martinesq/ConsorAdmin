using BE;

namespace BLL
{
    // estado del fondo del reporte de gestion: no tiene tabla propia, junta pagos y egresos
    public class FondoBLL_755ME
    {
        private readonly ExpensaBLL_755ME _expensaBLL = new ExpensaBLL_755ME();
        private readonly PagoBLL_755ME _pagoBLL = new PagoBLL_755ME();
        private readonly EgresoBLL_755ME _egresoBLL = new EgresoBLL_755ME();

        // pagos y egresos se traen por periodo, asi que se filtra por consorcio aca
        public EstadoFondoBE_755ME? ObtenerEstadoFondo_755ME(int idConsorcio, DateTime periodo)
        {
            HashSet<int> idsExpensaDelConsorcio = _expensaBLL.ObtenerExpensas_755ME(-idConsorcio).Select(e => e.IdExpensa_755ME).ToHashSet();
            List<PagoBE_755ME> pagos = _pagoBLL.ObtenerPagosPorPeriodo_755ME(periodo).Where(p => idsExpensaDelConsorcio.Contains(p.IdExpensa_755ME)).ToList();
            List<EgresoBE_755ME> egresos = _egresoBLL.ObtenerEgresosPorPeriodo_755ME(periodo).Where(g => g.IdConsorcio_755ME == idConsorcio).ToList();

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

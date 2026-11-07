using BE;

namespace BLL
{
    // estado de cuenta del reporte de gestion: no tiene tabla propia, junta expensas, pagos y egresos
    public class EstadoCuentaBLL_755ME
    {
        private readonly ExpensaBLL_755ME _expensaBLL = new ExpensaBLL_755ME();
        private readonly PagoBLL_755ME _pagoBLL = new PagoBLL_755ME();
        private readonly EgresoBLL_755ME _egresoBLL = new EgresoBLL_755ME();

        // id >= 0: unidad funcional, id < 0: consorcio completo (-idConsorcio)
        public EstadoCuentaBE_755ME? ObtenerEstadoCuenta_755ME(int id)
        {
            List<ExpensaBE_755ME> expensas = _expensaBLL.ObtenerExpensas_755ME(id);
            List<PagoBE_755ME> pagos = _pagoBLL.ObtenerPagos_755ME(id);
            List<EgresoBE_755ME> egresos = _egresoBLL.ObtenerEgresos_755ME(id);

            if (expensas.Count == 0 && pagos.Count == 0 && egresos.Count == 0) return null;

            return new EstadoCuentaBE_755ME
            {
                Expensas_755ME = expensas,
                Pagos_755ME = pagos,
                Egresos_755ME = egresos,
                Saldo_755ME = expensas.Sum(e => e.Monto_755ME) - pagos.Sum(p => p.Monto_755ME)
            };
        }
    }
}

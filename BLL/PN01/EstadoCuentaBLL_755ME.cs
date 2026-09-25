using BE;
using DAL;

namespace BLL
{
    public class EstadoCuentaBLL_755ME
    {
        private readonly ConsorcioDAL_755ME _consorcioDAL = new ConsorcioDAL_755ME();
        private readonly UnidadFuncionalDAL_755ME _ufDAL = new UnidadFuncionalDAL_755ME();
        private readonly ExpensaDAL_755ME _expensaDAL = new ExpensaDAL_755ME();
        private readonly PagoDAL_755ME _pagoDAL = new PagoDAL_755ME();
        private readonly EgresoDAL_755ME _egresoDAL = new EgresoDAL_755ME();

        public List<ConsorcioBE_755ME> ObtenerConsorciosAsignados_755ME()
        {
            return _consorcioDAL.ObtenerConsorciosConUnidadesActivas_755ME();
        }

        public List<UnidadFuncionalBE_755ME> ObtenerUnidades_755ME(int idConsorcio)
        {
            return _ufDAL.ObtenerUnidadesActivas_755ME(idConsorcio);
        }

        // id >= 0: unidad funcional, id < 0: consorcio completo (-idConsorcio)
        public EstadoCuentaBE_755ME? ObtenerEstadoCuenta_755ME(int id)
        {
            List<ExpensaBE_755ME> expensas = _expensaDAL.ObtenerExpensas_755ME(id);
            List<PagoBE_755ME> pagos = _pagoDAL.ObtenerPagos_755ME(id);
            List<EgresoBE_755ME> egresos = _egresoDAL.ObtenerEgresos_755ME(id);

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

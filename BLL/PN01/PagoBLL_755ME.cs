using BE;
using DAL;

namespace BLL
{
    public class PagoBLL_755ME
    {
        private readonly PagoDAL_755ME _pagoDAL = new PagoDAL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        // datos que deja CobrarExpensa_755ME para ImputarPago_755ME
        private string _medioEnCurso = "";
        private decimal _saldoPendienteEnCurso;

        // ExpensaBLL se crea dentro de cada metodo porque tambien usa esta BLL

        // pagos ya imputados a una expensa (para calcular el saldo)
        public List<PagoBE_755ME> ObtenerPorExpensa_755ME(int idExpensa)
        {
            return _pagoDAL.ObtenerPorExpensa_755ME(idExpensa);
        }

        public bool TienePagosImputados_755ME(int idExpensa)
        {
            return _pagoDAL.TienePagosImputados_755ME(idExpensa);
        }

        // total recaudado historico del consorcio
        public decimal ObtenerTotalRecaudado_755ME(int idConsorcio)
        {
            return _pagoDAL.ObtenerTotalRecaudado_755ME(idConsorcio);
        }

        // id >= 0: unidad funcional, id < 0: todo el consorcio (-idConsorcio)
        public List<PagoBE_755ME> ObtenerPagos_755ME(int id)
        {
            return _pagoDAL.ObtenerPagos_755ME(id);
        }

        public List<PagoBE_755ME> ObtenerPagosPorPeriodo_755ME(DateTime periodo)
        {
            return _pagoDAL.ObtenerPagosPorPeriodo_755ME(periodo);
        }

        public List<ExpensaBE_755ME> ObtenerExpensasPendientes_755ME(int idUF)
        {
            ExpensaBLL_755ME expensaBLL = new ExpensaBLL_755ME();
            expensaBLL.ActualizarExpensasVencidas_755ME();
            List<ExpensaBE_755ME> pendientes = expensaBLL.ObtenerExpensasPendientes_755ME(idUF);
            foreach (ExpensaBE_755ME e in pendientes)
            {
                e.Pagado_755ME = _pagoDAL.ObtenerPorExpensa_755ME(e.IdExpensa_755ME).Sum(p => p.Monto_755ME);
            }
            return pendientes;
        }

        // FA-3 y FA-4: por debajo del saldo queda PagadaParcial, igual o por encima queda Pagada
        public (ExpensaBE_755ME expensa, PagoBE_755ME comprobante) CobrarExpensa_755ME(int idExpensa, decimal monto, string medio)
        {
            ExpensaBLL_755ME expensaBLL = new ExpensaBLL_755ME();
            ExpensaBE_755ME expensa = expensaBLL.ObtenerPorId_755ME(idExpensa);
            decimal pagadoPrevio = _pagoDAL.ObtenerPorExpensa_755ME(idExpensa).Sum(p => p.Monto_755ME);
            _medioEnCurso = medio;
            _saldoPendienteEnCurso = expensa.Monto_755ME - pagadoPrevio;
            PagoBE_755ME comprobante = ImputarPago_755ME(expensa, monto);

            // con saldo: Vencida si ya paso el vencimiento, si no PagadaParcial
            string estadoNuevo = comprobante.Monto_755ME < _saldoPendienteEnCurso
                ? (expensa.FechaVencimiento_755ME.Date < DateTime.Now.Date ? "Vencida" : "PagadaParcial")
                : "Pagada";
            expensa = expensaBLL.ActualizarEstado_755ME(idExpensa, estadoNuevo);

            _bitacora.RegistrarDeUsuarioActual("Cobrar expensa", idExpensa.ToString(),
                comprobante.Monto_755ME.ToString("F2") + " " + _medioEnCurso);
            return (expensa, comprobante);
        }

        private PagoBE_755ME ImputarPago_755ME(ExpensaBE_755ME expensa, decimal monto)
        {
            // redondea a 2 decimales para que el DVH coincida al releer de la base
            monto = Math.Round(monto, 2, MidpointRounding.AwayFromZero) + 0.00m;
            PagoBE_755ME pago = new PagoBE_755ME
            {
                IdExpensa_755ME = expensa.IdExpensa_755ME,
                Monto_755ME = monto,
                // solo la fecha: la columna es date y si no el DVH no coincide al releer
                FechaPago_755ME = DateTime.Now.Date,
                MedioPago_755ME = _medioEnCurso,
                NumeroComprobante_755ME = "P-" + DateTime.Now.ToString("yyyyMMddHHmmssfff")
            };
            int dvh = _verificador.CalcularDVH(pago);
            _pagoDAL.GuardarPago_755ME(pago, dvh);
            _verificador.ActualizarDVV("PAGO", _pagoDAL.ObtenerTodos_755ME().Cast<INT.IVerificable>().ToList());
            return pago;
        }
    }
}

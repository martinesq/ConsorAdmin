using BE;
using DAL;

namespace BLL
{
    public class PagoBLL_755ME
    {
        private readonly ConsorcioDAL_755ME _consorcioDAL = new ConsorcioDAL_755ME();
        private readonly UnidadFuncionalDAL_755ME _ufDAL = new UnidadFuncionalDAL_755ME();
        private readonly ExpensaDAL_755ME _expensaDAL = new ExpensaDAL_755ME();
        private readonly PagoDAL_755ME _pagoDAL = new PagoDAL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        // datos que deja RegistrarPago_755ME para ImputarPago_755ME
        private string _medioEnCurso = "";
        private decimal _saldoPendienteEnCurso;

        public List<ConsorcioBE_755ME> ObtenerConsorciosAsignados_755ME()
        {
            return _consorcioDAL.ObtenerConsorciosConUnidadesActivas_755ME();
        }

        public List<UnidadFuncionalBE_755ME> ObtenerUnidades_755ME(int idConsorcio)
        {
            return _ufDAL.ObtenerUnidadesActivas_755ME(idConsorcio);
        }

        public ExpensaBE_755ME? ObtenerExpensaPendiente_755ME(int idUF)
        {
            return _expensaDAL.ObtenerExpensaPendiente_755ME(idUF);
        }

        public List<ExpensaBE_755ME> ObtenerExpensasPendientes_755ME(int idUF)
        {
            new ExpensaBLL_755ME().ActualizarExpensasVencidas_755ME();
            List<ExpensaBE_755ME> pendientes = _expensaDAL.ObtenerExpensasPendientes_755ME(idUF);
            foreach (ExpensaBE_755ME e in pendientes)
            {
                e.Pagado_755ME = _pagoDAL.ObtenerPorExpensa_755ME(e.IdExpensa_755ME).Sum(p => p.Monto_755ME);
            }
            return pendientes;
        }

        // FA-3 y FA-4: por debajo del saldo queda PagadaParcial, igual o por encima queda Pagada
        public (ExpensaBE_755ME expensa, PagoBE_755ME comprobante) RegistrarPago_755ME(int idExpensa, decimal monto, string medio)
        {
            ExpensaBE_755ME expensa = _expensaDAL.ObtenerPorId_755ME(idExpensa);
            decimal pagadoPrevio = _pagoDAL.ObtenerPorExpensa_755ME(idExpensa).Sum(p => p.Monto_755ME);
            _medioEnCurso = medio;
            _saldoPendienteEnCurso = expensa.Monto_755ME - pagadoPrevio;
            PagoBE_755ME comprobante = ImputarPago_755ME(expensa, monto);
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
                FechaPago_755ME = DateTime.Now,
                MedioPago_755ME = _medioEnCurso,
                NumeroComprobante_755ME = "P-" + DateTime.Now.ToString("yyyyMMddHHmmssfff")
            };
            int dvh = _verificador.CalcularDVH(pago);
            _pagoDAL.GuardarPago_755ME(pago, dvh);
            _verificador.ActualizarDVV("PAGO", _pagoDAL.ObtenerTodos_755ME().Cast<INT.IVerificable>().ToList());

            // Estado entra en el DVH de la expensa, asi que se recalcula al cambiarlo
            // con saldo: Vencida si ya paso el vencimiento, si no PagadaParcial
            string estadoNuevo = monto < _saldoPendienteEnCurso
                ? (expensa.FechaVencimiento_755ME.Date < DateTime.Now.Date ? "Vencida" : "PagadaParcial")
                : "Pagada";
            _expensaDAL.ActualizarEstado_755ME(expensa.IdExpensa_755ME, estadoNuevo);
            expensa.Estado_755ME = estadoNuevo;
            expensa.DVH = _verificador.CalcularDVH(expensa);
            _expensaDAL.ActualizarDvh_755ME(expensa.IdExpensa_755ME, expensa.DVH);
            _verificador.ActualizarDVV("EXPENSA", _expensaDAL.ObtenerTodas_755ME().Cast<INT.IVerificable>().ToList());

            _bitacora.RegistrarDeUsuarioActual("Registrar pago", expensa.IdExpensa_755ME.ToString(),
                monto.ToString("F2") + " " + _medioEnCurso);
            return pago;
        }
    }
}

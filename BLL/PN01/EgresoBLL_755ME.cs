using BE;
using DAL;

namespace BLL
{
    public class EgresoBLL_755ME
    {
        private readonly ConsorcioDAL_755ME _consorcioDAL = new ConsorcioDAL_755ME();
        private readonly ServicioDAL_755ME _servicioDAL = new ServicioDAL_755ME();
        private readonly EgresoDAL_755ME _egresoDAL = new EgresoDAL_755ME();
        private readonly FondoBLL_755ME _fondoBLL = new FondoBLL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        // consorcio de la ultima consulta (lo deja ObtenerServiciosAprobados_755ME)
        private int _idConsorcioEnCurso;

        public List<ConsorcioBE_755ME> ObtenerConsorciosAsignados_755ME()
        {
            return _consorcioDAL.ObtenerConsorciosConUnidadesActivas_755ME();
        }

        public List<ServicioBE_755ME> ObtenerServiciosAprobados_755ME(int idConsorcio)
        {
            _idConsorcioEnCurso = idConsorcio;
            return _servicioDAL.ObtenerServiciosAprobadosPendientes_755ME(idConsorcio);
        }

        public decimal ObtenerSaldoDisponible_755ME(int idConsorcio)
        {
            _idConsorcioEnCurso = idConsorcio;
            return _fondoBLL.ObtenerSaldoDisponible_755ME(idConsorcio);
        }

        // concepto se usa cuando se carga un insumo
        public (EgresoBE_755ME egreso, decimal saldoActualizado) RegistrarEgreso_755ME(int? idServicio, string concepto, decimal monto, int? idProveedor)
        {
            // redondea a 2 decimales para que el DVH coincida al releer de la base
            monto = Math.Round(monto, 2, MidpointRounding.AwayFromZero) + 0.00m;
            decimal saldoDisponible = _fondoBLL.ObtenerSaldoDisponible_755ME(_idConsorcioEnCurso);
            if (monto > saldoDisponible)
            {
                throw new InvalidOperationException("Saldo insuficiente");
            }

            EgresoBE_755ME egreso = new EgresoBE_755ME
            {
                IdConsorcio_755ME = _idConsorcioEnCurso,
                IdServicio_755ME = idServicio,
                IdProveedor_755ME = idProveedor,
                Concepto_755ME = concepto,
                Monto_755ME = monto,
                Fecha_755ME = DateTime.Now
            };
            int dvh = _verificador.CalcularDVH(egreso);
            _egresoDAL.GuardarEgreso_755ME(egreso, dvh);
            // recalcula el DVV de la tabla
            _verificador.ActualizarDVV("EGRESO", _egresoDAL.ObtenerTodos_755ME().Cast<INT.IVerificable>().ToList());

            if (idServicio.HasValue)
            {
                _servicioDAL.MarcarPagado_755ME(idServicio.Value);
            }

            decimal saldoActualizado = saldoDisponible - monto;
            _bitacora.RegistrarDeUsuarioActual("Registrar egreso", egreso.IdEgreso_755ME.ToString(), concepto + " " + monto.ToString("F2"));
            return (egreso, saldoActualizado);
        }
    }
}

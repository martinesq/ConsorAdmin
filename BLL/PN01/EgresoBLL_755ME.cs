using BE;
using DAL;

namespace BLL
{
    public class EgresoBLL_755ME
    {
        private readonly EgresoDAL_755ME _egresoDAL = new EgresoDAL_755ME();
        private readonly PagoBLL_755ME _pagoBLL = new PagoBLL_755ME();
        private readonly ServicioBLL_755ME _servicioBLL = new ServicioBLL_755ME();
        private readonly GastoBLL_755ME _gastoBLL = new GastoBLL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        // consorcio de la ultima consulta (lo deja ObtenerSaldoDisponible_755ME)
        private int _idConsorcioEnCurso;

        // saldo = recaudado - egresado
        public decimal ObtenerSaldoDisponible_755ME(int idConsorcio)
        {
            _idConsorcioEnCurso = idConsorcio;
            return _pagoBLL.ObtenerTotalRecaudado_755ME(idConsorcio) - ObtenerTotalEgresado_755ME(idConsorcio);
        }

        // id < 0: consorcio (-idConsorcio); los egresos son por consorcio
        public List<EgresoBE_755ME> ObtenerEgresos_755ME(int id)
        {
            return _egresoDAL.ObtenerEgresos_755ME(id);
        }

        public List<EgresoBE_755ME> ObtenerEgresosPorPeriodo_755ME(DateTime periodo)
        {
            return _egresoDAL.ObtenerEgresosPorPeriodo_755ME(periodo);
        }

        public decimal ObtenerTotalEgresado_755ME(int idConsorcio)
        {
            return _egresoDAL.ObtenerTotalEgresado_755ME(idConsorcio);
        }

        // concepto se usa cuando se carga un insumo
        public (EgresoBE_755ME egreso, decimal saldoActualizado) RegistrarEgreso_755ME(int? idServicio, string concepto, decimal monto, int? idProveedor)
        {
            // redondea a 2 decimales para que el DVH coincida al releer de la base
            monto = Math.Round(monto, 2, MidpointRounding.AwayFromZero) + 0.00m;
            decimal saldoDisponible = _pagoBLL.ObtenerTotalRecaudado_755ME(_idConsorcioEnCurso) - ObtenerTotalEgresado_755ME(_idConsorcioEnCurso);
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
                // solo la fecha: la columna es date y si no el DVH no coincide al releer
                Fecha_755ME = DateTime.Now.Date
            };
            int dvh = _verificador.CalcularDVH(egreso);
            _egresoDAL.GuardarEgreso_755ME(egreso, dvh);
            // recalcula el DVV de la tabla
            _verificador.ActualizarDVV("EGRESO", _egresoDAL.ObtenerTodos_755ME().Cast<INT.IVerificable>().ToList());

            // el rubro del gasto es la categoria del servicio, o "Insumos" si es una compra
            string rubro = "Insumos";
            if (idServicio.HasValue)
            {
                rubro = _servicioBLL.MarcarPagado_755ME(idServicio.Value).Categoria_755ME;
            }
            _gastoBLL.GenerarGastoDeEgreso_755ME(_idConsorcioEnCurso, concepto, rubro, monto, egreso.Fecha_755ME);

            decimal saldoActualizado = saldoDisponible - monto;
            _bitacora.RegistrarDeUsuarioActual("Registrar egreso", egreso.IdEgreso_755ME.ToString(), concepto + " " + monto.ToString("F2"));
            return (egreso, saldoActualizado);
        }
    }
}

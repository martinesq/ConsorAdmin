using BE;
using DAL;
using SER;

namespace BLL
{
    // metodos de CU001, CU003, CU004 y CU008
    public class ExpensaBLL_755ME
    {
        // recargo por mora: 10% de la deuda vencida del periodo anterior
        private const decimal PorcentajeRecargoPorMora_755ME = 0.10m;

        private readonly ExpensaDAL_755ME _expensaDAL = new ExpensaDAL_755ME();
        private readonly UnidadFuncionalBLL_755ME _ufBLL = new UnidadFuncionalBLL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        // datos que deja PrepararLiquidacion_755ME para GenerarLiquidacion_755ME
        private int _idConsorcioEnCurso;
        private DateTime _periodoEnCurso;
        private decimal _totalGastosEnCurso;

        // pasa a Vencida las expensas con saldo cuyo vencimiento ya paso (recalcula DVH y DVV)
        public void ActualizarExpensasVencidas_755ME()
        {
            List<ExpensaBE_755ME> porVencer = _expensaDAL.ObtenerPendientesConVencimientoCumplido_755ME();
            if (porVencer.Count == 0) return;
            foreach (ExpensaBE_755ME e in porVencer)
            {
                e.Estado_755ME = "Vencida";
                _expensaDAL.ActualizarEstado_755ME(e.IdExpensa_755ME, "Vencida", e.MotivoAnulacion_755ME!, _verificador.CalcularDVH(e));
            }
            ActualizarDvvExpensa_755ME();
        }

        // PagoBLL y GastoBLL se crean dentro de cada metodo porque tambien usan esta BLL

        public ExpensaBE_755ME ObtenerPorId_755ME(int idExpensa)
        {
            return _expensaDAL.ObtenerPorId_755ME(idExpensa);
        }

        public List<ExpensaBE_755ME> ObtenerExpensasPendientes_755ME(int idUF)
        {
            return _expensaDAL.ObtenerExpensasPendientes_755ME(idUF);
        }

        public List<DateTime> ObtenerPeriodosLiquidados_755ME(int idConsorcio)
        {
            return _expensaDAL.ObtenerPeriodosLiquidados_755ME(idConsorcio);
        }

        // ---------- CU004 ----------

        public List<UnidadFuncionalBE_755ME> ObtenerUnidadesConExpensaSinOrden_755ME(int idConsorcio)
        {
            return _expensaDAL.ObtenerUnidadesConExpensaSinOrden_755ME(idConsorcio);
        }

        public ExpensaBE_755ME ObtenerExpensaLiquidada_755ME(int idUF)
        {
            return _expensaDAL.ObtenerExpensaLiquidada_755ME(idUF);
        }

        // cambia el estado y recalcula el DVH
        public ExpensaBE_755ME ActualizarEstado_755ME(int idExpensa, string estado)
        {
            ExpensaBE_755ME expensa = _expensaDAL.ObtenerPorId_755ME(idExpensa);
            expensa.Estado_755ME = estado;
            expensa.DVH = _verificador.CalcularDVH(expensa);
            _expensaDAL.ActualizarEstado_755ME(idExpensa, estado, expensa.DVH);
            ActualizarDvvExpensa_755ME();
            return expensa;
        }

        // ---------- CU001: Anular Expensa ----------

        public List<ExpensaBE_755ME> ObtenerExpensasAnulables_755ME(int idConsorcio)
        {
            ActualizarExpensasVencidas_755ME();
            return _expensaDAL.ObtenerExpensasPendientesOVencidas_755ME(idConsorcio);
        }

        public void ExportarExpensas_755ME(int idConsorcio, string ruta)
        {
            var expensas = ObtenerExpensasAnulables_755ME(idConsorcio);
            var servicioSerializacion = new SerializacionService_755ME();
            servicioSerializacion.Serializar_755ME(expensas, ruta);
        }

        // solo lee el archivo: no escribe nada en la base
        public List<ExpensaBE_755ME> ImportarExpensas_755ME(string ruta)
        {
            var servicioSerializacion = new SerializacionService_755ME();
            return servicioSerializacion.Deserializar_755ME<List<ExpensaBE_755ME>>(ruta);
        }

        public ExpensaBE_755ME AnularExpensa_755ME(int idExpensa, string motivo)
        {
            if (string.IsNullOrWhiteSpace(motivo))
            {
                throw new ArgumentException("Debe indicar un motivo");
            }
            if (new PagoBLL_755ME().TienePagosImputados_755ME(idExpensa))
            {
                throw new InvalidOperationException("No se puede anular una expensa con pagos imputados");
            }
            ExpensaBE_755ME expensa = _expensaDAL.ObtenerPorId_755ME(idExpensa);
            expensa.Estado_755ME = "Anulada";
            expensa.MotivoAnulacion_755ME = motivo;
            int dvh = _verificador.CalcularDVH(expensa);
            _expensaDAL.ActualizarEstado_755ME(idExpensa, "Anulada", motivo, dvh);
            ActualizarDvvExpensa_755ME();
            _bitacora.RegistrarDeUsuarioActual("Anular expensa", idExpensa.ToString(), motivo);
            return expensa;
        }

        // ---------- CU003: Obtener estadisticas de morosidad ----------

        public List<UnidadMorosaBE_755ME> ObtenerMorosidad_755ME(int idConsorcio)
        {
            ActualizarExpensasVencidas_755ME();
            List<ExpensaBE_755ME> vencidas = _expensaDAL.ObtenerExpensasVencidasImpagas_755ME(idConsorcio);
            PagoBLL_755ME pagoBLL = new PagoBLL_755ME();
            Dictionary<int, string> numeros = _ufBLL.ObtenerUnidadesActivas_755ME(idConsorcio).ToDictionary(u => u.IdUnidadFuncional_755ME, u => u.Numero_755ME);
            List<UnidadMorosaBE_755ME> resultado = new List<UnidadMorosaBE_755ME>();
            foreach (var grupo in vencidas.GroupBy(e => e.IdUnidadFuncional_755ME))
            {
                decimal adeudado = 0;
                int diasAtraso = 0;
                List<ExpensaAdeudadaBE_755ME> detalle = new List<ExpensaAdeudadaBE_755ME>();
                foreach (ExpensaBE_755ME e in grupo.OrderBy(x => x.Periodo_755ME))
                {
                    decimal pagado = pagoBLL.ObtenerPorExpensa_755ME(e.IdExpensa_755ME).Sum(p => p.Monto_755ME);
                    decimal saldo = e.Monto_755ME - pagado;
                    adeudado += saldo;
                    int dias = (int)(DateTime.Now.Date - e.FechaVencimiento_755ME.Date).TotalDays;
                    if (dias > diasAtraso) diasAtraso = dias;
                    detalle.Add(new ExpensaAdeudadaBE_755ME
                    {
                        Periodo_755ME = e.Periodo_755ME,
                        FechaVencimiento_755ME = e.FechaVencimiento_755ME,
                        Monto_755ME = e.Monto_755ME,
                        Pagado_755ME = pagado,
                        Saldo_755ME = saldo,
                        RecargoPorMora_755ME = e.RecargoPorMora_755ME,
                        DiasAtraso_755ME = dias,
                        Estado_755ME = e.Estado_755ME
                    });
                }
                resultado.Add(new UnidadMorosaBE_755ME
                {
                    IdUnidadFuncional_755ME = grupo.Key,
                    NumeroUnidad_755ME = numeros.TryGetValue(grupo.Key, out string? numero) ? numero : "",
                    MontoAdeudado_755ME = adeudado,
                    DiasAtraso_755ME = diasAtraso,
                    CuotasPendientes_755ME = grupo.Count(),
                    Detalle_755ME = detalle
                });
            }
            return resultado;
        }

        // ---------- CU004: Generar liquidacion de expensas ----------

        public decimal PrepararLiquidacion_755ME(int idConsorcio, DateTime periodo)
        {
            ActualizarExpensasVencidas_755ME();
            _idConsorcioEnCurso = idConsorcio;
            _periodoEnCurso = periodo;
            return new GastoBLL_755ME().ObtenerGastosPorPeriodo_755ME(periodo).Where(g => g.IdConsorcio_755ME == idConsorcio).Sum(g => g.Monto_755ME);
        }

        // vencimiento minimo para liquidar: despues de fin de periodo, no antes de hoy ni del vencimiento de periodos previos
        public DateTime ObtenerVencimientoMinimo_755ME(int idConsorcio, DateTime periodo)
        {
            DateTime minimo = new DateTime(periodo.Year, periodo.Month, 1).AddMonths(1);
            if (minimo < DateTime.Now.Date) minimo = DateTime.Now.Date;
            DateTime? anterior = _expensaDAL.ObtenerUltimoVencimientoPeriodosAnteriores_755ME(idConsorcio, periodo);
            if (anterior.HasValue && anterior.Value.Date > minimo) minimo = anterior.Value.Date;
            return minimo;
        }

        public List<ExpensaBE_755ME> GenerarLiquidacion_755ME(DateTime vencimiento, decimal honorario)
        {
            if (honorario < 0 || honorario > 100)
            {
                throw new ArgumentException("El porcentaje de honorario debe estar entre 0% y 100%");
            }
            // el vencimiento no puede ser anterior a hoy
            if (vencimiento.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("La fecha de vencimiento no puede ser anterior a la fecha actual");
            }
            // primero pasa a Vencida las que correspondan, porque el recargo se calcula sobre esas
            ActualizarExpensasVencidas_755ME();
            DateTime minimo = ObtenerVencimientoMinimo_755ME(_idConsorcioEnCurso, _periodoEnCurso);
            if (vencimiento.Date < minimo)
            {
                throw new ArgumentException("La fecha de vencimiento no puede ser anterior al " + minimo.ToString("dd/MM/yyyy") +
                    " (posterior al fin del periodo y no anterior al vencimiento de periodos previos)");
            }
            List<UnidadFuncionalBE_755ME> unidades = _ufBLL.ObtenerUnidadesActivas_755ME(_idConsorcioEnCurso);
            List<ExpensaBE_755ME> deudaAnterior = _expensaDAL.ObtenerDeudaVencidaPeriodoAnterior_755ME(_idConsorcioEnCurso, _periodoEnCurso);
            _totalGastosEnCurso = new GastoBLL_755ME().ObtenerGastosPorPeriodo_755ME(_periodoEnCurso).Where(g => g.IdConsorcio_755ME == _idConsorcioEnCurso).Sum(g => g.Monto_755ME);

            PagoBLL_755ME pagoBLL = new PagoBLL_755ME();
            List<ExpensaBE_755ME> expensas = new List<ExpensaBE_755ME>();
            foreach (UnidadFuncionalBE_755ME uf in unidades)
            {
                decimal deudaVencidaUF = 0;
                foreach (ExpensaBE_755ME pendiente in deudaAnterior.Where(e => e.IdUnidadFuncional_755ME == uf.IdUnidadFuncional_755ME))
                {
                    decimal pagado = pagoBLL.ObtenerPorExpensa_755ME(pendiente.IdExpensa_755ME).Sum(p => p.Monto_755ME);
                    deudaVencidaUF += pendiente.Monto_755ME - pagado;
                }
                // redondea a 2 decimales para que el DVH coincida al releer de la base
                decimal gastosPorUF = RedondearMonto_755ME(_totalGastosEnCurso * uf.Coeficiente_755ME);
                decimal honorarioPorUF = RedondearMonto_755ME(gastosPorUF * (honorario / 100m));
                decimal recargoPorMora = RedondearMonto_755ME(deudaVencidaUF * PorcentajeRecargoPorMora_755ME);
                decimal monto = CalcularMontoPorUF_755ME(uf.Coeficiente_755ME, honorario, deudaVencidaUF);

                ExpensaBE_755ME expensa = new ExpensaBE_755ME
                {
                    IdUnidadFuncional_755ME = uf.IdUnidadFuncional_755ME,
                    Periodo_755ME = _periodoEnCurso.Date,
                    Monto_755ME = monto,
                    FechaVencimiento_755ME = vencimiento.Date,
                    HonorarioAplicado_755ME = honorarioPorUF,
                    CoeficienteAplicado_755ME = uf.Coeficiente_755ME,
                    RecargoPorMora_755ME = recargoPorMora,
                    Estado_755ME = "Pendiente"
                };
                expensa.DVH = _verificador.CalcularDVH(expensa);
                expensas.Add(expensa);
            }
            _expensaDAL.GuardarExpensas_755ME(expensas);
            ActualizarDvvExpensa_755ME();
            _bitacora.RegistrarDeUsuarioActual("Generar liquidacion de expensas", _idConsorcioEnCurso.ToString(),
                "Periodo " + _periodoEnCurso.ToString("yyyy-MM") + ", " + expensas.Count + " expensas generadas");
            return expensas;
        }

        // recalcula el DVV de EXPENSA despues de cada cambio
        private void ActualizarDvvExpensa_755ME()
        {
            _verificador.ActualizarDVV("EXPENSA", _expensaDAL.ObtenerTodas_755ME().Cast<INT.IVerificable>().ToList());
        }

        // monto de la unidad: su parte de los gastos por coeficiente + honorario + recargo por mora
        private decimal CalcularMontoPorUF_755ME(decimal coeficiente, decimal honorario, decimal deudaVencida)
        {
            decimal gastosPorUF = RedondearMonto_755ME(_totalGastosEnCurso * coeficiente);
            decimal honorarioPorUF = RedondearMonto_755ME(gastosPorUF * (honorario / 100m));
            decimal recargoPorMora = RedondearMonto_755ME(deudaVencida * PorcentajeRecargoPorMora_755ME);
            return RedondearMonto_755ME(gastosPorUF + honorarioPorUF + recargoPorMora);
        }

        // fuerza 2 decimales exactos, Math.Round solo no alcanza para que el ToString del DVH coincida
        private static decimal RedondearMonto_755ME(decimal valor)
        {
            return Math.Round(valor, 2, MidpointRounding.AwayFromZero) + 0.00m;
        }

        // ---------- CU008: Revisar composicion de expensa ----------

        public List<ExpensaBE_755ME> ObtenerExpensasLiquidadas_755ME(int idUF)
        {
            ActualizarExpensasVencidas_755ME();
            return _expensaDAL.ObtenerExpensasLiquidadas_755ME(idUF);
        }

        // no hay tabla de detalle: los gastos son los del consorcio en el periodo de la expensa
        public ComposicionExpensaBE_755ME ObtenerComposicion_755ME(int idExpensa)
        {
            ExpensaBE_755ME expensa = _expensaDAL.ObtenerPorId_755ME(idExpensa);
            int idConsorcio = _ufBLL.ObtenerPorId_755ME(expensa.IdUnidadFuncional_755ME).IdConsorcio_755ME;
            return new ComposicionExpensaBE_755ME
            {
                Gastos_755ME = new GastoBLL_755ME().ObtenerGastosPorPeriodo_755ME(expensa.Periodo_755ME)
                    .Where(g => g.IdConsorcio_755ME == idConsorcio).ToList(),
                HonorarioAplicado_755ME = expensa.HonorarioAplicado_755ME,
                Coeficiente_755ME = expensa.CoeficienteAplicado_755ME,
                RecargoPorMora_755ME = expensa.RecargoPorMora_755ME
            };
        }

        // id >= 0: unidad funcional, id < 0: todo el consorcio (-idConsorcio)
        public List<ExpensaBE_755ME> ObtenerExpensas_755ME(int id)
        {
            return _expensaDAL.ObtenerExpensas_755ME(id);
        }
    }
}

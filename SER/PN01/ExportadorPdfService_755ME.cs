using BE;
using PdfSharp.Pdf;

namespace SER
{
    // reporte de gestion: un solo PDF con composicion, morosidad, estado del fondo y estado de cuenta (una seccion por pagina)
    public class ExportadorPdfService_755ME
    {
        private const string SinDatos = "Sin datos para los filtros elegidos";

        private readonly ExportadorPdfService _exportador = new ExportadorPdfService();

        // los textos de cada filtro llegan armados desde la pantalla para mostrarlos en el titulo de la seccion
        public byte[] ExportarReporteGestion_755ME(string consorcio,
            string filtroComposicion, ComposicionExpensaBE_755ME? composicion,
            List<UnidadMorosaBE_755ME> morosidad,
            string filtroFondo, EstadoFondoBE_755ME? fondo,
            string filtroEstadoCuenta, EstadoCuentaBE_755ME? estadoCuenta)
        {
            PdfDocument documento = new PdfDocument();
            documento.Info.Title = "Reporte de gestion - " + consorcio;

            _exportador.AgregarTabla(documento, "Composicion de expensa - " + consorcio + " - " + filtroComposicion,
                new List<string> { "Concepto", "Rubro", "Monto" }, FilasComposicion_755ME(composicion));
            _exportador.AgregarTabla(documento, "Estadisticas de morosidad - " + consorcio,
                new List<string> { "Unidad", "Monto adeudado", "Dias de atraso", "Cuotas pendientes", "Periodos adeudados" }, FilasMorosidad_755ME(morosidad));
            _exportador.AgregarTabla(documento, "Estado del fondo - " + consorcio + " - " + filtroFondo,
                new List<string> { "Concepto", "Monto" }, FilasFondo_755ME(fondo));
            _exportador.AgregarTabla(documento, "Estado de cuenta - " + consorcio + " - " + filtroEstadoCuenta,
                new List<string> { "Tipo", "Fecha", "Concepto", "Monto" }, FilasEstadoCuenta_755ME(estadoCuenta));

            using (MemoryStream salida = new MemoryStream())
            {
                documento.Save(salida);
                return salida.ToArray();
            }
        }

        private static List<List<string>> FilasComposicion_755ME(ComposicionExpensaBE_755ME? composicion)
        {
            List<List<string>> filas = new List<List<string>>();
            if (composicion == null)
            {
                filas.Add(new List<string> { SinDatos, "", "" });
                return filas;
            }
            foreach (GastoBE_755ME g in composicion.Gastos_755ME)
            {
                filas.Add(new List<string> { g.Descripcion_755ME, g.Rubro_755ME, g.Monto_755ME.ToString("F2") });
            }
            filas.Add(new List<string> { "Coeficiente aplicado", "", composicion.Coeficiente_755ME.ToString("P2") });
            filas.Add(new List<string> { "Honorario aplicado", "", composicion.HonorarioAplicado_755ME.ToString("F2") });
            if (composicion.RecargoPorMora_755ME > 0)
            {
                filas.Add(new List<string> { "Recargo por mora", "", composicion.RecargoPorMora_755ME.ToString("F2") });
            }
            return filas;
        }

        private static List<List<string>> FilasMorosidad_755ME(List<UnidadMorosaBE_755ME> morosidad)
        {
            List<List<string>> filas = new List<List<string>>();
            foreach (UnidadMorosaBE_755ME u in morosidad)
            {
                filas.Add(new List<string> { u.NumeroUnidad_755ME, u.MontoAdeudado_755ME.ToString("F2"), u.DiasAtraso_755ME.ToString(),
                    u.CuotasPendientes_755ME.ToString(), string.Join(", ", u.Detalle_755ME.Select(d => d.Periodo_755ME.ToString("MM/yyyy"))) });
            }
            if (filas.Count == 0) filas.Add(new List<string> { "El consorcio no registra unidades morosas", "", "", "", "" });
            return filas;
        }

        private static List<List<string>> FilasFondo_755ME(EstadoFondoBE_755ME? fondo)
        {
            List<List<string>> filas = new List<List<string>>();
            if (fondo == null)
            {
                filas.Add(new List<string> { SinDatos, "" });
                return filas;
            }
            filas.Add(new List<string> { "Total recaudado", fondo.TotalRecaudado_755ME.ToString("F2") });
            filas.Add(new List<string> { "Total egresado", fondo.TotalEgresado_755ME.ToString("F2") });
            filas.Add(new List<string> { "Saldo disponible", fondo.SaldoDisponible_755ME.ToString("F2") });
            return filas;
        }

        private static List<List<string>> FilasEstadoCuenta_755ME(EstadoCuentaBE_755ME? estadoCuenta)
        {
            List<List<string>> filas = new List<List<string>>();
            if (estadoCuenta == null)
            {
                filas.Add(new List<string> { SinDatos, "", "", "" });
                return filas;
            }
            foreach (ExpensaBE_755ME e in estadoCuenta.Expensas_755ME)
            {
                filas.Add(new List<string> { "Expensa", e.Periodo_755ME.ToString("MM/yyyy"), "Expensa " + e.Estado_755ME, e.Monto_755ME.ToString("F2") });
            }
            foreach (PagoBE_755ME p in estadoCuenta.Pagos_755ME)
            {
                filas.Add(new List<string> { "Pago", p.FechaPago_755ME.ToString("dd/MM/yyyy"), p.MedioPago_755ME + " - " + p.NumeroComprobante_755ME, p.Monto_755ME.ToString("F2") });
            }
            foreach (EgresoBE_755ME g in estadoCuenta.Egresos_755ME)
            {
                filas.Add(new List<string> { "Egreso", g.Fecha_755ME.ToString("dd/MM/yyyy"), g.Concepto_755ME, g.Monto_755ME.ToString("F2") });
            }
            filas.Add(new List<string> { "", "", "Saldo", estadoCuenta.Saldo_755ME.ToString("F2") });
            return filas;
        }
    }
}

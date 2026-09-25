using BE;

namespace SER
{
    // CU005: exporta el estado de cuenta a PDF
    public class ExportadorPdfService_755ME
    {
        private readonly ExportadorPdfService _exportador = new ExportadorPdfService();

        public byte[] Exportar_755ME(EstadoCuentaBE_755ME estadoCuenta)
        {
            List<string> encabezados = new List<string> { "Tipo", "Fecha", "Concepto", "Monto" };
            List<List<string>> filas = new List<List<string>>();
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

            string rutaTemporal = Path.Combine(Path.GetTempPath(), "EstadoCuenta_" + Guid.NewGuid().ToString("N") + ".pdf");
            _exportador.ExportarTabla("Estado de cuenta", encabezados, filas, rutaTemporal);
            byte[] contenido = File.ReadAllBytes(rutaTemporal);
            File.Delete(rutaTemporal);
            return contenido;
        }
    }
}

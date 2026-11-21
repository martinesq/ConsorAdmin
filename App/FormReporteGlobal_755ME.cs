using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // A02: resumen de todos los consorcios activos con ranking por cobranza
    public partial class FormReporteGlobal_755ME : Form, IIdiomaObserver
    {
        private readonly ReporteGlobalBLL_755ME _reporteBLL = new ReporteGlobalBLL_755ME();
        private List<ResumenConsorcioBE_755ME> _resumen = new List<ResumenConsorcioBE_755ME>();
        private readonly ExportadorPdfService _exportador = new ExportadorPdfService();

        public FormReporteGlobal_755ME()
        {
            InitializeComponent();
            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;
        }

        private void FormReporteGlobal_755ME_Load(object sender, EventArgs e)
        {
            SessionManager.AgregarObservador(this);
            ActualizarIdioma(SessionManager.Idioma);
            MostrarTotales_755ME();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            dgvGlobal.Rows.Clear();
            try
            {
                _resumen = _reporteBLL.ObtenerResumenGlobal_755ME(dtpDesde.Value, dtpHasta.Value);
            }
            catch (ArgumentException ex)
            {
                _resumen = new List<ResumenConsorcioBE_755ME>();
                MostrarTotales_755ME();
                btnExportarPdf.Enabled = false;
                MessageBox.Show(ex.Message, Text);
                return;
            }
            foreach (ResumenConsorcioBE_755ME r in _resumen)
            {
                dgvGlobal.Rows.Add(r.Posicion_755ME, r.Nombre_755ME, r.UnidadesActivas_755ME, r.TotalExpensado_755ME.ToString("F2"),
                    r.TotalCobrado_755ME.ToString("F2"), r.DeudaVencida_755ME.ToString("F2"), r.TasaCobranza_755ME.ToString("F2"),
                    r.TotalGastos_755ME.ToString("F2"), r.ServiciosAprobadosPendientes_755ME, r.CostoServiciosPendientes_755ME.ToString("F2"),
                    r.TotalEgresos_755ME.ToString("F2"), r.SaldoFondo_755ME.ToString("F2"));
            }
            MostrarTotales_755ME();
            btnExportarPdf.Enabled = _resumen.Count > 0;
            if (_resumen.Count == 0)
            {
                MessageBox.Show(IdiomaUI_755ME.Texto("lb_repglobal_sin_datos", "No hay consorcios activos para el periodo elegido"), Text);
            }
        }

        // si cambia el periodo lo que esta en la grilla ya no corresponde
        private void dtpPeriodo_ValueChanged(object sender, EventArgs e)
        {
            dgvGlobal.Rows.Clear();
            _resumen = new List<ResumenConsorcioBE_755ME>();
            MostrarTotales_755ME();
            btnExportarPdf.Enabled = false;
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "Archivos PDF (*.pdf)|*.pdf";
                dialogo.FileName = "ReporteGlobal_" + dtpDesde.Value.ToString("yyyyMMdd") + "_" + dtpHasta.Value.ToString("yyyyMMdd") + ".pdf";
                if (dialogo.ShowDialog() != DialogResult.OK) return;
                try
                {
                    ExportarPdf_755ME(dialogo.FileName);
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_repserv_pdf_ok", "Reporte exportado"), Text);
                }
                catch (IOException)
                {
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_repglobal_pdf_archivo", "No se pudo guardar el archivo. Verifique que no este abierto en otro programa"), Text);
                }
                catch (Exception)
                {
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_repserv_pdf_error", "No se pudo generar el PDF, intente nuevamente"), Text);
                }
            }
        }

        // el PDF se arma con lo que ya esta en la grilla, sin volver a consultar
        private void ExportarPdf_755ME(string ruta)
        {
            List<string> encabezados = dgvGlobal.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText).ToList();
            List<List<string>> filas = dgvGlobal.Rows.Cast<DataGridViewRow>()
                .Select(r => r.Cells.Cast<DataGridViewCell>().Select(c => c.Value?.ToString() ?? "").ToList()).ToList();
            decimal expensado = _resumen.Sum(r => r.TotalExpensado_755ME);
            decimal cobrado = _resumen.Sum(r => r.TotalCobrado_755ME);
            filas.Add(new List<string>
            {
                "", IdiomaUI_755ME.Texto("lb_repglobal_totales", "Totales"), _resumen.Sum(r => r.UnidadesActivas_755ME).ToString(),
                expensado.ToString("F2"), cobrado.ToString("F2"), _resumen.Sum(r => r.DeudaVencida_755ME).ToString("F2"),
                (expensado == 0 ? 0 : cobrado * 100 / expensado).ToString("F2"), _resumen.Sum(r => r.TotalGastos_755ME).ToString("F2"),
                _resumen.Sum(r => r.ServiciosAprobadosPendientes_755ME).ToString(), _resumen.Sum(r => r.CostoServiciosPendientes_755ME).ToString("F2"),
                _resumen.Sum(r => r.TotalEgresos_755ME).ToString("F2"), _resumen.Sum(r => r.SaldoFondo_755ME).ToString("F2")
            });
            string periodo = dtpDesde.Value.ToString("dd/MM/yyyy") + " - " + dtpHasta.Value.ToString("dd/MM/yyyy");
            _exportador.ExportarTabla(Text + " " + periodo, encabezados, filas, ruta);
        }

        private void MostrarTotales_755ME()
        {
            IdiomaUI_755ME.PonerValor(lblTotalExpensado, () => _resumen.Sum(r => r.TotalExpensado_755ME).ToString("F2"));
            IdiomaUI_755ME.PonerValor(lblTotalCobrado, () => _resumen.Sum(r => r.TotalCobrado_755ME).ToString("F2"));
            IdiomaUI_755ME.PonerValor(lblTotalDeuda, () => _resumen.Sum(r => r.DeudaVencida_755ME).ToString("F2"));
            IdiomaUI_755ME.PonerValor(lblTotalSaldo, () => _resumen.Sum(r => r.SaldoFondo_755ME).ToString("F2"));
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            if (MdiParent is frmMdiPrincipal f) f.CambiarIdiomaFormulario(this, idioma);
            IdiomaUI_755ME.Refrescar(this);
        }

        private void FormReporteGlobal_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }

        private void FormReporteGlobal_755ME_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            FormAyuda_755ME.Mostrar_755ME(this, "reporte-global");
            hlpevent.Handled = true;
        }
    }
}

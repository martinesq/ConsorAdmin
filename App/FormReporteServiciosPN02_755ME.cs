using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // RF15: historial, estado y costo acumulado de los servicios, por consorcio o por proveedor
    public partial class FormReporteServiciosPN02_755ME : Form, IIdiomaObserver
    {
        private readonly ServicioBLL_755ME _servicioBLL = new ServicioBLL_755ME();
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private readonly ProveedorBLL_755ME _proveedorBLL = new ProveedorBLL_755ME();
        private readonly ExportadorPdfService _exportador = new ExportadorPdfService();
        private List<ConsorcioBE_755ME> _consorcios = new List<ConsorcioBE_755ME>();
        private decimal _acumulado;

        public FormReporteServiciosPN02_755ME()
        {
            InitializeComponent();
        }

        private void FormReporteServiciosPN02_755ME_Load(object sender, EventArgs e)
        {
            SessionManager.AgregarObservador(this);
            ActualizarIdioma(SessionManager.Idioma);
            _consorcios = _consorcioBLL.ObtenerConsorciosAsignados_755ME();
            cboConsorcio.DisplayMember = "Nombre_755ME";
            cboConsorcio.DataSource = _consorcios;
            cboConsorcio.SelectedIndex = -1;
            // todos, no solo los habilitados: un proveedor inhabilitado tambien tiene historial
            cboProveedor.DisplayMember = "Nombre_755ME";
            cboProveedor.DataSource = _proveedorBLL.ObtenerTodos_755ME();
            cboProveedor.SelectedIndex = -1;
            AplicarFiltro_755ME();
            // sin consorcios asignados no hay nada para consultar
            lblSinConsorcios.Visible = _consorcios.Count == 0;
            if (_consorcios.Count == 0)
            {
                rbPorConsorcio.Enabled = false;
                rbPorProveedor.Enabled = false;
                cboConsorcio.Enabled = false;
                cboProveedor.Enabled = false;
                btnGenerar.Enabled = false;
            }
        }

        private void rbPorConsorcio_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro_755ME();
        }

        private void AplicarFiltro_755ME()
        {
            cboConsorcio.Enabled = rbPorConsorcio.Checked;
            cboProveedor.Enabled = rbPorProveedor.Checked;
            colConsorcio.Visible = rbPorProveedor.Checked;
            colProveedor.Visible = rbPorConsorcio.Checked;
            LimpiarResultado_755ME();
        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarResultado_755ME();
        }

        private void LimpiarResultado_755ME()
        {
            dgvServicios.Rows.Clear();
            _acumulado = 0;
            IdiomaUI_755ME.PonerValor(lblCostoAcumulado, () => _acumulado.ToString("F2"));
            btnExportarPdf.Enabled = false;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            List<ServicioBE_755ME> servicios;
            if (rbPorConsorcio.Checked)
            {
                if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio)
                {
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_repserv_elegir_consorcio", "Seleccione un consorcio"), Text);
                    return;
                }
                servicios = _servicioBLL.ObtenerPorConsorcio_755ME(consorcio.IdConsorcio_755ME);
            }
            else
            {
                if (cboProveedor.SelectedItem is not ProveedorBE_755ME proveedor)
                {
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_repserv_elegir_proveedor", "Seleccione un proveedor"), Text);
                    return;
                }
                // un proveedor trabaja para varios consorcios: el gestor solo ve los suyos
                servicios = _servicioBLL.ObtenerPorProveedor_755ME(proveedor.IdProveedor_755ME)
                    .Where(s => _consorcios.Any(c => c.IdConsorcio_755ME == s.IdConsorcio_755ME)).ToList();
            }

            dgvServicios.Rows.Clear();
            foreach (ServicioBE_755ME s in servicios)
            {
                string consorcio = _consorcios.FirstOrDefault(c => c.IdConsorcio_755ME == s.IdConsorcio_755ME)?.Nombre_755ME ?? "";
                dgvServicios.Rows.Add(consorcio, s.NombreProveedor_755ME, s.Categoria_755ME, s.Descripcion_755ME, s.Estado_755ME, s.Costo_755ME.ToString("F2"));
            }
            _acumulado = servicios.Sum(s => s.Costo_755ME);
            IdiomaUI_755ME.PonerValor(lblCostoAcumulado, () => _acumulado.ToString("F2"));
            btnExportarPdf.Enabled = servicios.Count > 0;
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "Archivos PDF (*.pdf)|*.pdf";
                dialogo.FileName = "ReporteServicios_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";
                if (dialogo.ShowDialog() != DialogResult.OK) return;
                try
                {
                    ExportarPdf_755ME(dialogo.FileName);
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_repserv_pdf_ok", "Reporte exportado"), Text);
                }
                catch (Exception)
                {
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_repserv_pdf_error", "No se pudo generar el PDF, intente nuevamente"), Text);
                }
            }
        }

        // el PDF lleva lo mismo que se ve en la grilla, mas el costo acumulado
        private void ExportarPdf_755ME(string ruta)
        {
            List<DataGridViewColumn> columnas = dgvServicios.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
            List<List<string>> filas = dgvServicios.Rows.Cast<DataGridViewRow>()
                .Select(r => columnas.Select(c => r.Cells[c.Index].Value?.ToString() ?? "").ToList()).ToList();
            List<string> total = columnas.Select(c => "").ToList();
            total[total.Count - 2] = IdiomaUI_755ME.Texto("lb_repserv_costo_acumulado", "Costo acumulado:");
            total[total.Count - 1] = _acumulado.ToString("F2");
            filas.Add(total);
            string filtro = rbPorConsorcio.Checked ? cboConsorcio.Text : cboProveedor.Text;
            _exportador.ExportarTabla(Text + " - " + filtro, columnas.Select(c => c.HeaderText).ToList(), filas, ruta);
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
            IdiomaUI_755ME.Refrescar(this);
        }

        private void FormReporteServiciosPN02_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }

        private void FormReporteServiciosPN02_755ME_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            FormAyuda_755ME.Mostrar_755ME(this, "reporte-servicios");
            hlpevent.Handled = true;
        }
    }
}

using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // CU008: Cargar prestacion del proveedor
    public partial class FormPrestacion_755ME : Form, IIdiomaObserver
    {
        private readonly ServicioBLL_755ME _bll = new ServicioBLL_755ME();
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private ServicioBE_755ME? _servicioSeleccionado;

        public FormPrestacion_755ME()
        {
            InitializeComponent();
        }

        private void FormPrestacion_755ME_Load(object sender, EventArgs e)
        {
            SessionManager.AgregarObservador(this);
            ActualizarIdioma(SessionManager.Idioma);
            List<ConsorcioBE_755ME> consorcios = _consorcioBLL.ObtenerConsorciosAsignados_755ME();
            cboConsorcio.DisplayMember = "Nombre_755ME";
            cboConsorcio.DataSource = consorcios;
            // FA-1
            bool sinConsorcios = consorcios.Count == 0;
            lblSinConsorcios.Visible = sinConsorcios;
            cboConsorcio.Enabled = !sinConsorcios;
        }

        private void cboConsorcio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarServicios_755ME(true);
        }

        private void CargarServicios_755ME(bool avisarSiVacio)
        {
            dgvServicios.Rows.Clear();
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            List<ServicioBE_755ME> pendientes = _bll.ObtenerPendientesDeCarga_755ME(consorcio.IdConsorcio_755ME);
            foreach (ServicioBE_755ME s in pendientes)
            {
                int fila = dgvServicios.Rows.Add(s.IdServicio_755ME, s.Categoria_755ME, s.Descripcion_755ME, s.NombreProveedor_755ME,
                    s.PlazoEstimado_755ME, s.FechaAsignacion_755ME?.ToString("dd/MM/yyyy"));
                dgvServicios.Rows[fila].Tag = s;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvServicios_SelectionChanged(dgvServicios, EventArgs.Empty);
            // FA-2
            if (pendientes.Count == 0 && avisarSiVacio)
            {
                MessageBox.Show("No hay servicios asignados pendientes de carga", Text);
            }
        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count == 0 || dgvServicios.SelectedRows[0].Tag == null)
            {
                _servicioSeleccionado = null;
                grpPrestacion.Enabled = false;
            }
            else
            {
                _servicioSeleccionado = (ServicioBE_755ME)dgvServicios.SelectedRows[0].Tag!;
                grpPrestacion.Enabled = true;
            }
            ActualizarBoton_755ME();
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Filter = "Comprobantes (*.pdf;*.jpg;*.png)|*.pdf;*.jpg;*.jpeg;*.png|Todos los archivos (*.*)|*.*";
                if (dialogo.ShowDialog() == DialogResult.OK) txtArchivo.Text = dialogo.FileName;
            }
        }

        private void datosPrestacion_Changed(object sender, EventArgs e)
        {
            ActualizarBoton_755ME();
        }

        // FA-3: sin costo o sin numero de factura no habilita continuar (el archivo es opcional)
        private void ActualizarBoton_755ME()
        {
            btnConfirmar.Enabled = _servicioSeleccionado != null
                && !string.IsNullOrWhiteSpace(numCosto.Text) && !string.IsNullOrWhiteSpace(txtFactura.Text);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_servicioSeleccionado == null) return;
            try
            {
                ServicioBE_755ME servicio = _bll.CargarPrestacion_755ME(_servicioSeleccionado.IdServicio_755ME, dtpFecha.Value,
                    txtTrabajo.Text.Trim(), numCosto.Value, txtFactura.Text.Trim(), txtArchivo.Text);
                MessageBox.Show("Servicio N.º " + servicio.IdServicio_755ME + " en estado " + servicio.Estado_755ME +
                    "\nCosto: " + servicio.Costo_755ME.ToString("F2") + "\nComprobante: " + servicio.NumeroFactura_755ME, Text);
                txtTrabajo.Clear();
                numCosto.Value = 0;
                txtFactura.Clear();
                txtArchivo.Clear();
                CargarServicios_755ME(false);
            }
            catch (Exception ex)
            {
                // FA-4: la BLL rechaza un costo menor o igual a cero
                MessageBox.Show(ex.Message, Text);
            }
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
            IdiomaUI_755ME.Refrescar(this);
        }

        private void FormPrestacion_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }

        private void FormPrestacion_755ME_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            FormAyuda_755ME.Mostrar_755ME(this, "cargar-prestacion");
            hlpevent.Handled = true;
        }
    }
}

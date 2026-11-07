using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // CU009: Aprobar prestacion
    public partial class FormAprobacionPrestacion_755ME : Form, IIdiomaObserver
    {
        private readonly ServicioBLL_755ME _bll = new ServicioBLL_755ME();
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private ServicioBE_755ME? _servicioSeleccionado;

        public FormAprobacionPrestacion_755ME()
        {
            InitializeComponent();
        }

        private void FormAprobacionPrestacion_755ME_Load(object sender, EventArgs e)
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
            CargarPrestaciones_755ME(true);
        }

        private void CargarPrestaciones_755ME(bool avisarSiVacio)
        {
            dgvPrestaciones.Rows.Clear();
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            List<ServicioBE_755ME> pendientes = _bll.ObtenerPendientesDeAprobacion_755ME(consorcio.IdConsorcio_755ME);
            foreach (ServicioBE_755ME s in pendientes)
            {
                int fila = dgvPrestaciones.Rows.Add(s.IdServicio_755ME, s.Categoria_755ME, s.NombreProveedor_755ME,
                    s.FechaPrestacion_755ME?.ToString("dd/MM/yyyy"), s.Costo_755ME.ToString("F2"));
                dgvPrestaciones.Rows[fila].Tag = s;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvPrestaciones_SelectionChanged(dgvPrestaciones, EventArgs.Empty);
            // FA-2
            if (pendientes.Count == 0 && avisarSiVacio)
            {
                MessageBox.Show("No hay prestaciones pendientes de aprobacion", Text);
            }
        }

        private void dgvPrestaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPrestaciones.SelectedRows.Count == 0 || dgvPrestaciones.SelectedRows[0].Tag == null)
            {
                _servicioSeleccionado = null;
                grpDetalle.Enabled = false;
                IdiomaUI_755ME.PonerValor(lblProveedor, null);
                IdiomaUI_755ME.PonerValor(lblTrabajo, null);
                IdiomaUI_755ME.PonerValor(lblCosto, null);
                IdiomaUI_755ME.PonerValor(lblComprobante, null);
            }
            else
            {
                ServicioBE_755ME s = (ServicioBE_755ME)dgvPrestaciones.SelectedRows[0].Tag!;
                _servicioSeleccionado = s;
                grpDetalle.Enabled = true;
                IdiomaUI_755ME.PonerValor(lblProveedor, () => s.NombreProveedor_755ME);
                IdiomaUI_755ME.PonerValor(lblTrabajo, () => s.DescripcionTrabajo_755ME);
                IdiomaUI_755ME.PonerValor(lblCosto, () => s.Costo_755ME.ToString("F2"));
                IdiomaUI_755ME.PonerValor(lblComprobante, () => s.NumeroFactura_755ME + (s.ArchivoAdjunto_755ME == "" ? "" : "  (" + s.ArchivoAdjunto_755ME + ")"));
            }
            txtMotivo.Clear();
            ActualizarBotones_755ME();
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
            ActualizarBotones_755ME();
        }

        // FA-4: sin motivo no habilita confirmar el rechazo
        private void ActualizarBotones_755ME()
        {
            bool hayMotivo = !string.IsNullOrWhiteSpace(txtMotivo.Text);
            btnAprobar.Enabled = _servicioSeleccionado != null;
            btnRechazar.Enabled = _servicioSeleccionado != null && hayMotivo;
            lblSinMotivo.Visible = _servicioSeleccionado != null && !hayMotivo;
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (_servicioSeleccionado == null) return;
            try
            {
                ServicioBE_755ME servicio = _bll.AprobarPrestacion_755ME(_servicioSeleccionado.IdServicio_755ME);
                MessageBox.Show("Servicio N.º " + servicio.IdServicio_755ME + " en estado " + servicio.Estado_755ME +
                    "\nQueda disponible para su pago como egreso", Text);
                CargarPrestaciones_755ME(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        // FA-3: el gestor rechaza la prestacion
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (_servicioSeleccionado == null) return;
            try
            {
                ServicioBE_755ME servicio = _bll.RechazarPrestacion_755ME(_servicioSeleccionado.IdServicio_755ME, txtMotivo.Text.Trim());
                MessageBox.Show("Servicio N.º " + servicio.IdServicio_755ME + " en estado " + servicio.Estado_755ME +
                    "\nMotivo: " + servicio.MotivoRechazo_755ME, Text);
                CargarPrestaciones_755ME(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
            IdiomaUI_755ME.Refrescar(this);
        }

        private void FormAprobacionPrestacion_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

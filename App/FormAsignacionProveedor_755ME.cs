using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // CU007: Asignar proveedor al servicio
    public partial class FormAsignacionProveedor_755ME : Form, IIdiomaObserver
    {
        private readonly ServicioBLL_755ME _bll = new ServicioBLL_755ME();
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private readonly ProveedorBLL_755ME _proveedorBLL = new ProveedorBLL_755ME();
        private ServicioBE_755ME? _servicioSeleccionado;

        public FormAsignacionProveedor_755ME()
        {
            InitializeComponent();
        }

        private void FormAsignacionProveedor_755ME_Load(object sender, EventArgs e)
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
            CargarSolicitudes_755ME(true);
        }

        private void CargarSolicitudes_755ME(bool avisarSiVacio)
        {
            dgvSolicitudes.Rows.Clear();
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            List<ServicioBE_755ME> pendientes = _bll.ObtenerPendientesDeAsignacion_755ME(consorcio.IdConsorcio_755ME);
            foreach (ServicioBE_755ME s in pendientes)
            {
                int fila = dgvSolicitudes.Rows.Add(s.IdServicio_755ME, s.Categoria_755ME, s.Descripcion_755ME,
                    s.IdUnidadFuncional_755ME.HasValue ? "Unidad funcional" : "Área común");
                dgvSolicitudes.Rows[fila].Tag = s;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvSolicitudes_SelectionChanged(dgvSolicitudes, EventArgs.Empty);
            // FA-2
            if (pendientes.Count == 0 && avisarSiVacio)
            {
                MessageBox.Show("No hay solicitudes pendientes de asignacion", Text);
            }
        }

        private void dgvSolicitudes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSolicitudes.SelectedRows.Count == 0 || dgvSolicitudes.SelectedRows[0].Tag == null)
            {
                _servicioSeleccionado = null;
                grpAsignacion.Enabled = false;
                cboProveedor.DataSource = null;
                ActualizarBoton_755ME();
                return;
            }
            bool cambioDeServicio = _servicioSeleccionado != dgvSolicitudes.SelectedRows[0].Tag;
            _servicioSeleccionado = (ServicioBE_755ME)dgvSolicitudes.SelectedRows[0].Tag!;
            grpAsignacion.Enabled = true;
            if (cambioDeServicio || cboProveedor.DataSource == null) CargarProveedores_755ME();
            ActualizarBoton_755ME();
        }

        private void CargarProveedores_755ME()
        {
            List<ProveedorBE_755ME> proveedores = _proveedorBLL.ObtenerHabilitados_755ME();
            cboProveedor.DisplayMember = "Nombre_755ME";
            cboProveedor.DataSource = proveedores;
            // FA-3
            if (proveedores.Count == 0)
            {
                MessageBox.Show("No hay proveedores habilitados", Text);
            }
        }

        private void numPlazo_ValueChanged(object sender, EventArgs e)
        {
            ActualizarBoton_755ME();
        }

        // FA-4: sin plazo valido no habilita confirmar
        private void ActualizarBoton_755ME()
        {
            // se lee el texto tipeado porque numPlazo.Value se actualiza recien al salir del control
            decimal plazo = decimal.TryParse(numPlazo.Text, out decimal p) ? p : numPlazo.Value;
            bool plazoValido = plazo > 0;
            lblPlazoInvalido.Visible = _servicioSeleccionado != null && !plazoValido;
            btnConfirmar.Enabled = _servicioSeleccionado != null && cboProveedor.SelectedItem != null && plazoValido;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_servicioSeleccionado == null || cboProveedor.SelectedItem is not ProveedorBE_755ME proveedor) return;
            try
            {
                ServicioBE_755ME servicio = _bll.AsignarProveedor_755ME(_servicioSeleccionado.IdServicio_755ME, proveedor.IdProveedor_755ME, (int)numPlazo.Value);
                MessageBox.Show("Servicio N.º " + servicio.IdServicio_755ME + " en estado " + servicio.Estado_755ME +
                    "\nProveedor: " + proveedor.Nombre_755ME + "\nPlazo estimado: " + servicio.PlazoEstimado_755ME + " dias", Text);
                numPlazo.Value = 0;
                CargarSolicitudes_755ME(false);
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

        private void FormAsignacionProveedor_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }

        private void FormAsignacionProveedor_755ME_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            FormAyuda_755ME.Mostrar_755ME(this, "asignar-proveedor");
            hlpevent.Handled = true;
        }
    }
}

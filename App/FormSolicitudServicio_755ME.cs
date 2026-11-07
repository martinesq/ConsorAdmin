using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // CU006: Formalizar solicitud de servicio
    public partial class FormSolicitudServicio_755ME : Form, IIdiomaObserver
    {
        private readonly ServicioBLL_755ME _bll = new ServicioBLL_755ME();
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private readonly UnidadFuncionalBLL_755ME _ufBLL = new UnidadFuncionalBLL_755ME();

        public FormSolicitudServicio_755ME()
        {
            InitializeComponent();
        }

        private void FormSolicitudServicio_755ME_Load(object sender, EventArgs e)
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
            grpSolicitud.Enabled = !sinConsorcios;
            ActualizarBoton_755ME();
        }

        private void cboConsorcio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboUnidad.DataSource = null;
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            cboUnidad.DisplayMember = "Numero_755ME";
            cboUnidad.DataSource = _ufBLL.ObtenerUnidadesActivas_755ME(consorcio.IdConsorcio_755ME);
            cboUnidad.SelectedIndex = -1;
        }

        private void rbUbicacion_CheckedChanged(object sender, EventArgs e)
        {
            cboUnidad.Enabled = rbUnidadFuncional.Checked;
        }

        private void txtSolicitud_TextChanged(object sender, EventArgs e)
        {
            ActualizarBoton_755ME();
        }

        // FA-2: sin categoria o descripcion no habilita continuar
        private void ActualizarBoton_755ME()
        {
            btnConfirmar.Enabled = cboConsorcio.SelectedItem != null
                && !string.IsNullOrWhiteSpace(txtCategoria.Text) && !string.IsNullOrWhiteSpace(txtDescripcion.Text);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            int? idUnidadFuncional = null;
            if (rbUnidadFuncional.Checked)
            {
                // FA-3
                if (cboUnidad.SelectedItem is not UnidadFuncionalBE_755ME uf)
                {
                    MessageBox.Show("Debe seleccionar la unidad funcional", Text);
                    return;
                }
                idUnidadFuncional = uf.IdUnidadFuncional_755ME;
            }
            try
            {
                ServicioBE_755ME servicio = _bll.FormalizarSolicitud_755ME(consorcio.IdConsorcio_755ME, txtCategoria.Text.Trim(), txtDescripcion.Text.Trim(), idUnidadFuncional);
                IdiomaUI_755ME.PonerValor(lblResultado, () => "N.º " + servicio.IdServicio_755ME + " - " + servicio.Estado_755ME);
                txtCategoria.Clear();
                txtDescripcion.Clear();
                rbAreaComun.Checked = true;
                cboUnidad.SelectedIndex = -1;
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

        private void FormSolicitudServicio_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

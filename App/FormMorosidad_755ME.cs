using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    public partial class FormMorosidad_755ME : Form, IIdiomaObserver
    {
        private readonly ExpensaBLL_755ME _bll = new ExpensaBLL_755ME();

        public FormMorosidad_755ME()
        {
            InitializeComponent();
        }

        private void FormMorosidad_755ME_Load(object sender, EventArgs e)
        {
            SessionManager.AgregarObservador(this);
            ActualizarIdioma(SessionManager.Idioma);
            List<ConsorcioBE_755ME> consorcios = _bll.ObtenerConsorciosAsignados_755ME();
            cboConsorcio.DisplayMember = "Nombre_755ME";
            cboConsorcio.DataSource = consorcios;
            bool sinConsorcios = consorcios.Count == 0;
            lblSinConsorcios.Visible = sinConsorcios;
            lblSinConsorcios.Text = sinConsorcios ? "No tiene consorcios asignados" : "";
            cboConsorcio.Enabled = !sinConsorcios;
        }

        private void cboConsorcio_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvMorosidad.Rows.Clear();
            dgvDetalle.Rows.Clear();
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;

            List<UnidadMorosaBE_755ME> morosidad = _bll.ObtenerMorosidad_755ME(consorcio.IdConsorcio_755ME);
            foreach (UnidadMorosaBE_755ME u in morosidad)
            {
                int fila = dgvMorosidad.Rows.Add(u.NumeroUnidad_755ME, u.MontoAdeudado_755ME.ToString("F2"), u.DiasAtraso_755ME, u.CuotasPendientes_755ME,
                    string.Join(", ", u.Detalle_755ME.Select(d => d.Periodo_755ME.ToString("MM/yyyy"))));
                dgvMorosidad.Rows[fila].Tag = u;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvMorosidad_SelectionChanged(dgvMorosidad, EventArgs.Empty);
            if (morosidad.Count == 0)
            {
                MessageBox.Show("El consorcio no registra unidades morosas", Text);
            }
        }

        private void dgvMorosidad_SelectionChanged(object? sender, EventArgs e)
        {
            dgvDetalle.Rows.Clear();
            // puede llegar con Tag == null porque lo dispara el Rows.Add
            if (dgvMorosidad.SelectedRows.Count == 0 || dgvMorosidad.SelectedRows[0].Tag is not UnidadMorosaBE_755ME u) return;
            foreach (ExpensaAdeudadaBE_755ME d in u.Detalle_755ME)
            {
                dgvDetalle.Rows.Add(d.Periodo_755ME.ToString("MM/yyyy"), d.FechaVencimiento_755ME.ToString("dd/MM/yyyy"), d.Monto_755ME.ToString("F2"),
                    d.Pagado_755ME.ToString("F2"), d.Saldo_755ME.ToString("F2"), d.RecargoPorMora_755ME.ToString("F2"), d.DiasAtraso_755ME);
            }
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
        }

        private void FormMorosidad_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

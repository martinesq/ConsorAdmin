using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    public partial class FormFondo_755ME : Form, IIdiomaObserver
    {
        private readonly FondoBLL_755ME _bll = new FondoBLL_755ME();
        private int _idConsorcioSeleccionado;

        public FormFondo_755ME()
        {
            InitializeComponent();
        }

        private void FormFondo_755ME_Load(object sender, EventArgs e)
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
            cboPeriodo.DataSource = null;
            cboPeriodo.Enabled = false;
            btnConsultar.Enabled = false;
            LimpiarEstadoFondo_755ME();
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            _idConsorcioSeleccionado = consorcio.IdConsorcio_755ME;

            List<DateTime> periodos = _bll.ObtenerPeriodosLiquidados_755ME(consorcio.IdConsorcio_755ME);
            cboPeriodo.Tag = periodos;
            cboPeriodo.DataSource = periodos.Select(p => p.ToString("MM/yyyy")).ToList();
            cboPeriodo.Enabled = periodos.Count > 0;
            btnConsultar.Enabled = periodos.Count > 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cboPeriodo.SelectedIndex < 0 || cboPeriodo.Tag is not List<DateTime> periodos) return;
            DateTime periodo = periodos[cboPeriodo.SelectedIndex];

            EstadoFondoBE_755ME? estado = _bll.ObtenerEstadoFondo_755ME(_idConsorcioSeleccionado, periodo);
            if (estado == null)
            {
                LimpiarEstadoFondo_755ME();
                MessageBox.Show("El período no registra pagos ni egresos", Text);
                return;
            }
            IdiomaUI_755ME.PonerValor(lblTotalRecaudado, () => estado.TotalRecaudado_755ME.ToString("F2"));
            IdiomaUI_755ME.PonerValor(lblTotalEgresado, () => estado.TotalEgresado_755ME.ToString("F2"));
            IdiomaUI_755ME.PonerValor(lblSaldoDisponible, () => estado.SaldoDisponible_755ME.ToString("F2"));
        }

        private void LimpiarEstadoFondo_755ME()
        {
            IdiomaUI_755ME.PonerValor(lblTotalRecaudado, null);
            IdiomaUI_755ME.PonerValor(lblTotalEgresado, null);
            IdiomaUI_755ME.PonerValor(lblSaldoDisponible, null);
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
            IdiomaUI_755ME.Refrescar(this);
        }

        private void FormFondo_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

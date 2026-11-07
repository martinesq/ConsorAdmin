using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // RF01: ABM simple de gastos
    public partial class FormGasto_755ME : Form, IIdiomaObserver
    {
        private readonly GastoBLL_755ME _bll = new GastoBLL_755ME();
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private int _idConsorcioSeleccionado;

        public FormGasto_755ME()
        {
            InitializeComponent();
        }

        private void FormGasto_755ME_Load(object sender, EventArgs e)
        {
            SessionManager.AgregarObservador(this);
            ActualizarIdioma(SessionManager.Idioma);
            List<ConsorcioBE_755ME> consorcios = _consorcioBLL.ObtenerConsorciosAsignados_755ME();
            cboConsorcio.DisplayMember = "Nombre_755ME";
            cboConsorcio.DataSource = consorcios;
            bool sinConsorcios = consorcios.Count == 0;
            lblSinConsorcios.Visible = sinConsorcios;
            cboConsorcio.Enabled = !sinConsorcios;
        }

        private void cboConsorcio_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpNuevoGasto.Enabled = false;
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            _idConsorcioSeleccionado = consorcio.IdConsorcio_755ME;
            grpNuevoGasto.Enabled = true;
            CargarGastos_755ME();
        }

        private void CargarGastos_755ME()
        {
            dgvGastos.Rows.Clear();
            foreach (GastoBE_755ME gasto in _bll.ObtenerPorConsorcio_755ME(_idConsorcioSeleccionado))
            {
                dgvGastos.Rows.Add(gasto.Periodo_755ME.ToString("MM/yyyy"), gasto.Descripcion_755ME, gasto.Rubro_755ME, gasto.Monto_755ME.ToString("F2"));
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GastoBE_755ME gasto = new GastoBE_755ME
                {
                    IdConsorcio_755ME = _idConsorcioSeleccionado,
                    Descripcion_755ME = txtDescripcion.Text,
                    Monto_755ME = numMonto.Value,
                    Periodo_755ME = new DateTime(dtpPeriodo.Value.Year, dtpPeriodo.Value.Month, 1),
                    Rubro_755ME = txtRubro.Text
                };
                _bll.Insertar_755ME(gasto);
                txtDescripcion.Clear();
                txtRubro.Clear();
                numMonto.Value = 0;
                CargarGastos_755ME();
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
        }

        private void FormGasto_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

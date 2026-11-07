using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    public partial class FormLiquidacion_755ME : Form, IIdiomaObserver
    {
        private readonly ExpensaBLL_755ME _bll = new ExpensaBLL_755ME();
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private readonly GastoBLL_755ME _gastoBLL = new GastoBLL_755ME();
        private readonly UnidadFuncionalBLL_755ME _ufBLL = new UnidadFuncionalBLL_755ME();
        private int _idConsorcioSeleccionado;

        public FormLiquidacion_755ME()
        {
            InitializeComponent();
        }

        private void FormLiquidacion_755ME_Load(object sender, EventArgs e)
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
            dgvResultado.Rows.Clear();
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            _idConsorcioSeleccionado = consorcio.IdConsorcio_755ME;
            CargarPeriodos_755ME();
        }

        private void CargarPeriodos_755ME()
        {
            cboPeriodo.DataSource = null;
            cboPeriodo.Enabled = false;
            lblSinPeriodos.Text = "";
            grpLiquidacion.Enabled = false;

            List<DateTime> periodos = _gastoBLL.ObtenerPeriodosConGastos_755ME(_idConsorcioSeleccionado);
            if (periodos.Count == 0)
            {
                lblSinPeriodos.Text = "No hay períodos con gastos pendientes de liquidar";
                MessageBox.Show(lblSinPeriodos.Text, Text);
                return;
            }
            // Tag antes que DataSource, porque el DataSource dispara SelectedIndexChanged
            cboPeriodo.Tag = periodos;
            cboPeriodo.DataSource = periodos.Select(p => p.ToString("MM/yyyy")).ToList();
            cboPeriodo.Enabled = true;
        }

        private void cboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpLiquidacion.Enabled = false;
            if (cboPeriodo.SelectedIndex < 0 || cboPeriodo.Tag is not List<DateTime> periodos) return;

            DateTime periodo = periodos[cboPeriodo.SelectedIndex];
            decimal totalGastos = _bll.PrepararLiquidacion_755ME(_idConsorcioSeleccionado, periodo);
            IdiomaUI_755ME.PonerValor(lblTotalGastos, () => totalGastos.ToString("F2"));
            // el vencimiento minimo tambien lo valida GenerarLiquidacion_755ME
            DateTime minimo = _bll.ObtenerVencimientoMinimo_755ME(_idConsorcioSeleccionado, periodo);
            dtpVencimiento.MinDate = minimo;
            dtpVencimiento.Value = minimo.AddDays(10);
            numHonorario.Value = 0;
            grpLiquidacion.Enabled = true;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                List<ExpensaBE_755ME> expensas = _bll.GenerarLiquidacion_755ME(dtpVencimiento.Value, numHonorario.Value);
                Dictionary<int, string> numerosUnidad = _ufBLL.ObtenerUnidadesActivas_755ME(_idConsorcioSeleccionado).ToDictionary(u => u.IdUnidadFuncional_755ME, u => u.Numero_755ME);
                dgvResultado.Rows.Clear();
                foreach (ExpensaBE_755ME exp in expensas)
                {
                    dgvResultado.Rows.Add(
                        numerosUnidad.TryGetValue(exp.IdUnidadFuncional_755ME, out string? numero) ? numero : exp.IdUnidadFuncional_755ME.ToString(),
                        exp.Monto_755ME.ToString("F2"), exp.HonorarioAplicado_755ME.ToString("F2"), exp.RecargoPorMora_755ME.ToString("F2"), exp.Estado_755ME);
                }
                MessageBox.Show("Liquidación generada: " + expensas.Count + " expensas", Text);
                CargarPeriodos_755ME();
            }
            catch (ArgumentException ex)
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

        private void FormLiquidacion_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

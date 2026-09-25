using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // CU001 (Anular Expensa) y CU008 (Revisar composicion): cada uno va en su pestaña
    public partial class FormExpensa_755ME : Form, IIdiomaObserver
    {
        private readonly ExpensaBLL_755ME _bll = new ExpensaBLL_755ME();
        private ExpensaBE_755ME? _expensaSeleccionada;
        private readonly bool _abrirEnComposicion;

        public FormExpensa_755ME() : this(false)
        {
        }

        // abrirEnComposicion: indica desde que opcion del menu se abrio el formulario
        public FormExpensa_755ME(bool abrirEnComposicion)
        {
            InitializeComponent();
            _abrirEnComposicion = abrirEnComposicion;
        }

        private void FormExpensa_755ME_Load(object sender, EventArgs e)
        {
            SessionManager.AgregarObservador(this);
            ActualizarIdioma(SessionManager.Idioma);
            CargarConsorcios_755ME(cboConsorcioAnular, lblSinConsorciosAnular);
            CargarConsorcios_755ME(cboConsorcioComposicion, lblSinConsorciosComposicion);
            if (_abrirEnComposicion)
            {
                tabExpensa.SelectedTab = tabComposicion;
            }
        }

        private void CargarConsorcios_755ME(ComboBox combo, Label lblSinConsorcios)
        {
            List<ConsorcioBE_755ME> consorcios = _bll.ObtenerConsorciosAsignados_755ME();
            combo.DisplayMember = "Nombre_755ME";
            combo.DataSource = consorcios;
            bool sinConsorcios = consorcios.Count == 0;
            lblSinConsorcios.Visible = sinConsorcios;
            lblSinConsorcios.Text = sinConsorcios ? "No tiene consorcios asignados" : "";
            combo.Enabled = !sinConsorcios;
        }

        // ---------- Pestaña Anular Expensa (CU001) ----------

        private void cboConsorcioAnular_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAnulables.Rows.Clear();
            grpMotivo.Enabled = false;
            txtMotivo.Clear();
            _expensaSeleccionada = null;
            if (cboConsorcioAnular.SelectedItem is not ConsorcioBE_755ME consorcio) return;

            List<ExpensaBE_755ME> expensas = _bll.ObtenerExpensasAnulables_755ME(consorcio.IdConsorcio_755ME);
            foreach (ExpensaBE_755ME exp in expensas)
            {
                int fila = dgvAnulables.Rows.Add(exp.Periodo_755ME.ToString("MM/yyyy"), exp.Monto_755ME.ToString("F2"), exp.FechaVencimiento_755ME.ToString("dd/MM/yyyy"), exp.Estado_755ME);
                dgvAnulables.Rows[fila].Tag = exp;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvAnulables_SelectionChanged(dgvAnulables, EventArgs.Empty);
            if (expensas.Count == 0)
            {
                MessageBox.Show("El consorcio no tiene expensas pendientes o vencidas", Text);
            }
        }

        private void dgvAnulables_SelectionChanged(object sender, EventArgs e)
        {
            // puede llegar con Tag == null porque lo dispara el Rows.Add
            if (dgvAnulables.SelectedRows.Count == 0 || dgvAnulables.SelectedRows[0].Tag == null)
            {
                _expensaSeleccionada = null;
                grpMotivo.Enabled = false;
                return;
            }
            _expensaSeleccionada = (ExpensaBE_755ME)dgvAnulables.SelectedRows[0].Tag!;
            grpMotivo.Enabled = true;
            ActualizarBotonAnular_755ME();
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
            ActualizarBotonAnular_755ME();
        }

        private void ActualizarBotonAnular_755ME()
        {
            btnAnular.Enabled = _expensaSeleccionada != null && !string.IsNullOrWhiteSpace(txtMotivo.Text);
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (_expensaSeleccionada == null) return;
            try
            {
                _bll.AnularExpensa_755ME(_expensaSeleccionada.IdExpensa_755ME, txtMotivo.Text);
                MessageBox.Show("Expensa anulada", Text);
                cboConsorcioAnular_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        // ---------- Pestaña Revisar composición (CU008) ----------

        private void cboConsorcioComposicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboUnidad.DataSource = null;
            cboUnidad.Enabled = false;
            dgvLiquidadas.Rows.Clear();
            LimpiarComposicion_755ME();
            if (cboConsorcioComposicion.SelectedItem is not ConsorcioBE_755ME consorcio) return;

            List<UnidadFuncionalBE_755ME> unidades = _bll.ObtenerUnidades_755ME(consorcio.IdConsorcio_755ME);
            cboUnidad.DisplayMember = "Numero_755ME";
            cboUnidad.DataSource = unidades;
            cboUnidad.Enabled = unidades.Count > 0;
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvLiquidadas.Rows.Clear();
            LimpiarComposicion_755ME();
            if (cboUnidad.SelectedItem is not UnidadFuncionalBE_755ME uf) return;

            List<ExpensaBE_755ME> liquidadas = _bll.ObtenerExpensasLiquidadas_755ME(uf.IdUnidadFuncional_755ME);
            foreach (ExpensaBE_755ME exp in liquidadas)
            {
                int fila = dgvLiquidadas.Rows.Add(exp.Periodo_755ME.ToString("MM/yyyy"), exp.Monto_755ME.ToString("F2"),
                    exp.FechaVencimiento_755ME.ToString("dd/MM/yyyy"), exp.Estado_755ME);
                dgvLiquidadas.Rows[fila].Tag = exp;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvLiquidadas_SelectionChanged(dgvLiquidadas, EventArgs.Empty);
            if (liquidadas.Count == 0)
            {
                MessageBox.Show("La unidad no tiene expensas liquidadas", Text);
            }
        }

        private void dgvLiquidadas_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarComposicion_755ME();
            // puede llegar con Tag == null porque lo dispara el Rows.Add
            if (dgvLiquidadas.SelectedRows.Count == 0 || dgvLiquidadas.SelectedRows[0].Tag == null) return;
            ExpensaBE_755ME expensa = (ExpensaBE_755ME)dgvLiquidadas.SelectedRows[0].Tag!;

            ComposicionExpensaBE_755ME composicion = _bll.ObtenerComposicion_755ME(expensa.IdExpensa_755ME);
            foreach (GastoBE_755ME gasto in composicion.Gastos_755ME)
            {
                dgvGastos.Rows.Add(gasto.Descripcion_755ME, gasto.Monto_755ME.ToString("F2"), gasto.Rubro_755ME);
            }
            IdiomaUI_755ME.PonerValor(lblHonorarioAplicado, () => composicion.HonorarioAplicado_755ME.ToString("F2"));
            IdiomaUI_755ME.PonerValor(lblCoeficienteAplicado, () => composicion.Coeficiente_755ME.ToString("P2"));
            // FA-3: sin recargo no se muestra esa seccion
            lblRecargoPorMora.Visible = composicion.RecargoPorMora_755ME > 0;
            IdiomaUI_755ME.PonerValor(lblRecargoPorMora, () => composicion.RecargoPorMora_755ME.ToString("F2"));
        }

        private void LimpiarComposicion_755ME()
        {
            dgvGastos.Rows.Clear();
            IdiomaUI_755ME.PonerValor(lblHonorarioAplicado, null);
            IdiomaUI_755ME.PonerValor(lblCoeficienteAplicado, null);
            IdiomaUI_755ME.PonerValor(lblRecargoPorMora, null);
            lblRecargoPorMora.Visible = true;
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
            IdiomaUI_755ME.Refrescar(this);
        }

        private void FormExpensa_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

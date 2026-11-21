using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // CU001: Anular expensa (la composicion paso al reporte de gestion)
    public partial class FormExpensa_755ME : Form, IIdiomaObserver
    {
        private readonly ExpensaBLL_755ME _bll = new ExpensaBLL_755ME();
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private ExpensaBE_755ME? _expensaSeleccionada;

        public FormExpensa_755ME()
        {
            InitializeComponent();
        }

        private void FormExpensa_755ME_Load(object sender, EventArgs e)
        {
            SessionManager.AgregarObservador(this);
            ActualizarIdioma(SessionManager.Idioma);
            CargarConsorcios_755ME(cboConsorcioAnular, lblSinConsorciosAnular);
        }

        private void CargarConsorcios_755ME(ComboBox combo, Label lblSinConsorcios)
        {
            List<ConsorcioBE_755ME> consorcios = _consorcioBLL.ObtenerConsorciosAsignados_755ME();
            combo.DisplayMember = "Nombre_755ME";
            combo.DataSource = consorcios;
            bool sinConsorcios = consorcios.Count == 0;
            lblSinConsorcios.Visible = sinConsorcios;
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

        private void FormExpensa_755ME_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            FormAyuda_755ME.Mostrar_755ME(this, "expensas");
            hlpevent.Handled = true;
        }
    }
}

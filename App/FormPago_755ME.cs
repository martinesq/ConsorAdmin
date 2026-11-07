using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    public partial class FormPago_755ME : Form, IIdiomaObserver
    {
        private readonly PagoBLL_755ME _bll = new PagoBLL_755ME();
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private readonly UnidadFuncionalBLL_755ME _ufBLL = new UnidadFuncionalBLL_755ME();
        private ExpensaBE_755ME? _expensaPendiente;

        public FormPago_755ME()
        {
            InitializeComponent();
        }

        private void FormPago_755ME_Load(object sender, EventArgs e)
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
            cboUnidad.DataSource = null;
            cboUnidad.Enabled = false;
            LimpiarExpensa_755ME();
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;

            List<UnidadFuncionalBE_755ME> unidades = _ufBLL.ObtenerUnidadesActivas_755ME(consorcio.IdConsorcio_755ME);
            cboUnidad.DisplayMember = "Numero_755ME";
            cboUnidad.DataSource = unidades;
            cboUnidad.Enabled = unidades.Count > 0;
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvExpensasPendientes.Rows.Clear();
            LimpiarExpensa_755ME();
            if (cboUnidad.SelectedItem is not UnidadFuncionalBE_755ME uf) return;

            // lista las expensas pendientes de la unidad para que el gestor elija cual cobrar
            List<ExpensaBE_755ME> pendientes = _bll.ObtenerExpensasPendientes_755ME(uf.IdUnidadFuncional_755ME);
            foreach (ExpensaBE_755ME exp in pendientes)
            {
                int fila = dgvExpensasPendientes.Rows.Add(exp.Periodo_755ME.ToString("MM/yyyy"), exp.Monto_755ME.ToString("F2"),
                    exp.FechaVencimiento_755ME.ToString("dd/MM/yyyy"), exp.Estado_755ME);
                dgvExpensasPendientes.Rows[fila].Tag = exp;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvExpensasPendientes_SelectionChanged(dgvExpensasPendientes, EventArgs.Empty);
            if (pendientes.Count == 0)
            {
                lblSinExpensaPendiente.Text = "La unidad no tiene expensas pendientes de pago";
                MessageBox.Show(lblSinExpensaPendiente.Text, Text);
            }
        }

        private void dgvExpensasPendientes_SelectionChanged(object sender, EventArgs e)
        {
            // puede llegar con Tag == null porque lo dispara el Rows.Add
            if (dgvExpensasPendientes.SelectedRows.Count == 0 || dgvExpensasPendientes.SelectedRows[0].Tag == null)
            {
                _expensaPendiente = null;
                IdiomaUI_755ME.PonerValor(lblMontoExpensa, null);
                IdiomaUI_755ME.PonerValor(lblVencimientoExpensa, null);
                IdiomaUI_755ME.PonerValor(lblEstadoExpensa, null);
                grpPago.Enabled = false;
                return;
            }
            _expensaPendiente = (ExpensaBE_755ME)dgvExpensasPendientes.SelectedRows[0].Tag!;
            ExpensaBE_755ME expensa = _expensaPendiente;
            IdiomaUI_755ME.PonerValor(lblMontoExpensa, () => expensa.Monto_755ME.ToString("F2") + "  |  " + IdiomaUI_755ME.Texto("lb_pagado", "Pagado:") + " " + expensa.Pagado_755ME.ToString("F2")
                + "  |  " + IdiomaUI_755ME.Texto("lb_saldo", "Saldo:") + " " + expensa.Saldo_755ME.ToString("F2"));
            IdiomaUI_755ME.PonerValor(lblVencimientoExpensa, () => expensa.FechaVencimiento_755ME.ToString("dd/MM/yyyy"));
            IdiomaUI_755ME.PonerValor(lblEstadoExpensa, () => expensa.Estado_755ME);
            numMonto.Value = Math.Min(_expensaPendiente.Saldo_755ME, numMonto.Maximum);
            grpPago.Enabled = true;
        }

        private void LimpiarExpensa_755ME()
        {
            _expensaPendiente = null;
            IdiomaUI_755ME.PonerValor(lblMontoExpensa, null);
            IdiomaUI_755ME.PonerValor(lblVencimientoExpensa, null);
            IdiomaUI_755ME.PonerValor(lblEstadoExpensa, null);
            lblSinExpensaPendiente.Text = "";
            grpPago.Enabled = false;
            lblResultado.Text = "";
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (_expensaPendiente == null || cboMedio.SelectedItem == null) return;
            decimal monto = numMonto.Value;

            // FA-4: si el monto supera la deuda se pide confirmar el excedente
            if (monto > _expensaPendiente.Saldo_755ME)
            {
                decimal excedente = monto - _expensaPendiente.Saldo_755ME;
                DialogResult resultado = MessageBox.Show(
                    "El monto ingresado supera la deuda. ¿Confirma el excedente de " + excedente.ToString("F2") + " como saldo a favor?",
                    Text, MessageBoxButtons.YesNo);
                if (resultado != DialogResult.Yes) return;
            }

            try
            {
                (ExpensaBE_755ME expensa, PagoBE_755ME comprobante) = _bll.RegistrarPago_755ME(_expensaPendiente.IdExpensa_755ME, monto, cboMedio.Text);
                lblResultado.Text = expensa.Estado_755ME != "Pagada"
                    ? "Expensa pagada parcialmente. Saldo restante: " + (_expensaPendiente.Saldo_755ME - monto).ToString("F2")
                    : "Expensa pagada. Comprobante: " + comprobante.NumeroComprobante_755ME;
                cboUnidad_SelectedIndexChanged(sender, e);
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

        private void FormPago_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

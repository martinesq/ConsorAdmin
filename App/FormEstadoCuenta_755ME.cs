using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    public partial class FormEstadoCuenta_755ME : Form, IIdiomaObserver
    {
        // opcion del combo: Id positivo = unidad funcional, negativo = -idConsorcio (consorcio completo)
        private class OpcionEstadoCuenta_755ME
        {
            public string Texto = "";
            public int Id;
            public override string ToString() => Texto;
        }

        private readonly EstadoCuentaBLL_755ME _bll = new EstadoCuentaBLL_755ME();
        private readonly ExportadorPdfService_755ME _exportador = new ExportadorPdfService_755ME();
        private EstadoCuentaBE_755ME? _estadoCuentaActual;

        public FormEstadoCuenta_755ME()
        {
            InitializeComponent();
        }

        private void FormEstadoCuenta_755ME_Load(object sender, EventArgs e)
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
            cboUnidad.Items.Clear();
            cboUnidad.Enabled = false;
            LimpiarEstadoCuenta_755ME();
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;

            cboUnidad.Items.Add(new OpcionEstadoCuenta_755ME { Texto = "Consorcio completo", Id = -consorcio.IdConsorcio_755ME });
            foreach (UnidadFuncionalBE_755ME uf in _bll.ObtenerUnidades_755ME(consorcio.IdConsorcio_755ME))
            {
                cboUnidad.Items.Add(new OpcionEstadoCuenta_755ME { Texto = "Unidad " + uf.Numero_755ME, Id = uf.IdUnidadFuncional_755ME });
            }
            cboUnidad.Enabled = true;
        }

        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarEstadoCuenta_755ME();
            if (cboUnidad.SelectedItem is not OpcionEstadoCuenta_755ME opcion) return;

            _estadoCuentaActual = _bll.ObtenerEstadoCuenta_755ME(opcion.Id);
            if (_estadoCuentaActual == null)
            {
                MessageBox.Show("No hay movimientos registrados", Text);
                return;
            }
            foreach (ExpensaBE_755ME exp in _estadoCuentaActual.Expensas_755ME)
            {
                dgvMovimientos.Rows.Add("Expensa", exp.Periodo_755ME.ToString("MM/yyyy"),
                    "Expensa " + exp.Estado_755ME + " (vence " + exp.FechaVencimiento_755ME.ToString("dd/MM/yyyy") + ")", exp.Monto_755ME.ToString("F2"));
            }
            foreach (PagoBE_755ME pago in _estadoCuentaActual.Pagos_755ME)
            {
                dgvMovimientos.Rows.Add("Pago", pago.FechaPago_755ME.ToString("dd/MM/yyyy"), pago.MedioPago_755ME + " - " + pago.NumeroComprobante_755ME, pago.Monto_755ME.ToString("F2"));
            }
            foreach (EgresoBE_755ME egreso in _estadoCuentaActual.Egresos_755ME)
            {
                dgvMovimientos.Rows.Add("Egreso", egreso.Fecha_755ME.ToString("dd/MM/yyyy"), egreso.Concepto_755ME, egreso.Monto_755ME.ToString("F2"));
            }
            IdiomaUI_755ME.PonerValor(lblSaldo, () => _estadoCuentaActual.Saldo_755ME.ToString("F2"));
            btnEmitir.Enabled = true;
        }

        private void LimpiarEstadoCuenta_755ME()
        {
            _estadoCuentaActual = null;
            dgvMovimientos.Rows.Clear();
            IdiomaUI_755ME.PonerValor(lblSaldo, null);
            btnEmitir.Enabled = false;
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            if (_estadoCuentaActual == null) return;
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                byte[] pdf = _exportador.Exportar_755ME(_estadoCuentaActual);
                File.WriteAllBytes(saveFileDialog.FileName, pdf);
                MessageBox.Show("Estado de cuenta emitido", Text);
            }
            catch (Exception)
            {
                // FA-3: deja en pantalla lo que ya se mostro
                MessageBox.Show("No se pudo generar el PDF, intente nuevamente", Text);
            }
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
            IdiomaUI_755ME.Refrescar(this);
        }

        private void FormEstadoCuenta_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

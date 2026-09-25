using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    public partial class FormOrdenPago_755ME : Form, IIdiomaObserver
    {
        private readonly OrdenPagoBLL_755ME _bll = new OrdenPagoBLL_755ME();
        private UnidadFuncionalBE_755ME? _unidadSeleccionada;

        public FormOrdenPago_755ME()
        {
            InitializeComponent();
        }

        private void FormOrdenPago_755ME_Load(object sender, EventArgs e)
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
            CargarPendientes_755ME();
        }

        private void CargarPendientes_755ME()
        {
            LimpiarTalon_755ME();
            RecargarGrillaPendientes_755ME();
        }

        private void RecargarGrillaPendientes_755ME()
        {
            dgvPendientes.Rows.Clear();
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;

            List<UnidadFuncionalBE_755ME> pendientes = _bll.ObtenerUnidadesPendientesDeOrden_755ME(consorcio.IdConsorcio_755ME);
            foreach (UnidadFuncionalBE_755ME uf in pendientes)
            {
                int fila = dgvPendientes.Rows.Add(uf.Numero_755ME, uf.Tipo_755ME);
                dgvPendientes.Rows[fila].Tag = uf;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvPendientes_SelectionChanged(dgvPendientes, EventArgs.Empty);
            if (pendientes.Count == 0)
            {
                MessageBox.Show("No hay unidades con expensa liquidada pendiente de orden de pago", Text);
            }
        }

        private void dgvPendientes_SelectionChanged(object sender, EventArgs e)
        {
            // puede llegar con Tag == null porque lo dispara el Rows.Add
            if (dgvPendientes.SelectedRows.Count == 0 || dgvPendientes.SelectedRows[0].Tag == null)
            {
                _unidadSeleccionada = null;
                btnGenerarOrden.Enabled = false;
                return;
            }
            _unidadSeleccionada = (UnidadFuncionalBE_755ME)dgvPendientes.SelectedRows[0].Tag!;
            btnGenerarOrden.Enabled = true;
        }

        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            if (_unidadSeleccionada == null) return;
            try
            {
                OrdenDePagoBE_755ME orden = _bll.GenerarOrdenPago_755ME(_unidadSeleccionada.IdUnidadFuncional_755ME);
                IdiomaUI_755ME.PonerValor(lblNumeroOrden, () => orden.NumeroOrden_755ME.ToString());
                IdiomaUI_755ME.PonerValor(lblPropietario, () => orden.PropietarioSnapshot_755ME);
                IdiomaUI_755ME.PonerValor(lblMontoOrden, () => orden.Monto_755ME.ToString("F2"));
                IdiomaUI_755ME.PonerValor(lblVencimientoOrden, () => orden.FechaVencimiento_755ME.ToString("dd/MM/yyyy"));
                RecargarGrillaPendientes_755ME();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void LimpiarTalon_755ME()
        {
            _unidadSeleccionada = null;
            btnGenerarOrden.Enabled = false;
            IdiomaUI_755ME.PonerValor(lblNumeroOrden, null);
            IdiomaUI_755ME.PonerValor(lblPropietario, null);
            IdiomaUI_755ME.PonerValor(lblMontoOrden, null);
            IdiomaUI_755ME.PonerValor(lblVencimientoOrden, null);
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
            IdiomaUI_755ME.Refrescar(this);
        }

        private void FormOrdenPago_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

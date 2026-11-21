using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    public partial class FormEgreso_755ME : Form, IIdiomaObserver
    {
        private readonly EgresoBLL_755ME _bll = new EgresoBLL_755ME();
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private readonly ServicioBLL_755ME _servicioBLL = new ServicioBLL_755ME();
        private ServicioBE_755ME? _servicioSeleccionado;

        public FormEgreso_755ME()
        {
            InitializeComponent();
        }

        private void FormEgreso_755ME_Load(object sender, EventArgs e)
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
            dgvServicios.Rows.Clear();
            LimpiarSeleccion_755ME();
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;

            List<ServicioBE_755ME> servicios = _servicioBLL.ObtenerServiciosAprobadosPendientes_755ME(consorcio.IdConsorcio_755ME);
            foreach (ServicioBE_755ME s in servicios)
            {
                int fila = dgvServicios.Rows.Add(s.Categoria_755ME, s.Descripcion_755ME, s.Costo_755ME.ToString("F2"));
                dgvServicios.Rows[fila].Tag = s;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvServicios_SelectionChanged(dgvServicios, EventArgs.Empty);
            // FA-2: sin servicios aprobados solo se puede cargar un insumo
            lblSinServicios.Text = servicios.Count == 0 ? "El consorcio no tiene servicios aprobados pendientes de pago" : "";
        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {
            _servicioSeleccionado = dgvServicios.SelectedRows.Count > 0 ? (ServicioBE_755ME)dgvServicios.SelectedRows[0].Tag! : null;
            if (_servicioSeleccionado != null)
            {
                txtConcepto.Text = "";
                numMonto.Value = 0;
            }
            ActualizarSaldoYBoton_755ME();
        }

        private void txtConcepto_TextChanged(object sender, EventArgs e)
        {
            ActualizarSaldoYBoton_755ME();
        }

        private void numMonto_ValueChanged(object sender, EventArgs e)
        {
            ActualizarSaldoYBoton_755ME();
        }

        private void numMonto_TextChanged(object sender, EventArgs e)
        {
            ActualizarSaldoYBoton_755ME();
        }

        private void ActualizarSaldoYBoton_755ME()
        {
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio)
            {
                btnConfirmar.Enabled = false;
                return;
            }
            decimal saldo = _bll.ObtenerSaldoDisponible_755ME(consorcio.IdConsorcio_755ME);
            // el monto de un insumo no puede superar el saldo disponible
            // solo se reasigna si cambio, para no molestar mientras se tipea
            if (numMonto.Maximum != Math.Max(saldo, 0m)) numMonto.Maximum = Math.Max(saldo, 0m);
            // se lee el texto tipeado porque numMonto.Value se actualiza recien al salir del control
            decimal montoTipeado = decimal.TryParse(numMonto.Text, out decimal m) ? m : numMonto.Value;
            bool hayDatosValidos = _servicioSeleccionado != null || (!string.IsNullOrWhiteSpace(txtConcepto.Text) && montoTipeado > 0);
            decimal montoAPagar = _servicioSeleccionado != null ? _servicioSeleccionado.Costo_755ME : montoTipeado;
            bool saldoInsuficiente = hayDatosValidos && montoAPagar > saldo;
            IdiomaUI_755ME.PonerValor(lblSaldoDisponible, () => saldo.ToString("F2")
                + (saldoInsuficiente ? "  (" + IdiomaUI_755ME.Texto("lb_saldo_insuficiente", "saldo insuficiente para este egreso") + ")" : ""));
            // FA-3: sin concepto y monto no habilita continuar
            btnConfirmar.Enabled = hayDatosValidos && !saldoInsuficiente;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_servicioSeleccionado != null)
                {
                    _bll.RegistrarEgreso_755ME(_servicioSeleccionado.IdServicio_755ME, _servicioSeleccionado.Descripcion_755ME, _servicioSeleccionado.Costo_755ME, _servicioSeleccionado.IdProveedor_755ME);
                }
                else
                {
                    _bll.RegistrarEgreso_755ME(null, txtConcepto.Text, numMonto.Value, null);
                }
                MessageBox.Show("Egreso registrado. Se cargo el gasto para la proxima liquidacion", Text);
                cboConsorcio_SelectedIndexChanged(sender, e);
            }
            catch (InvalidOperationException ex)
            {
                // FA-4: saldo insuficiente, no deja confirmar
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void LimpiarSeleccion_755ME()
        {
            _servicioSeleccionado = null;
            txtConcepto.Clear();
            numMonto.Value = 0;
            IdiomaUI_755ME.PonerValor(lblSaldoDisponible, null);
            btnConfirmar.Enabled = false;
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
            IdiomaUI_755ME.Refrescar(this);
        }

        private void FormEgreso_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }

        private void FormEgreso_755ME_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            FormAyuda_755ME.Mostrar_755ME(this, "egresos");
            hlpevent.Handled = true;
        }
    }
}

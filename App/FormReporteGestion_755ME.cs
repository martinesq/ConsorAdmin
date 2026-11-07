using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // reporte de gestion (A02): composicion de expensa, morosidad, estado del fondo y estado de cuenta en una sola pantalla
    public partial class FormReporteGestion_755ME : Form, IIdiomaObserver
    {
        // opcion del combo de estado de cuenta: Id positivo = unidad funcional, negativo = -idConsorcio (consorcio completo)
        private class OpcionEstadoCuenta_755ME
        {
            public string Texto = "";
            public int Id;
            public override string ToString() => Texto;
        }

        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private readonly UnidadFuncionalBLL_755ME _ufBLL = new UnidadFuncionalBLL_755ME();
        private readonly ExpensaBLL_755ME _expensaBLL = new ExpensaBLL_755ME();
        private readonly FondoBLL_755ME _fondoBLL = new FondoBLL_755ME();
        private readonly EstadoCuentaBLL_755ME _estadoCuentaBLL = new EstadoCuentaBLL_755ME();
        private readonly ExportadorPdfService_755ME _exportador = new ExportadorPdfService_755ME();

        // lo que se esta mostrando en cada pestaña, es lo que se exporta
        private ComposicionExpensaBE_755ME? _composicionActual;
        private string _filtroComposicion = "";
        private List<UnidadMorosaBE_755ME> _morosidadActual = new List<UnidadMorosaBE_755ME>();
        private EstadoFondoBE_755ME? _fondoActual;
        private string _filtroFondo = "";
        private EstadoCuentaBE_755ME? _estadoCuentaActual;
        private string _filtroEstadoCuenta = "";

        public FormReporteGestion_755ME()
        {
            InitializeComponent();
        }

        private void FormReporteGestion_755ME_Load(object sender, EventArgs e)
        {
            SessionManager.AgregarObservador(this);
            ActualizarIdioma(SessionManager.Idioma);
            List<ConsorcioBE_755ME> consorcios = _consorcioBLL.ObtenerConsorciosAsignados_755ME();
            cboConsorcio.DisplayMember = "Nombre_755ME";
            cboConsorcio.DataSource = consorcios;
            bool sinConsorcios = consorcios.Count == 0;
            lblSinConsorcios.Visible = sinConsorcios;
            cboConsorcio.Enabled = !sinConsorcios;
            btnGenerar.Enabled = !sinConsorcios;
        }

        // al cambiar el consorcio se recargan los filtros de las pestañas, los datos salen con Generar
        private void cboConsorcio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            CargarFiltrosComposicion_755ME(consorcio);
            CargarPeriodosFondo_755ME(consorcio);
            CargarFiltrosEstadoCuenta_755ME(consorcio);
            LimpiarResultados_755ME();
        }

        // llena las 4 pestañas con los filtros elegidos y recien ahi se puede exportar
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            MostrarLiquidadas_755ME(cboUnidadComposicion.SelectedItem as UnidadFuncionalBE_755ME);
            CargarMorosidad_755ME(consorcio);
            MostrarFondo_755ME();
            MostrarEstadoCuenta_755ME();
            btnExportarPdf.Enabled = true;
        }

        // si cambia un filtro lo que estaba a la vista ya no corresponde
        private void LimpiarResultados_755ME()
        {
            MostrarLiquidadas_755ME(null);
            _morosidadActual = new List<UnidadMorosaBE_755ME>();
            dgvMorosidad.Rows.Clear();
            dgvDetalleMorosidad.Rows.Clear();
            lblAvisoMorosidad.Text = "";
            LimpiarFondo_755ME();
            LimpiarEstadoCuenta_755ME();
            btnExportarPdf.Enabled = false;
        }

        // ---------- Composicion de expensa ----------

        private void CargarFiltrosComposicion_755ME(ConsorcioBE_755ME consorcio)
        {
            cboUnidadComposicion.DataSource = null;
            List<UnidadFuncionalBE_755ME> unidades = _ufBLL.ObtenerUnidadesActivas_755ME(consorcio.IdConsorcio_755ME);
            cboUnidadComposicion.DisplayMember = "Numero_755ME";
            cboUnidadComposicion.DataSource = unidades;
            cboUnidadComposicion.Enabled = unidades.Count > 0;
        }

        private void cboUnidadComposicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarResultados_755ME();
        }

        private void MostrarLiquidadas_755ME(UnidadFuncionalBE_755ME? uf)
        {
            dgvLiquidadas.Rows.Clear();
            List<ExpensaBE_755ME> liquidadas = uf == null ? new List<ExpensaBE_755ME>() : _expensaBLL.ObtenerExpensasLiquidadas_755ME(uf.IdUnidadFuncional_755ME);
            foreach (ExpensaBE_755ME exp in liquidadas)
            {
                int fila = dgvLiquidadas.Rows.Add(exp.Periodo_755ME.ToString("MM/yyyy"), exp.Monto_755ME.ToString("F2"),
                    exp.FechaVencimiento_755ME.ToString("dd/MM/yyyy"), exp.Estado_755ME);
                dgvLiquidadas.Rows[fila].Tag = exp;
            }
            lblAvisoComposicion.Text = uf != null && liquidadas.Count == 0 ? "La unidad no tiene expensas liquidadas" : "";
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvLiquidadas_SelectionChanged(dgvLiquidadas, EventArgs.Empty);
        }

        private void dgvLiquidadas_SelectionChanged(object sender, EventArgs e)
        {
            dgvGastos.Rows.Clear();
            _composicionActual = null;
            _filtroComposicion = "";
            IdiomaUI_755ME.PonerValor(lblHonorarioAplicado, null);
            IdiomaUI_755ME.PonerValor(lblCoeficienteAplicado, null);
            IdiomaUI_755ME.PonerValor(lblRecargoPorMora, null);
            lblRecargoPorMora.Visible = true;
            if (dgvLiquidadas.SelectedRows.Count == 0 || dgvLiquidadas.SelectedRows[0].Tag is not ExpensaBE_755ME expensa) return;

            ComposicionExpensaBE_755ME composicion = _expensaBLL.ObtenerComposicion_755ME(expensa.IdExpensa_755ME);
            foreach (GastoBE_755ME gasto in composicion.Gastos_755ME)
            {
                dgvGastos.Rows.Add(gasto.Descripcion_755ME, gasto.Monto_755ME.ToString("F2"), gasto.Rubro_755ME);
            }
            IdiomaUI_755ME.PonerValor(lblHonorarioAplicado, () => composicion.HonorarioAplicado_755ME.ToString("F2"));
            IdiomaUI_755ME.PonerValor(lblCoeficienteAplicado, () => composicion.Coeficiente_755ME.ToString("P2"));
            // sin recargo no se muestra esa linea
            lblRecargoPorMora.Visible = composicion.RecargoPorMora_755ME > 0;
            IdiomaUI_755ME.PonerValor(lblRecargoPorMora, () => composicion.RecargoPorMora_755ME.ToString("F2"));
            _composicionActual = composicion;
            _filtroComposicion = "Unidad " + ((UnidadFuncionalBE_755ME)cboUnidadComposicion.SelectedItem!).Numero_755ME
                + ", periodo " + expensa.Periodo_755ME.ToString("MM/yyyy");
        }

        // ---------- Estadisticas de morosidad ----------

        private void CargarMorosidad_755ME(ConsorcioBE_755ME consorcio)
        {
            dgvMorosidad.Rows.Clear();
            _morosidadActual = _expensaBLL.ObtenerMorosidad_755ME(consorcio.IdConsorcio_755ME);
            foreach (UnidadMorosaBE_755ME u in _morosidadActual)
            {
                int fila = dgvMorosidad.Rows.Add(u.NumeroUnidad_755ME, u.MontoAdeudado_755ME.ToString("F2"), u.DiasAtraso_755ME, u.CuotasPendientes_755ME,
                    string.Join(", ", u.Detalle_755ME.Select(d => d.Periodo_755ME.ToString("MM/yyyy"))));
                dgvMorosidad.Rows[fila].Tag = u;
            }
            lblAvisoMorosidad.Text = _morosidadActual.Count == 0 ? "El consorcio no registra unidades morosas" : "";
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvMorosidad_SelectionChanged(dgvMorosidad, EventArgs.Empty);
        }

        private void dgvMorosidad_SelectionChanged(object sender, EventArgs e)
        {
            dgvDetalleMorosidad.Rows.Clear();
            if (dgvMorosidad.SelectedRows.Count == 0 || dgvMorosidad.SelectedRows[0].Tag is not UnidadMorosaBE_755ME u) return;
            foreach (ExpensaAdeudadaBE_755ME d in u.Detalle_755ME)
            {
                dgvDetalleMorosidad.Rows.Add(d.Periodo_755ME.ToString("MM/yyyy"), d.FechaVencimiento_755ME.ToString("dd/MM/yyyy"), d.Monto_755ME.ToString("F2"),
                    d.Pagado_755ME.ToString("F2"), d.Saldo_755ME.ToString("F2"), d.RecargoPorMora_755ME.ToString("F2"), d.DiasAtraso_755ME);
            }
        }

        // ---------- Estado del fondo ----------

        private void CargarPeriodosFondo_755ME(ConsorcioBE_755ME consorcio)
        {
            List<DateTime> periodos = _expensaBLL.ObtenerPeriodosLiquidados_755ME(consorcio.IdConsorcio_755ME);
            cboPeriodo.Tag = periodos;
            cboPeriodo.DataSource = periodos.Select(p => p.ToString("MM/yyyy")).ToList();
            cboPeriodo.Enabled = periodos.Count > 0;
        }

        private void cboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarResultados_755ME();
        }

        private void LimpiarFondo_755ME()
        {
            _fondoActual = null;
            _filtroFondo = "";
            IdiomaUI_755ME.PonerValor(lblTotalRecaudado, null);
            IdiomaUI_755ME.PonerValor(lblTotalEgresado, null);
            IdiomaUI_755ME.PonerValor(lblSaldoDisponible, null);
            lblAvisoFondo.Text = "";
        }

        private void MostrarFondo_755ME()
        {
            LimpiarFondo_755ME();
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            if (cboPeriodo.SelectedIndex < 0 || cboPeriodo.Tag is not List<DateTime> periodos) return;
            DateTime periodo = periodos[cboPeriodo.SelectedIndex];

            EstadoFondoBE_755ME? estado = _fondoBLL.ObtenerEstadoFondo_755ME(consorcio.IdConsorcio_755ME, periodo);
            if (estado == null)
            {
                lblAvisoFondo.Text = "El período no registra pagos ni egresos";
                return;
            }
            IdiomaUI_755ME.PonerValor(lblTotalRecaudado, () => estado.TotalRecaudado_755ME.ToString("F2"));
            IdiomaUI_755ME.PonerValor(lblTotalEgresado, () => estado.TotalEgresado_755ME.ToString("F2"));
            IdiomaUI_755ME.PonerValor(lblSaldoDisponible, () => estado.SaldoDisponible_755ME.ToString("F2"));
            _fondoActual = estado;
            _filtroFondo = "Periodo " + periodo.ToString("MM/yyyy");
        }

        // ---------- Estado de cuenta ----------

        private void CargarFiltrosEstadoCuenta_755ME(ConsorcioBE_755ME consorcio)
        {
            cboUnidadCuenta.Items.Clear();
            cboUnidadCuenta.Items.Add(new OpcionEstadoCuenta_755ME { Texto = "Consorcio completo", Id = -consorcio.IdConsorcio_755ME });
            foreach (UnidadFuncionalBE_755ME uf in _ufBLL.ObtenerUnidadesActivas_755ME(consorcio.IdConsorcio_755ME))
            {
                cboUnidadCuenta.Items.Add(new OpcionEstadoCuenta_755ME { Texto = "Unidad " + uf.Numero_755ME, Id = uf.IdUnidadFuncional_755ME });
            }
            cboUnidadCuenta.SelectedIndex = 0;
        }

        private void cboUnidadCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarResultados_755ME();
        }

        private void LimpiarEstadoCuenta_755ME()
        {
            dgvMovimientos.Rows.Clear();
            IdiomaUI_755ME.PonerValor(lblSaldo, null);
            _estadoCuentaActual = null;
            _filtroEstadoCuenta = "";
            lblAvisoCuenta.Text = "";
        }

        private void MostrarEstadoCuenta_755ME()
        {
            LimpiarEstadoCuenta_755ME();
            if (cboUnidadCuenta.SelectedItem is not OpcionEstadoCuenta_755ME opcion) return;

            EstadoCuentaBE_755ME? estadoCuenta = _estadoCuentaBLL.ObtenerEstadoCuenta_755ME(opcion.Id);
            if (estadoCuenta == null)
            {
                lblAvisoCuenta.Text = "No hay movimientos registrados";
                return;
            }
            foreach (ExpensaBE_755ME exp in estadoCuenta.Expensas_755ME)
            {
                dgvMovimientos.Rows.Add("Expensa", exp.Periodo_755ME.ToString("MM/yyyy"),
                    "Expensa " + exp.Estado_755ME + " (vence " + exp.FechaVencimiento_755ME.ToString("dd/MM/yyyy") + ")", exp.Monto_755ME.ToString("F2"));
            }
            foreach (PagoBE_755ME pago in estadoCuenta.Pagos_755ME)
            {
                dgvMovimientos.Rows.Add("Pago", pago.FechaPago_755ME.ToString("dd/MM/yyyy"), pago.MedioPago_755ME + " - " + pago.NumeroComprobante_755ME, pago.Monto_755ME.ToString("F2"));
            }
            foreach (EgresoBE_755ME egreso in estadoCuenta.Egresos_755ME)
            {
                dgvMovimientos.Rows.Add("Egreso", egreso.Fecha_755ME.ToString("dd/MM/yyyy"), egreso.Concepto_755ME, egreso.Monto_755ME.ToString("F2"));
            }
            IdiomaUI_755ME.PonerValor(lblSaldo, () => estadoCuenta.Saldo_755ME.ToString("F2"));
            _estadoCuentaActual = estadoCuenta;
            _filtroEstadoCuenta = opcion.Texto;
        }

        // ---------- Exportar ----------

        // un solo PDF con las 4 consultas tal como estan en pantalla
        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (cboConsorcio.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            saveFileDialog.FileName = "ReporteGestion_" + consorcio.Nombre_755ME.Replace(" ", "") + "_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                byte[] pdf = _exportador.ExportarReporteGestion_755ME(consorcio.Nombre_755ME,
                    _filtroComposicion, _composicionActual, _morosidadActual,
                    _filtroFondo, _fondoActual, _filtroEstadoCuenta, _estadoCuentaActual);
                File.WriteAllBytes(saveFileDialog.FileName, pdf);
                MessageBox.Show("Reporte exportado", Text);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo generar el PDF, intente nuevamente", Text);
            }
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
            IdiomaUI_755ME.Refrescar(this);
        }

        private void FormReporteGestion_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

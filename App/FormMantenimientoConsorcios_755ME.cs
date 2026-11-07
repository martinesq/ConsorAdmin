using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // Maestros: alta/baja de Consorcio, Unidad Funcional y Consorcista (solo Administrador global)
    public partial class FormMantenimientoConsorcios_755ME : Form, IIdiomaObserver
    {
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private readonly UnidadFuncionalBLL_755ME _ufBLL = new UnidadFuncionalBLL_755ME();
        private readonly ConsorcistaBLL_755ME _consorcistaBLL = new ConsorcistaBLL_755ME();
        private readonly UnidadConsorcistaBLL_755ME _unidadConsorcistaBLL = new UnidadConsorcistaBLL_755ME();
        private readonly ProveedorBLL_755ME _proveedorBLL = new ProveedorBLL_755ME();
        private ProveedorBE_755ME? _proveedorSeleccionado;
        private ConsorcioBE_755ME? _consorcioSeleccionado;
        private UnidadFuncionalBE_755ME? _unidadSeleccionada;
        private ConsorcistaBE_755ME? _consorcistaSeleccionado;

        // muestra el consorcio junto al numero porque el combo lista unidades de todos los consorcios
        private class OpcionUnidadPropietario_755ME
        {
            public string Texto = "";
            public UnidadFuncionalBE_755ME Unidad = null!;
            public override string ToString() => Texto;
        }

        public FormMantenimientoConsorcios_755ME()
        {
            InitializeComponent();
        }

        private void FormMantenimientoConsorcios_755ME_Load(object sender, EventArgs e)
        {
            SessionManager.AgregarObservador(this);
            ActualizarIdioma(SessionManager.Idioma);
            cboGestor.DisplayMember = "Email";
            cboGestor.DataSource = _consorcioBLL.ObtenerUsuariosGestores_755ME();

            CargarConsorcios_755ME();
            CargarComboConsorcios_755ME();
            CargarConsorcistas_755ME();
            CargarComboUnidadesPropietario_755ME();
            CargarProveedores_755ME();
            LimpiarDetalleConsorcio_755ME();
            LimpiarDetalleUnidad_755ME();
            LimpiarDetalleConsorcista_755ME();
            LimpiarDetalleProveedor_755ME();
        }

        // ---------- Consorcios ----------

        private void CargarConsorcios_755ME()
        {
            dgvConsorcios.Rows.Clear();
            foreach (ConsorcioBE_755ME c in _consorcioBLL.ObtenerTodosLosConsorcios_755ME())
            {
                int fila = dgvConsorcios.Rows.Add(c.Nombre_755ME, c.Direccion_755ME, c.CantidadUnidades_755ME, c.Activo_755ME ? "Si" : "No", ObtenerEmailUsuario_755ME(c.IdGestor_755ME));
                dgvConsorcios.Rows[fila].Tag = c;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvConsorcios_SelectionChanged(dgvConsorcios, EventArgs.Empty);
        }

        private string ObtenerEmailUsuario_755ME(Guid idGestor)
        {
            Usuario? usuario = (cboGestor.DataSource as List<Usuario>)?.FirstOrDefault(u => u.Id == idGestor);
            return usuario?.Email ?? idGestor.ToString();
        }

        private void dgvConsorcios_SelectionChanged(object sender, EventArgs e)
        {
            // puede llegar con Tag == null porque lo dispara el Rows.Add
            // solo cuenta la fila que elige el usuario, no la que la grilla selecciona sola al cargar
            if (!dgvConsorcios.Focused || dgvConsorcios.SelectedRows.Count == 0 || dgvConsorcios.SelectedRows[0].Tag == null)
            {
                LimpiarDetalleConsorcio_755ME();
                return;
            }
            _consorcioSeleccionado = (ConsorcioBE_755ME)dgvConsorcios.SelectedRows[0].Tag!;
            txtNombre.Text = _consorcioSeleccionado.Nombre_755ME;
            txtDireccion.Text = _consorcioSeleccionado.Direccion_755ME;
            numCantidadUnidades.Value = _consorcioSeleccionado.CantidadUnidades_755ME;
            cboGestor.SelectedItem = (cboGestor.DataSource as List<Usuario>)?.FirstOrDefault(u => u.Id == _consorcioSeleccionado.IdGestor_755ME);
            btnInactivarConsorcio.Enabled = _consorcioSeleccionado.Activo_755ME;
            btnReactivarConsorcio.Enabled = !_consorcioSeleccionado.Activo_755ME;
        }

        private void btnNuevoConsorcio_Click(object sender, EventArgs e)
        {
            dgvConsorcios.ClearSelection();
            LimpiarDetalleConsorcio_755ME();
        }

        private void LimpiarDetalleConsorcio_755ME()
        {
            _consorcioSeleccionado = null;
            txtNombre.Clear();
            txtDireccion.Clear();
            numCantidadUnidades.Value = 1;
            if (cboGestor.Items.Count > 0) cboGestor.SelectedIndex = 0;
            btnInactivarConsorcio.Enabled = false;
            btnReactivarConsorcio.Enabled = false;
        }

        private void btnGuardarConsorcio_Click(object sender, EventArgs e)
        {
            try
            {
                ConsorcioBE_755ME consorcio = _consorcioSeleccionado ?? new ConsorcioBE_755ME();
                consorcio.Nombre_755ME = txtNombre.Text;
                consorcio.Direccion_755ME = txtDireccion.Text;
                consorcio.CantidadUnidades_755ME = (int)numCantidadUnidades.Value;
                consorcio.IdGestor_755ME = (cboGestor.SelectedItem as Usuario)?.Id ?? Guid.Empty;
                _consorcioBLL.GuardarConsorcio_755ME(consorcio);
                MessageBox.Show("Guardado", Text);
                CargarConsorcios_755ME();
                CargarComboConsorcios_755ME();
                LimpiarDetalleConsorcio_755ME();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void btnInactivarConsorcio_Click(object sender, EventArgs e)
        {
            if (_consorcioSeleccionado == null) return;
            try
            {
                _consorcioBLL.InactivarConsorcio_755ME(_consorcioSeleccionado.IdConsorcio_755ME);
                CargarConsorcios_755ME();
                CargarComboConsorcios_755ME();
                LimpiarDetalleConsorcio_755ME();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void btnReactivarConsorcio_Click(object sender, EventArgs e)
        {
            if (_consorcioSeleccionado == null) return;
            _consorcioBLL.ReactivarConsorcio_755ME(_consorcioSeleccionado.IdConsorcio_755ME);
            CargarConsorcios_755ME();
            CargarComboConsorcios_755ME();
            LimpiarDetalleConsorcio_755ME();
        }

        // ---------- Unidades funcionales ----------

        private void CargarComboConsorcios_755ME()
        {
            object? seleccionActual = cboConsorcioUnidad.SelectedItem;
            cboConsorcioUnidad.DisplayMember = "Nombre_755ME";
            cboConsorcioUnidad.DataSource = _consorcioBLL.ObtenerTodosLosConsorcios_755ME();
            if (seleccionActual != null) cboConsorcioUnidad.SelectedItem = seleccionActual;
        }

        private void cboConsorcioUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUnidades_755ME();
            LimpiarDetalleUnidad_755ME();
        }

        private void CargarUnidades_755ME()
        {
            dgvUnidades.Rows.Clear();
            if (cboConsorcioUnidad.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            foreach (UnidadFuncionalBE_755ME u in _ufBLL.ObtenerUnidadesPorConsorcio_755ME(consorcio.IdConsorcio_755ME))
            {
                int fila = dgvUnidades.Rows.Add(u.Numero_755ME, u.Tipo_755ME, u.Coeficiente_755ME, u.Activa_755ME ? "Si" : "No");
                dgvUnidades.Rows[fila].Tag = u;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvUnidades_SelectionChanged(dgvUnidades, EventArgs.Empty);
        }

        private void dgvUnidades_SelectionChanged(object sender, EventArgs e)
        {
            // solo cuenta la fila que elige el usuario, no la que la grilla selecciona sola al cargar
            if (!dgvUnidades.Focused || dgvUnidades.SelectedRows.Count == 0 || dgvUnidades.SelectedRows[0].Tag == null)
            {
                LimpiarDetalleUnidad_755ME();
                return;
            }
            _unidadSeleccionada = (UnidadFuncionalBE_755ME)dgvUnidades.SelectedRows[0].Tag!;
            txtNumero.Text = _unidadSeleccionada.Numero_755ME;
            txtTipo.Text = _unidadSeleccionada.Tipo_755ME;
            numCoeficiente.Value = _unidadSeleccionada.Coeficiente_755ME;
            btnInactivarUnidad.Enabled = _unidadSeleccionada.Activa_755ME;
            btnReactivarUnidad.Enabled = !_unidadSeleccionada.Activa_755ME;
            btnVerHistorialUnidad.Enabled = true;
        }

        private void btnVerHistorialUnidad_Click(object sender, EventArgs e)
        {
            if (_unidadSeleccionada == null || cboConsorcioUnidad.SelectedItem is not ConsorcioBE_755ME consorcio) return;

            using (var pantalla = new FormHistorialUnidad_755ME(consorcio.IdConsorcio_755ME, consorcio.Nombre_755ME, _unidadSeleccionada.IdUnidadFuncional_755ME))
            {
                pantalla.ShowDialog(this);
            }
            // la unidad pudo haberse restaurado desde el historial
            CargarUnidades_755ME();
            LimpiarDetalleUnidad_755ME();
        }

        private void btnNuevaUnidad_Click(object sender, EventArgs e)
        {
            dgvUnidades.ClearSelection();
            LimpiarDetalleUnidad_755ME();
        }

        private void LimpiarDetalleUnidad_755ME()
        {
            _unidadSeleccionada = null;
            txtNumero.Clear();
            txtTipo.Clear();
            numCoeficiente.Value = 0;
            btnInactivarUnidad.Enabled = false;
            btnReactivarUnidad.Enabled = false;
            btnVerHistorialUnidad.Enabled = false;
        }

        private void btnGuardarUnidad_Click(object sender, EventArgs e)
        {
            if (cboConsorcioUnidad.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            try
            {
                UnidadFuncionalBE_755ME uf = _unidadSeleccionada ?? new UnidadFuncionalBE_755ME { IdConsorcio_755ME = consorcio.IdConsorcio_755ME };
                uf.Numero_755ME = txtNumero.Text;
                uf.Tipo_755ME = txtTipo.Text;
                uf.Coeficiente_755ME = numCoeficiente.Value;
                _ufBLL.GuardarUnidad_755ME(uf);
                MessageBox.Show("Guardado", Text);
                CargarUnidades_755ME();
                LimpiarDetalleUnidad_755ME();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void btnInactivarUnidad_Click(object sender, EventArgs e)
        {
            if (_unidadSeleccionada == null) return;
            try
            {
                _ufBLL.InactivarUnidad_755ME(_unidadSeleccionada.IdUnidadFuncional_755ME);
                CargarUnidades_755ME();
                LimpiarDetalleUnidad_755ME();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void btnReactivarUnidad_Click(object sender, EventArgs e)
        {
            if (_unidadSeleccionada == null) return;
            _ufBLL.ReactivarUnidad_755ME(_unidadSeleccionada.IdUnidadFuncional_755ME);
            CargarUnidades_755ME();
            LimpiarDetalleUnidad_755ME();
        }

        // ---------- Consorcistas ----------

        private void CargarConsorcistas_755ME()
        {
            dgvConsorcistas.Rows.Clear();
            foreach (ConsorcistaBE_755ME c in _consorcistaBLL.ObtenerTodosLosConsorcistas_755ME())
            {
                int fila = dgvConsorcistas.Rows.Add(c.Nombre_755ME, c.Apellido_755ME, c.DNI_755ME, c.Activo_755ME ? "Si" : "No");
                dgvConsorcistas.Rows[fila].Tag = c;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvConsorcistas_SelectionChanged(dgvConsorcistas, EventArgs.Empty);
        }

        private void dgvConsorcistas_SelectionChanged(object sender, EventArgs e)
        {
            // solo cuenta la fila que elige el usuario, no la que la grilla selecciona sola al cargar
            if (!dgvConsorcistas.Focused || dgvConsorcistas.SelectedRows.Count == 0 || dgvConsorcistas.SelectedRows[0].Tag == null)
            {
                LimpiarDetalleConsorcista_755ME();
                return;
            }
            _consorcistaSeleccionado = (ConsorcistaBE_755ME)dgvConsorcistas.SelectedRows[0].Tag!;
            txtNombreConsorcista.Text = _consorcistaSeleccionado.Nombre_755ME;
            txtApellidoConsorcista.Text = _consorcistaSeleccionado.Apellido_755ME;
            txtDniConsorcista.Text = _consorcistaSeleccionado.DNI_755ME;
            btnInactivarConsorcista.Enabled = _consorcistaSeleccionado.Activo_755ME;
            btnReactivarConsorcista.Enabled = !_consorcistaSeleccionado.Activo_755ME;
            grpPropietario.Enabled = true;
            CargarUnidadesDelConsorcista_755ME();
        }

        private void btnNuevoConsorcista_Click(object sender, EventArgs e)
        {
            dgvConsorcistas.ClearSelection();
            LimpiarDetalleConsorcista_755ME();
        }

        private void LimpiarDetalleConsorcista_755ME()
        {
            _consorcistaSeleccionado = null;
            txtNombreConsorcista.Clear();
            txtApellidoConsorcista.Clear();
            txtDniConsorcista.Clear();
            btnInactivarConsorcista.Enabled = false;
            btnReactivarConsorcista.Enabled = false;
            grpPropietario.Enabled = false;
            dgvUnidadesPropietario.Rows.Clear();
            btnQuitarPropietario.Enabled = false;
        }

        private void btnGuardarConsorcista_Click(object sender, EventArgs e)
        {
            try
            {
                ConsorcistaBE_755ME consorcista = _consorcistaSeleccionado ?? new ConsorcistaBE_755ME();
                consorcista.Nombre_755ME = txtNombreConsorcista.Text;
                consorcista.Apellido_755ME = txtApellidoConsorcista.Text;
                consorcista.DNI_755ME = txtDniConsorcista.Text;
                _consorcistaBLL.GuardarConsorcista_755ME(consorcista);
                MessageBox.Show("Guardado", Text);
                CargarConsorcistas_755ME();
                LimpiarDetalleConsorcista_755ME();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void btnInactivarConsorcista_Click(object sender, EventArgs e)
        {
            if (_consorcistaSeleccionado == null) return;
            try
            {
                _consorcistaBLL.InactivarConsorcista_755ME(_consorcistaSeleccionado.IdConsorcista_755ME);
                CargarConsorcistas_755ME();
                LimpiarDetalleConsorcista_755ME();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void btnReactivarConsorcista_Click(object sender, EventArgs e)
        {
            if (_consorcistaSeleccionado == null) return;
            _consorcistaBLL.ReactivarConsorcista_755ME(_consorcistaSeleccionado.IdConsorcista_755ME);
            CargarConsorcistas_755ME();
            LimpiarDetalleConsorcista_755ME();
        }

        // ---------- Propietario de unidad funcional ----------

        private void CargarComboUnidadesPropietario_755ME()
        {
            Dictionary<int, string> nombresConsorcio = _consorcioBLL.ObtenerTodosLosConsorcios_755ME().ToDictionary(c => c.IdConsorcio_755ME, c => c.Nombre_755ME);
            List<OpcionUnidadPropietario_755ME> opciones = _ufBLL.ObtenerTodasLasUnidades_755ME()
                .Select(u => new OpcionUnidadPropietario_755ME
                {
                    Unidad = u,
                    Texto = (nombresConsorcio.TryGetValue(u.IdConsorcio_755ME, out string? nombre) ? nombre : u.IdConsorcio_755ME.ToString()) + " - " + u.Numero_755ME
                })
                .ToList();
            cboUnidadPropietario.DataSource = opciones;
        }

        private void CargarUnidadesDelConsorcista_755ME()
        {
            dgvUnidadesPropietario.Rows.Clear();
            btnQuitarPropietario.Enabled = false;
            if (_consorcistaSeleccionado == null) return;
            foreach (UnidadFuncionalBE_755ME uf in _ufBLL.ObtenerUnidadesDelPropietario_755ME(_consorcistaSeleccionado.IdConsorcista_755ME))
            {
                int fila = dgvUnidadesPropietario.Rows.Add(uf.Numero_755ME);
                dgvUnidadesPropietario.Rows[fila].Tag = uf;
            }
            // con una sola unidad la fila ya queda seleccionada y no dispara el evento, se reevalua el boton aca
            ActualizarBotonQuitarPropietario_755ME();
        }

        private void dgvUnidadesPropietario_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonQuitarPropietario_755ME();
        }

        private void ActualizarBotonQuitarPropietario_755ME()
        {
            btnQuitarPropietario.Enabled = dgvUnidadesPropietario.SelectedRows.Count > 0 && dgvUnidadesPropietario.SelectedRows[0].Tag != null;
        }

        private void btnAsignarPropietario_Click(object sender, EventArgs e)
        {
            if (_consorcistaSeleccionado == null || cboUnidadPropietario.SelectedItem is not OpcionUnidadPropietario_755ME opcion) return;
            try
            {
                _unidadConsorcistaBLL.AsignarPropietario_755ME(opcion.Unidad.IdUnidadFuncional_755ME, _consorcistaSeleccionado.IdConsorcista_755ME);
                CargarUnidadesDelConsorcista_755ME();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void btnQuitarPropietario_Click(object sender, EventArgs e)
        {
            if (_consorcistaSeleccionado == null || dgvUnidadesPropietario.SelectedRows.Count == 0
                || dgvUnidadesPropietario.SelectedRows[0].Tag is not UnidadFuncionalBE_755ME unidad) return;
            try
            {
                _unidadConsorcistaBLL.QuitarPropietario_755ME(unidad.IdUnidadFuncional_755ME, _consorcistaSeleccionado.IdConsorcista_755ME);
                CargarUnidadesDelConsorcista_755ME();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        // ---------- Proveedores ----------

        private void CargarProveedores_755ME()
        {
            dgvProveedores.Rows.Clear();
            foreach (ProveedorBE_755ME p in _proveedorBLL.ObtenerTodos_755ME())
            {
                int fila = dgvProveedores.Rows.Add(p.Nombre_755ME, p.Habilitado_755ME ? "Si" : "No");
                dgvProveedores.Rows[fila].Tag = p;
            }
            // Rows.Add selecciona la fila antes de que tenga Tag, se reevalua aca
            dgvProveedores_SelectionChanged(dgvProveedores, EventArgs.Empty);
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            // solo cuenta la fila que elige el usuario, no la que la grilla selecciona sola al cargar
            if (!dgvProveedores.Focused || dgvProveedores.SelectedRows.Count == 0 || dgvProveedores.SelectedRows[0].Tag == null)
            {
                LimpiarDetalleProveedor_755ME();
                return;
            }
            _proveedorSeleccionado = (ProveedorBE_755ME)dgvProveedores.SelectedRows[0].Tag!;
            txtNombreProveedor.Text = _proveedorSeleccionado.Nombre_755ME;
            btnInhabilitarProveedor.Enabled = _proveedorSeleccionado.Habilitado_755ME;
            btnHabilitarProveedor.Enabled = !_proveedorSeleccionado.Habilitado_755ME;
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            dgvProveedores.ClearSelection();
            LimpiarDetalleProveedor_755ME();
        }

        private void LimpiarDetalleProveedor_755ME()
        {
            _proveedorSeleccionado = null;
            txtNombreProveedor.Clear();
            btnInhabilitarProveedor.Enabled = false;
            btnHabilitarProveedor.Enabled = false;
        }

        private void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                ProveedorBE_755ME proveedor = _proveedorSeleccionado ?? new ProveedorBE_755ME();
                proveedor.Nombre_755ME = txtNombreProveedor.Text;
                _proveedorBLL.GuardarProveedor_755ME(proveedor);
                MessageBox.Show("Guardado", Text);
                CargarProveedores_755ME();
                LimpiarDetalleProveedor_755ME();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void btnInhabilitarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedorSeleccionado == null) return;
            _proveedorBLL.InhabilitarProveedor_755ME(_proveedorSeleccionado.IdProveedor_755ME);
            CargarProveedores_755ME();
            LimpiarDetalleProveedor_755ME();
        }

        private void btnHabilitarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedorSeleccionado == null) return;
            _proveedorBLL.HabilitarProveedor_755ME(_proveedorSeleccionado.IdProveedor_755ME);
            CargarProveedores_755ME();
            LimpiarDetalleProveedor_755ME();
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
        }

        private void FormMantenimientoConsorcios_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

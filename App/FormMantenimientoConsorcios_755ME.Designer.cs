namespace AppBase
{
    partial class FormMantenimientoConsorcios_755ME
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabMaestros = new System.Windows.Forms.TabControl();
            tabConsorcios = new System.Windows.Forms.TabPage();
            dgvConsorcios = new System.Windows.Forms.DataGridView();
            colCNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCGestor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpConsorcio = new System.Windows.Forms.GroupBox();
            btnReactivarConsorcio = new System.Windows.Forms.Button();
            btnInactivarConsorcio = new System.Windows.Forms.Button();
            btnGuardarConsorcio = new System.Windows.Forms.Button();
            btnNuevoConsorcio = new System.Windows.Forms.Button();
            cboGestor = new System.Windows.Forms.ComboBox();
            lblGestor = new System.Windows.Forms.Label();
            numCantidadUnidades = new System.Windows.Forms.NumericUpDown();
            lblCantidadUnidades = new System.Windows.Forms.Label();
            txtDireccion = new System.Windows.Forms.TextBox();
            lblDireccion = new System.Windows.Forms.Label();
            txtNombre = new System.Windows.Forms.TextBox();
            lblNombre = new System.Windows.Forms.Label();
            tabUnidades = new System.Windows.Forms.TabPage();
            lblConsorcioUnidad = new System.Windows.Forms.Label();
            cboConsorcioUnidad = new System.Windows.Forms.ComboBox();
            dgvUnidades = new System.Windows.Forms.DataGridView();
            colUNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colUTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colUCoeficiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colUActiva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpUnidad = new System.Windows.Forms.GroupBox();
            btnReactivarUnidad = new System.Windows.Forms.Button();
            btnVerHistorialUnidad = new System.Windows.Forms.Button();
            btnInactivarUnidad = new System.Windows.Forms.Button();
            btnGuardarUnidad = new System.Windows.Forms.Button();
            btnNuevaUnidad = new System.Windows.Forms.Button();
            numCoeficiente = new System.Windows.Forms.NumericUpDown();
            lblCoeficiente = new System.Windows.Forms.Label();
            txtTipo = new System.Windows.Forms.TextBox();
            lblTipo = new System.Windows.Forms.Label();
            txtNumero = new System.Windows.Forms.TextBox();
            lblNumero = new System.Windows.Forms.Label();
            tabConsorcistas = new System.Windows.Forms.TabPage();
            tabProveedores = new System.Windows.Forms.TabPage();
            dgvProveedores = new System.Windows.Forms.DataGridView();
            colPrNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPrHabilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpProveedor = new System.Windows.Forms.GroupBox();
            lblNombreProveedor = new System.Windows.Forms.Label();
            txtNombreProveedor = new System.Windows.Forms.TextBox();
            btnNuevoProveedor = new System.Windows.Forms.Button();
            btnGuardarProveedor = new System.Windows.Forms.Button();
            btnInhabilitarProveedor = new System.Windows.Forms.Button();
            btnHabilitarProveedor = new System.Windows.Forms.Button();
            dgvConsorcistas = new System.Windows.Forms.DataGridView();
            colCoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCoApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCoDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCoActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpConsorcista = new System.Windows.Forms.GroupBox();
            btnReactivarConsorcista = new System.Windows.Forms.Button();
            btnInactivarConsorcista = new System.Windows.Forms.Button();
            btnGuardarConsorcista = new System.Windows.Forms.Button();
            btnNuevoConsorcista = new System.Windows.Forms.Button();
            txtDniConsorcista = new System.Windows.Forms.TextBox();
            lblDniConsorcista = new System.Windows.Forms.Label();
            txtApellidoConsorcista = new System.Windows.Forms.TextBox();
            lblApellidoConsorcista = new System.Windows.Forms.Label();
            txtNombreConsorcista = new System.Windows.Forms.TextBox();
            lblNombreConsorcista = new System.Windows.Forms.Label();
            grpPropietario = new System.Windows.Forms.GroupBox();
            btnQuitarPropietario = new System.Windows.Forms.Button();
            dgvUnidadesPropietario = new System.Windows.Forms.DataGridView();
            colPropietarioUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnAsignarPropietario = new System.Windows.Forms.Button();
            cboUnidadPropietario = new System.Windows.Forms.ComboBox();
            lblUnidadPropietario = new System.Windows.Forms.Label();
            tabMaestros.SuspendLayout();
            tabConsorcios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsorcios).BeginInit();
            grpConsorcio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadUnidades).BeginInit();
            tabUnidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnidades).BeginInit();
            grpUnidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCoeficiente).BeginInit();
            tabConsorcistas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsorcistas).BeginInit();
            grpConsorcista.SuspendLayout();
            grpPropietario.SuspendLayout();
            tabProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            grpProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnidadesPropietario).BeginInit();
            SuspendLayout();
            //
            // tabMaestros
            //
            tabMaestros.Controls.Add(tabConsorcios);
            tabMaestros.Controls.Add(tabUnidades);
            tabMaestros.Controls.Add(tabConsorcistas);
            tabMaestros.Controls.Add(tabProveedores);
            tabMaestros.Dock = System.Windows.Forms.DockStyle.Fill;
            tabMaestros.Location = new System.Drawing.Point(0, 0);
            tabMaestros.Name = "tabMaestros";
            tabMaestros.SelectedIndex = 0;
            tabMaestros.Size = new System.Drawing.Size(1120, 740);
            tabMaestros.TabIndex = 0;
            //
            // tabConsorcios
            //
            tabConsorcios.Controls.Add(grpConsorcio);
            tabConsorcios.Controls.Add(dgvConsorcios);
            tabConsorcios.Location = new System.Drawing.Point(4, 24);
            tabConsorcios.Name = "tabConsorcios";
            tabConsorcios.Padding = new System.Windows.Forms.Padding(10);
            tabConsorcios.Size = new System.Drawing.Size(1112, 712);
            tabConsorcios.TabIndex = 0;
            tabConsorcios.Text = "Consorcios";
            tabConsorcios.Tag = "lb_tab_consorcios";
            //
            // dgvConsorcios
            //
            dgvConsorcios.AllowUserToAddRows = false;
            dgvConsorcios.AllowUserToDeleteRows = false;
            dgvConsorcios.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvConsorcios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colCNombre, colCDireccion, colCCantidad, colCActivo, colCGestor });
            dgvConsorcios.Location = new System.Drawing.Point(13, 13);
            dgvConsorcios.MultiSelect = false;
            dgvConsorcios.Name = "dgvConsorcios";
            dgvConsorcios.ReadOnly = true;
            dgvConsorcios.RowHeadersVisible = false;
            dgvConsorcios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvConsorcios.Size = new System.Drawing.Size(700, 686);
            dgvConsorcios.TabIndex = 0;
            dgvConsorcios.SelectionChanged += dgvConsorcios_SelectionChanged;
            //
            // colCNombre
            //
            colCNombre.HeaderText = "Nombre";
            colCNombre.Tag = "lb_col_nombre";
            colCNombre.Name = "colCNombre";
            colCNombre.ReadOnly = true;
            //
            // colCDireccion
            //
            colCDireccion.HeaderText = "Direccion";
            colCDireccion.Tag = "lb_col_direccion";
            colCDireccion.Name = "colCDireccion";
            colCDireccion.ReadOnly = true;
            //
            // colCCantidad
            //
            colCCantidad.HeaderText = "Cant. unidades";
            colCCantidad.Tag = "lb_col_cant_unidades";
            colCCantidad.Name = "colCCantidad";
            colCCantidad.ReadOnly = true;
            //
            // colCActivo
            //
            colCActivo.HeaderText = "Activo";
            colCActivo.Tag = "lb_col_activo";
            colCActivo.Name = "colCActivo";
            colCActivo.ReadOnly = true;
            //
            // colCGestor
            //
            colCGestor.HeaderText = "Gestor";
            colCGestor.Tag = "lb_col_gestor";
            colCGestor.Name = "colCGestor";
            colCGestor.ReadOnly = true;
            //
            // grpConsorcio
            //
            grpConsorcio.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            grpConsorcio.Controls.Add(btnReactivarConsorcio);
            grpConsorcio.Controls.Add(btnInactivarConsorcio);
            grpConsorcio.Controls.Add(btnGuardarConsorcio);
            grpConsorcio.Controls.Add(btnNuevoConsorcio);
            grpConsorcio.Controls.Add(cboGestor);
            grpConsorcio.Controls.Add(lblGestor);
            grpConsorcio.Controls.Add(numCantidadUnidades);
            grpConsorcio.Controls.Add(lblCantidadUnidades);
            grpConsorcio.Controls.Add(txtDireccion);
            grpConsorcio.Controls.Add(lblDireccion);
            grpConsorcio.Controls.Add(txtNombre);
            grpConsorcio.Controls.Add(lblNombre);
            grpConsorcio.Location = new System.Drawing.Point(725, 13);
            grpConsorcio.Name = "grpConsorcio";
            grpConsorcio.Size = new System.Drawing.Size(370, 320);
            grpConsorcio.TabIndex = 1;
            grpConsorcio.TabStop = false;
            grpConsorcio.Text = "Consorcio";
            grpConsorcio.Tag = "lb_grp_consorcio";
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new System.Drawing.Point(15, 28);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(58, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            lblNombre.Tag = "lb_nombre";
            //
            // txtNombre
            //
            txtNombre.Location = new System.Drawing.Point(120, 25);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(230, 23);
            txtNombre.TabIndex = 1;
            //
            // lblDireccion
            //
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new System.Drawing.Point(15, 58);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new System.Drawing.Size(65, 15);
            lblDireccion.TabIndex = 2;
            lblDireccion.Text = "Direccion:";
            lblDireccion.Tag = "lb_direccion";
            //
            // txtDireccion
            //
            txtDireccion.Location = new System.Drawing.Point(120, 55);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new System.Drawing.Size(230, 23);
            txtDireccion.TabIndex = 3;
            //
            // lblCantidadUnidades
            //
            lblCantidadUnidades.AutoSize = true;
            lblCantidadUnidades.Location = new System.Drawing.Point(15, 88);
            lblCantidadUnidades.Name = "lblCantidadUnidades";
            lblCantidadUnidades.Size = new System.Drawing.Size(105, 15);
            lblCantidadUnidades.TabIndex = 4;
            lblCantidadUnidades.Text = "Cant. de unidades:";
            lblCantidadUnidades.Tag = "lb_cant_unidades";
            //
            // numCantidadUnidades
            //
            numCantidadUnidades.Location = new System.Drawing.Point(150, 86);
            numCantidadUnidades.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numCantidadUnidades.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidadUnidades.Name = "numCantidadUnidades";
            numCantidadUnidades.Size = new System.Drawing.Size(100, 23);
            numCantidadUnidades.TabIndex = 5;
            numCantidadUnidades.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // lblGestor
            //
            lblGestor.AutoSize = true;
            lblGestor.Location = new System.Drawing.Point(15, 118);
            lblGestor.Name = "lblGestor";
            lblGestor.Size = new System.Drawing.Size(46, 15);
            lblGestor.TabIndex = 6;
            lblGestor.Text = "Gestor:";
            lblGestor.Tag = "lb_gestor";
            //
            // cboGestor
            //
            cboGestor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboGestor.FormattingEnabled = true;
            cboGestor.Location = new System.Drawing.Point(120, 115);
            cboGestor.Name = "cboGestor";
            cboGestor.Size = new System.Drawing.Size(230, 23);
            cboGestor.TabIndex = 7;
            //
            // btnNuevoConsorcio
            //
            btnNuevoConsorcio.Location = new System.Drawing.Point(15, 155);
            btnNuevoConsorcio.Name = "btnNuevoConsorcio";
            btnNuevoConsorcio.Size = new System.Drawing.Size(90, 28);
            btnNuevoConsorcio.TabIndex = 8;
            btnNuevoConsorcio.Text = "Nuevo";
            btnNuevoConsorcio.Tag = "btn_nuevo";
            btnNuevoConsorcio.Click += btnNuevoConsorcio_Click;
            //
            // btnGuardarConsorcio
            //
            btnGuardarConsorcio.Location = new System.Drawing.Point(115, 155);
            btnGuardarConsorcio.Name = "btnGuardarConsorcio";
            btnGuardarConsorcio.Size = new System.Drawing.Size(90, 28);
            btnGuardarConsorcio.TabIndex = 9;
            btnGuardarConsorcio.Text = "Guardar";
            btnGuardarConsorcio.Tag = "btn_guardar";
            btnGuardarConsorcio.Click += btnGuardarConsorcio_Click;
            //
            // btnInactivarConsorcio
            //
            btnInactivarConsorcio.Enabled = false;
            btnInactivarConsorcio.Location = new System.Drawing.Point(15, 195);
            btnInactivarConsorcio.Name = "btnInactivarConsorcio";
            btnInactivarConsorcio.Size = new System.Drawing.Size(90, 28);
            btnInactivarConsorcio.TabIndex = 10;
            btnInactivarConsorcio.Text = "Inactivar";
            btnInactivarConsorcio.Tag = "btn_inactivar";
            btnInactivarConsorcio.Click += btnInactivarConsorcio_Click;
            //
            // btnReactivarConsorcio
            //
            btnReactivarConsorcio.Enabled = false;
            btnReactivarConsorcio.Location = new System.Drawing.Point(115, 195);
            btnReactivarConsorcio.Name = "btnReactivarConsorcio";
            btnReactivarConsorcio.Size = new System.Drawing.Size(90, 28);
            btnReactivarConsorcio.TabIndex = 11;
            btnReactivarConsorcio.Text = "Reactivar";
            btnReactivarConsorcio.Tag = "btn_reactivar";
            btnReactivarConsorcio.Click += btnReactivarConsorcio_Click;
            //
            // tabUnidades
            //
            tabUnidades.Controls.Add(grpUnidad);
            tabUnidades.Controls.Add(dgvUnidades);
            tabUnidades.Controls.Add(cboConsorcioUnidad);
            tabUnidades.Controls.Add(lblConsorcioUnidad);
            tabUnidades.Location = new System.Drawing.Point(4, 24);
            tabUnidades.Name = "tabUnidades";
            tabUnidades.Padding = new System.Windows.Forms.Padding(10);
            tabUnidades.Size = new System.Drawing.Size(1112, 712);
            tabUnidades.TabIndex = 1;
            tabUnidades.Text = "Unidades Funcionales";
            tabUnidades.Tag = "lb_tab_unidades";
            //
            // lblConsorcioUnidad
            //
            lblConsorcioUnidad.AutoSize = true;
            lblConsorcioUnidad.Location = new System.Drawing.Point(13, 15);
            lblConsorcioUnidad.Name = "lblConsorcioUnidad";
            lblConsorcioUnidad.Size = new System.Drawing.Size(63, 15);
            lblConsorcioUnidad.TabIndex = 0;
            lblConsorcioUnidad.Text = "Consorcio:";
            lblConsorcioUnidad.Tag = "lb_consorcio";
            //
            // cboConsorcioUnidad
            //
            cboConsorcioUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboConsorcioUnidad.FormattingEnabled = true;
            cboConsorcioUnidad.Location = new System.Drawing.Point(110, 12);
            cboConsorcioUnidad.Name = "cboConsorcioUnidad";
            cboConsorcioUnidad.Size = new System.Drawing.Size(300, 23);
            cboConsorcioUnidad.TabIndex = 1;
            cboConsorcioUnidad.SelectedIndexChanged += cboConsorcioUnidad_SelectedIndexChanged;
            //
            // dgvUnidades
            //
            dgvUnidades.AllowUserToAddRows = false;
            dgvUnidades.AllowUserToDeleteRows = false;
            dgvUnidades.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvUnidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colUNumero, colUTipo, colUCoeficiente, colUActiva });
            dgvUnidades.Location = new System.Drawing.Point(13, 45);
            dgvUnidades.MultiSelect = false;
            dgvUnidades.Name = "dgvUnidades";
            dgvUnidades.ReadOnly = true;
            dgvUnidades.RowHeadersVisible = false;
            dgvUnidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvUnidades.Size = new System.Drawing.Size(700, 654);
            dgvUnidades.TabIndex = 2;
            dgvUnidades.SelectionChanged += dgvUnidades_SelectionChanged;
            //
            // colUNumero
            //
            colUNumero.HeaderText = "Numero";
            colUNumero.Tag = "lb_col_numero";
            colUNumero.Name = "colUNumero";
            colUNumero.ReadOnly = true;
            //
            // colUTipo
            //
            colUTipo.HeaderText = "Tipo";
            colUTipo.Tag = "lb_col_tipo";
            colUTipo.Name = "colUTipo";
            colUTipo.ReadOnly = true;
            //
            // colUCoeficiente
            //
            colUCoeficiente.HeaderText = "Coeficiente";
            colUCoeficiente.Tag = "lb_col_coeficiente";
            colUCoeficiente.Name = "colUCoeficiente";
            colUCoeficiente.ReadOnly = true;
            //
            // colUActiva
            //
            colUActiva.HeaderText = "Activa";
            colUActiva.Tag = "lb_col_activa";
            colUActiva.Name = "colUActiva";
            colUActiva.ReadOnly = true;
            //
            // grpUnidad
            //
            grpUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            grpUnidad.Controls.Add(btnVerHistorialUnidad);
            grpUnidad.Controls.Add(btnReactivarUnidad);
            grpUnidad.Controls.Add(btnInactivarUnidad);
            grpUnidad.Controls.Add(btnGuardarUnidad);
            grpUnidad.Controls.Add(btnNuevaUnidad);
            grpUnidad.Controls.Add(numCoeficiente);
            grpUnidad.Controls.Add(lblCoeficiente);
            grpUnidad.Controls.Add(txtTipo);
            grpUnidad.Controls.Add(lblTipo);
            grpUnidad.Controls.Add(txtNumero);
            grpUnidad.Controls.Add(lblNumero);
            grpUnidad.Location = new System.Drawing.Point(725, 45);
            grpUnidad.Name = "grpUnidad";
            grpUnidad.Size = new System.Drawing.Size(370, 280);
            grpUnidad.TabIndex = 3;
            grpUnidad.TabStop = false;
            grpUnidad.Text = "Unidad funcional";
            grpUnidad.Tag = "lb_unidad_funcional";
            //
            // lblNumero
            //
            lblNumero.AutoSize = true;
            lblNumero.Location = new System.Drawing.Point(15, 28);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new System.Drawing.Size(53, 15);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "Numero:";
            lblNumero.Tag = "lb_numero";
            //
            // txtNumero
            //
            txtNumero.Location = new System.Drawing.Point(120, 25);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new System.Drawing.Size(230, 23);
            txtNumero.TabIndex = 1;
            //
            // lblTipo
            //
            lblTipo.AutoSize = true;
            lblTipo.Location = new System.Drawing.Point(15, 58);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new System.Drawing.Size(33, 15);
            lblTipo.TabIndex = 2;
            lblTipo.Text = "Tipo:";
            lblTipo.Tag = "lb_tipo";
            //
            // txtTipo
            //
            txtTipo.Location = new System.Drawing.Point(120, 55);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new System.Drawing.Size(230, 23);
            txtTipo.TabIndex = 3;
            //
            // lblCoeficiente
            //
            lblCoeficiente.AutoSize = true;
            lblCoeficiente.Location = new System.Drawing.Point(15, 88);
            lblCoeficiente.Name = "lblCoeficiente";
            lblCoeficiente.Size = new System.Drawing.Size(72, 15);
            lblCoeficiente.TabIndex = 4;
            lblCoeficiente.Text = "Coeficiente:";
            lblCoeficiente.Tag = "lb_coeficiente";
            //
            // numCoeficiente
            //
            numCoeficiente.DecimalPlaces = 4;
            numCoeficiente.Increment = new decimal(new int[] { 1, 0, 0, 262144 });
            numCoeficiente.Location = new System.Drawing.Point(120, 86);
            numCoeficiente.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numCoeficiente.Name = "numCoeficiente";
            numCoeficiente.Size = new System.Drawing.Size(120, 23);
            numCoeficiente.TabIndex = 5;
            //
            // btnNuevaUnidad
            //
            btnNuevaUnidad.Location = new System.Drawing.Point(15, 125);
            btnNuevaUnidad.Name = "btnNuevaUnidad";
            btnNuevaUnidad.Size = new System.Drawing.Size(90, 28);
            btnNuevaUnidad.TabIndex = 6;
            btnNuevaUnidad.Text = "Nueva";
            btnNuevaUnidad.Tag = "btn_nueva";
            btnNuevaUnidad.Click += btnNuevaUnidad_Click;
            //
            // btnGuardarUnidad
            //
            btnGuardarUnidad.Location = new System.Drawing.Point(115, 125);
            btnGuardarUnidad.Name = "btnGuardarUnidad";
            btnGuardarUnidad.Size = new System.Drawing.Size(90, 28);
            btnGuardarUnidad.TabIndex = 7;
            btnGuardarUnidad.Text = "Guardar";
            btnGuardarUnidad.Tag = "btn_guardar";
            btnGuardarUnidad.Click += btnGuardarUnidad_Click;
            //
            // btnInactivarUnidad
            //
            btnInactivarUnidad.Enabled = false;
            btnInactivarUnidad.Location = new System.Drawing.Point(15, 165);
            btnInactivarUnidad.Name = "btnInactivarUnidad";
            btnInactivarUnidad.Size = new System.Drawing.Size(90, 28);
            btnInactivarUnidad.TabIndex = 8;
            btnInactivarUnidad.Text = "Inactivar";
            btnInactivarUnidad.Tag = "btn_inactivar";
            btnInactivarUnidad.Click += btnInactivarUnidad_Click;
            //
            // btnReactivarUnidad
            //
            btnReactivarUnidad.Enabled = false;
            btnReactivarUnidad.Location = new System.Drawing.Point(115, 165);
            btnReactivarUnidad.Name = "btnReactivarUnidad";
            btnReactivarUnidad.Size = new System.Drawing.Size(90, 28);
            btnReactivarUnidad.TabIndex = 9;
            btnReactivarUnidad.Text = "Reactivar";
            btnReactivarUnidad.Tag = "btn_reactivar";
            btnReactivarUnidad.Click += btnReactivarUnidad_Click;
            //
            // btnVerHistorialUnidad
            //
            btnVerHistorialUnidad.Enabled = false;
            btnVerHistorialUnidad.Location = new System.Drawing.Point(15, 205);
            btnVerHistorialUnidad.Name = "btnVerHistorialUnidad";
            btnVerHistorialUnidad.Size = new System.Drawing.Size(190, 28);
            btnVerHistorialUnidad.TabIndex = 10;
            btnVerHistorialUnidad.Text = "Ver historial";
            btnVerHistorialUnidad.Click += btnVerHistorialUnidad_Click;
            //
            // tabConsorcistas
            //
            tabConsorcistas.Controls.Add(grpPropietario);
            tabConsorcistas.Controls.Add(grpConsorcista);
            tabConsorcistas.Controls.Add(dgvConsorcistas);
            tabConsorcistas.Location = new System.Drawing.Point(4, 24);
            tabConsorcistas.Name = "tabConsorcistas";
            tabConsorcistas.Padding = new System.Windows.Forms.Padding(10);
            tabConsorcistas.Size = new System.Drawing.Size(1112, 712);
            tabConsorcistas.TabIndex = 2;
            tabConsorcistas.Text = "Consorcistas";
            tabConsorcistas.Tag = "lb_tab_consorcistas";
            //
            // dgvConsorcistas
            //
            dgvConsorcistas.AllowUserToAddRows = false;
            dgvConsorcistas.AllowUserToDeleteRows = false;
            dgvConsorcistas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvConsorcistas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colCoNombre, colCoApellido, colCoDni, colCoActivo });
            dgvConsorcistas.Location = new System.Drawing.Point(13, 13);
            dgvConsorcistas.MultiSelect = false;
            dgvConsorcistas.Name = "dgvConsorcistas";
            dgvConsorcistas.ReadOnly = true;
            dgvConsorcistas.RowHeadersVisible = false;
            dgvConsorcistas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvConsorcistas.Size = new System.Drawing.Size(700, 686);
            dgvConsorcistas.TabIndex = 0;
            dgvConsorcistas.SelectionChanged += dgvConsorcistas_SelectionChanged;
            //
            // colCoNombre
            //
            colCoNombre.HeaderText = "Nombre";
            colCoNombre.Tag = "lb_col_nombre";
            colCoNombre.Name = "colCoNombre";
            colCoNombre.ReadOnly = true;
            //
            // colCoApellido
            //
            colCoApellido.HeaderText = "Apellido";
            colCoApellido.Tag = "lb_col_apellido";
            colCoApellido.Name = "colCoApellido";
            colCoApellido.ReadOnly = true;
            //
            // colCoDni
            //
            colCoDni.HeaderText = "DNI";
            colCoDni.Tag = "lb_col_dni";
            colCoDni.Name = "colCoDni";
            colCoDni.ReadOnly = true;
            //
            // colCoActivo
            //
            colCoActivo.HeaderText = "Activo";
            colCoActivo.Tag = "lb_col_activo";
            colCoActivo.Name = "colCoActivo";
            colCoActivo.ReadOnly = true;
            //
            // grpConsorcista
            //
            grpConsorcista.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            grpConsorcista.Controls.Add(btnReactivarConsorcista);
            grpConsorcista.Controls.Add(btnInactivarConsorcista);
            grpConsorcista.Controls.Add(btnGuardarConsorcista);
            grpConsorcista.Controls.Add(btnNuevoConsorcista);
            grpConsorcista.Controls.Add(txtDniConsorcista);
            grpConsorcista.Controls.Add(lblDniConsorcista);
            grpConsorcista.Controls.Add(txtApellidoConsorcista);
            grpConsorcista.Controls.Add(lblApellidoConsorcista);
            grpConsorcista.Controls.Add(txtNombreConsorcista);
            grpConsorcista.Controls.Add(lblNombreConsorcista);
            grpConsorcista.Location = new System.Drawing.Point(725, 13);
            grpConsorcista.Name = "grpConsorcista";
            grpConsorcista.Size = new System.Drawing.Size(370, 280);
            grpConsorcista.TabIndex = 1;
            grpConsorcista.TabStop = false;
            grpConsorcista.Text = "Consorcista";
            grpConsorcista.Tag = "lb_grp_consorcista";
            //
            // lblNombreConsorcista
            //
            lblNombreConsorcista.AutoSize = true;
            lblNombreConsorcista.Location = new System.Drawing.Point(15, 28);
            lblNombreConsorcista.Name = "lblNombreConsorcista";
            lblNombreConsorcista.Size = new System.Drawing.Size(58, 15);
            lblNombreConsorcista.TabIndex = 0;
            lblNombreConsorcista.Text = "Nombre:";
            lblNombreConsorcista.Tag = "lb_nombre";
            //
            // txtNombreConsorcista
            //
            txtNombreConsorcista.Location = new System.Drawing.Point(120, 25);
            txtNombreConsorcista.Name = "txtNombreConsorcista";
            txtNombreConsorcista.Size = new System.Drawing.Size(230, 23);
            txtNombreConsorcista.TabIndex = 1;
            //
            // lblApellidoConsorcista
            //
            lblApellidoConsorcista.AutoSize = true;
            lblApellidoConsorcista.Location = new System.Drawing.Point(15, 58);
            lblApellidoConsorcista.Name = "lblApellidoConsorcista";
            lblApellidoConsorcista.Size = new System.Drawing.Size(55, 15);
            lblApellidoConsorcista.TabIndex = 2;
            lblApellidoConsorcista.Text = "Apellido:";
            lblApellidoConsorcista.Tag = "lb_apellido";
            //
            // txtApellidoConsorcista
            //
            txtApellidoConsorcista.Location = new System.Drawing.Point(120, 55);
            txtApellidoConsorcista.Name = "txtApellidoConsorcista";
            txtApellidoConsorcista.Size = new System.Drawing.Size(230, 23);
            txtApellidoConsorcista.TabIndex = 3;
            //
            // lblDniConsorcista
            //
            lblDniConsorcista.AutoSize = true;
            lblDniConsorcista.Location = new System.Drawing.Point(15, 88);
            lblDniConsorcista.Name = "lblDniConsorcista";
            lblDniConsorcista.Size = new System.Drawing.Size(31, 15);
            lblDniConsorcista.TabIndex = 4;
            lblDniConsorcista.Text = "DNI:";
            lblDniConsorcista.Tag = "lb_dni";
            //
            // txtDniConsorcista
            //
            txtDniConsorcista.Location = new System.Drawing.Point(120, 85);
            txtDniConsorcista.Name = "txtDniConsorcista";
            txtDniConsorcista.Size = new System.Drawing.Size(120, 23);
            txtDniConsorcista.TabIndex = 5;
            //
            // btnNuevoConsorcista
            //
            btnNuevoConsorcista.Location = new System.Drawing.Point(15, 125);
            btnNuevoConsorcista.Name = "btnNuevoConsorcista";
            btnNuevoConsorcista.Size = new System.Drawing.Size(90, 28);
            btnNuevoConsorcista.TabIndex = 6;
            btnNuevoConsorcista.Text = "Nuevo";
            btnNuevoConsorcista.Tag = "btn_nuevo";
            btnNuevoConsorcista.Click += btnNuevoConsorcista_Click;
            //
            // btnGuardarConsorcista
            //
            btnGuardarConsorcista.Location = new System.Drawing.Point(115, 125);
            btnGuardarConsorcista.Name = "btnGuardarConsorcista";
            btnGuardarConsorcista.Size = new System.Drawing.Size(90, 28);
            btnGuardarConsorcista.TabIndex = 7;
            btnGuardarConsorcista.Text = "Guardar";
            btnGuardarConsorcista.Tag = "btn_guardar";
            btnGuardarConsorcista.Click += btnGuardarConsorcista_Click;
            //
            // btnInactivarConsorcista
            //
            btnInactivarConsorcista.Enabled = false;
            btnInactivarConsorcista.Location = new System.Drawing.Point(15, 165);
            btnInactivarConsorcista.Name = "btnInactivarConsorcista";
            btnInactivarConsorcista.Size = new System.Drawing.Size(90, 28);
            btnInactivarConsorcista.TabIndex = 8;
            btnInactivarConsorcista.Text = "Inactivar";
            btnInactivarConsorcista.Tag = "btn_inactivar";
            btnInactivarConsorcista.Click += btnInactivarConsorcista_Click;
            //
            // btnReactivarConsorcista
            //
            btnReactivarConsorcista.Enabled = false;
            btnReactivarConsorcista.Location = new System.Drawing.Point(115, 165);
            btnReactivarConsorcista.Name = "btnReactivarConsorcista";
            btnReactivarConsorcista.Size = new System.Drawing.Size(90, 28);
            btnReactivarConsorcista.TabIndex = 9;
            btnReactivarConsorcista.Text = "Reactivar";
            btnReactivarConsorcista.Tag = "btn_reactivar";
            btnReactivarConsorcista.Click += btnReactivarConsorcista_Click;
            //
            // grpPropietario
            //
            grpPropietario.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            grpPropietario.Controls.Add(btnQuitarPropietario);
            grpPropietario.Controls.Add(dgvUnidadesPropietario);
            grpPropietario.Controls.Add(btnAsignarPropietario);
            grpPropietario.Controls.Add(cboUnidadPropietario);
            grpPropietario.Controls.Add(lblUnidadPropietario);
            grpPropietario.Enabled = false;
            grpPropietario.Location = new System.Drawing.Point(725, 300);
            grpPropietario.Name = "grpPropietario";
            grpPropietario.Size = new System.Drawing.Size(370, 300);
            grpPropietario.TabIndex = 2;
            grpPropietario.TabStop = false;
            grpPropietario.Text = "Unidad funcional (propietario)";
            grpPropietario.Tag = "lb_grp_unidad_propietario";
            //
            // lblUnidadPropietario
            //
            lblUnidadPropietario.AutoSize = true;
            lblUnidadPropietario.Location = new System.Drawing.Point(15, 28);
            lblUnidadPropietario.Name = "lblUnidadPropietario";
            lblUnidadPropietario.Size = new System.Drawing.Size(85, 15);
            lblUnidadPropietario.TabIndex = 0;
            lblUnidadPropietario.Text = "Unidad funcional:";
            lblUnidadPropietario.Tag = "lb_unidad";
            //
            // cboUnidadPropietario
            //
            cboUnidadPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboUnidadPropietario.FormattingEnabled = true;
            cboUnidadPropietario.Location = new System.Drawing.Point(110, 25);
            cboUnidadPropietario.Name = "cboUnidadPropietario";
            cboUnidadPropietario.Size = new System.Drawing.Size(240, 23);
            cboUnidadPropietario.TabIndex = 1;
            //
            // btnAsignarPropietario
            //
            btnAsignarPropietario.Location = new System.Drawing.Point(15, 58);
            btnAsignarPropietario.Name = "btnAsignarPropietario";
            btnAsignarPropietario.Size = new System.Drawing.Size(150, 28);
            btnAsignarPropietario.TabIndex = 2;
            btnAsignarPropietario.Text = "Asignar como propietario";
            btnAsignarPropietario.Tag = "btn_asignar_propietario";
            btnAsignarPropietario.Click += btnAsignarPropietario_Click;
            //
            // dgvUnidadesPropietario
            //
            dgvUnidadesPropietario.AllowUserToAddRows = false;
            dgvUnidadesPropietario.AllowUserToDeleteRows = false;
            dgvUnidadesPropietario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colPropietarioUnidad });
            dgvUnidadesPropietario.Location = new System.Drawing.Point(15, 95);
            dgvUnidadesPropietario.MultiSelect = false;
            dgvUnidadesPropietario.Name = "dgvUnidadesPropietario";
            dgvUnidadesPropietario.ReadOnly = true;
            dgvUnidadesPropietario.RowHeadersVisible = false;
            dgvUnidadesPropietario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvUnidadesPropietario.Size = new System.Drawing.Size(340, 150);
            dgvUnidadesPropietario.TabIndex = 3;
            dgvUnidadesPropietario.SelectionChanged += dgvUnidadesPropietario_SelectionChanged;
            //
            // colPropietarioUnidad
            //
            colPropietarioUnidad.HeaderText = "Unidad funcional propia";
            colPropietarioUnidad.Tag = "lb_col_unidad_propia";
            colPropietarioUnidad.Name = "colPropietarioUnidad";
            colPropietarioUnidad.ReadOnly = true;
            //
            // btnQuitarPropietario
            //
            btnQuitarPropietario.Enabled = false;
            btnQuitarPropietario.Location = new System.Drawing.Point(15, 255);
            btnQuitarPropietario.Name = "btnQuitarPropietario";
            btnQuitarPropietario.Size = new System.Drawing.Size(150, 28);
            btnQuitarPropietario.TabIndex = 4;
            btnQuitarPropietario.Text = "Quitar propietario";
            btnQuitarPropietario.Tag = "btn_quitar_propietario";
            btnQuitarPropietario.Click += btnQuitarPropietario_Click;
            //
            // tabProveedores
            //
            tabProveedores.Controls.Add(grpProveedor);
            tabProveedores.Controls.Add(dgvProveedores);
            tabProveedores.Location = new System.Drawing.Point(4, 24);
            tabProveedores.Name = "tabProveedores";
            tabProveedores.Padding = new System.Windows.Forms.Padding(10);
            tabProveedores.Size = new System.Drawing.Size(1112, 712);
            tabProveedores.TabIndex = 3;
            tabProveedores.Text = "Proveedores";
            tabProveedores.Tag = "lb_tab_proveedores";
            //
            // dgvProveedores
            //
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AllowUserToDeleteRows = false;
            dgvProveedores.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colPrNombre, colPrHabilitado });
            dgvProveedores.Location = new System.Drawing.Point(13, 13);
            dgvProveedores.MultiSelect = false;
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.RowHeadersVisible = false;
            dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new System.Drawing.Size(700, 686);
            dgvProveedores.TabIndex = 0;
            dgvProveedores.SelectionChanged += dgvProveedores_SelectionChanged;
            //
            // colPrNombre
            //
            colPrNombre.FillWeight = 300F;
            colPrNombre.HeaderText = "Nombre";
            colPrNombre.Tag = "lb_col_nombre";
            colPrNombre.Name = "colPrNombre";
            colPrNombre.ReadOnly = true;
            //
            // colPrHabilitado
            //
            colPrHabilitado.HeaderText = "Habilitado";
            colPrHabilitado.Tag = "lb_col_habilitado";
            colPrHabilitado.Name = "colPrHabilitado";
            colPrHabilitado.ReadOnly = true;
            //
            // grpProveedor
            //
            grpProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            grpProveedor.Controls.Add(btnHabilitarProveedor);
            grpProveedor.Controls.Add(btnInhabilitarProveedor);
            grpProveedor.Controls.Add(btnGuardarProveedor);
            grpProveedor.Controls.Add(btnNuevoProveedor);
            grpProveedor.Controls.Add(txtNombreProveedor);
            grpProveedor.Controls.Add(lblNombreProveedor);
            grpProveedor.Location = new System.Drawing.Point(725, 13);
            grpProveedor.Name = "grpProveedor";
            grpProveedor.Size = new System.Drawing.Size(370, 160);
            grpProveedor.TabIndex = 1;
            grpProveedor.TabStop = false;
            grpProveedor.Text = "Proveedor";
            grpProveedor.Tag = "lb_grp_proveedor";
            //
            // lblNombreProveedor
            //
            lblNombreProveedor.AutoSize = true;
            lblNombreProveedor.Location = new System.Drawing.Point(15, 28);
            lblNombreProveedor.Name = "lblNombreProveedor";
            lblNombreProveedor.Size = new System.Drawing.Size(58, 15);
            lblNombreProveedor.TabIndex = 0;
            lblNombreProveedor.Text = "Nombre:";
            lblNombreProveedor.Tag = "lb_nombre";
            //
            // txtNombreProveedor
            //
            txtNombreProveedor.Location = new System.Drawing.Point(120, 25);
            txtNombreProveedor.MaxLength = 100;
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.Size = new System.Drawing.Size(230, 23);
            txtNombreProveedor.TabIndex = 1;
            //
            // btnNuevoProveedor
            //
            btnNuevoProveedor.Location = new System.Drawing.Point(15, 70);
            btnNuevoProveedor.Name = "btnNuevoProveedor";
            btnNuevoProveedor.Size = new System.Drawing.Size(90, 28);
            btnNuevoProveedor.TabIndex = 2;
            btnNuevoProveedor.Text = "Nuevo";
            btnNuevoProveedor.Tag = "btn_nuevo";
            btnNuevoProveedor.Click += btnNuevoProveedor_Click;
            //
            // btnGuardarProveedor
            //
            btnGuardarProveedor.Location = new System.Drawing.Point(115, 70);
            btnGuardarProveedor.Name = "btnGuardarProveedor";
            btnGuardarProveedor.Size = new System.Drawing.Size(90, 28);
            btnGuardarProveedor.TabIndex = 3;
            btnGuardarProveedor.Text = "Guardar";
            btnGuardarProveedor.Tag = "btn_guardar";
            btnGuardarProveedor.Click += btnGuardarProveedor_Click;
            //
            // btnInhabilitarProveedor
            //
            btnInhabilitarProveedor.Enabled = false;
            btnInhabilitarProveedor.Location = new System.Drawing.Point(15, 110);
            btnInhabilitarProveedor.Name = "btnInhabilitarProveedor";
            btnInhabilitarProveedor.Size = new System.Drawing.Size(90, 28);
            btnInhabilitarProveedor.TabIndex = 4;
            btnInhabilitarProveedor.Text = "Inhabilitar";
            btnInhabilitarProveedor.Tag = "btn_inhabilitar";
            btnInhabilitarProveedor.Click += btnInhabilitarProveedor_Click;
            //
            // btnHabilitarProveedor
            //
            btnHabilitarProveedor.Enabled = false;
            btnHabilitarProveedor.Location = new System.Drawing.Point(115, 110);
            btnHabilitarProveedor.Name = "btnHabilitarProveedor";
            btnHabilitarProveedor.Size = new System.Drawing.Size(90, 28);
            btnHabilitarProveedor.TabIndex = 5;
            btnHabilitarProveedor.Text = "Habilitar";
            btnHabilitarProveedor.Tag = "btn_habilitar";
            btnHabilitarProveedor.Click += btnHabilitarProveedor_Click;
            //
            // FormMantenimientoConsorcios_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1120, 740);
            Controls.Add(tabMaestros);
            MinimumSize = new System.Drawing.Size(1120, 740);
            Name = "FormMantenimientoConsorcios_755ME";
            Text = "Mantenimiento de consorcios";
            Tag = "lb_mant_consorcios";
            Load += FormMantenimientoConsorcios_755ME_Load;
            FormClosing += FormMantenimientoConsorcios_755ME_FormClosing;
            tabMaestros.ResumeLayout(false);
            tabConsorcios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvConsorcios).EndInit();
            grpConsorcio.ResumeLayout(false);
            grpConsorcio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadUnidades).EndInit();
            tabUnidades.ResumeLayout(false);
            tabUnidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnidades).EndInit();
            grpUnidad.ResumeLayout(false);
            grpUnidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCoeficiente).EndInit();
            tabConsorcistas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvConsorcistas).EndInit();
            grpConsorcista.ResumeLayout(false);
            grpConsorcista.PerformLayout();
            grpPropietario.ResumeLayout(false);
            grpPropietario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnidadesPropietario).EndInit();
            tabProveedores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            grpProveedor.ResumeLayout(false);
            grpProveedor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabMaestros;
        private System.Windows.Forms.TabPage tabConsorcios;
        private System.Windows.Forms.DataGridView dgvConsorcios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCGestor;
        private System.Windows.Forms.GroupBox grpConsorcio;
        private System.Windows.Forms.Button btnReactivarConsorcio;
        private System.Windows.Forms.Button btnInactivarConsorcio;
        private System.Windows.Forms.Button btnGuardarConsorcio;
        private System.Windows.Forms.Button btnNuevoConsorcio;
        private System.Windows.Forms.ComboBox cboGestor;
        private System.Windows.Forms.Label lblGestor;
        private System.Windows.Forms.NumericUpDown numCantidadUnidades;
        private System.Windows.Forms.Label lblCantidadUnidades;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TabPage tabUnidades;
        private System.Windows.Forms.Label lblConsorcioUnidad;
        private System.Windows.Forms.ComboBox cboConsorcioUnidad;
        private System.Windows.Forms.DataGridView dgvUnidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUCoeficiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUActiva;
        private System.Windows.Forms.GroupBox grpUnidad;
        private System.Windows.Forms.Button btnReactivarUnidad;
        private System.Windows.Forms.Button btnVerHistorialUnidad;
        private System.Windows.Forms.Button btnInactivarUnidad;
        private System.Windows.Forms.Button btnGuardarUnidad;
        private System.Windows.Forms.Button btnNuevaUnidad;
        private System.Windows.Forms.NumericUpDown numCoeficiente;
        private System.Windows.Forms.Label lblCoeficiente;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TabPage tabConsorcistas;
        private System.Windows.Forms.TabPage tabProveedores;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrHabilitado;
        private System.Windows.Forms.GroupBox grpProveedor;
        private System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.Button btnNuevoProveedor;
        private System.Windows.Forms.Button btnGuardarProveedor;
        private System.Windows.Forms.Button btnInhabilitarProveedor;
        private System.Windows.Forms.Button btnHabilitarProveedor;
        private System.Windows.Forms.DataGridView dgvConsorcistas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoActivo;
        private System.Windows.Forms.GroupBox grpConsorcista;
        private System.Windows.Forms.Button btnReactivarConsorcista;
        private System.Windows.Forms.Button btnInactivarConsorcista;
        private System.Windows.Forms.Button btnGuardarConsorcista;
        private System.Windows.Forms.Button btnNuevoConsorcista;
        private System.Windows.Forms.TextBox txtDniConsorcista;
        private System.Windows.Forms.Label lblDniConsorcista;
        private System.Windows.Forms.TextBox txtApellidoConsorcista;
        private System.Windows.Forms.Label lblApellidoConsorcista;
        private System.Windows.Forms.TextBox txtNombreConsorcista;
        private System.Windows.Forms.Label lblNombreConsorcista;
        private System.Windows.Forms.GroupBox grpPropietario;
        private System.Windows.Forms.Label lblUnidadPropietario;
        private System.Windows.Forms.ComboBox cboUnidadPropietario;
        private System.Windows.Forms.Button btnAsignarPropietario;
        private System.Windows.Forms.DataGridView dgvUnidadesPropietario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropietarioUnidad;
        private System.Windows.Forms.Button btnQuitarPropietario;
    }
}

namespace AppBase
{
    partial class FormPrestacion_755ME
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
            lblConsorcio = new System.Windows.Forms.Label();
            cboConsorcio = new System.Windows.Forms.ComboBox();
            lblSinConsorcios = new System.Windows.Forms.Label();
            dgvServicios = new System.Windows.Forms.DataGridView();
            colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPlazo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colFechaAsignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpPrestacion = new System.Windows.Forms.GroupBox();
            lblFecha = new System.Windows.Forms.Label();
            dtpFecha = new System.Windows.Forms.DateTimePicker();
            lblTrabajo = new System.Windows.Forms.Label();
            txtTrabajo = new System.Windows.Forms.TextBox();
            lblCosto = new System.Windows.Forms.Label();
            numCosto = new System.Windows.Forms.NumericUpDown();
            lblFactura = new System.Windows.Forms.Label();
            txtFactura = new System.Windows.Forms.TextBox();
            lblArchivo = new System.Windows.Forms.Label();
            txtArchivo = new System.Windows.Forms.TextBox();
            btnAdjuntar = new System.Windows.Forms.Button();
            btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
            grpPrestacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCosto).BeginInit();
            SuspendLayout();
            //
            // lblConsorcio
            //
            lblConsorcio.AutoSize = true;
            lblConsorcio.Location = new System.Drawing.Point(15, 18);
            lblConsorcio.Name = "lblConsorcio";
            lblConsorcio.Size = new System.Drawing.Size(63, 15);
            lblConsorcio.TabIndex = 0;
            lblConsorcio.Text = "Consorcio:";
            lblConsorcio.Tag = "lb_consorcio";
            //
            // cboConsorcio
            //
            cboConsorcio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboConsorcio.FormattingEnabled = true;
            cboConsorcio.Location = new System.Drawing.Point(110, 15);
            cboConsorcio.Name = "cboConsorcio";
            cboConsorcio.Size = new System.Drawing.Size(300, 23);
            cboConsorcio.TabIndex = 1;
            cboConsorcio.SelectedIndexChanged += cboConsorcio_SelectedIndexChanged;
            //
            // lblSinConsorcios
            //
            lblSinConsorcios.AutoSize = true;
            lblSinConsorcios.ForeColor = System.Drawing.Color.DarkRed;
            lblSinConsorcios.Location = new System.Drawing.Point(430, 18);
            lblSinConsorcios.Name = "lblSinConsorcios";
            lblSinConsorcios.Tag = "lb_sin_consorcios";
            lblSinConsorcios.Text = "No tiene consorcios asignados";
            lblSinConsorcios.Size = new System.Drawing.Size(0, 15);
            lblSinConsorcios.TabIndex = 2;
            //
            // dgvServicios
            //
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.AllowUserToDeleteRows = false;
            dgvServicios.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colNumero, colCategoria, colDescripcion, colProveedor, colPlazo, colFechaAsignacion });
            dgvServicios.Location = new System.Drawing.Point(15, 50);
            dgvServicios.MultiSelect = false;
            dgvServicios.Name = "dgvServicios";
            dgvServicios.ReadOnly = true;
            dgvServicios.RowHeadersVisible = false;
            dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvServicios.Size = new System.Drawing.Size(760, 200);
            dgvServicios.TabIndex = 3;
            dgvServicios.SelectionChanged += dgvServicios_SelectionChanged;
            //
            // colNumero
            //
            colNumero.FillWeight = 40F;
            colNumero.HeaderText = "N.º";
            colNumero.Name = "colNumero";
            colNumero.ReadOnly = true;
            //
            // colCategoria
            //
            colCategoria.HeaderText = "Categoría";
            colCategoria.Tag = "lb_categoria";
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            //
            // colDescripcion
            //
            colDescripcion.FillWeight = 180F;
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Tag = "lb_descripcion";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            //
            // colProveedor
            //
            colProveedor.FillWeight = 120F;
            colProveedor.HeaderText = "Proveedor";
            colProveedor.Tag = "lb_col_proveedor";
            colProveedor.Name = "colProveedor";
            colProveedor.ReadOnly = true;
            //
            // colPlazo
            //
            colPlazo.FillWeight = 60F;
            colPlazo.HeaderText = "Plazo (días)";
            colPlazo.Tag = "lb_plazo_dias";
            colPlazo.Name = "colPlazo";
            colPlazo.ReadOnly = true;
            //
            // colFechaAsignacion
            //
            colFechaAsignacion.FillWeight = 70F;
            colFechaAsignacion.HeaderText = "Asignado el";
            colFechaAsignacion.Tag = "lb_asignado_el";
            colFechaAsignacion.Name = "colFechaAsignacion";
            colFechaAsignacion.ReadOnly = true;
            //
            // grpPrestacion
            //
            grpPrestacion.Controls.Add(lblFecha);
            grpPrestacion.Controls.Add(dtpFecha);
            grpPrestacion.Controls.Add(lblTrabajo);
            grpPrestacion.Controls.Add(txtTrabajo);
            grpPrestacion.Controls.Add(lblCosto);
            grpPrestacion.Controls.Add(numCosto);
            grpPrestacion.Controls.Add(lblFactura);
            grpPrestacion.Controls.Add(txtFactura);
            grpPrestacion.Controls.Add(lblArchivo);
            grpPrestacion.Controls.Add(txtArchivo);
            grpPrestacion.Controls.Add(btnAdjuntar);
            grpPrestacion.Enabled = false;
            grpPrestacion.Location = new System.Drawing.Point(15, 260);
            grpPrestacion.Name = "grpPrestacion";
            grpPrestacion.Size = new System.Drawing.Size(760, 225);
            grpPrestacion.TabIndex = 4;
            grpPrestacion.TabStop = false;
            grpPrestacion.Text = "Prestación realizada";
            grpPrestacion.Tag = "lb_grp_prestacion";
            //
            // lblFecha
            //
            lblFecha.AutoSize = true;
            lblFecha.Location = new System.Drawing.Point(15, 30);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new System.Drawing.Size(41, 15);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha:";
            lblFecha.Tag = "lb_fecha";
            //
            // dtpFecha
            //
            dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFecha.Location = new System.Drawing.Point(140, 27);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new System.Drawing.Size(120, 23);
            dtpFecha.TabIndex = 1;
            //
            // lblTrabajo
            //
            lblTrabajo.AutoSize = true;
            lblTrabajo.Location = new System.Drawing.Point(15, 62);
            lblTrabajo.Name = "lblTrabajo";
            lblTrabajo.Size = new System.Drawing.Size(105, 15);
            lblTrabajo.TabIndex = 2;
            lblTrabajo.Text = "Trabajo realizado:";
            lblTrabajo.Tag = "lb_trabajo_realizado";
            //
            // txtTrabajo
            //
            txtTrabajo.Location = new System.Drawing.Point(140, 59);
            txtTrabajo.MaxLength = 500;
            txtTrabajo.Multiline = true;
            txtTrabajo.Name = "txtTrabajo";
            txtTrabajo.Size = new System.Drawing.Size(600, 55);
            txtTrabajo.TabIndex = 3;
            //
            // lblCosto
            //
            lblCosto.AutoSize = true;
            lblCosto.Location = new System.Drawing.Point(15, 127);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new System.Drawing.Size(41, 15);
            lblCosto.TabIndex = 4;
            lblCosto.Text = "Costo:";
            lblCosto.Tag = "lb_costo";
            //
            // numCosto
            //
            numCosto.DecimalPlaces = 2;
            numCosto.Location = new System.Drawing.Point(140, 125);
            numCosto.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numCosto.Name = "numCosto";
            numCosto.Size = new System.Drawing.Size(120, 23);
            numCosto.TabIndex = 5;
            numCosto.ValueChanged += datosPrestacion_Changed;
            numCosto.KeyUp += datosPrestacion_Changed;
            //
            // lblFactura
            //
            lblFactura.AutoSize = true;
            lblFactura.Location = new System.Drawing.Point(290, 127);
            lblFactura.Name = "lblFactura";
            lblFactura.Size = new System.Drawing.Size(70, 15);
            lblFactura.TabIndex = 6;
            lblFactura.Text = "N.º factura:";
            lblFactura.Tag = "lb_numero_factura";
            //
            // txtFactura
            //
            txtFactura.Location = new System.Drawing.Point(370, 124);
            txtFactura.MaxLength = 30;
            txtFactura.Name = "txtFactura";
            txtFactura.Size = new System.Drawing.Size(180, 23);
            txtFactura.TabIndex = 7;
            txtFactura.TextChanged += datosPrestacion_Changed;
            //
            // lblArchivo
            //
            lblArchivo.AutoSize = true;
            lblArchivo.Location = new System.Drawing.Point(15, 165);
            lblArchivo.Name = "lblArchivo";
            lblArchivo.Size = new System.Drawing.Size(80, 15);
            lblArchivo.TabIndex = 8;
            lblArchivo.Text = "Archivo (opcional):";
            lblArchivo.Tag = "lb_archivo_opcional";
            //
            // txtArchivo
            //
            txtArchivo.Location = new System.Drawing.Point(140, 162);
            txtArchivo.Name = "txtArchivo";
            txtArchivo.ReadOnly = true;
            txtArchivo.Size = new System.Drawing.Size(480, 23);
            txtArchivo.TabIndex = 9;
            //
            // btnAdjuntar
            //
            btnAdjuntar.Location = new System.Drawing.Point(630, 161);
            btnAdjuntar.Name = "btnAdjuntar";
            btnAdjuntar.Size = new System.Drawing.Size(110, 25);
            btnAdjuntar.TabIndex = 10;
            btnAdjuntar.Text = "Adjuntar...";
            btnAdjuntar.Tag = "lb_adjuntar";
            btnAdjuntar.Click += btnAdjuntar_Click;
            //
            // btnConfirmar
            //
            btnConfirmar.Enabled = false;
            btnConfirmar.Location = new System.Drawing.Point(15, 495);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new System.Drawing.Size(180, 28);
            btnConfirmar.TabIndex = 5;
            btnConfirmar.Text = "Confirmar carga";
            btnConfirmar.Tag = "lb_confirmar_carga";
            btnConfirmar.Click += btnConfirmar_Click;
            //
            // FormPrestacion_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(790, 550);
            Controls.Add(btnConfirmar);
            Controls.Add(grpPrestacion);
            Controls.Add(dgvServicios);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(790, 500);
            Name = "FormPrestacion_755ME";
            HelpRequested += FormPrestacion_755ME_HelpRequested;
            Text = "Cargar prestación del proveedor";
            Tag = "lb_cargar_prestacion";
            Load += FormPrestacion_755ME_Load;
            FormClosing += FormPrestacion_755ME_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvServicios).EndInit();
            grpPrestacion.ResumeLayout(false);
            grpPrestacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCosto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlazo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaAsignacion;
        private System.Windows.Forms.GroupBox grpPrestacion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblTrabajo;
        private System.Windows.Forms.TextBox txtTrabajo;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.NumericUpDown numCosto;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Button btnAdjuntar;
        private System.Windows.Forms.Button btnConfirmar;
    }
}

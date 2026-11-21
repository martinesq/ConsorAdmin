namespace AppBase
{
    partial class FormAsignacionProveedor_755ME
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
            dgvSolicitudes = new System.Windows.Forms.DataGridView();
            colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpAsignacion = new System.Windows.Forms.GroupBox();
            lblProveedor = new System.Windows.Forms.Label();
            cboProveedor = new System.Windows.Forms.ComboBox();
            lblPlazo = new System.Windows.Forms.Label();
            numPlazo = new System.Windows.Forms.NumericUpDown();
            lblPlazoInvalido = new System.Windows.Forms.Label();
            btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).BeginInit();
            grpAsignacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPlazo).BeginInit();
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
            // dgvSolicitudes
            //
            dgvSolicitudes.AllowUserToAddRows = false;
            dgvSolicitudes.AllowUserToDeleteRows = false;
            dgvSolicitudes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvSolicitudes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colNumero, colCategoria, colDescripcion, colUbicacion });
            dgvSolicitudes.Location = new System.Drawing.Point(15, 50);
            dgvSolicitudes.MultiSelect = false;
            dgvSolicitudes.Name = "dgvSolicitudes";
            dgvSolicitudes.ReadOnly = true;
            dgvSolicitudes.RowHeadersVisible = false;
            dgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSolicitudes.Size = new System.Drawing.Size(760, 240);
            dgvSolicitudes.TabIndex = 3;
            dgvSolicitudes.SelectionChanged += dgvSolicitudes_SelectionChanged;
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
            colDescripcion.FillWeight = 200F;
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Tag = "lb_descripcion";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            //
            // colUbicacion
            //
            colUbicacion.HeaderText = "Ubicación";
            colUbicacion.Tag = "lb_ubicacion";
            colUbicacion.Name = "colUbicacion";
            colUbicacion.ReadOnly = true;
            //
            // grpAsignacion
            //
            grpAsignacion.Controls.Add(lblProveedor);
            grpAsignacion.Controls.Add(cboProveedor);
            grpAsignacion.Controls.Add(lblPlazo);
            grpAsignacion.Controls.Add(numPlazo);
            grpAsignacion.Controls.Add(lblPlazoInvalido);
            grpAsignacion.Enabled = false;
            grpAsignacion.Location = new System.Drawing.Point(15, 300);
            grpAsignacion.Name = "grpAsignacion";
            grpAsignacion.Size = new System.Drawing.Size(760, 110);
            grpAsignacion.TabIndex = 4;
            grpAsignacion.TabStop = false;
            grpAsignacion.Text = "Asignación";
            grpAsignacion.Tag = "lb_grp_asignacion";
            //
            // lblProveedor
            //
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new System.Drawing.Point(15, 30);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new System.Drawing.Size(64, 15);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            lblProveedor.Tag = "lb_proveedor";
            //
            // cboProveedor
            //
            cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Location = new System.Drawing.Point(140, 27);
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new System.Drawing.Size(270, 23);
            cboProveedor.TabIndex = 1;
            //
            // lblPlazo
            //
            lblPlazo.AutoSize = true;
            lblPlazo.Location = new System.Drawing.Point(15, 65);
            lblPlazo.Name = "lblPlazo";
            lblPlazo.Size = new System.Drawing.Size(118, 15);
            lblPlazo.TabIndex = 2;
            lblPlazo.Text = "Plazo estimado (días):";
            lblPlazo.Tag = "lb_plazo_estimado";
            //
            // numPlazo
            //
            numPlazo.Location = new System.Drawing.Point(140, 63);
            numPlazo.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            numPlazo.Name = "numPlazo";
            numPlazo.Size = new System.Drawing.Size(80, 23);
            numPlazo.TabIndex = 3;
            numPlazo.ValueChanged += numPlazo_ValueChanged;
            numPlazo.KeyUp += numPlazo_ValueChanged;
            //
            // lblPlazoInvalido
            //
            lblPlazoInvalido.AutoSize = true;
            lblPlazoInvalido.ForeColor = System.Drawing.Color.DarkRed;
            lblPlazoInvalido.Location = new System.Drawing.Point(235, 65);
            lblPlazoInvalido.Name = "lblPlazoInvalido";
            lblPlazoInvalido.Size = new System.Drawing.Size(230, 15);
            lblPlazoInvalido.TabIndex = 4;
            lblPlazoInvalido.Text = "Debe indicar un plazo estimado válido";
            lblPlazoInvalido.Tag = "lb_plazo_invalido";
            lblPlazoInvalido.Visible = false;
            //
            // btnConfirmar
            //
            btnConfirmar.Enabled = false;
            btnConfirmar.Location = new System.Drawing.Point(15, 425);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new System.Drawing.Size(180, 28);
            btnConfirmar.TabIndex = 5;
            btnConfirmar.Text = "Confirmar asignación";
            btnConfirmar.Tag = "lb_confirmar_asignacion";
            btnConfirmar.Click += btnConfirmar_Click;
            //
            // FormAsignacionProveedor_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(790, 550);
            Controls.Add(btnConfirmar);
            Controls.Add(grpAsignacion);
            Controls.Add(dgvSolicitudes);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(790, 500);
            Name = "FormAsignacionProveedor_755ME";
            HelpRequested += FormAsignacionProveedor_755ME_HelpRequested;
            Text = "Asignar proveedor al servicio";
            Tag = "lb_asignar_proveedor";
            Load += FormAsignacionProveedor_755ME_Load;
            FormClosing += FormAsignacionProveedor_755ME_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).EndInit();
            grpAsignacion.ResumeLayout(false);
            grpAsignacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPlazo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUbicacion;
        private System.Windows.Forms.GroupBox grpAsignacion;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Label lblPlazo;
        private System.Windows.Forms.NumericUpDown numPlazo;
        private System.Windows.Forms.Label lblPlazoInvalido;
        private System.Windows.Forms.Button btnConfirmar;
    }
}

namespace AppBase
{
    partial class FormAprobacionPrestacion_755ME
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
            dgvPrestaciones = new System.Windows.Forms.DataGridView();
            colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpDetalle = new System.Windows.Forms.GroupBox();
            lblProveedor = new System.Windows.Forms.Label();
            lblTrabajo = new System.Windows.Forms.Label();
            lblCosto = new System.Windows.Forms.Label();
            lblComprobante = new System.Windows.Forms.Label();
            btnAprobar = new System.Windows.Forms.Button();
            lblMotivo = new System.Windows.Forms.Label();
            txtMotivo = new System.Windows.Forms.TextBox();
            btnRechazar = new System.Windows.Forms.Button();
            lblSinMotivo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvPrestaciones).BeginInit();
            grpDetalle.SuspendLayout();
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
            // dgvPrestaciones
            //
            dgvPrestaciones.AllowUserToAddRows = false;
            dgvPrestaciones.AllowUserToDeleteRows = false;
            dgvPrestaciones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvPrestaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrestaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colNumero, colCategoria, colProveedor, colFecha, colCosto });
            dgvPrestaciones.Location = new System.Drawing.Point(15, 50);
            dgvPrestaciones.MultiSelect = false;
            dgvPrestaciones.Name = "dgvPrestaciones";
            dgvPrestaciones.ReadOnly = true;
            dgvPrestaciones.RowHeadersVisible = false;
            dgvPrestaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPrestaciones.Size = new System.Drawing.Size(760, 200);
            dgvPrestaciones.TabIndex = 3;
            dgvPrestaciones.SelectionChanged += dgvPrestaciones_SelectionChanged;
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
            // colProveedor
            //
            colProveedor.FillWeight = 150F;
            colProveedor.HeaderText = "Proveedor";
            colProveedor.Tag = "lb_col_proveedor";
            colProveedor.Name = "colProveedor";
            colProveedor.ReadOnly = true;
            //
            // colFecha
            //
            colFecha.FillWeight = 70F;
            colFecha.HeaderText = "Fecha";
            colFecha.Tag = "lb_col_fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            //
            // colCosto
            //
            colCosto.FillWeight = 70F;
            colCosto.HeaderText = "Costo";
            colCosto.Tag = "lb_col_costo";
            colCosto.Name = "colCosto";
            colCosto.ReadOnly = true;
            //
            // grpDetalle
            //
            grpDetalle.Controls.Add(lblProveedor);
            grpDetalle.Controls.Add(lblTrabajo);
            grpDetalle.Controls.Add(lblCosto);
            grpDetalle.Controls.Add(lblComprobante);
            grpDetalle.Controls.Add(btnAprobar);
            grpDetalle.Controls.Add(lblMotivo);
            grpDetalle.Controls.Add(txtMotivo);
            grpDetalle.Controls.Add(btnRechazar);
            grpDetalle.Controls.Add(lblSinMotivo);
            grpDetalle.Enabled = false;
            grpDetalle.Location = new System.Drawing.Point(15, 260);
            grpDetalle.Name = "grpDetalle";
            grpDetalle.Size = new System.Drawing.Size(760, 270);
            grpDetalle.TabIndex = 4;
            grpDetalle.TabStop = false;
            grpDetalle.Text = "Detalle de la prestación";
            grpDetalle.Tag = "lb_grp_detalle_prestacion";
            //
            // lblProveedor
            //
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new System.Drawing.Point(15, 28);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new System.Drawing.Size(64, 15);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            lblProveedor.Tag = "lb_proveedor";
            //
            // lblTrabajo
            //
            lblTrabajo.AutoSize = true;
            lblTrabajo.Location = new System.Drawing.Point(15, 53);
            lblTrabajo.MaximumSize = new System.Drawing.Size(730, 0);
            lblTrabajo.Name = "lblTrabajo";
            lblTrabajo.Size = new System.Drawing.Size(105, 15);
            lblTrabajo.TabIndex = 1;
            lblTrabajo.Text = "Trabajo realizado:";
            lblTrabajo.Tag = "lb_trabajo_realizado";
            //
            // lblCosto
            //
            lblCosto.AutoSize = true;
            lblCosto.Location = new System.Drawing.Point(15, 98);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new System.Drawing.Size(41, 15);
            lblCosto.TabIndex = 2;
            lblCosto.Text = "Costo:";
            lblCosto.Tag = "lb_costo";
            //
            // lblComprobante
            //
            lblComprobante.AutoSize = true;
            lblComprobante.Location = new System.Drawing.Point(15, 123);
            lblComprobante.MaximumSize = new System.Drawing.Size(730, 0);
            lblComprobante.Name = "lblComprobante";
            lblComprobante.Size = new System.Drawing.Size(80, 15);
            lblComprobante.TabIndex = 3;
            lblComprobante.Text = "Comprobante:";
            lblComprobante.Tag = "lb_comprobante";
            //
            // btnAprobar
            //
            btnAprobar.Enabled = false;
            btnAprobar.Location = new System.Drawing.Point(15, 160);
            btnAprobar.Name = "btnAprobar";
            btnAprobar.Size = new System.Drawing.Size(160, 28);
            btnAprobar.TabIndex = 4;
            btnAprobar.Text = "Aprobar prestación";
            btnAprobar.Tag = "lb_aprobar_prestacion";
            btnAprobar.Click += btnAprobar_Click;
            //
            // lblMotivo
            //
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new System.Drawing.Point(15, 205);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new System.Drawing.Size(115, 15);
            lblMotivo.TabIndex = 5;
            lblMotivo.Text = "Motivo del rechazo:";
            lblMotivo.Tag = "lb_motivo_rechazo";
            //
            // txtMotivo
            //
            txtMotivo.Location = new System.Drawing.Point(140, 202);
            txtMotivo.MaxLength = 200;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new System.Drawing.Size(430, 23);
            txtMotivo.TabIndex = 6;
            txtMotivo.TextChanged += txtMotivo_TextChanged;
            //
            // btnRechazar
            //
            btnRechazar.Enabled = false;
            btnRechazar.Location = new System.Drawing.Point(585, 200);
            btnRechazar.Name = "btnRechazar";
            btnRechazar.Size = new System.Drawing.Size(160, 28);
            btnRechazar.TabIndex = 7;
            btnRechazar.Text = "Rechazar prestación";
            btnRechazar.Tag = "lb_rechazar_prestacion";
            btnRechazar.Click += btnRechazar_Click;
            //
            // lblSinMotivo
            //
            lblSinMotivo.AutoSize = true;
            lblSinMotivo.ForeColor = System.Drawing.Color.DarkRed;
            lblSinMotivo.Location = new System.Drawing.Point(140, 232);
            lblSinMotivo.Name = "lblSinMotivo";
            lblSinMotivo.Size = new System.Drawing.Size(250, 15);
            lblSinMotivo.TabIndex = 8;
            lblSinMotivo.Text = "Debe indicar un motivo para rechazar";
            lblSinMotivo.Tag = "lb_debe_indicar_motivo";
            lblSinMotivo.Visible = false;
            //
            // FormAprobacionPrestacion_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(790, 550);
            Controls.Add(grpDetalle);
            Controls.Add(dgvPrestaciones);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(790, 500);
            Name = "FormAprobacionPrestacion_755ME";
            HelpRequested += FormAprobacionPrestacion_755ME_HelpRequested;
            Text = "Aprobar prestación";
            Tag = "lb_aprobar_prestacion";
            Load += FormAprobacionPrestacion_755ME_Load;
            FormClosing += FormAprobacionPrestacion_755ME_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvPrestaciones).EndInit();
            grpDetalle.ResumeLayout(false);
            grpDetalle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.DataGridView dgvPrestaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCosto;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblTrabajo;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Label lblSinMotivo;
    }
}

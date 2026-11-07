namespace AppBase
{
    partial class FormReporteServiciosPN02_755ME
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
            rbPorConsorcio = new System.Windows.Forms.RadioButton();
            cboConsorcio = new System.Windows.Forms.ComboBox();
            rbPorProveedor = new System.Windows.Forms.RadioButton();
            cboProveedor = new System.Windows.Forms.ComboBox();
            btnGenerar = new System.Windows.Forms.Button();
            btnExportarPdf = new System.Windows.Forms.Button();
            dgvServicios = new System.Windows.Forms.DataGridView();
            colConsorcio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblCostoAcumulado = new System.Windows.Forms.Label();
            lblSinConsorcios = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
            SuspendLayout();
            //
            // rbPorConsorcio
            //
            rbPorConsorcio.AutoSize = true;
            rbPorConsorcio.Checked = true;
            rbPorConsorcio.Location = new System.Drawing.Point(12, 15);
            rbPorConsorcio.Name = "rbPorConsorcio";
            rbPorConsorcio.Size = new System.Drawing.Size(100, 19);
            rbPorConsorcio.TabIndex = 0;
            rbPorConsorcio.TabStop = true;
            rbPorConsorcio.Tag = "lb_repserv_por_consorcio";
            rbPorConsorcio.Text = "Por consorcio";
            rbPorConsorcio.UseVisualStyleBackColor = true;
            rbPorConsorcio.CheckedChanged += rbPorConsorcio_CheckedChanged;
            //
            // cboConsorcio
            //
            cboConsorcio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboConsorcio.FormattingEnabled = true;
            cboConsorcio.Location = new System.Drawing.Point(125, 12);
            cboConsorcio.Name = "cboConsorcio";
            cboConsorcio.Size = new System.Drawing.Size(250, 23);
            cboConsorcio.TabIndex = 1;
            cboConsorcio.SelectedIndexChanged += cboFiltro_SelectedIndexChanged;
            //
            // rbPorProveedor
            //
            rbPorProveedor.AutoSize = true;
            rbPorProveedor.Location = new System.Drawing.Point(12, 45);
            rbPorProveedor.Name = "rbPorProveedor";
            rbPorProveedor.Size = new System.Drawing.Size(100, 19);
            rbPorProveedor.TabIndex = 2;
            rbPorProveedor.Tag = "lb_repserv_por_proveedor";
            rbPorProveedor.Text = "Por proveedor";
            rbPorProveedor.UseVisualStyleBackColor = true;
            //
            // cboProveedor
            //
            cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboProveedor.Enabled = false;
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Location = new System.Drawing.Point(125, 42);
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new System.Drawing.Size(250, 23);
            cboProveedor.TabIndex = 3;
            cboProveedor.SelectedIndexChanged += cboFiltro_SelectedIndexChanged;
            //
            // btnGenerar
            //
            btnGenerar.Location = new System.Drawing.Point(390, 25);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new System.Drawing.Size(100, 28);
            btnGenerar.TabIndex = 4;
            btnGenerar.Tag = "lb_repserv_generar";
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            //
            // btnExportarPdf
            //
            btnExportarPdf.Enabled = false;
            btnExportarPdf.Location = new System.Drawing.Point(500, 25);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new System.Drawing.Size(120, 28);
            btnExportarPdf.TabIndex = 7;
            btnExportarPdf.Tag = "lb_exportar_pdf";
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = true;
            btnExportarPdf.Click += btnExportarPdf_Click;
            //
            // dgvServicios
            //
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.AllowUserToDeleteRows = false;
            dgvServicios.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colConsorcio, colProveedor, colCategoria, colDescripcion, colEstado, colCosto });
            dgvServicios.Location = new System.Drawing.Point(12, 80);
            dgvServicios.Name = "dgvServicios";
            dgvServicios.ReadOnly = true;
            dgvServicios.RowHeadersVisible = false;
            dgvServicios.Size = new System.Drawing.Size(860, 360);
            dgvServicios.TabIndex = 5;
            //
            // colConsorcio
            //
            colConsorcio.HeaderText = "Consorcio";
            colConsorcio.Name = "colConsorcio";
            colConsorcio.ReadOnly = true;
            colConsorcio.Tag = "lb_repserv_col_consorcio";
            //
            // colProveedor
            //
            colProveedor.HeaderText = "Proveedor";
            colProveedor.Name = "colProveedor";
            colProveedor.ReadOnly = true;
            colProveedor.Tag = "lb_col_proveedor";
            //
            // colCategoria
            //
            colCategoria.HeaderText = "Categoría";
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            colCategoria.Tag = "lb_categoria";
            //
            // colDescripcion
            //
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            colDescripcion.Tag = "lb_repserv_col_descripcion";
            //
            // colEstado
            //
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            colEstado.Tag = "lb_repserv_col_estado";
            //
            // colCosto
            //
            colCosto.HeaderText = "Costo";
            colCosto.Name = "colCosto";
            colCosto.ReadOnly = true;
            colCosto.Tag = "lb_repserv_col_costo";
            //
            // lblSinConsorcios
            //
            lblSinConsorcios.AutoSize = true;
            lblSinConsorcios.ForeColor = System.Drawing.Color.DarkRed;
            lblSinConsorcios.Location = new System.Drawing.Point(635, 32);
            lblSinConsorcios.Name = "lblSinConsorcios";
            lblSinConsorcios.Size = new System.Drawing.Size(170, 15);
            lblSinConsorcios.TabIndex = 20;
            lblSinConsorcios.Tag = "lb_sin_consorcios";
            lblSinConsorcios.Text = "No tiene consorcios asignados";
            lblSinConsorcios.Visible = false;
            //
            // lblCostoAcumulado
            //
            lblCostoAcumulado.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblCostoAcumulado.AutoSize = true;
            lblCostoAcumulado.Location = new System.Drawing.Point(12, 450);
            lblCostoAcumulado.Name = "lblCostoAcumulado";
            lblCostoAcumulado.Size = new System.Drawing.Size(103, 15);
            lblCostoAcumulado.TabIndex = 6;
            lblCostoAcumulado.Tag = "lb_repserv_costo_acumulado";
            lblCostoAcumulado.Text = "Costo acumulado:";
            //
            // FormReporteServiciosPN02_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(884, 481);
            Controls.Add(lblSinConsorcios);
            Controls.Add(lblCostoAcumulado);
            Controls.Add(dgvServicios);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnGenerar);
            Controls.Add(cboProveedor);
            Controls.Add(rbPorProveedor);
            Controls.Add(cboConsorcio);
            Controls.Add(rbPorConsorcio);
            Name = "FormReporteServiciosPN02_755ME";
            Tag = "lb_reporte_servicios";
            Text = "Reporte de servicios";
            FormClosing += FormReporteServiciosPN02_755ME_FormClosing;
            Load += FormReporteServiciosPN02_755ME_Load;
            ((System.ComponentModel.ISupportInitialize)dgvServicios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RadioButton rbPorConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.RadioButton rbPorProveedor;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnExportarPdf;
        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsorcio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCosto;
        private System.Windows.Forms.Label lblCostoAcumulado;
        private System.Windows.Forms.Label lblSinConsorcios;
    }
}

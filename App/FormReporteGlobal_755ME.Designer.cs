namespace AppBase
{
    partial class FormReporteGlobal_755ME
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

        private void InitializeComponent()
        {
            lblDesde = new System.Windows.Forms.Label();
            dtpDesde = new System.Windows.Forms.DateTimePicker();
            lblHasta = new System.Windows.Forms.Label();
            dtpHasta = new System.Windows.Forms.DateTimePicker();
            btnGenerar = new System.Windows.Forms.Button();
            btnExportarPdf = new System.Windows.Forms.Button();
            dgvGlobal = new System.Windows.Forms.DataGridView();
            colPuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colConsorcio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colUnidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colExpensado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCobrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDeuda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCobranza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colGastos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colServicios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCostoServicios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEgresos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblTotalExpensado = new System.Windows.Forms.Label();
            lblTotalCobrado = new System.Windows.Forms.Label();
            lblTotalDeuda = new System.Windows.Forms.Label();
            lblTotalSaldo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvGlobal).BeginInit();
            SuspendLayout();
            //
            // lblDesde
            //
            lblDesde.AutoSize = true;
            lblDesde.Location = new System.Drawing.Point(12, 18);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new System.Drawing.Size(42, 15);
            lblDesde.TabIndex = 0;
            lblDesde.Tag = "lb_repglobal_desde";
            lblDesde.Text = "Desde:";
            //
            // dtpDesde
            //
            dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDesde.Location = new System.Drawing.Point(65, 14);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new System.Drawing.Size(110, 23);
            dtpDesde.TabIndex = 1;
            dtpDesde.ValueChanged += dtpPeriodo_ValueChanged;
            //
            // lblHasta
            //
            lblHasta.AutoSize = true;
            lblHasta.Location = new System.Drawing.Point(190, 18);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new System.Drawing.Size(40, 15);
            lblHasta.TabIndex = 2;
            lblHasta.Tag = "lb_repglobal_hasta";
            lblHasta.Text = "Hasta:";
            //
            // dtpHasta
            //
            dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpHasta.Location = new System.Drawing.Point(240, 14);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new System.Drawing.Size(110, 23);
            dtpHasta.TabIndex = 3;
            dtpHasta.ValueChanged += dtpPeriodo_ValueChanged;
            //
            // btnGenerar
            //
            btnGenerar.Location = new System.Drawing.Point(370, 12);
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
            btnExportarPdf.Location = new System.Drawing.Point(480, 12);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new System.Drawing.Size(120, 28);
            btnExportarPdf.TabIndex = 10;
            btnExportarPdf.Tag = "lb_exportar_pdf";
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = true;
            btnExportarPdf.Click += btnExportarPdf_Click;
            //
            // dgvGlobal
            //
            dgvGlobal.AllowUserToAddRows = false;
            dgvGlobal.AllowUserToDeleteRows = false;
            dgvGlobal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvGlobal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvGlobal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGlobal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colPuesto, colConsorcio, colUnidades, colExpensado, colCobrado, colDeuda, colCobranza, colGastos, colServicios, colCostoServicios, colEgresos, colSaldo });
            dgvGlobal.Location = new System.Drawing.Point(12, 52);
            dgvGlobal.Name = "dgvGlobal";
            dgvGlobal.ReadOnly = true;
            dgvGlobal.RowHeadersVisible = false;
            dgvGlobal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvGlobal.Size = new System.Drawing.Size(1060, 380);
            dgvGlobal.TabIndex = 5;
            //
            // colPuesto
            //
            colPuesto.FillWeight = 50;
            colPuesto.HeaderText = "Puesto";
            colPuesto.Name = "colPuesto";
            colPuesto.ReadOnly = true;
            colPuesto.Tag = "lb_repglobal_col_puesto";
            //
            // colConsorcio
            //
            colConsorcio.FillWeight = 150;
            colConsorcio.HeaderText = "Consorcio";
            colConsorcio.Name = "colConsorcio";
            colConsorcio.ReadOnly = true;
            colConsorcio.Tag = "lb_repserv_col_consorcio";
            //
            // colUnidades
            //
            colUnidades.FillWeight = 70;
            colUnidades.HeaderText = "Unidades activas";
            colUnidades.Name = "colUnidades";
            colUnidades.ReadOnly = true;
            colUnidades.Tag = "lb_repglobal_col_unidades";
            //
            // colExpensado
            //
            colExpensado.FillWeight = 90;
            colExpensado.HeaderText = "Expensado";
            colExpensado.Name = "colExpensado";
            colExpensado.ReadOnly = true;
            colExpensado.Tag = "lb_repglobal_col_expensado";
            //
            // colCobrado
            //
            colCobrado.FillWeight = 90;
            colCobrado.HeaderText = "Cobrado";
            colCobrado.Name = "colCobrado";
            colCobrado.ReadOnly = true;
            colCobrado.Tag = "lb_repglobal_col_cobrado";
            //
            // colDeuda
            //
            colDeuda.FillWeight = 90;
            colDeuda.HeaderText = "Deuda vencida";
            colDeuda.Name = "colDeuda";
            colDeuda.ReadOnly = true;
            colDeuda.Tag = "lb_repglobal_col_deuda";
            //
            // colCobranza
            //
            colCobranza.FillWeight = 70;
            colCobranza.HeaderText = "Cobranza %";
            colCobranza.Name = "colCobranza";
            colCobranza.ReadOnly = true;
            colCobranza.Tag = "lb_repglobal_col_cobranza";
            //
            // colGastos
            //
            colGastos.FillWeight = 90;
            colGastos.HeaderText = "Gastos";
            colGastos.Name = "colGastos";
            colGastos.ReadOnly = true;
            colGastos.Tag = "lb_repglobal_col_gastos";
            //
            // colServicios
            //
            colServicios.FillWeight = 90;
            colServicios.HeaderText = "Servicios aprobados pendientes";
            colServicios.Name = "colServicios";
            colServicios.ReadOnly = true;
            colServicios.Tag = "lb_repglobal_col_servicios";
            //
            // colCostoServicios
            //
            colCostoServicios.FillWeight = 90;
            colCostoServicios.HeaderText = "Costo de esos servicios";
            colCostoServicios.Name = "colCostoServicios";
            colCostoServicios.ReadOnly = true;
            colCostoServicios.Tag = "lb_repglobal_col_costo_servicios";
            //
            // colEgresos
            //
            colEgresos.FillWeight = 90;
            colEgresos.HeaderText = "Egresos";
            colEgresos.Name = "colEgresos";
            colEgresos.ReadOnly = true;
            colEgresos.Tag = "lb_repglobal_col_egresos";
            //
            // colSaldo
            //
            colSaldo.FillWeight = 90;
            colSaldo.HeaderText = "Saldo del fondo";
            colSaldo.Name = "colSaldo";
            colSaldo.ReadOnly = true;
            colSaldo.Tag = "lb_repglobal_col_saldo";
            //
            // lblTotalExpensado
            //
            lblTotalExpensado.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalExpensado.AutoSize = true;
            lblTotalExpensado.Location = new System.Drawing.Point(12, 445);
            lblTotalExpensado.Name = "lblTotalExpensado";
            lblTotalExpensado.Size = new System.Drawing.Size(100, 15);
            lblTotalExpensado.TabIndex = 6;
            lblTotalExpensado.Tag = "lb_repglobal_total_expensado";
            lblTotalExpensado.Text = "Total expensado:";
            //
            // lblTotalCobrado
            //
            lblTotalCobrado.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalCobrado.AutoSize = true;
            lblTotalCobrado.Location = new System.Drawing.Point(252, 445);
            lblTotalCobrado.Name = "lblTotalCobrado";
            lblTotalCobrado.Size = new System.Drawing.Size(100, 15);
            lblTotalCobrado.TabIndex = 7;
            lblTotalCobrado.Tag = "lb_repglobal_total_cobrado";
            lblTotalCobrado.Text = "Total cobrado:";
            //
            // lblTotalDeuda
            //
            lblTotalDeuda.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalDeuda.AutoSize = true;
            lblTotalDeuda.Location = new System.Drawing.Point(492, 445);
            lblTotalDeuda.Name = "lblTotalDeuda";
            lblTotalDeuda.Size = new System.Drawing.Size(100, 15);
            lblTotalDeuda.TabIndex = 8;
            lblTotalDeuda.Tag = "lb_repglobal_total_deuda";
            lblTotalDeuda.Text = "Total deuda vencida:";
            //
            // lblTotalSaldo
            //
            lblTotalSaldo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalSaldo.AutoSize = true;
            lblTotalSaldo.Location = new System.Drawing.Point(732, 445);
            lblTotalSaldo.Name = "lblTotalSaldo";
            lblTotalSaldo.Size = new System.Drawing.Size(100, 15);
            lblTotalSaldo.TabIndex = 9;
            lblTotalSaldo.Tag = "lb_repglobal_total_saldo";
            lblTotalSaldo.Text = "Total saldo:";
            //
            // FormReporteGlobal_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1084, 475);
            Controls.Add(lblTotalSaldo);
            Controls.Add(lblTotalDeuda);
            Controls.Add(lblTotalCobrado);
            Controls.Add(lblTotalExpensado);
            Controls.Add(dgvGlobal);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnGenerar);
            Controls.Add(dtpHasta);
            Controls.Add(lblHasta);
            Controls.Add(dtpDesde);
            Controls.Add(lblDesde);
            Name = "FormReporteGlobal_755ME";
            HelpRequested += FormReporteGlobal_755ME_HelpRequested;
            Tag = "lb_reporte_global";
            Text = "Reporte global";
            FormClosing += FormReporteGlobal_755ME_FormClosing;
            Load += FormReporteGlobal_755ME_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGlobal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnExportarPdf;
        private System.Windows.Forms.DataGridView dgvGlobal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsorcio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpensado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCobrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeuda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCobranza;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServicios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoServicios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEgresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.Label lblTotalExpensado;
        private System.Windows.Forms.Label lblTotalCobrado;
        private System.Windows.Forms.Label lblTotalDeuda;
        private System.Windows.Forms.Label lblTotalSaldo;
    }
}

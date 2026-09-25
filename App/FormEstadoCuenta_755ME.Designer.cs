namespace AppBase
{
    partial class FormEstadoCuenta_755ME
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
            lblUnidad = new System.Windows.Forms.Label();
            cboUnidad = new System.Windows.Forms.ComboBox();
            btnEmitir = new System.Windows.Forms.Button();
            lblSaldo = new System.Windows.Forms.Label();
            dgvMovimientos = new System.Windows.Forms.DataGridView();
            colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
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
            lblSinConsorcios.Size = new System.Drawing.Size(0, 15);
            lblSinConsorcios.TabIndex = 2;
            //
            // lblUnidad
            //
            lblUnidad.AutoSize = true;
            lblUnidad.Location = new System.Drawing.Point(15, 50);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new System.Drawing.Size(140, 15);
            lblUnidad.TabIndex = 3;
            lblUnidad.Text = "Unidad funcional / consorcio:";
            lblUnidad.Tag = "lb_unidad_o_consorcio";
            //
            // cboUnidad
            //
            cboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboUnidad.Enabled = false;
            cboUnidad.FormattingEnabled = true;
            cboUnidad.Location = new System.Drawing.Point(160, 47);
            cboUnidad.Name = "cboUnidad";
            cboUnidad.Size = new System.Drawing.Size(250, 23);
            cboUnidad.TabIndex = 4;
            cboUnidad.SelectedIndexChanged += cboUnidad_SelectedIndexChanged;
            //
            // btnEmitir
            //
            btnEmitir.Enabled = false;
            btnEmitir.Location = new System.Drawing.Point(430, 46);
            btnEmitir.Name = "btnEmitir";
            btnEmitir.Size = new System.Drawing.Size(150, 25);
            btnEmitir.TabIndex = 5;
            btnEmitir.Text = "Emitir (PDF)";
            btnEmitir.Tag = "btn_emitir_pdf";
            btnEmitir.Click += btnEmitir_Click;
            //
            // lblSaldo
            //
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new System.Drawing.Point(15, 80);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new System.Drawing.Size(43, 15);
            lblSaldo.TabIndex = 6;
            lblSaldo.Text = "Saldo:";
            lblSaldo.Tag = "lb_saldo";
            //
            // dgvMovimientos
            //
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colTipo, colFecha, colDetalle, colMonto });
            dgvMovimientos.Location = new System.Drawing.Point(15, 105);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.Size = new System.Drawing.Size(760, 425);
            dgvMovimientos.TabIndex = 7;
            //
            // colTipo
            //
            colTipo.HeaderText = "Tipo";
            colTipo.Tag = "lb_col_tipo";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            //
            // colFecha
            //
            colFecha.HeaderText = "Fecha";
            colFecha.Tag = "lb_fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            //
            // colDetalle
            //
            colDetalle.HeaderText = "Detalle";
            colDetalle.Tag = "lb_detalle";
            colDetalle.Name = "colDetalle";
            colDetalle.ReadOnly = true;
            //
            // colMonto
            //
            colMonto.HeaderText = "Monto";
            colMonto.Tag = "lb_col_monto";
            colMonto.Name = "colMonto";
            colMonto.ReadOnly = true;
            //
            // saveFileDialog
            //
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            //
            // FormEstadoCuenta_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(790, 550);
            Controls.Add(dgvMovimientos);
            Controls.Add(lblSaldo);
            Controls.Add(btnEmitir);
            Controls.Add(cboUnidad);
            Controls.Add(lblUnidad);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(790, 500);
            Name = "FormEstadoCuenta_755ME";
            Text = "Estado de cuenta";
            Tag = "lb_estado_cuenta";
            Load += FormEstadoCuenta_755ME_Load;
            FormClosing += FormEstadoCuenta_755ME_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.ComboBox cboUnidad;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

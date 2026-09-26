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
            lblConsorcio = new Label();
            cboConsorcio = new ComboBox();
            lblSinConsorcios = new Label();
            lblUnidad = new Label();
            cboUnidad = new ComboBox();
            btnEmitir = new Button();
            lblSaldo = new Label();
            dgvMovimientos = new DataGridView();
            colTipo = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colDetalle = new DataGridViewTextBoxColumn();
            colMonto = new DataGridViewTextBoxColumn();
            saveFileDialog = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();
            // 
            // lblConsorcio
            // 
            lblConsorcio.AutoSize = true;
            lblConsorcio.Location = new Point(15, 18);
            lblConsorcio.Name = "lblConsorcio";
            lblConsorcio.Size = new Size(64, 15);
            lblConsorcio.TabIndex = 0;
            lblConsorcio.Tag = "lb_consorcio";
            lblConsorcio.Text = "Consorcio:";
            // 
            // cboConsorcio
            // 
            cboConsorcio.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConsorcio.FormattingEnabled = true;
            cboConsorcio.Location = new Point(110, 15);
            cboConsorcio.Name = "cboConsorcio";
            cboConsorcio.Size = new Size(300, 23);
            cboConsorcio.TabIndex = 1;
            cboConsorcio.SelectedIndexChanged += cboConsorcio_SelectedIndexChanged;
            // 
            // lblSinConsorcios
            // 
            lblSinConsorcios.AutoSize = true;
            lblSinConsorcios.ForeColor = Color.DarkRed;
            lblSinConsorcios.Location = new Point(430, 18);
            lblSinConsorcios.Name = "lblSinConsorcios";
            lblSinConsorcios.Size = new Size(0, 15);
            lblSinConsorcios.TabIndex = 2;
            // 
            // lblUnidad
            // 
            lblUnidad.AutoSize = true;
            lblUnidad.Location = new Point(15, 50);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new Size(164, 15);
            lblUnidad.TabIndex = 3;
            lblUnidad.Tag = "lb_unidad_o_consorcio";
            lblUnidad.Text = "Unidad funcional / consorcio:";
            // 
            // cboUnidad
            // 
            cboUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnidad.Enabled = false;
            cboUnidad.FormattingEnabled = true;
            cboUnidad.Location = new Point(181, 46);
            cboUnidad.Name = "cboUnidad";
            cboUnidad.Size = new Size(250, 23);
            cboUnidad.TabIndex = 4;
            cboUnidad.SelectedIndexChanged += cboUnidad_SelectedIndexChanged;
            // 
            // btnEmitir
            // 
            btnEmitir.Enabled = false;
            btnEmitir.Location = new Point(451, 45);
            btnEmitir.Name = "btnEmitir";
            btnEmitir.Size = new Size(150, 25);
            btnEmitir.TabIndex = 5;
            btnEmitir.Tag = "btn_emitir_pdf";
            btnEmitir.Text = "Emitir (PDF)";
            btnEmitir.Click += btnEmitir_Click;
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(15, 80);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(39, 15);
            lblSaldo.TabIndex = 6;
            lblSaldo.Tag = "lb_saldo";
            lblSaldo.Text = "Saldo:";
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMovimientos.Columns.AddRange(new DataGridViewColumn[] { colTipo, colFecha, colDetalle, colMonto });
            dgvMovimientos.Location = new Point(15, 105);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.Size = new Size(760, 425);
            dgvMovimientos.TabIndex = 7;
            // 
            // colTipo
            // 
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colDetalle
            // 
            colDetalle.HeaderText = "Detalle";
            colDetalle.Name = "colDetalle";
            colDetalle.ReadOnly = true;
            // 
            // colMonto
            // 
            colMonto.HeaderText = "Monto";
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 550);
            Controls.Add(dgvMovimientos);
            Controls.Add(lblSaldo);
            Controls.Add(btnEmitir);
            Controls.Add(cboUnidad);
            Controls.Add(lblUnidad);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new Size(790, 500);
            Name = "FormEstadoCuenta_755ME";
            Tag = "lb_estado_cuenta";
            Text = "Estado de cuenta";
            FormClosing += FormEstadoCuenta_755ME_FormClosing;
            Load += FormEstadoCuenta_755ME_Load;
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

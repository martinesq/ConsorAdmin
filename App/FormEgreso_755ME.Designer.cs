namespace AppBase
{
    partial class FormEgreso_755ME
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
            colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblSinServicios = new System.Windows.Forms.Label();
            grpInsumo = new System.Windows.Forms.GroupBox();
            lblConcepto = new System.Windows.Forms.Label();
            txtConcepto = new System.Windows.Forms.TextBox();
            lblMonto = new System.Windows.Forms.Label();
            numMonto = new System.Windows.Forms.NumericUpDown();
            lblSaldoDisponible = new System.Windows.Forms.Label();
            btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
            grpInsumo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMonto).BeginInit();
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
            dgvServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colCategoria, colDescripcion, colCosto });
            dgvServicios.Location = new System.Drawing.Point(15, 50);
            dgvServicios.MultiSelect = false;
            dgvServicios.Name = "dgvServicios";
            dgvServicios.ReadOnly = true;
            dgvServicios.RowHeadersVisible = false;
            dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvServicios.Size = new System.Drawing.Size(760, 180);
            dgvServicios.TabIndex = 3;
            dgvServicios.SelectionChanged += dgvServicios_SelectionChanged;
            //
            // colCategoria
            //
            colCategoria.HeaderText = "Categoría";
            colCategoria.Tag = "lb_col_categoria";
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            //
            // colDescripcion
            //
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Tag = "lb_col_descripcion";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            //
            // colCosto
            //
            colCosto.HeaderText = "Costo";
            colCosto.Tag = "lb_col_costo";
            colCosto.Name = "colCosto";
            colCosto.ReadOnly = true;
            //
            // lblSinServicios
            //
            lblSinServicios.AutoSize = true;
            lblSinServicios.ForeColor = System.Drawing.Color.DarkRed;
            lblSinServicios.Location = new System.Drawing.Point(15, 235);
            lblSinServicios.Name = "lblSinServicios";
            lblSinServicios.Size = new System.Drawing.Size(0, 15);
            lblSinServicios.TabIndex = 4;
            //
            // grpInsumo
            //
            grpInsumo.Controls.Add(numMonto);
            grpInsumo.Controls.Add(lblMonto);
            grpInsumo.Controls.Add(txtConcepto);
            grpInsumo.Controls.Add(lblConcepto);
            grpInsumo.Location = new System.Drawing.Point(15, 255);
            grpInsumo.Name = "grpInsumo";
            grpInsumo.Size = new System.Drawing.Size(760, 90);
            grpInsumo.TabIndex = 5;
            grpInsumo.TabStop = false;
            grpInsumo.Text = "Compra de insumo (si no se selecciona un servicio aprobado)";
            grpInsumo.Tag = "lb_grp_insumo";
            //
            // lblConcepto
            //
            lblConcepto.AutoSize = true;
            lblConcepto.Location = new System.Drawing.Point(15, 28);
            lblConcepto.Name = "lblConcepto";
            lblConcepto.Size = new System.Drawing.Size(58, 15);
            lblConcepto.TabIndex = 0;
            lblConcepto.Text = "Concepto:";
            lblConcepto.Tag = "lb_concepto";
            //
            // txtConcepto
            //
            txtConcepto.Location = new System.Drawing.Point(110, 25);
            txtConcepto.Name = "txtConcepto";
            txtConcepto.Size = new System.Drawing.Size(400, 23);
            txtConcepto.TabIndex = 1;
            txtConcepto.TextChanged += txtConcepto_TextChanged;
            //
            // lblMonto
            //
            lblMonto.AutoSize = true;
            lblMonto.Location = new System.Drawing.Point(530, 28);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new System.Drawing.Size(46, 15);
            lblMonto.TabIndex = 2;
            lblMonto.Text = "Monto:";
            lblMonto.Tag = "lb_monto";
            //
            // numMonto
            //
            numMonto.DecimalPlaces = 2;
            numMonto.Location = new System.Drawing.Point(590, 25);
            numMonto.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numMonto.Name = "numMonto";
            numMonto.Size = new System.Drawing.Size(150, 23);
            numMonto.TabIndex = 3;
            numMonto.ValueChanged += numMonto_ValueChanged;
            numMonto.TextChanged += numMonto_TextChanged;
            //
            // lblSaldoDisponible
            //
            lblSaldoDisponible.AutoSize = true;
            lblSaldoDisponible.Location = new System.Drawing.Point(15, 360);
            lblSaldoDisponible.Name = "lblSaldoDisponible";
            lblSaldoDisponible.Size = new System.Drawing.Size(120, 15);
            lblSaldoDisponible.TabIndex = 6;
            lblSaldoDisponible.Text = "Saldo disponible:";
            lblSaldoDisponible.Tag = "lb_saldo_disponible";
            //
            // btnConfirmar
            //
            btnConfirmar.Enabled = false;
            btnConfirmar.Location = new System.Drawing.Point(15, 390);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new System.Drawing.Size(180, 28);
            btnConfirmar.TabIndex = 7;
            btnConfirmar.Text = "Confirmar egreso";
            btnConfirmar.Tag = "btn_confirmar_egreso";
            btnConfirmar.Click += btnConfirmar_Click;
            //
            // FormEgreso_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(790, 450);
            Controls.Add(btnConfirmar);
            Controls.Add(lblSaldoDisponible);
            Controls.Add(grpInsumo);
            Controls.Add(lblSinServicios);
            Controls.Add(dgvServicios);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(790, 480);
            Name = "FormEgreso_755ME";
            HelpRequested += FormEgreso_755ME_HelpRequested;
            Text = "Registrar egreso a proveedor";
            Tag = "lb_registrar_egreso";
            Load += FormEgreso_755ME_Load;
            FormClosing += FormEgreso_755ME_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvServicios).EndInit();
            grpInsumo.ResumeLayout(false);
            grpInsumo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCosto;
        private System.Windows.Forms.Label lblSinServicios;
        private System.Windows.Forms.GroupBox grpInsumo;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Label lblSaldoDisponible;
        private System.Windows.Forms.Button btnConfirmar;
    }
}

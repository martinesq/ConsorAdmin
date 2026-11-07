namespace AppBase
{
    partial class FormGasto_755ME
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
            dgvGastos = new System.Windows.Forms.DataGridView();
            colPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colRubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpNuevoGasto = new System.Windows.Forms.GroupBox();
            btnGuardar = new System.Windows.Forms.Button();
            numMonto = new System.Windows.Forms.NumericUpDown();
            lblMonto = new System.Windows.Forms.Label();
            dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            lblPeriodo = new System.Windows.Forms.Label();
            txtRubro = new System.Windows.Forms.TextBox();
            lblRubro = new System.Windows.Forms.Label();
            txtDescripcion = new System.Windows.Forms.TextBox();
            lblDescripcion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvGastos).BeginInit();
            grpNuevoGasto.SuspendLayout();
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
            // dgvGastos
            //
            dgvGastos.AllowUserToAddRows = false;
            dgvGastos.AllowUserToDeleteRows = false;
            dgvGastos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colPeriodo, colDescripcion, colRubro, colMonto });
            dgvGastos.Location = new System.Drawing.Point(15, 50);
            dgvGastos.Name = "dgvGastos";
            dgvGastos.ReadOnly = true;
            dgvGastos.RowHeadersVisible = false;
            dgvGastos.Size = new System.Drawing.Size(760, 300);
            dgvGastos.TabIndex = 3;
            //
            // colPeriodo
            //
            colPeriodo.HeaderText = "Periodo";
            colPeriodo.Tag = "lb_col_periodo";
            colPeriodo.Name = "colPeriodo";
            colPeriodo.ReadOnly = true;
            //
            // colDescripcion
            //
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Tag = "lb_col_descripcion";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            //
            // colRubro
            //
            colRubro.HeaderText = "Rubro";
            colRubro.Tag = "lb_col_rubro";
            colRubro.Name = "colRubro";
            colRubro.ReadOnly = true;
            //
            // colMonto
            //
            colMonto.HeaderText = "Monto";
            colMonto.Tag = "lb_col_monto";
            colMonto.Name = "colMonto";
            colMonto.ReadOnly = true;
            //
            // grpNuevoGasto
            //
            grpNuevoGasto.Controls.Add(btnGuardar);
            grpNuevoGasto.Controls.Add(numMonto);
            grpNuevoGasto.Controls.Add(lblMonto);
            grpNuevoGasto.Controls.Add(dtpPeriodo);
            grpNuevoGasto.Controls.Add(lblPeriodo);
            grpNuevoGasto.Controls.Add(txtRubro);
            grpNuevoGasto.Controls.Add(lblRubro);
            grpNuevoGasto.Controls.Add(txtDescripcion);
            grpNuevoGasto.Controls.Add(lblDescripcion);
            grpNuevoGasto.Enabled = false;
            grpNuevoGasto.Location = new System.Drawing.Point(15, 360);
            grpNuevoGasto.Name = "grpNuevoGasto";
            grpNuevoGasto.Size = new System.Drawing.Size(760, 130);
            grpNuevoGasto.TabIndex = 4;
            grpNuevoGasto.TabStop = false;
            grpNuevoGasto.Text = "Nuevo gasto";
            grpNuevoGasto.Tag = "lb_grp_nuevo_gasto";
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new System.Drawing.Point(15, 28);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new System.Drawing.Size(72, 15);
            lblDescripcion.TabIndex = 0;
            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Tag = "lb_descripcion";
            //
            // txtDescripcion
            //
            txtDescripcion.Location = new System.Drawing.Point(110, 25);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new System.Drawing.Size(300, 23);
            txtDescripcion.TabIndex = 1;
            //
            // lblRubro
            //
            lblRubro.AutoSize = true;
            lblRubro.Location = new System.Drawing.Point(430, 28);
            lblRubro.Name = "lblRubro";
            lblRubro.Size = new System.Drawing.Size(40, 15);
            lblRubro.TabIndex = 2;
            lblRubro.Text = "Rubro:";
            lblRubro.Tag = "lb_rubro";
            //
            // txtRubro
            //
            txtRubro.Location = new System.Drawing.Point(480, 25);
            txtRubro.Name = "txtRubro";
            txtRubro.Size = new System.Drawing.Size(200, 23);
            txtRubro.TabIndex = 3;
            //
            // lblPeriodo
            //
            lblPeriodo.AutoSize = true;
            lblPeriodo.Location = new System.Drawing.Point(15, 60);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new System.Drawing.Size(52, 15);
            lblPeriodo.TabIndex = 4;
            lblPeriodo.Text = "Periodo:";
            lblPeriodo.Tag = "lb_periodo";
            //
            // dtpPeriodo
            //
            dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "MM/yyyy";
            dtpPeriodo.Location = new System.Drawing.Point(110, 57);
            dtpPeriodo.Name = "dtpPeriodo";
            dtpPeriodo.Size = new System.Drawing.Size(150, 23);
            dtpPeriodo.TabIndex = 5;
            //
            // lblMonto
            //
            lblMonto.AutoSize = true;
            lblMonto.Location = new System.Drawing.Point(430, 60);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new System.Drawing.Size(46, 15);
            lblMonto.TabIndex = 6;
            lblMonto.Text = "Monto:";
            lblMonto.Tag = "lb_monto";
            //
            // numMonto
            //
            numMonto.DecimalPlaces = 2;
            numMonto.Location = new System.Drawing.Point(480, 57);
            numMonto.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numMonto.Name = "numMonto";
            numMonto.Size = new System.Drawing.Size(200, 23);
            numMonto.TabIndex = 7;
            //
            // btnGuardar
            //
            btnGuardar.Location = new System.Drawing.Point(15, 90);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(150, 28);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.Tag = "btn_guardar";
            btnGuardar.Click += btnGuardar_Click;
            //
            // FormGasto_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(790, 510);
            Controls.Add(grpNuevoGasto);
            Controls.Add(dgvGastos);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(790, 500);
            Name = "FormGasto_755ME";
            Text = "Gastos";
            Tag = "lb_gastos";
            Load += FormGasto_755ME_Load;
            FormClosing += FormGasto_755ME_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvGastos).EndInit();
            grpNuevoGasto.ResumeLayout(false);
            grpNuevoGasto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.DataGridView dgvGastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.GroupBox grpNuevoGasto;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.TextBox txtRubro;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpPeriodo;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Button btnGuardar;
    }
}

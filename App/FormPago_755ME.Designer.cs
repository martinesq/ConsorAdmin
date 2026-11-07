namespace AppBase
{
    partial class FormPago_755ME
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
            lblUnidad = new System.Windows.Forms.Label();
            cboUnidad = new System.Windows.Forms.ComboBox();
            lblSinConsorcios = new System.Windows.Forms.Label();
            dgvExpensasPendientes = new System.Windows.Forms.DataGridView();
            colPagoPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPagoMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPagoVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPagoEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblSinExpensaPendiente = new System.Windows.Forms.Label();
            grpExpensa = new System.Windows.Forms.GroupBox();
            lblMontoExpensa = new System.Windows.Forms.Label();
            lblVencimientoExpensa = new System.Windows.Forms.Label();
            lblEstadoExpensa = new System.Windows.Forms.Label();
            grpPago = new System.Windows.Forms.GroupBox();
            lblMonto = new System.Windows.Forms.Label();
            numMonto = new System.Windows.Forms.NumericUpDown();
            lblMedio = new System.Windows.Forms.Label();
            cboMedio = new System.Windows.Forms.ComboBox();
            btnRegistrarPago = new System.Windows.Forms.Button();
            lblResultado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvExpensasPendientes).BeginInit();
            grpExpensa.SuspendLayout();
            grpPago.SuspendLayout();
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
            // lblUnidad
            //
            lblUnidad.AutoSize = true;
            lblUnidad.Location = new System.Drawing.Point(430, 18);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new System.Drawing.Size(85, 15);
            lblUnidad.TabIndex = 2;
            lblUnidad.Text = "Unidad funcional:";
            lblUnidad.Tag = "lb_unidad";
            //
            // cboUnidad
            //
            cboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboUnidad.Enabled = false;
            cboUnidad.FormattingEnabled = true;
            cboUnidad.Location = new System.Drawing.Point(525, 15);
            cboUnidad.Name = "cboUnidad";
            cboUnidad.Size = new System.Drawing.Size(180, 23);
            cboUnidad.TabIndex = 3;
            cboUnidad.SelectedIndexChanged += cboUnidad_SelectedIndexChanged;
            //
            // lblSinConsorcios
            //
            lblSinConsorcios.AutoSize = true;
            lblSinConsorcios.ForeColor = System.Drawing.Color.DarkRed;
            lblSinConsorcios.Location = new System.Drawing.Point(110, 45);
            lblSinConsorcios.Name = "lblSinConsorcios";
            lblSinConsorcios.Tag = "lb_sin_consorcios";
            lblSinConsorcios.Text = "No tiene consorcios asignados";
            lblSinConsorcios.Size = new System.Drawing.Size(0, 15);
            lblSinConsorcios.TabIndex = 4;
            //
            // dgvExpensasPendientes
            //
            dgvExpensasPendientes.AllowUserToAddRows = false;
            dgvExpensasPendientes.AllowUserToDeleteRows = false;
            dgvExpensasPendientes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvExpensasPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colPagoPeriodo, colPagoMonto, colPagoVencimiento, colPagoEstado });
            dgvExpensasPendientes.Location = new System.Drawing.Point(15, 60);
            dgvExpensasPendientes.MultiSelect = false;
            dgvExpensasPendientes.Name = "dgvExpensasPendientes";
            dgvExpensasPendientes.ReadOnly = true;
            dgvExpensasPendientes.RowHeadersVisible = false;
            dgvExpensasPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvExpensasPendientes.Size = new System.Drawing.Size(690, 150);
            dgvExpensasPendientes.TabIndex = 5;
            dgvExpensasPendientes.SelectionChanged += dgvExpensasPendientes_SelectionChanged;
            //
            // colPagoPeriodo
            //
            colPagoPeriodo.HeaderText = "Periodo";
            colPagoPeriodo.Tag = "lb_col_periodo";
            colPagoPeriodo.Name = "colPagoPeriodo";
            colPagoPeriodo.ReadOnly = true;
            //
            // colPagoMonto
            //
            colPagoMonto.HeaderText = "Monto";
            colPagoMonto.Tag = "lb_col_monto";
            colPagoMonto.Name = "colPagoMonto";
            colPagoMonto.ReadOnly = true;
            //
            // colPagoVencimiento
            //
            colPagoVencimiento.HeaderText = "Vencimiento";
            colPagoVencimiento.Tag = "lb_col_vencimiento";
            colPagoVencimiento.Name = "colPagoVencimiento";
            colPagoVencimiento.ReadOnly = true;
            //
            // colPagoEstado
            //
            colPagoEstado.HeaderText = "Estado";
            colPagoEstado.Tag = "lb_col_estado";
            colPagoEstado.Name = "colPagoEstado";
            colPagoEstado.ReadOnly = true;
            //
            // lblSinExpensaPendiente
            //
            lblSinExpensaPendiente.AutoSize = true;
            lblSinExpensaPendiente.ForeColor = System.Drawing.Color.DarkRed;
            lblSinExpensaPendiente.Location = new System.Drawing.Point(15, 215);
            lblSinExpensaPendiente.Name = "lblSinExpensaPendiente";
            lblSinExpensaPendiente.Size = new System.Drawing.Size(0, 15);
            lblSinExpensaPendiente.TabIndex = 6;
            //
            // grpExpensa
            //
            grpExpensa.Controls.Add(lblEstadoExpensa);
            grpExpensa.Controls.Add(lblVencimientoExpensa);
            grpExpensa.Controls.Add(lblMontoExpensa);
            grpExpensa.Location = new System.Drawing.Point(15, 235);
            grpExpensa.Name = "grpExpensa";
            grpExpensa.Size = new System.Drawing.Size(690, 90);
            grpExpensa.TabIndex = 7;
            grpExpensa.TabStop = false;
            grpExpensa.Text = "Expensa seleccionada";
            grpExpensa.Tag = "lb_grp_expensa_sel";
            //
            // lblMontoExpensa
            //
            lblMontoExpensa.AutoSize = true;
            lblMontoExpensa.Location = new System.Drawing.Point(15, 22);
            lblMontoExpensa.Name = "lblMontoExpensa";
            lblMontoExpensa.Size = new System.Drawing.Size(46, 15);
            lblMontoExpensa.TabIndex = 0;
            lblMontoExpensa.Text = "Monto:";
            lblMontoExpensa.Tag = "lb_monto";
            //
            // lblVencimientoExpensa
            //
            lblVencimientoExpensa.AutoSize = true;
            lblVencimientoExpensa.Location = new System.Drawing.Point(15, 45);
            lblVencimientoExpensa.Name = "lblVencimientoExpensa";
            lblVencimientoExpensa.Size = new System.Drawing.Size(84, 15);
            lblVencimientoExpensa.TabIndex = 1;
            lblVencimientoExpensa.Text = "Vencimiento:";
            lblVencimientoExpensa.Tag = "lb_vencimiento";
            //
            // lblEstadoExpensa
            //
            lblEstadoExpensa.AutoSize = true;
            lblEstadoExpensa.Location = new System.Drawing.Point(15, 68);
            lblEstadoExpensa.Name = "lblEstadoExpensa";
            lblEstadoExpensa.Size = new System.Drawing.Size(48, 15);
            lblEstadoExpensa.TabIndex = 2;
            lblEstadoExpensa.Text = "Estado:";
            lblEstadoExpensa.Tag = "lb_estado";
            //
            // grpPago
            //
            grpPago.Controls.Add(btnRegistrarPago);
            grpPago.Controls.Add(cboMedio);
            grpPago.Controls.Add(lblMedio);
            grpPago.Controls.Add(numMonto);
            grpPago.Controls.Add(lblMonto);
            grpPago.Enabled = false;
            grpPago.Location = new System.Drawing.Point(15, 335);
            grpPago.Name = "grpPago";
            grpPago.Size = new System.Drawing.Size(690, 110);
            grpPago.TabIndex = 8;
            grpPago.TabStop = false;
            grpPago.Text = "Registrar pago";
            grpPago.Tag = "lb_registrar_pago";
            //
            // lblMonto
            //
            lblMonto.AutoSize = true;
            lblMonto.Location = new System.Drawing.Point(15, 28);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new System.Drawing.Size(46, 15);
            lblMonto.TabIndex = 0;
            lblMonto.Text = "Monto:";
            lblMonto.Tag = "lb_monto";
            //
            // numMonto
            //
            numMonto.DecimalPlaces = 2;
            numMonto.Location = new System.Drawing.Point(110, 26);
            numMonto.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numMonto.Name = "numMonto";
            numMonto.Size = new System.Drawing.Size(150, 23);
            numMonto.TabIndex = 1;
            //
            // lblMedio
            //
            lblMedio.AutoSize = true;
            lblMedio.Location = new System.Drawing.Point(280, 28);
            lblMedio.Name = "lblMedio";
            lblMedio.Size = new System.Drawing.Size(89, 15);
            lblMedio.TabIndex = 2;
            lblMedio.Text = "Medio de pago:";
            lblMedio.Tag = "lb_medio_pago";
            //
            // cboMedio
            //
            cboMedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboMedio.Items.AddRange(new object[] { "Efectivo", "Transferencia", "Débito", "Cheque" });
            cboMedio.Location = new System.Drawing.Point(380, 25);
            cboMedio.Name = "cboMedio";
            cboMedio.Size = new System.Drawing.Size(150, 23);
            cboMedio.TabIndex = 3;
            //
            // btnRegistrarPago
            //
            btnRegistrarPago.Location = new System.Drawing.Point(110, 65);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new System.Drawing.Size(150, 28);
            btnRegistrarPago.TabIndex = 4;
            btnRegistrarPago.Text = "Registrar pago";
            btnRegistrarPago.Tag = "lb_registrar_pago";
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            //
            // lblResultado
            //
            lblResultado.AutoSize = true;
            lblResultado.Location = new System.Drawing.Point(15, 455);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new System.Drawing.Size(0, 15);
            lblResultado.TabIndex = 9;
            //
            // FormPago_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(720, 500);
            Controls.Add(lblResultado);
            Controls.Add(grpPago);
            Controls.Add(grpExpensa);
            Controls.Add(lblSinExpensaPendiente);
            Controls.Add(dgvExpensasPendientes);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboUnidad);
            Controls.Add(lblUnidad);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(720, 500);
            Name = "FormPago_755ME";
            Text = "Registrar pago";
            Tag = "lb_registrar_pago";
            Load += FormPago_755ME_Load;
            FormClosing += FormPago_755ME_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvExpensasPendientes).EndInit();
            grpExpensa.ResumeLayout(false);
            grpExpensa.PerformLayout();
            grpPago.ResumeLayout(false);
            grpPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.ComboBox cboUnidad;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.DataGridView dgvExpensasPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagoPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagoMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagoVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPagoEstado;
        private System.Windows.Forms.GroupBox grpExpensa;
        private System.Windows.Forms.Label lblMontoExpensa;
        private System.Windows.Forms.Label lblVencimientoExpensa;
        private System.Windows.Forms.Label lblEstadoExpensa;
        private System.Windows.Forms.Label lblSinExpensaPendiente;
        private System.Windows.Forms.GroupBox grpPago;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Label lblMedio;
        private System.Windows.Forms.ComboBox cboMedio;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Label lblResultado;
    }
}

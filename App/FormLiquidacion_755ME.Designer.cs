namespace AppBase
{
    partial class FormLiquidacion_755ME
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
            lblPeriodo = new System.Windows.Forms.Label();
            cboPeriodo = new System.Windows.Forms.ComboBox();
            lblSinPeriodos = new System.Windows.Forms.Label();
            grpLiquidacion = new System.Windows.Forms.GroupBox();
            lblTotalGastos = new System.Windows.Forms.Label();
            lblVencimiento = new System.Windows.Forms.Label();
            dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            lblHonorario = new System.Windows.Forms.Label();
            numHonorario = new System.Windows.Forms.NumericUpDown();
            btnGenerar = new System.Windows.Forms.Button();
            dgvResultado = new System.Windows.Forms.DataGridView();
            colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHonorarioAplicado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colRecargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpLiquidacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHonorario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultado).BeginInit();
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
            // lblPeriodo
            //
            lblPeriodo.AutoSize = true;
            lblPeriodo.Location = new System.Drawing.Point(15, 50);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new System.Drawing.Size(52, 15);
            lblPeriodo.TabIndex = 3;
            lblPeriodo.Text = "Periodo:";
            lblPeriodo.Tag = "lb_periodo";
            //
            // cboPeriodo
            //
            cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPeriodo.Enabled = false;
            cboPeriodo.FormattingEnabled = true;
            cboPeriodo.Location = new System.Drawing.Point(110, 47);
            cboPeriodo.Name = "cboPeriodo";
            cboPeriodo.Size = new System.Drawing.Size(150, 23);
            cboPeriodo.TabIndex = 4;
            cboPeriodo.SelectedIndexChanged += cboPeriodo_SelectedIndexChanged;
            //
            // lblSinPeriodos
            //
            lblSinPeriodos.AutoSize = true;
            lblSinPeriodos.ForeColor = System.Drawing.Color.DarkRed;
            lblSinPeriodos.Location = new System.Drawing.Point(270, 50);
            lblSinPeriodos.Name = "lblSinPeriodos";
            lblSinPeriodos.Size = new System.Drawing.Size(0, 15);
            lblSinPeriodos.TabIndex = 5;
            //
            // grpLiquidacion
            //
            grpLiquidacion.Controls.Add(btnGenerar);
            grpLiquidacion.Controls.Add(numHonorario);
            grpLiquidacion.Controls.Add(lblHonorario);
            grpLiquidacion.Controls.Add(dtpVencimiento);
            grpLiquidacion.Controls.Add(lblVencimiento);
            grpLiquidacion.Controls.Add(lblTotalGastos);
            grpLiquidacion.Enabled = false;
            grpLiquidacion.Location = new System.Drawing.Point(15, 80);
            grpLiquidacion.Name = "grpLiquidacion";
            grpLiquidacion.Size = new System.Drawing.Size(760, 110);
            grpLiquidacion.TabIndex = 6;
            grpLiquidacion.TabStop = false;
            grpLiquidacion.Text = "Liquidación";
            grpLiquidacion.Tag = "lb_grp_liquidacion";
            //
            // lblTotalGastos
            //
            lblTotalGastos.AutoSize = true;
            lblTotalGastos.Location = new System.Drawing.Point(15, 25);
            lblTotalGastos.Name = "lblTotalGastos";
            lblTotalGastos.Size = new System.Drawing.Size(120, 15);
            lblTotalGastos.TabIndex = 0;
            lblTotalGastos.Text = "Total de gastos:";
            lblTotalGastos.Tag = "lb_total_gastos";
            //
            // lblVencimiento
            //
            lblVencimiento.AutoSize = true;
            lblVencimiento.Location = new System.Drawing.Point(15, 55);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new System.Drawing.Size(120, 15);
            lblVencimiento.TabIndex = 1;
            lblVencimiento.Text = "Fecha de vencimiento:";
            lblVencimiento.Tag = "lb_fecha_vencimiento";
            //
            // dtpVencimiento
            //
            dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpVencimiento.Location = new System.Drawing.Point(160, 52);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new System.Drawing.Size(150, 23);
            dtpVencimiento.TabIndex = 2;
            //
            // lblHonorario
            //
            lblHonorario.AutoSize = true;
            lblHonorario.Location = new System.Drawing.Point(340, 55);
            lblHonorario.Name = "lblHonorario";
            lblHonorario.Size = new System.Drawing.Size(130, 15);
            lblHonorario.TabIndex = 3;
            lblHonorario.Text = "% de honorario:";
            lblHonorario.Tag = "lb_pct_honorario";
            //
            // numHonorario
            //
            numHonorario.DecimalPlaces = 2;
            numHonorario.Location = new System.Drawing.Point(480, 53);
            numHonorario.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numHonorario.Name = "numHonorario";
            numHonorario.Size = new System.Drawing.Size(100, 23);
            numHonorario.TabIndex = 4;
            //
            // btnGenerar
            //
            btnGenerar.Location = new System.Drawing.Point(15, 80);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new System.Drawing.Size(180, 25);
            btnGenerar.TabIndex = 5;
            btnGenerar.Text = "Generar liquidación";
            btnGenerar.Tag = "btn_generar_liq";
            btnGenerar.Click += btnGenerar_Click;
            //
            // dgvResultado
            //
            dgvResultado.AllowUserToAddRows = false;
            dgvResultado.AllowUserToDeleteRows = false;
            dgvResultado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colUnidad, colMonto, colHonorarioAplicado, colRecargo, colEstado });
            dgvResultado.Location = new System.Drawing.Point(15, 200);
            dgvResultado.Name = "dgvResultado";
            dgvResultado.ReadOnly = true;
            dgvResultado.RowHeadersVisible = false;
            dgvResultado.Size = new System.Drawing.Size(760, 330);
            dgvResultado.TabIndex = 7;
            //
            // colUnidad
            //
            colUnidad.HeaderText = "Unidad funcional";
            colUnidad.Tag = "lb_unidad_funcional";
            colUnidad.Name = "colUnidad";
            colUnidad.ReadOnly = true;
            //
            // colMonto
            //
            colMonto.HeaderText = "Monto";
            colMonto.Tag = "lb_col_monto";
            colMonto.Name = "colMonto";
            colMonto.ReadOnly = true;
            //
            // colHonorarioAplicado
            //
            colHonorarioAplicado.HeaderText = "Honorario aplicado";
            colHonorarioAplicado.Tag = "lb_col_honorario";
            colHonorarioAplicado.Name = "colHonorarioAplicado";
            colHonorarioAplicado.ReadOnly = true;
            //
            // colRecargo
            //
            colRecargo.HeaderText = "Recargo por mora";
            colRecargo.Tag = "lb_col_recargo";
            colRecargo.Name = "colRecargo";
            colRecargo.ReadOnly = true;
            //
            // colEstado
            //
            colEstado.HeaderText = "Estado";
            colEstado.Tag = "lb_col_estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            //
            // FormLiquidacion_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(790, 550);
            Controls.Add(dgvResultado);
            Controls.Add(grpLiquidacion);
            Controls.Add(lblSinPeriodos);
            Controls.Add(cboPeriodo);
            Controls.Add(lblPeriodo);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(790, 500);
            Name = "FormLiquidacion_755ME";
            Text = "Generar liquidación de expensas";
            Tag = "lb_generar_liquidacion";
            Load += FormLiquidacion_755ME_Load;
            FormClosing += FormLiquidacion_755ME_FormClosing;
            grpLiquidacion.ResumeLayout(false);
            grpLiquidacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numHonorario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultado).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label lblSinPeriodos;
        private System.Windows.Forms.GroupBox grpLiquidacion;
        private System.Windows.Forms.Label lblTotalGastos;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Label lblHonorario;
        private System.Windows.Forms.NumericUpDown numHonorario;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHonorarioAplicado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}

namespace AppBase
{
    partial class FormExpensa_755ME
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
            tabExpensa = new System.Windows.Forms.TabControl();
            tabAnular = new System.Windows.Forms.TabPage();
            lblConsorcioAnular = new System.Windows.Forms.Label();
            cboConsorcioAnular = new System.Windows.Forms.ComboBox();
            dgvAnulables = new System.Windows.Forms.DataGridView();
            colAnularPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAnularMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAnularVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAnularEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpMotivo = new System.Windows.Forms.GroupBox();
            lblMotivo = new System.Windows.Forms.Label();
            txtMotivo = new System.Windows.Forms.TextBox();
            btnAnular = new System.Windows.Forms.Button();
            lblSinConsorciosAnular = new System.Windows.Forms.Label();
            tabComposicion = new System.Windows.Forms.TabPage();
            lblConsorcioComposicion = new System.Windows.Forms.Label();
            cboConsorcioComposicion = new System.Windows.Forms.ComboBox();
            lblUnidad = new System.Windows.Forms.Label();
            cboUnidad = new System.Windows.Forms.ComboBox();
            dgvLiquidadas = new System.Windows.Forms.DataGridView();
            colLiqPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLiqMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLiqVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLiqEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grpComposicion = new System.Windows.Forms.GroupBox();
            dgvGastos = new System.Windows.Forms.DataGridView();
            colGastoDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colGastoMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colGastoRubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblHonorarioAplicado = new System.Windows.Forms.Label();
            lblCoeficienteAplicado = new System.Windows.Forms.Label();
            lblRecargoPorMora = new System.Windows.Forms.Label();
            lblSinConsorciosComposicion = new System.Windows.Forms.Label();
            tabExpensa.SuspendLayout();
            tabAnular.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnulables).BeginInit();
            grpMotivo.SuspendLayout();
            tabComposicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLiquidadas).BeginInit();
            grpComposicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGastos).BeginInit();
            SuspendLayout();
            //
            // tabExpensa
            //
            tabExpensa.Controls.Add(tabAnular);
            tabExpensa.Controls.Add(tabComposicion);
            tabExpensa.Dock = System.Windows.Forms.DockStyle.Fill;
            tabExpensa.Location = new System.Drawing.Point(0, 0);
            tabExpensa.Name = "tabExpensa";
            tabExpensa.SelectedIndex = 0;
            tabExpensa.Size = new System.Drawing.Size(1000, 650);
            tabExpensa.TabIndex = 0;
            //
            // tabAnular
            //
            tabAnular.Controls.Add(lblSinConsorciosAnular);
            tabAnular.Controls.Add(grpMotivo);
            tabAnular.Controls.Add(dgvAnulables);
            tabAnular.Controls.Add(cboConsorcioAnular);
            tabAnular.Controls.Add(lblConsorcioAnular);
            tabAnular.Location = new System.Drawing.Point(4, 24);
            tabAnular.Name = "tabAnular";
            tabAnular.Padding = new System.Windows.Forms.Padding(10);
            tabAnular.Size = new System.Drawing.Size(992, 622);
            tabAnular.TabIndex = 0;
            tabAnular.Text = "Anular expensa";
            tabAnular.Tag = "lb_anular_expensa";
            //
            // lblConsorcioAnular
            //
            lblConsorcioAnular.AutoSize = true;
            lblConsorcioAnular.Location = new System.Drawing.Point(13, 15);
            lblConsorcioAnular.Name = "lblConsorcioAnular";
            lblConsorcioAnular.Size = new System.Drawing.Size(63, 15);
            lblConsorcioAnular.TabIndex = 0;
            lblConsorcioAnular.Text = "Consorcio:";
            lblConsorcioAnular.Tag = "lb_consorcio";
            //
            // cboConsorcioAnular
            //
            cboConsorcioAnular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboConsorcioAnular.FormattingEnabled = true;
            cboConsorcioAnular.Location = new System.Drawing.Point(100, 12);
            cboConsorcioAnular.Name = "cboConsorcioAnular";
            cboConsorcioAnular.Size = new System.Drawing.Size(350, 23);
            cboConsorcioAnular.TabIndex = 1;
            cboConsorcioAnular.SelectedIndexChanged += cboConsorcioAnular_SelectedIndexChanged;
            //
            // dgvAnulables
            //
            dgvAnulables.AllowUserToAddRows = false;
            dgvAnulables.AllowUserToDeleteRows = false;
            dgvAnulables.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvAnulables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colAnularPeriodo, colAnularMonto, colAnularVencimiento, colAnularEstado });
            dgvAnulables.Location = new System.Drawing.Point(13, 45);
            dgvAnulables.MultiSelect = false;
            dgvAnulables.Name = "dgvAnulables";
            dgvAnulables.ReadOnly = true;
            dgvAnulables.RowHeadersVisible = false;
            dgvAnulables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvAnulables.Size = new System.Drawing.Size(966, 300);
            dgvAnulables.TabIndex = 2;
            dgvAnulables.SelectionChanged += dgvAnulables_SelectionChanged;
            //
            // colAnularPeriodo
            //
            colAnularPeriodo.HeaderText = "Periodo";
            colAnularPeriodo.Tag = "lb_col_periodo";
            colAnularPeriodo.Name = "colAnularPeriodo";
            colAnularPeriodo.ReadOnly = true;
            //
            // colAnularMonto
            //
            colAnularMonto.HeaderText = "Monto";
            colAnularMonto.Tag = "lb_col_monto";
            colAnularMonto.Name = "colAnularMonto";
            colAnularMonto.ReadOnly = true;
            //
            // colAnularVencimiento
            //
            colAnularVencimiento.HeaderText = "Vencimiento";
            colAnularVencimiento.Tag = "lb_col_vencimiento";
            colAnularVencimiento.Name = "colAnularVencimiento";
            colAnularVencimiento.ReadOnly = true;
            //
            // colAnularEstado
            //
            colAnularEstado.HeaderText = "Estado";
            colAnularEstado.Tag = "lb_col_estado";
            colAnularEstado.Name = "colAnularEstado";
            colAnularEstado.ReadOnly = true;
            //
            // grpMotivo
            //
            grpMotivo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpMotivo.Controls.Add(btnAnular);
            grpMotivo.Controls.Add(txtMotivo);
            grpMotivo.Controls.Add(lblMotivo);
            grpMotivo.Enabled = false;
            grpMotivo.Location = new System.Drawing.Point(13, 360);
            grpMotivo.Name = "grpMotivo";
            grpMotivo.Size = new System.Drawing.Size(966, 100);
            grpMotivo.TabIndex = 3;
            grpMotivo.TabStop = false;
            grpMotivo.Text = "Motivo de anulación";
            grpMotivo.Tag = "lb_grp_motivo_anulacion";
            //
            // lblMotivo
            //
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new System.Drawing.Point(14, 30);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new System.Drawing.Size(49, 15);
            lblMotivo.TabIndex = 0;
            lblMotivo.Text = "Motivo:";
            lblMotivo.Tag = "lb_motivo";
            //
            // txtMotivo
            //
            txtMotivo.Location = new System.Drawing.Point(100, 27);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new System.Drawing.Size(600, 23);
            txtMotivo.TabIndex = 1;
            txtMotivo.TextChanged += txtMotivo_TextChanged;
            //
            // btnAnular
            //
            btnAnular.Enabled = false;
            btnAnular.Location = new System.Drawing.Point(100, 60);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new System.Drawing.Size(120, 28);
            btnAnular.TabIndex = 2;
            btnAnular.Text = "Anular";
            btnAnular.Tag = "btn_anular";
            btnAnular.Click += btnAnular_Click;
            //
            // lblSinConsorciosAnular
            //
            lblSinConsorciosAnular.AutoSize = true;
            lblSinConsorciosAnular.ForeColor = System.Drawing.Color.DarkRed;
            lblSinConsorciosAnular.Location = new System.Drawing.Point(100, 45);
            lblSinConsorciosAnular.Name = "lblSinConsorciosAnular";
            lblSinConsorciosAnular.Size = new System.Drawing.Size(0, 15);
            lblSinConsorciosAnular.TabIndex = 4;
            lblSinConsorciosAnular.Visible = false;
            //
            // tabComposicion
            //
            tabComposicion.Controls.Add(lblSinConsorciosComposicion);
            tabComposicion.Controls.Add(grpComposicion);
            tabComposicion.Controls.Add(dgvLiquidadas);
            tabComposicion.Controls.Add(cboUnidad);
            tabComposicion.Controls.Add(lblUnidad);
            tabComposicion.Controls.Add(cboConsorcioComposicion);
            tabComposicion.Controls.Add(lblConsorcioComposicion);
            tabComposicion.Location = new System.Drawing.Point(4, 24);
            tabComposicion.Name = "tabComposicion";
            tabComposicion.Padding = new System.Windows.Forms.Padding(10);
            tabComposicion.Size = new System.Drawing.Size(992, 622);
            tabComposicion.TabIndex = 1;
            tabComposicion.Text = "Revisar composición";
            tabComposicion.Tag = "lb_tab_composicion";
            //
            // lblConsorcioComposicion
            //
            lblConsorcioComposicion.AutoSize = true;
            lblConsorcioComposicion.Location = new System.Drawing.Point(13, 15);
            lblConsorcioComposicion.Name = "lblConsorcioComposicion";
            lblConsorcioComposicion.Size = new System.Drawing.Size(63, 15);
            lblConsorcioComposicion.TabIndex = 0;
            lblConsorcioComposicion.Text = "Consorcio:";
            lblConsorcioComposicion.Tag = "lb_consorcio";
            //
            // cboConsorcioComposicion
            //
            cboConsorcioComposicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboConsorcioComposicion.FormattingEnabled = true;
            cboConsorcioComposicion.Location = new System.Drawing.Point(100, 12);
            cboConsorcioComposicion.Name = "cboConsorcioComposicion";
            cboConsorcioComposicion.Size = new System.Drawing.Size(300, 23);
            cboConsorcioComposicion.TabIndex = 1;
            cboConsorcioComposicion.SelectedIndexChanged += cboConsorcioComposicion_SelectedIndexChanged;
            //
            // lblUnidad
            //
            lblUnidad.AutoSize = true;
            lblUnidad.Location = new System.Drawing.Point(420, 15);
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
            cboUnidad.Location = new System.Drawing.Point(515, 12);
            cboUnidad.Name = "cboUnidad";
            cboUnidad.Size = new System.Drawing.Size(200, 23);
            cboUnidad.TabIndex = 3;
            cboUnidad.SelectedIndexChanged += cboUnidad_SelectedIndexChanged;
            //
            // dgvLiquidadas
            //
            dgvLiquidadas.AllowUserToAddRows = false;
            dgvLiquidadas.AllowUserToDeleteRows = false;
            dgvLiquidadas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvLiquidadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colLiqPeriodo, colLiqMonto, colLiqVencimiento, colLiqEstado });
            dgvLiquidadas.Location = new System.Drawing.Point(13, 45);
            dgvLiquidadas.MultiSelect = false;
            dgvLiquidadas.Name = "dgvLiquidadas";
            dgvLiquidadas.ReadOnly = true;
            dgvLiquidadas.RowHeadersVisible = false;
            dgvLiquidadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvLiquidadas.Size = new System.Drawing.Size(966, 180);
            dgvLiquidadas.TabIndex = 4;
            dgvLiquidadas.SelectionChanged += dgvLiquidadas_SelectionChanged;
            //
            // colLiqPeriodo
            //
            colLiqPeriodo.HeaderText = "Periodo";
            colLiqPeriodo.Tag = "lb_col_periodo";
            colLiqPeriodo.Name = "colLiqPeriodo";
            colLiqPeriodo.ReadOnly = true;
            //
            // colLiqMonto
            //
            colLiqMonto.HeaderText = "Monto";
            colLiqMonto.Tag = "lb_col_monto";
            colLiqMonto.Name = "colLiqMonto";
            colLiqMonto.ReadOnly = true;
            //
            // colLiqVencimiento
            //
            colLiqVencimiento.HeaderText = "Vencimiento";
            colLiqVencimiento.Tag = "lb_col_vencimiento";
            colLiqVencimiento.Name = "colLiqVencimiento";
            colLiqVencimiento.ReadOnly = true;
            //
            // colLiqEstado
            //
            colLiqEstado.HeaderText = "Estado";
            colLiqEstado.Tag = "lb_col_estado";
            colLiqEstado.Name = "colLiqEstado";
            colLiqEstado.ReadOnly = true;
            //
            // grpComposicion
            //
            grpComposicion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grpComposicion.Controls.Add(lblRecargoPorMora);
            grpComposicion.Controls.Add(lblCoeficienteAplicado);
            grpComposicion.Controls.Add(lblHonorarioAplicado);
            grpComposicion.Controls.Add(dgvGastos);
            grpComposicion.Location = new System.Drawing.Point(13, 240);
            grpComposicion.Name = "grpComposicion";
            grpComposicion.Size = new System.Drawing.Size(966, 350);
            grpComposicion.TabIndex = 5;
            grpComposicion.TabStop = false;
            grpComposicion.Text = "Composición de la expensa";
            grpComposicion.Tag = "lb_grp_composicion";
            //
            // dgvGastos
            //
            dgvGastos.AllowUserToAddRows = false;
            dgvGastos.AllowUserToDeleteRows = false;
            dgvGastos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colGastoDescripcion, colGastoMonto, colGastoRubro });
            dgvGastos.Location = new System.Drawing.Point(15, 22);
            dgvGastos.Name = "dgvGastos";
            dgvGastos.ReadOnly = true;
            dgvGastos.RowHeadersVisible = false;
            dgvGastos.Size = new System.Drawing.Size(936, 220);
            dgvGastos.TabIndex = 0;
            //
            // colGastoDescripcion
            //
            colGastoDescripcion.HeaderText = "Descripción";
            colGastoDescripcion.Tag = "lb_col_descripcion";
            colGastoDescripcion.Name = "colGastoDescripcion";
            colGastoDescripcion.ReadOnly = true;
            //
            // colGastoMonto
            //
            colGastoMonto.HeaderText = "Monto";
            colGastoMonto.Tag = "lb_col_monto";
            colGastoMonto.Name = "colGastoMonto";
            colGastoMonto.ReadOnly = true;
            //
            // colGastoRubro
            //
            colGastoRubro.HeaderText = "Rubro";
            colGastoRubro.Tag = "lb_col_rubro";
            colGastoRubro.Name = "colGastoRubro";
            colGastoRubro.ReadOnly = true;
            //
            // lblHonorarioAplicado
            //
            lblHonorarioAplicado.AutoSize = true;
            lblHonorarioAplicado.Location = new System.Drawing.Point(15, 255);
            lblHonorarioAplicado.Name = "lblHonorarioAplicado";
            lblHonorarioAplicado.Size = new System.Drawing.Size(120, 15);
            lblHonorarioAplicado.TabIndex = 1;
            lblHonorarioAplicado.Text = "Honorario aplicado:";
            lblHonorarioAplicado.Tag = "lb_honorario_aplicado";
            //
            // lblCoeficienteAplicado
            //
            lblCoeficienteAplicado.AutoSize = true;
            lblCoeficienteAplicado.Location = new System.Drawing.Point(320, 255);
            lblCoeficienteAplicado.Name = "lblCoeficienteAplicado";
            lblCoeficienteAplicado.Size = new System.Drawing.Size(130, 15);
            lblCoeficienteAplicado.TabIndex = 2;
            lblCoeficienteAplicado.Text = "Coeficiente utilizado:";
            lblCoeficienteAplicado.Tag = "lb_coeficiente_utilizado";
            //
            // lblRecargoPorMora
            //
            lblRecargoPorMora.AutoSize = true;
            lblRecargoPorMora.Location = new System.Drawing.Point(15, 285);
            lblRecargoPorMora.Name = "lblRecargoPorMora";
            lblRecargoPorMora.Size = new System.Drawing.Size(120, 15);
            lblRecargoPorMora.TabIndex = 3;
            lblRecargoPorMora.Text = "Recargo por mora:";
            lblRecargoPorMora.Tag = "lb_recargo_mora";
            //
            // lblSinConsorciosComposicion
            //
            lblSinConsorciosComposicion.AutoSize = true;
            lblSinConsorciosComposicion.ForeColor = System.Drawing.Color.DarkRed;
            lblSinConsorciosComposicion.Location = new System.Drawing.Point(100, 45);
            lblSinConsorciosComposicion.Name = "lblSinConsorciosComposicion";
            lblSinConsorciosComposicion.Size = new System.Drawing.Size(0, 15);
            lblSinConsorciosComposicion.TabIndex = 6;
            lblSinConsorciosComposicion.Visible = false;
            //
            // FormExpensa_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 650);
            Controls.Add(tabExpensa);
            MinimumSize = new System.Drawing.Size(900, 600);
            Name = "FormExpensa_755ME";
            Text = "Anular / revisar composición de expensa";
            Tag = "lb_expensa_titulo";
            Load += FormExpensa_755ME_Load;
            FormClosing += FormExpensa_755ME_FormClosing;
            tabExpensa.ResumeLayout(false);
            tabAnular.ResumeLayout(false);
            tabAnular.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnulables).EndInit();
            grpMotivo.ResumeLayout(false);
            grpMotivo.PerformLayout();
            tabComposicion.ResumeLayout(false);
            tabComposicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLiquidadas).EndInit();
            grpComposicion.ResumeLayout(false);
            grpComposicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGastos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabExpensa;
        private System.Windows.Forms.TabPage tabAnular;
        private System.Windows.Forms.Label lblConsorcioAnular;
        private System.Windows.Forms.ComboBox cboConsorcioAnular;
        private System.Windows.Forms.DataGridView dgvAnulables;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnularPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnularMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnularVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnularEstado;
        private System.Windows.Forms.GroupBox grpMotivo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Label lblSinConsorciosAnular;
        private System.Windows.Forms.TabPage tabComposicion;
        private System.Windows.Forms.Label lblConsorcioComposicion;
        private System.Windows.Forms.ComboBox cboConsorcioComposicion;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.ComboBox cboUnidad;
        private System.Windows.Forms.DataGridView dgvLiquidadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiqPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiqMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiqVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiqEstado;
        private System.Windows.Forms.GroupBox grpComposicion;
        private System.Windows.Forms.DataGridView dgvGastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoRubro;
        private System.Windows.Forms.Label lblHonorarioAplicado;
        private System.Windows.Forms.Label lblCoeficienteAplicado;
        private System.Windows.Forms.Label lblRecargoPorMora;
        private System.Windows.Forms.Label lblSinConsorciosComposicion;
    }
}

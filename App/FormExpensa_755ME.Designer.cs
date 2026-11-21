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
            tabExpensa.SuspendLayout();
            tabAnular.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnulables).BeginInit();
            grpMotivo.SuspendLayout();
            SuspendLayout();
            //
            // tabExpensa
            //
            tabExpensa.Controls.Add(tabAnular);
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
            lblSinConsorciosAnular.Tag = "lb_sin_consorcios";
            lblSinConsorciosAnular.Text = "No tiene consorcios asignados";
            lblSinConsorciosAnular.Size = new System.Drawing.Size(0, 15);
            lblSinConsorciosAnular.TabIndex = 4;
            lblSinConsorciosAnular.Visible = false;
            //
            // FormExpensa_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 650);
            Controls.Add(tabExpensa);
            MinimumSize = new System.Drawing.Size(900, 600);
            Name = "FormExpensa_755ME";
            HelpRequested += FormExpensa_755ME_HelpRequested;
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
    }
}

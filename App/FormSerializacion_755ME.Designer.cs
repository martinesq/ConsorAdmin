namespace AppBase
{
    partial class FormSerializacion_755ME
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
            lblConsorcio_755ME = new System.Windows.Forms.Label();
            cboConsorcio_755ME = new System.Windows.Forms.ComboBox();
            btnSerializar_755ME = new System.Windows.Forms.Button();
            btnDeserializar_755ME = new System.Windows.Forms.Button();
            lblAviso_755ME = new System.Windows.Forms.Label();
            lblSinConsorcios = new System.Windows.Forms.Label();
            dgvExpensas_755ME = new System.Windows.Forms.DataGridView();
            colPeriodo_755ME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMonto_755ME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colVencimiento_755ME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEstado_755ME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvExpensas_755ME).BeginInit();
            SuspendLayout();
            //
            // lblConsorcio_755ME
            //
            lblConsorcio_755ME.AutoSize = true;
            lblConsorcio_755ME.Location = new System.Drawing.Point(12, 15);
            lblConsorcio_755ME.Name = "lblConsorcio_755ME";
            lblConsorcio_755ME.Size = new System.Drawing.Size(64, 15);
            lblConsorcio_755ME.TabIndex = 0;
            lblConsorcio_755ME.Tag = "lb_ser_consorcio";
            lblConsorcio_755ME.Text = "Consorcio:";
            //
            // cboConsorcio_755ME
            //
            cboConsorcio_755ME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboConsorcio_755ME.FormattingEnabled = true;
            cboConsorcio_755ME.Location = new System.Drawing.Point(90, 12);
            cboConsorcio_755ME.Name = "cboConsorcio_755ME";
            cboConsorcio_755ME.Size = new System.Drawing.Size(280, 23);
            cboConsorcio_755ME.TabIndex = 1;
            cboConsorcio_755ME.SelectedIndexChanged += cboConsorcio_755ME_SelectedIndexChanged;
            //
            // btnSerializar_755ME
            //
            btnSerializar_755ME.Location = new System.Drawing.Point(385, 11);
            btnSerializar_755ME.Name = "btnSerializar_755ME";
            btnSerializar_755ME.Size = new System.Drawing.Size(120, 25);
            btnSerializar_755ME.TabIndex = 2;
            btnSerializar_755ME.Tag = "lb_ser_serializar";
            btnSerializar_755ME.Text = "Serializar";
            btnSerializar_755ME.UseVisualStyleBackColor = true;
            btnSerializar_755ME.Click += btnSerializar_755ME_Click;
            //
            // btnDeserializar_755ME
            //
            btnDeserializar_755ME.Location = new System.Drawing.Point(515, 11);
            btnDeserializar_755ME.Name = "btnDeserializar_755ME";
            btnDeserializar_755ME.Size = new System.Drawing.Size(120, 25);
            btnDeserializar_755ME.TabIndex = 3;
            btnDeserializar_755ME.Tag = "lb_ser_deserializar";
            btnDeserializar_755ME.Text = "Deserializar";
            btnDeserializar_755ME.UseVisualStyleBackColor = true;
            btnDeserializar_755ME.Click += btnDeserializar_755ME_Click;
            //
            // lblSinConsorcios
            //
            lblSinConsorcios.AutoSize = true;
            lblSinConsorcios.ForeColor = System.Drawing.Color.DarkRed;
            lblSinConsorcios.Location = new System.Drawing.Point(650, 16);
            lblSinConsorcios.Name = "lblSinConsorcios";
            lblSinConsorcios.Size = new System.Drawing.Size(170, 15);
            lblSinConsorcios.TabIndex = 20;
            lblSinConsorcios.Tag = "lb_sin_consorcios";
            lblSinConsorcios.Text = "No tiene consorcios asignados";
            lblSinConsorcios.Visible = false;
            //
            // lblAviso_755ME
            //
            lblAviso_755ME.AutoSize = true;
            lblAviso_755ME.Location = new System.Drawing.Point(12, 48);
            lblAviso_755ME.Name = "lblAviso_755ME";
            lblAviso_755ME.Size = new System.Drawing.Size(380, 15);
            lblAviso_755ME.TabIndex = 4;
            lblAviso_755ME.Tag = "lb_ser_aviso";
            lblAviso_755ME.Text = "Los datos deserializados no se guardan en la base de datos, solo se muestran en pantalla.";
            //
            // dgvExpensas_755ME
            //
            dgvExpensas_755ME.AllowUserToAddRows = false;
            dgvExpensas_755ME.AllowUserToDeleteRows = false;
            dgvExpensas_755ME.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvExpensas_755ME.AutoGenerateColumns = false;
            dgvExpensas_755ME.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpensas_755ME.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpensas_755ME.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colPeriodo_755ME, colMonto_755ME, colVencimiento_755ME, colEstado_755ME });
            dgvExpensas_755ME.Location = new System.Drawing.Point(12, 75);
            dgvExpensas_755ME.Name = "dgvExpensas_755ME";
            dgvExpensas_755ME.ReadOnly = true;
            dgvExpensas_755ME.RowHeadersVisible = false;
            dgvExpensas_755ME.Size = new System.Drawing.Size(860, 395);
            dgvExpensas_755ME.TabIndex = 5;
            //
            // colPeriodo_755ME
            //
            colPeriodo_755ME.DataPropertyName = "Periodo_755ME";
            colPeriodo_755ME.DefaultCellStyle.Format = "MM/yyyy";
            colPeriodo_755ME.HeaderText = "Período";
            colPeriodo_755ME.Name = "colPeriodo_755ME";
            colPeriodo_755ME.ReadOnly = true;
            colPeriodo_755ME.Tag = "lb_ser_col_periodo";
            //
            // colMonto_755ME
            //
            colMonto_755ME.DataPropertyName = "Monto_755ME";
            colMonto_755ME.DefaultCellStyle.Format = "N2";
            colMonto_755ME.HeaderText = "Monto";
            colMonto_755ME.Name = "colMonto_755ME";
            colMonto_755ME.ReadOnly = true;
            colMonto_755ME.Tag = "lb_ser_col_monto";
            //
            // colVencimiento_755ME
            //
            colVencimiento_755ME.DataPropertyName = "FechaVencimiento_755ME";
            colVencimiento_755ME.DefaultCellStyle.Format = "dd/MM/yyyy";
            colVencimiento_755ME.HeaderText = "Fecha de vencimiento";
            colVencimiento_755ME.Name = "colVencimiento_755ME";
            colVencimiento_755ME.ReadOnly = true;
            colVencimiento_755ME.Tag = "lb_ser_col_vencimiento";
            //
            // colEstado_755ME
            //
            colEstado_755ME.DataPropertyName = "Estado_755ME";
            colEstado_755ME.HeaderText = "Estado";
            colEstado_755ME.Name = "colEstado_755ME";
            colEstado_755ME.ReadOnly = true;
            colEstado_755ME.Tag = "lb_ser_col_estado";
            //
            // FormSerializacion_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(884, 481);
            Controls.Add(dgvExpensas_755ME);
            Controls.Add(lblSinConsorcios);
            Controls.Add(lblAviso_755ME);
            Controls.Add(btnDeserializar_755ME);
            Controls.Add(btnSerializar_755ME);
            Controls.Add(cboConsorcio_755ME);
            Controls.Add(lblConsorcio_755ME);
            Name = "FormSerializacion_755ME";
            HelpRequested += FormSerializacion_755ME_HelpRequested;
            Tag = "lb_ser_titulo";
            Text = "Serializar/Deserializar expensas";
            FormClosing += FormSerializacion_755ME_FormClosing;
            Load += FormSerializacion_755ME_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExpensas_755ME).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio_755ME;
        private System.Windows.Forms.ComboBox cboConsorcio_755ME;
        private System.Windows.Forms.Button btnSerializar_755ME;
        private System.Windows.Forms.Button btnDeserializar_755ME;
        private System.Windows.Forms.Label lblAviso_755ME;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.DataGridView dgvExpensas_755ME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodo_755ME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto_755ME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVencimiento_755ME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado_755ME;
    }
}

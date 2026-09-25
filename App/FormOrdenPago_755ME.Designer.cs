namespace AppBase
{
    partial class FormOrdenPago_755ME
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
            dgvPendientes = new System.Windows.Forms.DataGridView();
            colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnGenerarOrden = new System.Windows.Forms.Button();
            grpTalon = new System.Windows.Forms.GroupBox();
            lblNumeroOrden = new System.Windows.Forms.Label();
            lblPropietario = new System.Windows.Forms.Label();
            lblMontoOrden = new System.Windows.Forms.Label();
            lblVencimientoOrden = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvPendientes).BeginInit();
            grpTalon.SuspendLayout();
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
            // dgvPendientes
            //
            dgvPendientes.AllowUserToAddRows = false;
            dgvPendientes.AllowUserToDeleteRows = false;
            dgvPendientes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colUnidad, colTipo });
            dgvPendientes.Location = new System.Drawing.Point(15, 50);
            dgvPendientes.MultiSelect = false;
            dgvPendientes.Name = "dgvPendientes";
            dgvPendientes.ReadOnly = true;
            dgvPendientes.RowHeadersVisible = false;
            dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPendientes.Size = new System.Drawing.Size(760, 260);
            dgvPendientes.TabIndex = 3;
            dgvPendientes.SelectionChanged += dgvPendientes_SelectionChanged;
            //
            // colUnidad
            //
            colUnidad.HeaderText = "Unidad funcional";
            colUnidad.Tag = "lb_unidad_funcional";
            colUnidad.Name = "colUnidad";
            colUnidad.ReadOnly = true;
            //
            // colTipo
            //
            colTipo.HeaderText = "Tipo";
            colTipo.Tag = "lb_col_tipo";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            //
            // btnGenerarOrden
            //
            btnGenerarOrden.Enabled = false;
            btnGenerarOrden.Location = new System.Drawing.Point(15, 320);
            btnGenerarOrden.Name = "btnGenerarOrden";
            btnGenerarOrden.Size = new System.Drawing.Size(180, 28);
            btnGenerarOrden.TabIndex = 4;
            btnGenerarOrden.Text = "Generar orden de pago";
            btnGenerarOrden.Tag = "lb_generar_orden_pago";
            btnGenerarOrden.Click += btnGenerarOrden_Click;
            //
            // grpTalon
            //
            grpTalon.Controls.Add(lblVencimientoOrden);
            grpTalon.Controls.Add(lblMontoOrden);
            grpTalon.Controls.Add(lblPropietario);
            grpTalon.Controls.Add(lblNumeroOrden);
            grpTalon.Location = new System.Drawing.Point(15, 365);
            grpTalon.Name = "grpTalon";
            grpTalon.Size = new System.Drawing.Size(760, 150);
            grpTalon.TabIndex = 5;
            grpTalon.TabStop = false;
            grpTalon.Text = "Talón de la orden de pago";
            grpTalon.Tag = "lb_grp_talon";
            //
            // lblNumeroOrden
            //
            lblNumeroOrden.AutoSize = true;
            lblNumeroOrden.Location = new System.Drawing.Point(15, 25);
            lblNumeroOrden.Name = "lblNumeroOrden";
            lblNumeroOrden.Size = new System.Drawing.Size(90, 15);
            lblNumeroOrden.TabIndex = 0;
            lblNumeroOrden.Text = "N.º de orden:";
            lblNumeroOrden.Tag = "lb_numero_orden";
            //
            // lblPropietario
            //
            lblPropietario.AutoSize = true;
            lblPropietario.Location = new System.Drawing.Point(15, 50);
            lblPropietario.Name = "lblPropietario";
            lblPropietario.Size = new System.Drawing.Size(70, 15);
            lblPropietario.TabIndex = 1;
            lblPropietario.Text = "Propietario:";
            lblPropietario.Tag = "lb_propietario";
            //
            // lblMontoOrden
            //
            lblMontoOrden.AutoSize = true;
            lblMontoOrden.Location = new System.Drawing.Point(15, 75);
            lblMontoOrden.Name = "lblMontoOrden";
            lblMontoOrden.Size = new System.Drawing.Size(46, 15);
            lblMontoOrden.TabIndex = 2;
            lblMontoOrden.Text = "Monto:";
            lblMontoOrden.Tag = "lb_monto";
            //
            // lblVencimientoOrden
            //
            lblVencimientoOrden.AutoSize = true;
            lblVencimientoOrden.Location = new System.Drawing.Point(15, 100);
            lblVencimientoOrden.Name = "lblVencimientoOrden";
            lblVencimientoOrden.Size = new System.Drawing.Size(84, 15);
            lblVencimientoOrden.TabIndex = 3;
            lblVencimientoOrden.Text = "Vencimiento:";
            lblVencimientoOrden.Tag = "lb_vencimiento";
            //
            // FormOrdenPago_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(790, 550);
            Controls.Add(grpTalon);
            Controls.Add(btnGenerarOrden);
            Controls.Add(dgvPendientes);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(790, 500);
            Name = "FormOrdenPago_755ME";
            Text = "Generar orden de pago";
            Tag = "lb_generar_orden_pago";
            Load += FormOrdenPago_755ME_Load;
            FormClosing += FormOrdenPago_755ME_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvPendientes).EndInit();
            grpTalon.ResumeLayout(false);
            grpTalon.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.Button btnGenerarOrden;
        private System.Windows.Forms.GroupBox grpTalon;
        private System.Windows.Forms.Label lblNumeroOrden;
        private System.Windows.Forms.Label lblPropietario;
        private System.Windows.Forms.Label lblMontoOrden;
        private System.Windows.Forms.Label lblVencimientoOrden;
    }
}

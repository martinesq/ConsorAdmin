namespace AppBase
{
    partial class FormFondo_755ME
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
            btnConsultar = new System.Windows.Forms.Button();
            grpEstadoFondo = new System.Windows.Forms.GroupBox();
            lblTotalRecaudado = new System.Windows.Forms.Label();
            lblTotalEgresado = new System.Windows.Forms.Label();
            lblSaldoDisponible = new System.Windows.Forms.Label();
            grpEstadoFondo.SuspendLayout();
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
            //
            // btnConsultar
            //
            btnConsultar.Enabled = false;
            btnConsultar.Location = new System.Drawing.Point(280, 47);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new System.Drawing.Size(160, 25);
            btnConsultar.TabIndex = 5;
            btnConsultar.Text = "Obtener estado del fondo";
            btnConsultar.Tag = "lb_obtener_estado_fondo";
            btnConsultar.Click += btnConsultar_Click;
            //
            // grpEstadoFondo
            //
            grpEstadoFondo.Controls.Add(lblSaldoDisponible);
            grpEstadoFondo.Controls.Add(lblTotalEgresado);
            grpEstadoFondo.Controls.Add(lblTotalRecaudado);
            grpEstadoFondo.Location = new System.Drawing.Point(15, 85);
            grpEstadoFondo.Name = "grpEstadoFondo";
            grpEstadoFondo.Size = new System.Drawing.Size(500, 130);
            grpEstadoFondo.TabIndex = 6;
            grpEstadoFondo.TabStop = false;
            grpEstadoFondo.Text = "Estado del fondo";
            grpEstadoFondo.Tag = "lb_estado_fondo";
            //
            // lblTotalRecaudado
            //
            lblTotalRecaudado.AutoSize = true;
            lblTotalRecaudado.Location = new System.Drawing.Point(15, 25);
            lblTotalRecaudado.Name = "lblTotalRecaudado";
            lblTotalRecaudado.Size = new System.Drawing.Size(110, 15);
            lblTotalRecaudado.TabIndex = 0;
            lblTotalRecaudado.Text = "Total recaudado:";
            lblTotalRecaudado.Tag = "lb_total_recaudado";
            //
            // lblTotalEgresado
            //
            lblTotalEgresado.AutoSize = true;
            lblTotalEgresado.Location = new System.Drawing.Point(15, 55);
            lblTotalEgresado.Name = "lblTotalEgresado";
            lblTotalEgresado.Size = new System.Drawing.Size(96, 15);
            lblTotalEgresado.TabIndex = 1;
            lblTotalEgresado.Text = "Total egresado:";
            lblTotalEgresado.Tag = "lb_total_egresado";
            //
            // lblSaldoDisponible
            //
            lblSaldoDisponible.AutoSize = true;
            lblSaldoDisponible.Location = new System.Drawing.Point(15, 85);
            lblSaldoDisponible.Name = "lblSaldoDisponible";
            lblSaldoDisponible.Size = new System.Drawing.Size(120, 15);
            lblSaldoDisponible.TabIndex = 2;
            lblSaldoDisponible.Text = "Saldo disponible:";
            lblSaldoDisponible.Tag = "lb_saldo_disponible";
            //
            // FormFondo_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(560, 260);
            Controls.Add(grpEstadoFondo);
            Controls.Add(btnConsultar);
            Controls.Add(cboPeriodo);
            Controls.Add(lblPeriodo);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(560, 260);
            Name = "FormFondo_755ME";
            Text = "Estado del fondo";
            Tag = "lb_estado_fondo";
            Load += FormFondo_755ME_Load;
            FormClosing += FormFondo_755ME_FormClosing;
            grpEstadoFondo.ResumeLayout(false);
            grpEstadoFondo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.GroupBox grpEstadoFondo;
        private System.Windows.Forms.Label lblTotalRecaudado;
        private System.Windows.Forms.Label lblTotalEgresado;
        private System.Windows.Forms.Label lblSaldoDisponible;
    }
}

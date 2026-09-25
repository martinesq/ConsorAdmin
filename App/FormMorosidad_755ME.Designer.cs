namespace AppBase
{
    partial class FormMorosidad_755ME
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
            dgvMorosidad = new System.Windows.Forms.DataGridView();
            colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMontoAdeudado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDiasAtraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCuotasPendientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPeriodos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblDetalle = new System.Windows.Forms.Label();
            dgvDetalle = new System.Windows.Forms.DataGridView();
            colDetPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetRecargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMorosidad).BeginInit();
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
            cboConsorcio.Size = new System.Drawing.Size(350, 23);
            cboConsorcio.TabIndex = 1;
            cboConsorcio.SelectedIndexChanged += cboConsorcio_SelectedIndexChanged;
            //
            // lblSinConsorcios
            //
            lblSinConsorcios.AutoSize = true;
            lblSinConsorcios.ForeColor = System.Drawing.Color.DarkRed;
            lblSinConsorcios.Location = new System.Drawing.Point(470, 18);
            lblSinConsorcios.Name = "lblSinConsorcios";
            lblSinConsorcios.Size = new System.Drawing.Size(0, 15);
            lblSinConsorcios.TabIndex = 2;
            //
            // dgvMorosidad
            //
            dgvMorosidad.AllowUserToAddRows = false;
            dgvMorosidad.AllowUserToDeleteRows = false;
            dgvMorosidad.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvMorosidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colUnidad, colMontoAdeudado, colDiasAtraso, colCuotasPendientes, colPeriodos });
            dgvMorosidad.Location = new System.Drawing.Point(15, 50);
            dgvMorosidad.Name = "dgvMorosidad";
            dgvMorosidad.ReadOnly = true;
            dgvMorosidad.RowHeadersVisible = false;
            dgvMorosidad.Size = new System.Drawing.Size(760, 230);
            dgvMorosidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMorosidad.MultiSelect = false;
            dgvMorosidad.SelectionChanged += dgvMorosidad_SelectionChanged;
            dgvMorosidad.TabIndex = 3;
            //
            // colUnidad
            //
            colUnidad.HeaderText = "Unidad funcional";
            colUnidad.Tag = "lb_unidad_funcional";
            colUnidad.Name = "colUnidad";
            colUnidad.ReadOnly = true;
            //
            // colMontoAdeudado
            //
            colMontoAdeudado.HeaderText = "Monto adeudado";
            colMontoAdeudado.Tag = "lb_col_monto_adeudado";
            colMontoAdeudado.Name = "colMontoAdeudado";
            colMontoAdeudado.ReadOnly = true;
            //
            // colDiasAtraso
            //
            colDiasAtraso.HeaderText = "Días de atraso";
            colDiasAtraso.Tag = "lb_col_dias_atraso";
            colDiasAtraso.Name = "colDiasAtraso";
            colDiasAtraso.ReadOnly = true;
            //
            // colCuotasPendientes
            //
            colCuotasPendientes.HeaderText = "Cuotas pendientes";
            colCuotasPendientes.Tag = "lb_col_cuotas_pend";
            colCuotasPendientes.Name = "colCuotasPendientes";
            colCuotasPendientes.ReadOnly = true;
            //
            // colPeriodos
            //
            colPeriodos.HeaderText = "Períodos adeudados";
            colPeriodos.Tag = "lb_col_periodos_adeudados";
            colPeriodos.Name = "colPeriodos";
            colPeriodos.ReadOnly = true;
            colPeriodos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            //
            // lblDetalle
            //
            lblDetalle.AutoSize = true;
            lblDetalle.Location = new System.Drawing.Point(15, 290);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Text = "Detalle por período de la unidad seleccionada:";
            lblDetalle.Tag = "lb_detalle_periodo_unidad";
            //
            // dgvDetalle
            //
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colDetPeriodo, colDetVencimiento, colDetMonto, colDetPagado, colDetSaldo, colDetRecargo, colDetDias });
            dgvDetalle.Location = new System.Drawing.Point(15, 312);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.Size = new System.Drawing.Size(760, 220);
            dgvDetalle.TabIndex = 4;
            colDetPeriodo.HeaderText = "Período";
            colDetPeriodo.Tag = "lb_col_periodo_acento";
            colDetPeriodo.Name = "colDetPeriodo";
            colDetVencimiento.HeaderText = "Vencimiento";
            colDetVencimiento.Tag = "lb_col_vencimiento";
            colDetVencimiento.Name = "colDetVencimiento";
            colDetMonto.HeaderText = "Monto expensa";
            colDetMonto.Tag = "lb_col_monto_expensa";
            colDetMonto.Name = "colDetMonto";
            colDetPagado.HeaderText = "Pagado";
            colDetPagado.Tag = "lb_col_pagado";
            colDetPagado.Name = "colDetPagado";
            colDetSaldo.HeaderText = "Saldo adeudado";
            colDetSaldo.Tag = "lb_col_saldo_adeudado";
            colDetSaldo.Name = "colDetSaldo";
            colDetRecargo.HeaderText = "Incluye recargo por mora";
            colDetRecargo.Tag = "lb_col_incluye_recargo";
            colDetRecargo.Name = "colDetRecargo";
            colDetDias.HeaderText = "Días de atraso";
            colDetDias.Tag = "lb_col_dias_atraso";
            colDetDias.Name = "colDetDias";
            //
            // FormMorosidad_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(790, 550);
            Controls.Add(dgvDetalle);
            Controls.Add(lblDetalle);
            Controls.Add(dgvMorosidad);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(790, 500);
            Name = "FormMorosidad_755ME";
            Text = "Estadísticas de morosidad";
            Tag = "lb_morosidad_titulo";
            Load += FormMorosidad_755ME_Load;
            FormClosing += FormMorosidad_755ME_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvMorosidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.DataGridView dgvMorosidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoAdeudado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiasAtraso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuotasPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodos;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetRecargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetDias;
    }
}

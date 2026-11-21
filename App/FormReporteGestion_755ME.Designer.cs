namespace AppBase
{
    partial class FormReporteGestion_755ME
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
            btnGenerar = new System.Windows.Forms.Button();
            btnExportarPdf = new System.Windows.Forms.Button();
            tabReportes = new System.Windows.Forms.TabControl();
            tabComposicion = new System.Windows.Forms.TabPage();
            tabMorosidad = new System.Windows.Forms.TabPage();
            tabFondo = new System.Windows.Forms.TabPage();
            tabEstadoCuenta = new System.Windows.Forms.TabPage();
            lblUnidadComposicion = new System.Windows.Forms.Label();
            cboUnidadComposicion = new System.Windows.Forms.ComboBox();
            lblAvisoComposicion = new System.Windows.Forms.Label();
            dgvLiquidadas = new System.Windows.Forms.DataGridView();
            colLiqPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLiqMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLiqVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colLiqEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgvGastos = new System.Windows.Forms.DataGridView();
            colGastoDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colGastoMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colGastoRubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblCoeficienteAplicado = new System.Windows.Forms.Label();
            lblHonorarioAplicado = new System.Windows.Forms.Label();
            lblRecargoPorMora = new System.Windows.Forms.Label();
            lblAvisoMorosidad = new System.Windows.Forms.Label();
            dgvMorosidad = new System.Windows.Forms.DataGridView();
            colUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMontoAdeudado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDiasAtraso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCuotasPendientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPeriodos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblDetalleMorosidad = new System.Windows.Forms.Label();
            dgvDetalleMorosidad = new System.Windows.Forms.DataGridView();
            colDetPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetRecargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDetDias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblPeriodo = new System.Windows.Forms.Label();
            cboPeriodo = new System.Windows.Forms.ComboBox();
            lblAvisoFondo = new System.Windows.Forms.Label();
            lblTotalRecaudado = new System.Windows.Forms.Label();
            lblTotalEgresado = new System.Windows.Forms.Label();
            lblSaldoDisponible = new System.Windows.Forms.Label();
            lblUnidadCuenta = new System.Windows.Forms.Label();
            cboUnidadCuenta = new System.Windows.Forms.ComboBox();
            lblAvisoCuenta = new System.Windows.Forms.Label();
            dgvMovimientos = new System.Windows.Forms.DataGridView();
            colMovTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMovFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMovDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMovMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblSaldo = new System.Windows.Forms.Label();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)dgvLiquidadas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGastos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMorosidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleMorosidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            tabReportes.SuspendLayout();
            tabComposicion.SuspendLayout();
            tabMorosidad.SuspendLayout();
            tabFondo.SuspendLayout();
            tabEstadoCuenta.SuspendLayout();
            SuspendLayout();
            //
            // lblConsorcio
            //
            lblConsorcio.AutoSize = true;
            lblConsorcio.Location = new System.Drawing.Point(15, 18);
            lblConsorcio.Name = "lblConsorcio";
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
            lblSinConsorcios.Location = new System.Drawing.Point(785, 18);
            lblSinConsorcios.Name = "lblSinConsorcios";
            lblSinConsorcios.Tag = "lb_sin_consorcios";
            lblSinConsorcios.Text = "No tiene consorcios asignados";
            lblSinConsorcios.TabIndex = 3;
            //
            // btnGenerar
            //
            btnGenerar.Location = new System.Drawing.Point(480, 13);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new System.Drawing.Size(100, 27);
            btnGenerar.TabIndex = 4;
            btnGenerar.Text = "Generar";
            btnGenerar.Tag = "lb_repserv_generar";
            btnGenerar.Click += btnGenerar_Click;
            //
            // btnExportarPdf
            //
            btnExportarPdf.Enabled = false;
            btnExportarPdf.Location = new System.Drawing.Point(590, 13);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new System.Drawing.Size(180, 27);
            btnExportarPdf.TabIndex = 2;
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.Tag = "lb_exportar_pdf";
            btnExportarPdf.Click += btnExportarPdf_Click;
            //
            // tabReportes
            //
            tabReportes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabReportes.Controls.Add(tabComposicion);
            tabReportes.Controls.Add(tabMorosidad);
            tabReportes.Controls.Add(tabFondo);
            tabReportes.Controls.Add(tabEstadoCuenta);
            tabReportes.Location = new System.Drawing.Point(0, 50);
            tabReportes.Name = "tabReportes";
            tabReportes.SelectedIndex = 0;
            tabReportes.Size = new System.Drawing.Size(1000, 605);
            tabReportes.TabIndex = 4;
            //
            // lblUnidadComposicion
            //
            lblUnidadComposicion.AutoSize = true;
            lblUnidadComposicion.Location = new System.Drawing.Point(13, 15);
            lblUnidadComposicion.Name = "lblUnidadComposicion";
            lblUnidadComposicion.TabIndex = 0;
            lblUnidadComposicion.Text = "Unidad funcional:";
            lblUnidadComposicion.Tag = "lb_unidad";
            //
            // cboUnidadComposicion
            //
            cboUnidadComposicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboUnidadComposicion.FormattingEnabled = true;
            cboUnidadComposicion.Location = new System.Drawing.Point(130, 12);
            cboUnidadComposicion.Name = "cboUnidadComposicion";
            cboUnidadComposicion.Size = new System.Drawing.Size(200, 23);
            cboUnidadComposicion.TabIndex = 1;
            cboUnidadComposicion.SelectedIndexChanged += cboUnidadComposicion_SelectedIndexChanged;
            //
            // lblAvisoComposicion
            //
            lblAvisoComposicion.AutoSize = true;
            lblAvisoComposicion.ForeColor = System.Drawing.Color.DarkRed;
            lblAvisoComposicion.Location = new System.Drawing.Point(350, 15);
            lblAvisoComposicion.Name = "lblAvisoComposicion";
            lblAvisoComposicion.TabIndex = 2;
            lblAvisoComposicion.Text = "";
            //
            // dgvLiquidadas
            //
            dgvLiquidadas.AllowUserToAddRows = false;
            dgvLiquidadas.AllowUserToDeleteRows = false;
            dgvLiquidadas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvLiquidadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvLiquidadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colLiqPeriodo, colLiqMonto, colLiqVencimiento, colLiqEstado });
            dgvLiquidadas.Location = new System.Drawing.Point(13, 45);
            dgvLiquidadas.MultiSelect = false;
            dgvLiquidadas.Name = "dgvLiquidadas";
            dgvLiquidadas.ReadOnly = true;
            dgvLiquidadas.RowHeadersVisible = false;
            dgvLiquidadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvLiquidadas.Size = new System.Drawing.Size(966, 170);
            dgvLiquidadas.TabIndex = 3;
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
            // dgvGastos
            //
            dgvGastos.AllowUserToAddRows = false;
            dgvGastos.AllowUserToDeleteRows = false;
            dgvGastos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvGastos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colGastoDescripcion, colGastoMonto, colGastoRubro });
            dgvGastos.Location = new System.Drawing.Point(13, 225);
            dgvGastos.MultiSelect = false;
            dgvGastos.Name = "dgvGastos";
            dgvGastos.ReadOnly = true;
            dgvGastos.RowHeadersVisible = false;
            dgvGastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvGastos.Size = new System.Drawing.Size(966, 200);
            dgvGastos.TabIndex = 4;
            //
            // colGastoDescripcion
            //
            colGastoDescripcion.HeaderText = "Descripción";
            colGastoDescripcion.Tag = "lb_descripcion";
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
            // lblCoeficienteAplicado
            //
            lblCoeficienteAplicado.AutoSize = true;
            lblCoeficienteAplicado.Location = new System.Drawing.Point(13, 440);
            lblCoeficienteAplicado.Name = "lblCoeficienteAplicado";
            lblCoeficienteAplicado.TabIndex = 5;
            lblCoeficienteAplicado.Text = "Coeficiente aplicado:";
            lblCoeficienteAplicado.Tag = "lb_coeficiente_aplicado";
            //
            // lblHonorarioAplicado
            //
            lblHonorarioAplicado.AutoSize = true;
            lblHonorarioAplicado.Location = new System.Drawing.Point(13, 465);
            lblHonorarioAplicado.Name = "lblHonorarioAplicado";
            lblHonorarioAplicado.TabIndex = 6;
            lblHonorarioAplicado.Text = "Honorario aplicado:";
            lblHonorarioAplicado.Tag = "lb_honorario_aplicado";
            //
            // lblRecargoPorMora
            //
            lblRecargoPorMora.AutoSize = true;
            lblRecargoPorMora.Location = new System.Drawing.Point(13, 490);
            lblRecargoPorMora.Name = "lblRecargoPorMora";
            lblRecargoPorMora.TabIndex = 7;
            lblRecargoPorMora.Text = "Recargo por mora:";
            lblRecargoPorMora.Tag = "lb_recargo_por_mora";
            //
            // tabComposicion
            //
            tabComposicion.Controls.Add(lblUnidadComposicion);
            tabComposicion.Controls.Add(cboUnidadComposicion);
            tabComposicion.Controls.Add(lblAvisoComposicion);
            tabComposicion.Controls.Add(dgvLiquidadas);
            tabComposicion.Controls.Add(dgvGastos);
            tabComposicion.Controls.Add(lblCoeficienteAplicado);
            tabComposicion.Controls.Add(lblHonorarioAplicado);
            tabComposicion.Controls.Add(lblRecargoPorMora);
            tabComposicion.Location = new System.Drawing.Point(4, 24);
            tabComposicion.Name = "tabComposicion";
            tabComposicion.Padding = new System.Windows.Forms.Padding(3);
            tabComposicion.Size = new System.Drawing.Size(992, 577);
            tabComposicion.Text = "Composición de expensa";
            tabComposicion.Tag = "lb_tab_composicion";
            tabComposicion.UseVisualStyleBackColor = true;
            //
            // lblAvisoMorosidad
            //
            lblAvisoMorosidad.AutoSize = true;
            lblAvisoMorosidad.ForeColor = System.Drawing.Color.DarkRed;
            lblAvisoMorosidad.Location = new System.Drawing.Point(13, 15);
            lblAvisoMorosidad.Name = "lblAvisoMorosidad";
            lblAvisoMorosidad.TabIndex = 0;
            lblAvisoMorosidad.Text = "";
            //
            // dgvMorosidad
            //
            dgvMorosidad.AllowUserToAddRows = false;
            dgvMorosidad.AllowUserToDeleteRows = false;
            dgvMorosidad.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvMorosidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvMorosidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colUnidad, colMontoAdeudado, colDiasAtraso, colCuotasPendientes, colPeriodos });
            dgvMorosidad.Location = new System.Drawing.Point(13, 40);
            dgvMorosidad.MultiSelect = false;
            dgvMorosidad.Name = "dgvMorosidad";
            dgvMorosidad.ReadOnly = true;
            dgvMorosidad.RowHeadersVisible = false;
            dgvMorosidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMorosidad.Size = new System.Drawing.Size(966, 230);
            dgvMorosidad.TabIndex = 1;
            dgvMorosidad.SelectionChanged += dgvMorosidad_SelectionChanged;
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
            //
            // lblDetalleMorosidad
            //
            lblDetalleMorosidad.AutoSize = true;
            lblDetalleMorosidad.Location = new System.Drawing.Point(13, 280);
            lblDetalleMorosidad.Name = "lblDetalleMorosidad";
            lblDetalleMorosidad.TabIndex = 2;
            lblDetalleMorosidad.Text = "Detalle por período de la unidad seleccionada:";
            lblDetalleMorosidad.Tag = "lb_detalle_periodo_unidad";
            //
            // dgvDetalleMorosidad
            //
            dgvDetalleMorosidad.AllowUserToAddRows = false;
            dgvDetalleMorosidad.AllowUserToDeleteRows = false;
            dgvDetalleMorosidad.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvDetalleMorosidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleMorosidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colDetPeriodo, colDetVencimiento, colDetMonto, colDetPagado, colDetSaldo, colDetRecargo, colDetDias });
            dgvDetalleMorosidad.Location = new System.Drawing.Point(13, 302);
            dgvDetalleMorosidad.MultiSelect = false;
            dgvDetalleMorosidad.Name = "dgvDetalleMorosidad";
            dgvDetalleMorosidad.ReadOnly = true;
            dgvDetalleMorosidad.RowHeadersVisible = false;
            dgvDetalleMorosidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleMorosidad.Size = new System.Drawing.Size(966, 220);
            dgvDetalleMorosidad.TabIndex = 3;
            //
            // colDetPeriodo
            //
            colDetPeriodo.HeaderText = "Período";
            colDetPeriodo.Tag = "lb_col_periodo_acento";
            colDetPeriodo.Name = "colDetPeriodo";
            colDetPeriodo.ReadOnly = true;
            //
            // colDetVencimiento
            //
            colDetVencimiento.HeaderText = "Vencimiento";
            colDetVencimiento.Tag = "lb_col_vencimiento";
            colDetVencimiento.Name = "colDetVencimiento";
            colDetVencimiento.ReadOnly = true;
            //
            // colDetMonto
            //
            colDetMonto.HeaderText = "Monto expensa";
            colDetMonto.Tag = "lb_col_monto_expensa";
            colDetMonto.Name = "colDetMonto";
            colDetMonto.ReadOnly = true;
            //
            // colDetPagado
            //
            colDetPagado.HeaderText = "Pagado";
            colDetPagado.Tag = "lb_col_pagado";
            colDetPagado.Name = "colDetPagado";
            colDetPagado.ReadOnly = true;
            //
            // colDetSaldo
            //
            colDetSaldo.HeaderText = "Saldo adeudado";
            colDetSaldo.Tag = "lb_col_saldo_adeudado";
            colDetSaldo.Name = "colDetSaldo";
            colDetSaldo.ReadOnly = true;
            //
            // colDetRecargo
            //
            colDetRecargo.HeaderText = "Incluye recargo por mora";
            colDetRecargo.Tag = "lb_col_incluye_recargo";
            colDetRecargo.Name = "colDetRecargo";
            colDetRecargo.ReadOnly = true;
            //
            // colDetDias
            //
            colDetDias.HeaderText = "Días de atraso";
            colDetDias.Tag = "lb_col_dias_atraso";
            colDetDias.Name = "colDetDias";
            colDetDias.ReadOnly = true;
            //
            // tabMorosidad
            //
            tabMorosidad.Controls.Add(lblAvisoMorosidad);
            tabMorosidad.Controls.Add(dgvMorosidad);
            tabMorosidad.Controls.Add(lblDetalleMorosidad);
            tabMorosidad.Controls.Add(dgvDetalleMorosidad);
            tabMorosidad.Location = new System.Drawing.Point(4, 24);
            tabMorosidad.Name = "tabMorosidad";
            tabMorosidad.Padding = new System.Windows.Forms.Padding(3);
            tabMorosidad.Size = new System.Drawing.Size(992, 577);
            tabMorosidad.Text = "Estadísticas de morosidad";
            tabMorosidad.Tag = "lb_morosidad_titulo";
            tabMorosidad.UseVisualStyleBackColor = true;
            //
            // lblPeriodo
            //
            lblPeriodo.AutoSize = true;
            lblPeriodo.Location = new System.Drawing.Point(13, 15);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.TabIndex = 0;
            lblPeriodo.Text = "Periodo:";
            lblPeriodo.Tag = "lb_periodo";
            //
            // cboPeriodo
            //
            cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPeriodo.FormattingEnabled = true;
            cboPeriodo.Location = new System.Drawing.Point(130, 12);
            cboPeriodo.Name = "cboPeriodo";
            cboPeriodo.Size = new System.Drawing.Size(150, 23);
            cboPeriodo.TabIndex = 1;
            cboPeriodo.SelectedIndexChanged += cboPeriodo_SelectedIndexChanged;
            //
            // lblAvisoFondo
            //
            lblAvisoFondo.AutoSize = true;
            lblAvisoFondo.ForeColor = System.Drawing.Color.DarkRed;
            lblAvisoFondo.Location = new System.Drawing.Point(300, 15);
            lblAvisoFondo.Name = "lblAvisoFondo";
            lblAvisoFondo.TabIndex = 2;
            lblAvisoFondo.Text = "";
            //
            // lblTotalRecaudado
            //
            lblTotalRecaudado.AutoSize = true;
            lblTotalRecaudado.Location = new System.Drawing.Point(13, 60);
            lblTotalRecaudado.Name = "lblTotalRecaudado";
            lblTotalRecaudado.TabIndex = 3;
            lblTotalRecaudado.Text = "Total recaudado:";
            lblTotalRecaudado.Tag = "lb_total_recaudado";
            //
            // lblTotalEgresado
            //
            lblTotalEgresado.AutoSize = true;
            lblTotalEgresado.Location = new System.Drawing.Point(13, 90);
            lblTotalEgresado.Name = "lblTotalEgresado";
            lblTotalEgresado.TabIndex = 4;
            lblTotalEgresado.Text = "Total egresado:";
            lblTotalEgresado.Tag = "lb_total_egresado";
            //
            // lblSaldoDisponible
            //
            lblSaldoDisponible.AutoSize = true;
            lblSaldoDisponible.Location = new System.Drawing.Point(13, 120);
            lblSaldoDisponible.Name = "lblSaldoDisponible";
            lblSaldoDisponible.TabIndex = 5;
            lblSaldoDisponible.Text = "Saldo disponible:";
            lblSaldoDisponible.Tag = "lb_saldo_disponible";
            //
            // tabFondo
            //
            tabFondo.Controls.Add(lblPeriodo);
            tabFondo.Controls.Add(cboPeriodo);
            tabFondo.Controls.Add(lblAvisoFondo);
            tabFondo.Controls.Add(lblTotalRecaudado);
            tabFondo.Controls.Add(lblTotalEgresado);
            tabFondo.Controls.Add(lblSaldoDisponible);
            tabFondo.Location = new System.Drawing.Point(4, 24);
            tabFondo.Name = "tabFondo";
            tabFondo.Padding = new System.Windows.Forms.Padding(3);
            tabFondo.Size = new System.Drawing.Size(992, 577);
            tabFondo.Text = "Estado del fondo";
            tabFondo.Tag = "lb_estado_fondo";
            tabFondo.UseVisualStyleBackColor = true;
            //
            // lblUnidadCuenta
            //
            lblUnidadCuenta.AutoSize = true;
            lblUnidadCuenta.Location = new System.Drawing.Point(13, 15);
            lblUnidadCuenta.Name = "lblUnidadCuenta";
            lblUnidadCuenta.TabIndex = 0;
            lblUnidadCuenta.Text = "Unidad funcional / consorcio:";
            lblUnidadCuenta.Tag = "lb_unidad_o_consorcio";
            //
            // cboUnidadCuenta
            //
            cboUnidadCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboUnidadCuenta.FormattingEnabled = true;
            cboUnidadCuenta.Location = new System.Drawing.Point(190, 12);
            cboUnidadCuenta.Name = "cboUnidadCuenta";
            cboUnidadCuenta.Size = new System.Drawing.Size(220, 23);
            cboUnidadCuenta.TabIndex = 1;
            cboUnidadCuenta.SelectedIndexChanged += cboUnidadCuenta_SelectedIndexChanged;
            //
            // lblAvisoCuenta
            //
            lblAvisoCuenta.AutoSize = true;
            lblAvisoCuenta.ForeColor = System.Drawing.Color.DarkRed;
            lblAvisoCuenta.Location = new System.Drawing.Point(430, 15);
            lblAvisoCuenta.Name = "lblAvisoCuenta";
            lblAvisoCuenta.TabIndex = 2;
            lblAvisoCuenta.Text = "";
            //
            // dgvMovimientos
            //
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colMovTipo, colMovFecha, colMovDetalle, colMovMonto });
            dgvMovimientos.Location = new System.Drawing.Point(13, 45);
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new System.Drawing.Size(966, 440);
            dgvMovimientos.TabIndex = 3;
            //
            // colMovTipo
            //
            colMovTipo.HeaderText = "Tipo";
            colMovTipo.Tag = "lb_col_tipo";
            colMovTipo.Name = "colMovTipo";
            colMovTipo.ReadOnly = true;
            //
            // colMovFecha
            //
            colMovFecha.HeaderText = "Fecha";
            colMovFecha.Tag = "lb_col_fecha";
            colMovFecha.Name = "colMovFecha";
            colMovFecha.ReadOnly = true;
            //
            // colMovDetalle
            //
            colMovDetalle.HeaderText = "Detalle";
            colMovDetalle.Tag = "lb_col_detalle";
            colMovDetalle.Name = "colMovDetalle";
            colMovDetalle.ReadOnly = true;
            //
            // colMovMonto
            //
            colMovMonto.HeaderText = "Monto";
            colMovMonto.Tag = "lb_col_monto";
            colMovMonto.Name = "colMovMonto";
            colMovMonto.ReadOnly = true;
            //
            // lblSaldo
            //
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new System.Drawing.Point(13, 500);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.TabIndex = 4;
            lblSaldo.Text = "Saldo:";
            lblSaldo.Tag = "lb_saldo";
            //
            // tabEstadoCuenta
            //
            tabEstadoCuenta.Controls.Add(lblUnidadCuenta);
            tabEstadoCuenta.Controls.Add(cboUnidadCuenta);
            tabEstadoCuenta.Controls.Add(lblAvisoCuenta);
            tabEstadoCuenta.Controls.Add(dgvMovimientos);
            tabEstadoCuenta.Controls.Add(lblSaldo);
            tabEstadoCuenta.Location = new System.Drawing.Point(4, 24);
            tabEstadoCuenta.Name = "tabEstadoCuenta";
            tabEstadoCuenta.Padding = new System.Windows.Forms.Padding(3);
            tabEstadoCuenta.Size = new System.Drawing.Size(992, 577);
            tabEstadoCuenta.Text = "Estado de cuenta";
            tabEstadoCuenta.Tag = "lb_emitir_estado_cuenta";
            tabEstadoCuenta.UseVisualStyleBackColor = true;
            //
            // saveFileDialog
            //
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
            //
            // FormReporteGestion_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 655);
            Controls.Add(tabReportes);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnGenerar);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(1000, 600);
            Name = "FormReporteGestion_755ME";
            HelpRequested += FormReporteGestion_755ME_HelpRequested;
            Text = "Reporte de gestión";
            Tag = "lb_reporte_gestion";
            Load += FormReporteGestion_755ME_Load;
            FormClosing += FormReporteGestion_755ME_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvLiquidadas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGastos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMorosidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleMorosidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            tabReportes.ResumeLayout(false);
            tabComposicion.ResumeLayout(false);
            tabComposicion.PerformLayout();
            tabMorosidad.ResumeLayout(false);
            tabMorosidad.PerformLayout();
            tabFondo.ResumeLayout(false);
            tabFondo.PerformLayout();
            tabEstadoCuenta.ResumeLayout(false);
            tabEstadoCuenta.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnExportarPdf;
        private System.Windows.Forms.TabControl tabReportes;
        private System.Windows.Forms.TabPage tabComposicion;
        private System.Windows.Forms.TabPage tabMorosidad;
        private System.Windows.Forms.TabPage tabFondo;
        private System.Windows.Forms.TabPage tabEstadoCuenta;
        private System.Windows.Forms.Label lblUnidadComposicion;
        private System.Windows.Forms.ComboBox cboUnidadComposicion;
        private System.Windows.Forms.Label lblAvisoComposicion;
        private System.Windows.Forms.DataGridView dgvLiquidadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiqPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiqMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiqVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiqEstado;
        private System.Windows.Forms.DataGridView dgvGastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGastoRubro;
        private System.Windows.Forms.Label lblCoeficienteAplicado;
        private System.Windows.Forms.Label lblHonorarioAplicado;
        private System.Windows.Forms.Label lblRecargoPorMora;
        private System.Windows.Forms.Label lblAvisoMorosidad;
        private System.Windows.Forms.DataGridView dgvMorosidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoAdeudado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiasAtraso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuotasPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodos;
        private System.Windows.Forms.Label lblDetalleMorosidad;
        private System.Windows.Forms.DataGridView dgvDetalleMorosidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetRecargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetDias;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label lblAvisoFondo;
        private System.Windows.Forms.Label lblTotalRecaudado;
        private System.Windows.Forms.Label lblTotalEgresado;
        private System.Windows.Forms.Label lblSaldoDisponible;
        private System.Windows.Forms.Label lblUnidadCuenta;
        private System.Windows.Forms.ComboBox cboUnidadCuenta;
        private System.Windows.Forms.Label lblAvisoCuenta;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovMonto;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

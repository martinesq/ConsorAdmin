namespace AppBase
{
    partial class FormHistorialUnidad_755ME
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
            lblBuscarPor = new System.Windows.Forms.Label();
            rbPorId = new System.Windows.Forms.RadioButton();
            rbPorNumero = new System.Windows.Forms.RadioButton();
            txtBusqueda = new System.Windows.Forms.TextBox();
            lblDesde = new System.Windows.Forms.Label();
            dtpDesde = new System.Windows.Forms.DateTimePicker();
            lblHasta = new System.Windows.Forms.Label();
            dtpHasta = new System.Windows.Forms.DateTimePicker();
            btnAplicar = new System.Windows.Forms.Button();
            btnLimpiar = new System.Windows.Forms.Button();
            btnActivar = new System.Windows.Forms.Button();
            lblHistorial = new System.Windows.Forms.Label();
            dgvHistorial = new System.Windows.Forms.DataGridView();
            colHFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHCoeficiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHActiva = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colHAct = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colHOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblVigente = new System.Windows.Forms.Label();
            dgvVigente = new System.Windows.Forms.DataGridView();
            colVNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colVTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colVCoeficiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colVActiva = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVigente).BeginInit();
            SuspendLayout();
            //
            // lblBuscarPor
            //
            lblBuscarPor.AutoSize = true;
            lblBuscarPor.Location = new System.Drawing.Point(12, 15);
            lblBuscarPor.Name = "lblBuscarPor";
            lblBuscarPor.Size = new System.Drawing.Size(65, 15);
            lblBuscarPor.TabIndex = 0;
            lblBuscarPor.Text = "Buscar por:";
            //
            // rbPorId
            //
            rbPorId.AutoSize = true;
            rbPorId.Checked = true;
            rbPorId.Location = new System.Drawing.Point(85, 13);
            rbPorId.Name = "rbPorId";
            rbPorId.Size = new System.Drawing.Size(35, 19);
            rbPorId.TabIndex = 1;
            rbPorId.TabStop = true;
            rbPorId.Text = "Id";
            rbPorId.UseVisualStyleBackColor = true;
            //
            // rbPorNumero
            //
            rbPorNumero.AutoSize = true;
            rbPorNumero.Location = new System.Drawing.Point(130, 13);
            rbPorNumero.Name = "rbPorNumero";
            rbPorNumero.Size = new System.Drawing.Size(69, 19);
            rbPorNumero.TabIndex = 2;
            rbPorNumero.Text = "Número";
            rbPorNumero.UseVisualStyleBackColor = true;
            rbPorNumero.CheckedChanged += rbPorNumero_CheckedChanged;
            //
            // txtBusqueda
            //
            txtBusqueda.Location = new System.Drawing.Point(210, 12);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new System.Drawing.Size(120, 23);
            txtBusqueda.TabIndex = 3;
            //
            // lblDesde
            //
            lblDesde.AutoSize = true;
            lblDesde.Location = new System.Drawing.Point(345, 15);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new System.Drawing.Size(73, 15);
            lblDesde.TabIndex = 10;
            lblDesde.Text = "Fecha desde:";
            //
            // dtpDesde
            //
            dtpDesde.Checked = false;
            dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDesde.Location = new System.Drawing.Point(422, 12);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.ShowCheckBox = true;
            dtpDesde.Size = new System.Drawing.Size(120, 23);
            dtpDesde.TabIndex = 11;
            //
            // lblHasta
            //
            lblHasta.AutoSize = true;
            lblHasta.Location = new System.Drawing.Point(552, 15);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new System.Drawing.Size(70, 15);
            lblHasta.TabIndex = 12;
            lblHasta.Text = "Fecha hasta:";
            //
            // dtpHasta
            //
            dtpHasta.Checked = false;
            dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpHasta.Location = new System.Drawing.Point(626, 12);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.ShowCheckBox = true;
            dtpHasta.Size = new System.Drawing.Size(120, 23);
            dtpHasta.TabIndex = 13;
            //
            // btnAplicar
            //
            btnAplicar.Location = new System.Drawing.Point(758, 11);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new System.Drawing.Size(90, 25);
            btnAplicar.TabIndex = 8;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += btnAplicar_Click;
            //
            // btnLimpiar
            //
            btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnLimpiar.Location = new System.Drawing.Point(12, 418);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new System.Drawing.Size(90, 28);
            btnLimpiar.TabIndex = 14;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            //
            // btnActivar
            //
            btnActivar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnActivar.Location = new System.Drawing.Point(108, 418);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new System.Drawing.Size(90, 28);
            btnActivar.TabIndex = 9;
            btnActivar.Text = "Activar";
            btnActivar.UseVisualStyleBackColor = true;
            btnActivar.Click += btnActivar_Click;
            //
            // lblHistorial
            //
            lblHistorial.AutoSize = true;
            lblHistorial.Location = new System.Drawing.Point(12, 48);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new System.Drawing.Size(52, 15);
            lblHistorial.TabIndex = 3;
            lblHistorial.Text = "Historial";
            //
            // dgvHistorial
            //
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colHFecha, colHHora, colHNumero, colHTipo, colHCoeficiente, colHActiva, colHAct, colHOperacion });
            dgvHistorial.Location = new System.Drawing.Point(12, 68);
            dgvHistorial.MultiSelect = false;
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.Size = new System.Drawing.Size(600, 340);
            dgvHistorial.TabIndex = 4;
            //
            // colHFecha
            //
            colHFecha.DataPropertyName = "Fecha_755ME";
            colHFecha.DefaultCellStyle.Format = "dd/MM/yyyy";
            colHFecha.HeaderText = "Fecha";
            colHFecha.Name = "colHFecha";
            colHFecha.ReadOnly = true;
            //
            // colHHora
            //
            colHHora.DataPropertyName = "Hora_755ME";
            colHHora.DefaultCellStyle.Format = "hh\\:mm\\:ss";
            colHHora.HeaderText = "Hora";
            colHHora.Name = "colHHora";
            colHHora.ReadOnly = true;
            //
            // colHNumero
            //
            colHNumero.DataPropertyName = "Numero_755ME";
            colHNumero.HeaderText = "Numero";
            colHNumero.Name = "colHNumero";
            colHNumero.ReadOnly = true;
            //
            // colHTipo
            //
            colHTipo.DataPropertyName = "Tipo_755ME";
            colHTipo.HeaderText = "Tipo";
            colHTipo.Name = "colHTipo";
            colHTipo.ReadOnly = true;
            //
            // colHCoeficiente
            //
            colHCoeficiente.DataPropertyName = "Coeficiente_755ME";
            colHCoeficiente.HeaderText = "Coeficiente";
            colHCoeficiente.Name = "colHCoeficiente";
            colHCoeficiente.ReadOnly = true;
            //
            // colHActiva
            //
            colHActiva.DataPropertyName = "Activa_755ME";
            colHActiva.HeaderText = "Activa";
            colHActiva.Name = "colHActiva";
            colHActiva.ReadOnly = true;
            //
            // colHAct
            //
            colHAct.DataPropertyName = "Act_755ME";
            colHAct.HeaderText = "Act";
            colHAct.Name = "colHAct";
            colHAct.ReadOnly = true;
            //
            // colHOperacion
            //
            colHOperacion.DataPropertyName = "Operacion_755ME";
            colHOperacion.HeaderText = "Operacion";
            colHOperacion.Name = "colHOperacion";
            colHOperacion.ReadOnly = true;
            //
            // lblVigente
            //
            lblVigente.AutoSize = true;
            lblVigente.Location = new System.Drawing.Point(628, 48);
            lblVigente.Name = "lblVigente";
            lblVigente.Size = new System.Drawing.Size(150, 15);
            lblVigente.TabIndex = 5;
            lblVigente.Text = "Unidad Funcional (vigente)";
            //
            // dgvVigente
            //
            dgvVigente.AllowUserToAddRows = false;
            dgvVigente.AllowUserToDeleteRows = false;
            dgvVigente.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvVigente.AutoGenerateColumns = false;
            dgvVigente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvVigente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVigente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colVNumero, colVTipo, colVCoeficiente, colVActiva });
            dgvVigente.Location = new System.Drawing.Point(628, 68);
            dgvVigente.Name = "dgvVigente";
            dgvVigente.ReadOnly = true;
            dgvVigente.RowHeadersVisible = false;
            dgvVigente.Size = new System.Drawing.Size(344, 340);
            dgvVigente.TabIndex = 6;
            //
            // colVNumero
            //
            colVNumero.DataPropertyName = "Numero_755ME";
            colVNumero.HeaderText = "Numero";
            colVNumero.Name = "colVNumero";
            colVNumero.ReadOnly = true;
            //
            // colVTipo
            //
            colVTipo.DataPropertyName = "Tipo_755ME";
            colVTipo.HeaderText = "Tipo";
            colVTipo.Name = "colVTipo";
            colVTipo.ReadOnly = true;
            //
            // colVCoeficiente
            //
            colVCoeficiente.DataPropertyName = "Coeficiente_755ME";
            colVCoeficiente.HeaderText = "Coeficiente";
            colVCoeficiente.Name = "colVCoeficiente";
            colVCoeficiente.ReadOnly = true;
            //
            // colVActiva
            //
            colVActiva.DataPropertyName = "Activa_755ME";
            colVActiva.HeaderText = "Activa";
            colVActiva.Name = "colVActiva";
            colVActiva.ReadOnly = true;
            //
            // btnSalir
            //
            btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSalir.Location = new System.Drawing.Point(882, 418);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new System.Drawing.Size(90, 28);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            //
            // FormHistorialUnidad_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 456);
            Controls.Add(btnSalir);
            Controls.Add(dgvVigente);
            Controls.Add(lblVigente);
            Controls.Add(dgvHistorial);
            Controls.Add(lblHistorial);
            Controls.Add(btnAplicar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnActivar);
            Controls.Add(dtpHasta);
            Controls.Add(lblHasta);
            Controls.Add(dtpDesde);
            Controls.Add(lblDesde);
            Controls.Add(txtBusqueda);
            Controls.Add(rbPorNumero);
            Controls.Add(rbPorId);
            Controls.Add(lblBuscarPor);
            MinimizeBox = false;
            Name = "FormHistorialUnidad_755ME";
            HelpRequested += FormHistorialUnidad_755ME_HelpRequested;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Bitácora de Cambios — Unidad Funcional";
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVigente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.RadioButton rbPorId;
        private System.Windows.Forms.RadioButton rbPorNumero;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHCoeficiente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHActiva;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHAct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHOperacion;
        private System.Windows.Forms.Label lblVigente;
        private System.Windows.Forms.DataGridView dgvVigente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVCoeficiente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colVActiva;
        private System.Windows.Forms.Button btnSalir;
    }
}

namespace AppBase
{
    partial class frmIntegridad
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
            lbTitulo = new Label();
            lbDescripcion = new Label();
            dgvDetalle = new DataGridView();
            colTabla = new DataGridViewTextBoxColumn();
            colFila = new DataGridViewTextBoxColumn();
            colCampos = new DataGridViewTextBoxColumn();
            btnRestaurar = new Button();
            btnRecalcular = new Button();
            btnCancelar = new Button();
            lbRestoreConfirm = new Label();
            lbRestoreError = new Label();
            lbRecalcularConfirm = new Label();
            lbRecalcularError = new Label();
            lbIntegridadPersiste = new Label();
            lbSesionInvalida = new Label();
            lbTablaCompleta = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            //
            // lbTitulo
            //
            lbTitulo.AutoSize = true;
            lbTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbTitulo.Location = new Point(20, 15);
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(200, 21);
            lbTitulo.TabIndex = 0;
            lbTitulo.Tag = "lb_integridadTitulo";
            lbTitulo.Text = "Resolución de integridad";
            //
            // lbDescripcion
            //
            lbDescripcion.Location = new Point(20, 45);
            lbDescripcion.Name = "lbDescripcion";
            lbDescripcion.Size = new Size(640, 32);
            lbDescripcion.TabIndex = 1;
            lbDescripcion.Tag = "lb_integridadDescripcion";
            lbDescripcion.Text = "Se detectó una inconsistencia en los datos (posible manipulación fuera del sistema). Elija cómo resolverla:";
            //
            // dgvDetalle
            //
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Columns.AddRange(new DataGridViewColumn[] { colTabla, colFila, colCampos });
            dgvDetalle.Location = new Point(20, 85);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(640, 200);
            dgvDetalle.TabIndex = 2;
            //
            // colTabla
            //
            colTabla.HeaderText = "Tabla";
            colTabla.Name = "colTabla";
            colTabla.ReadOnly = true;
            colTabla.Tag = "lb_integridadColTabla";
            //
            // colFila
            //
            colFila.FillWeight = 200F;
            colFila.HeaderText = "Fila (clave primaria)";
            colFila.Name = "colFila";
            colFila.ReadOnly = true;
            colFila.Tag = "lb_integridadColFila";
            //
            // colCampos
            //
            colCampos.HeaderText = "Campos con falla";
            colCampos.Name = "colCampos";
            colCampos.ReadOnly = true;
            colCampos.Tag = "lb_integridadColCampos";
            //
            // btnRestaurar
            //
            btnRestaurar.Location = new Point(20, 300);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(200, 32);
            btnRestaurar.TabIndex = 3;
            btnRestaurar.Tag = "btn_integridadRestaurar";
            btnRestaurar.Text = "Restaurar desde backup";
            btnRestaurar.UseVisualStyleBackColor = true;
            btnRestaurar.Click += Restaurar;
            //
            // btnRecalcular
            //
            btnRecalcular.Location = new Point(230, 300);
            btnRecalcular.Name = "btnRecalcular";
            btnRecalcular.Size = new Size(230, 32);
            btnRecalcular.TabIndex = 4;
            btnRecalcular.Tag = "btn_integridadRecalcular";
            btnRecalcular.Text = "Recalcular dígitos verificadores";
            btnRecalcular.UseVisualStyleBackColor = true;
            btnRecalcular.Click += Recalcular;
            //
            // btnCancelar
            //
            btnCancelar.Location = new Point(470, 300);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(190, 32);
            btnCancelar.TabIndex = 5;
            btnCancelar.Tag = "btn_integridadCancelar";
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += Cancelar;
            //
            // lbRestoreConfirm
            //
            lbRestoreConfirm.AutoSize = true;
            lbRestoreConfirm.Location = new Point(700, 20);
            lbRestoreConfirm.Name = "lbRestoreConfirm";
            lbRestoreConfirm.TabIndex = 6;
            lbRestoreConfirm.Tag = "lb_integridadRestoreConfirm";
            lbRestoreConfirm.Text = "Esta acción reemplaza los datos actuales por los del backup. ¿Desea continuar?";
            lbRestoreConfirm.Visible = false;
            //
            // lbRestoreError
            //
            lbRestoreError.AutoSize = true;
            lbRestoreError.Location = new Point(700, 40);
            lbRestoreError.Name = "lbRestoreError";
            lbRestoreError.TabIndex = 7;
            lbRestoreError.Tag = "lb_restoreError";
            lbRestoreError.Text = "Error al restaurar la base de datos";
            lbRestoreError.Visible = false;
            //
            // lbRecalcularConfirm
            //
            lbRecalcularConfirm.AutoSize = true;
            lbRecalcularConfirm.Location = new Point(700, 60);
            lbRecalcularConfirm.Name = "lbRecalcularConfirm";
            lbRecalcularConfirm.TabIndex = 8;
            lbRecalcularConfirm.Tag = "lb_integridadRecalcularConfirm";
            lbRecalcularConfirm.Text = "Se tomarán como válidos los datos actuales y se recalcularán los dígitos verificadores. ¿Desea continuar?";
            lbRecalcularConfirm.Visible = false;
            //
            // lbRecalcularError
            //
            lbRecalcularError.AutoSize = true;
            lbRecalcularError.Location = new Point(700, 80);
            lbRecalcularError.Name = "lbRecalcularError";
            lbRecalcularError.TabIndex = 9;
            lbRecalcularError.Tag = "lb_integridadRecalcularError";
            lbRecalcularError.Text = "Error al recalcular los dígitos verificadores";
            lbRecalcularError.Visible = false;
            //
            // lbIntegridadPersiste
            //
            lbIntegridadPersiste.AutoSize = true;
            lbIntegridadPersiste.Location = new Point(700, 100);
            lbIntegridadPersiste.Name = "lbIntegridadPersiste";
            lbIntegridadPersiste.TabIndex = 10;
            lbIntegridadPersiste.Tag = "lb_integridadPersiste";
            lbIntegridadPersiste.Text = "La integridad de los datos sigue fallando. Revise el detalle y elija otra acción.";
            lbIntegridadPersiste.Visible = false;
            //
            // lbSesionInvalida
            //
            lbSesionInvalida.AutoSize = true;
            lbSesionInvalida.Location = new Point(700, 120);
            lbSesionInvalida.Name = "lbSesionInvalida";
            lbSesionInvalida.TabIndex = 11;
            lbSesionInvalida.Tag = "lb_integridadSesionInvalida";
            lbSesionInvalida.Text = "El backup restaurado no contiene al administrador actual. Debe iniciar sesión nuevamente.";
            lbSesionInvalida.Visible = false;
            //
            // lbTablaCompleta
            //
            lbTablaCompleta.AutoSize = true;
            lbTablaCompleta.Location = new Point(700, 140);
            lbTablaCompleta.Name = "lbTablaCompleta";
            lbTablaCompleta.TabIndex = 12;
            lbTablaCompleta.Tag = "lb_integridadTablaCompleta";
            lbTablaCompleta.Text = "(tabla completa)";
            lbTablaCompleta.Visible = false;
            //
            // frmIntegridad
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 350);
            ControlBox = false;
            Controls.Add(lbTablaCompleta);
            Controls.Add(lbSesionInvalida);
            Controls.Add(lbIntegridadPersiste);
            Controls.Add(lbRecalcularError);
            Controls.Add(lbRecalcularConfirm);
            Controls.Add(lbRestoreError);
            Controls.Add(lbRestoreConfirm);
            Controls.Add(btnCancelar);
            Controls.Add(btnRecalcular);
            Controls.Add(btnRestaurar);
            Controls.Add(dgvDetalle);
            Controls.Add(lbDescripcion);
            Controls.Add(lbTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmIntegridad";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Tag = "lb_integridadTitulo";
            Text = "Resolución de integridad";
            FormClosing += frmIntegridad_FormClosing;
            Load += frmIntegridad_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitulo;
        private Label lbDescripcion;
        private DataGridView dgvDetalle;
        private DataGridViewTextBoxColumn colTabla;
        private DataGridViewTextBoxColumn colFila;
        private DataGridViewTextBoxColumn colCampos;
        private Button btnRestaurar;
        private Button btnRecalcular;
        private Button btnCancelar;
        private Label lbRestoreConfirm;
        private Label lbRestoreError;
        private Label lbRecalcularConfirm;
        private Label lbRecalcularError;
        private Label lbIntegridadPersiste;
        private Label lbSesionInvalida;
        private Label lbTablaCompleta;
    }
}

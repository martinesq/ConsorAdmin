namespace AppBase
{
    partial class FormSolicitudServicio_755ME
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
            grpSolicitud = new System.Windows.Forms.GroupBox();
            lblCategoria = new System.Windows.Forms.Label();
            txtCategoria = new System.Windows.Forms.TextBox();
            lblDescripcion = new System.Windows.Forms.Label();
            txtDescripcion = new System.Windows.Forms.TextBox();
            lblUbicacion = new System.Windows.Forms.Label();
            rbAreaComun = new System.Windows.Forms.RadioButton();
            rbUnidadFuncional = new System.Windows.Forms.RadioButton();
            cboUnidad = new System.Windows.Forms.ComboBox();
            btnConfirmar = new System.Windows.Forms.Button();
            lblResultado = new System.Windows.Forms.Label();
            grpSolicitud.SuspendLayout();
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
            lblSinConsorcios.Tag = "lb_sin_consorcios";
            lblSinConsorcios.Text = "No tiene consorcios asignados";
            lblSinConsorcios.Size = new System.Drawing.Size(0, 15);
            lblSinConsorcios.TabIndex = 2;
            //
            // grpSolicitud
            //
            grpSolicitud.Controls.Add(lblCategoria);
            grpSolicitud.Controls.Add(txtCategoria);
            grpSolicitud.Controls.Add(lblDescripcion);
            grpSolicitud.Controls.Add(txtDescripcion);
            grpSolicitud.Controls.Add(lblUbicacion);
            grpSolicitud.Controls.Add(rbAreaComun);
            grpSolicitud.Controls.Add(rbUnidadFuncional);
            grpSolicitud.Controls.Add(cboUnidad);
            grpSolicitud.Location = new System.Drawing.Point(15, 55);
            grpSolicitud.Name = "grpSolicitud";
            grpSolicitud.Size = new System.Drawing.Size(760, 250);
            grpSolicitud.TabIndex = 3;
            grpSolicitud.TabStop = false;
            grpSolicitud.Text = "Solicitud de servicio";
            grpSolicitud.Tag = "lb_grp_solicitud_servicio";
            //
            // lblCategoria
            //
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new System.Drawing.Point(15, 30);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new System.Drawing.Size(61, 15);
            lblCategoria.TabIndex = 0;
            lblCategoria.Text = "Categoría:";
            lblCategoria.Tag = "lb_categoria";
            //
            // txtCategoria
            //
            txtCategoria.Location = new System.Drawing.Point(110, 27);
            txtCategoria.MaxLength = 50;
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new System.Drawing.Size(300, 23);
            txtCategoria.TabIndex = 1;
            txtCategoria.TextChanged += txtSolicitud_TextChanged;
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new System.Drawing.Point(15, 65);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new System.Drawing.Size(72, 15);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Tag = "lb_descripcion";
            //
            // txtDescripcion
            //
            txtDescripcion.Location = new System.Drawing.Point(110, 62);
            txtDescripcion.MaxLength = 200;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new System.Drawing.Size(630, 80);
            txtDescripcion.TabIndex = 3;
            txtDescripcion.TextChanged += txtSolicitud_TextChanged;
            //
            // lblUbicacion
            //
            lblUbicacion.AutoSize = true;
            lblUbicacion.Location = new System.Drawing.Point(15, 160);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new System.Drawing.Size(63, 15);
            lblUbicacion.TabIndex = 4;
            lblUbicacion.Text = "Ubicación:";
            lblUbicacion.Tag = "lb_ubicacion";
            //
            // rbAreaComun
            //
            rbAreaComun.AutoSize = true;
            rbAreaComun.Checked = true;
            rbAreaComun.Location = new System.Drawing.Point(110, 158);
            rbAreaComun.Name = "rbAreaComun";
            rbAreaComun.Size = new System.Drawing.Size(90, 19);
            rbAreaComun.TabIndex = 5;
            rbAreaComun.TabStop = true;
            rbAreaComun.Text = "Área común";
            rbAreaComun.Tag = "lb_area_comun";
            rbAreaComun.CheckedChanged += rbUbicacion_CheckedChanged;
            //
            // rbUnidadFuncional
            //
            rbUnidadFuncional.AutoSize = true;
            rbUnidadFuncional.Location = new System.Drawing.Point(110, 190);
            rbUnidadFuncional.Name = "rbUnidadFuncional";
            rbUnidadFuncional.Size = new System.Drawing.Size(115, 19);
            rbUnidadFuncional.TabIndex = 6;
            rbUnidadFuncional.Text = "Unidad funcional";
            rbUnidadFuncional.Tag = "lb_unidad_funcional";
            rbUnidadFuncional.CheckedChanged += rbUbicacion_CheckedChanged;
            //
            // cboUnidad
            //
            cboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboUnidad.Enabled = false;
            cboUnidad.FormattingEnabled = true;
            cboUnidad.Location = new System.Drawing.Point(240, 188);
            cboUnidad.Name = "cboUnidad";
            cboUnidad.Size = new System.Drawing.Size(170, 23);
            cboUnidad.TabIndex = 7;
            //
            // btnConfirmar
            //
            btnConfirmar.Enabled = false;
            btnConfirmar.Location = new System.Drawing.Point(15, 320);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new System.Drawing.Size(180, 28);
            btnConfirmar.TabIndex = 4;
            btnConfirmar.Text = "Confirmar solicitud";
            btnConfirmar.Tag = "lb_confirmar_solicitud";
            btnConfirmar.Click += btnConfirmar_Click;
            //
            // lblResultado
            //
            lblResultado.AutoSize = true;
            lblResultado.Location = new System.Drawing.Point(15, 365);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new System.Drawing.Size(115, 15);
            lblResultado.TabIndex = 5;
            lblResultado.Text = "Solicitud registrada:";
            lblResultado.Tag = "lb_solicitud_registrada";
            //
            // FormSolicitudServicio_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(790, 550);
            Controls.Add(lblResultado);
            Controls.Add(btnConfirmar);
            Controls.Add(grpSolicitud);
            Controls.Add(lblSinConsorcios);
            Controls.Add(cboConsorcio);
            Controls.Add(lblConsorcio);
            MinimumSize = new System.Drawing.Size(790, 500);
            Name = "FormSolicitudServicio_755ME";
            Text = "Formalizar solicitud de servicio";
            Tag = "lb_formalizar_solicitud";
            Load += FormSolicitudServicio_755ME_Load;
            FormClosing += FormSolicitudServicio_755ME_FormClosing;
            grpSolicitud.ResumeLayout(false);
            grpSolicitud.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblConsorcio;
        private System.Windows.Forms.ComboBox cboConsorcio;
        private System.Windows.Forms.Label lblSinConsorcios;
        private System.Windows.Forms.GroupBox grpSolicitud;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.RadioButton rbAreaComun;
        private System.Windows.Forms.RadioButton rbUnidadFuncional;
        private System.Windows.Forms.ComboBox cboUnidad;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblResultado;
    }
}

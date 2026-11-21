namespace AppBase
{
    partial class FormAyuda_755ME
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

        private void InitializeComponent()
        {
            lblTemas = new System.Windows.Forms.Label();
            tvTemas = new System.Windows.Forms.TreeView();
            wbContenido = new System.Windows.Forms.WebBrowser();
            btnCerrar = new System.Windows.Forms.Button();
            SuspendLayout();
            //
            // lblTemas
            //
            lblTemas.AutoSize = true;
            lblTemas.Location = new System.Drawing.Point(12, 12);
            lblTemas.Name = "lblTemas";
            lblTemas.Size = new System.Drawing.Size(45, 15);
            lblTemas.TabIndex = 0;
            lblTemas.Text = "Temas";
            //
            // tvTemas
            //
            tvTemas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            tvTemas.HideSelection = false;
            tvTemas.Location = new System.Drawing.Point(12, 32);
            tvTemas.Name = "tvTemas";
            tvTemas.Size = new System.Drawing.Size(260, 470);
            tvTemas.TabIndex = 1;
            tvTemas.AfterSelect += tvTemas_AfterSelect;
            //
            // wbContenido
            //
            wbContenido.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            wbContenido.Location = new System.Drawing.Point(282, 12);
            wbContenido.MinimumSize = new System.Drawing.Size(20, 20);
            wbContenido.Name = "wbContenido";
            wbContenido.ScriptErrorsSuppressed = true;
            wbContenido.Size = new System.Drawing.Size(590, 490);
            wbContenido.TabIndex = 2;
            wbContenido.WebBrowserShortcutsEnabled = false;
            wbContenido.Navigated += wbContenido_Navigated;
            //
            // btnCerrar
            //
            btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCerrar.Location = new System.Drawing.Point(782, 512);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new System.Drawing.Size(90, 28);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            //
            // FormAyuda_755ME
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(884, 551);
            Controls.Add(btnCerrar);
            Controls.Add(wbContenido);
            Controls.Add(tvTemas);
            Controls.Add(lblTemas);
            MinimizeBox = false;
            Name = "FormAyuda_755ME";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Ayuda";
            FormClosing += FormAyuda_755ME_FormClosing;
            Load += FormAyuda_755ME_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTemas;
        private System.Windows.Forms.TreeView tvTemas;
        private System.Windows.Forms.WebBrowser wbContenido;
        private System.Windows.Forms.Button btnCerrar;
    }
}

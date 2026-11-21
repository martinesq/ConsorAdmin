namespace AppBase
{
    partial class frmMdiPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuPrincipal = new MenuStrip();
            sesiónToolStripMenuItem = new ToolStripMenuItem();
            iniciarSesiónToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            familiasToolStripMenuItem = new ToolStripMenuItem();
            idiomaToolStripMenuItem = new ToolStripMenuItem();
            nuevoIdiomaToolStripMenuItem = new ToolStripMenuItem();
            baseDeDatosToolStripMenuItem = new ToolStripMenuItem();
            backupRestoreToolStripMenuItem = new ToolStripMenuItem();
            bitacoraToolStripMenuItem = new ToolStripMenuItem();
            mnuLiquidacionExpensas_755ME = new ToolStripMenuItem();
            mnuAnularExpensa_755ME = new ToolStripMenuItem();
            mnuCobrarExpensa_755ME = new ToolStripMenuItem();
            mnuGenerarLiquidacion_755ME = new ToolStripMenuItem();
            mnuGenerarOrdenPago_755ME = new ToolStripMenuItem();
            mnuRegistrarEgreso_755ME = new ToolStripMenuItem();
            mnuGestGastos_755ME = new ToolStripMenuItem();
            mnuReporteGestion_755ME = new ToolStripMenuItem();
            mnuReporteGlobal_755ME = new ToolStripMenuItem();
            mnuAyuda_755ME = new ToolStripMenuItem();
            mnuMantenimientoConsorcios_755ME = new ToolStripMenuItem();
            mnuSerializarExpensas_755ME = new ToolStripMenuItem();
            mnuServicios_755ME = new ToolStripMenuItem();
            mnuFormalizarSolicitud_755ME = new ToolStripMenuItem();
            mnuAsignarProveedor_755ME = new ToolStripMenuItem();
            mnuCargarPrestacion_755ME = new ToolStripMenuItem();
            mnuAprobarPrestacion_755ME = new ToolStripMenuItem();
            mnuReporteServicios_755ME = new ToolStripMenuItem();
            lbdeslog_1 = new Label();
            lbdeslog_2 = new Label();
            menuPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // menuPrincipal
            // 
            menuPrincipal.ImageScalingSize = new Size(24, 24);
            menuPrincipal.Items.AddRange(new ToolStripItem[] { sesiónToolStripMenuItem, usuariosToolStripMenuItem, familiasToolStripMenuItem, idiomaToolStripMenuItem, nuevoIdiomaToolStripMenuItem, baseDeDatosToolStripMenuItem, bitacoraToolStripMenuItem, mnuMantenimientoConsorcios_755ME, mnuSerializarExpensas_755ME, mnuLiquidacionExpensas_755ME, mnuServicios_755ME, mnuReporteGlobal_755ME, mnuAyuda_755ME });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(1220, 24);
            menuPrincipal.TabIndex = 1;
            menuPrincipal.Text = "menuPrincipal";
            // 
            // sesiónToolStripMenuItem
            // 
            sesiónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { iniciarSesiónToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            sesiónToolStripMenuItem.Name = "sesiónToolStripMenuItem";
            sesiónToolStripMenuItem.Size = new Size(53, 20);
            sesiónToolStripMenuItem.Tag = "lb_sesion";
            sesiónToolStripMenuItem.Text = "Sesión";
            // 
            // iniciarSesiónToolStripMenuItem
            // 
            iniciarSesiónToolStripMenuItem.Name = "iniciarSesiónToolStripMenuItem";
            iniciarSesiónToolStripMenuItem.Size = new Size(143, 22);
            iniciarSesiónToolStripMenuItem.Tag = "lb_IniciarSesion";
            iniciarSesiónToolStripMenuItem.Text = "Iniciar Sesión";
            iniciarSesiónToolStripMenuItem.Click += Logearse;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(143, 22);
            cerrarSesiónToolStripMenuItem.Tag = "lb_CerrarSesion";
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += Desloguearse;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(64, 20);
            usuariosToolStripMenuItem.Tag = "lb_Usuarios";
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += EditarUsuarios;
            // 
            // familiasToolStripMenuItem
            // 
            familiasToolStripMenuItem.Name = "familiasToolStripMenuItem";
            familiasToolStripMenuItem.Size = new Size(62, 20);
            familiasToolStripMenuItem.Tag = "lb_familias";
            familiasToolStripMenuItem.Text = "Familias";
            familiasToolStripMenuItem.Click += EditarFamilias;
            // 
            // idiomaToolStripMenuItem
            // 
            idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            idiomaToolStripMenuItem.Size = new Size(56, 20);
            idiomaToolStripMenuItem.Tag = "lb_Idioma";
            idiomaToolStripMenuItem.Text = "Idioma";
            // 
            // nuevoIdiomaToolStripMenuItem
            // 
            nuevoIdiomaToolStripMenuItem.Name = "nuevoIdiomaToolStripMenuItem";
            nuevoIdiomaToolStripMenuItem.Size = new Size(94, 20);
            nuevoIdiomaToolStripMenuItem.Tag = "lb_NuevoIdioma";
            nuevoIdiomaToolStripMenuItem.Text = "Nuevo Idioma";
            nuevoIdiomaToolStripMenuItem.Click += crearIdiomaToolStripMenuItem_Click;
            // 
            // baseDeDatosToolStripMenuItem
            // 
            baseDeDatosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backupRestoreToolStripMenuItem });
            baseDeDatosToolStripMenuItem.Name = "baseDeDatosToolStripMenuItem";
            baseDeDatosToolStripMenuItem.Size = new Size(92, 20);
            baseDeDatosToolStripMenuItem.Tag = "lb_baseDeDatos";
            baseDeDatosToolStripMenuItem.Text = "Base de Datos";
            baseDeDatosToolStripMenuItem.Visible = false;
            // 
            // backupRestoreToolStripMenuItem
            // 
            backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            backupRestoreToolStripMenuItem.Size = new Size(173, 22);
            backupRestoreToolStripMenuItem.Tag = "lb_backupRestore";
            backupRestoreToolStripMenuItem.Text = "Backup / Restaurar";
            backupRestoreToolStripMenuItem.Click += AbrirBackup;
            // 
            // bitacoraToolStripMenuItem
            // 
            bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            bitacoraToolStripMenuItem.Size = new Size(62, 20);
            bitacoraToolStripMenuItem.Tag = "lb_bitacora";
            bitacoraToolStripMenuItem.Text = "Bitácora";
            bitacoraToolStripMenuItem.Visible = false;
            bitacoraToolStripMenuItem.Click += AbrirBitacora;
            //
            // mnuLiquidacionExpensas_755ME
            //
            mnuLiquidacionExpensas_755ME.DropDownItems.AddRange(new ToolStripItem[] { mnuAnularExpensa_755ME, mnuCobrarExpensa_755ME, mnuGenerarLiquidacion_755ME, mnuGenerarOrdenPago_755ME, mnuRegistrarEgreso_755ME, mnuGestGastos_755ME, mnuReporteGestion_755ME });
            mnuLiquidacionExpensas_755ME.Name = "mnuLiquidacionExpensas_755ME";
            mnuLiquidacionExpensas_755ME.Size = new Size(160, 20);
            mnuLiquidacionExpensas_755ME.Text = "Liquidación de Expensas";
            mnuLiquidacionExpensas_755ME.Tag = "lb_menu_liquidacion";
            mnuLiquidacionExpensas_755ME.Visible = false;
            //
            // mnuAnularExpensa_755ME
            //
            mnuAnularExpensa_755ME.Name = "mnuAnularExpensa_755ME";
            mnuAnularExpensa_755ME.Size = new Size(238, 22);
            mnuAnularExpensa_755ME.Text = "Anular expensa";
            mnuAnularExpensa_755ME.Tag = "lb_anular_expensa";
            mnuAnularExpensa_755ME.Click += mnuAnularExpensa_755ME_Click;
            //
            // mnuCobrarExpensa_755ME
            //
            mnuCobrarExpensa_755ME.Name = "mnuCobrarExpensa_755ME";
            mnuCobrarExpensa_755ME.Size = new Size(238, 22);
            mnuCobrarExpensa_755ME.Text = "Cobrar expensa";
            mnuCobrarExpensa_755ME.Tag = "lb_cobrar_expensa";
            mnuCobrarExpensa_755ME.Click += mnuCobrarExpensa_755ME_Click;
            //
            // mnuGenerarLiquidacion_755ME
            //
            mnuGenerarLiquidacion_755ME.Name = "mnuGenerarLiquidacion_755ME";
            mnuGenerarLiquidacion_755ME.Size = new Size(238, 22);
            mnuGenerarLiquidacion_755ME.Text = "Generar liquidación de expensas";
            mnuGenerarLiquidacion_755ME.Tag = "lb_generar_liquidacion";
            mnuGenerarLiquidacion_755ME.Click += mnuGenerarLiquidacion_755ME_Click;
            //
            // mnuGenerarOrdenPago_755ME
            //
            mnuGenerarOrdenPago_755ME.Name = "mnuGenerarOrdenPago_755ME";
            mnuGenerarOrdenPago_755ME.Size = new Size(238, 22);
            mnuGenerarOrdenPago_755ME.Text = "Generar orden de pago";
            mnuGenerarOrdenPago_755ME.Tag = "lb_generar_orden_pago";
            mnuGenerarOrdenPago_755ME.Click += mnuGenerarOrdenPago_755ME_Click;
            //
            // mnuRegistrarEgreso_755ME
            //
            mnuRegistrarEgreso_755ME.Name = "mnuRegistrarEgreso_755ME";
            mnuRegistrarEgreso_755ME.Size = new Size(238, 22);
            mnuRegistrarEgreso_755ME.Text = "Registrar egreso a proveedor";
            mnuRegistrarEgreso_755ME.Tag = "lb_registrar_egreso";
            mnuRegistrarEgreso_755ME.Click += mnuRegistrarEgreso_755ME_Click;
            //
            // mnuGestGastos_755ME
            //
            mnuGestGastos_755ME.Name = "mnuGestGastos_755ME";
            mnuGestGastos_755ME.Size = new Size(238, 22);
            mnuGestGastos_755ME.Text = "Gastos";
            mnuGestGastos_755ME.Tag = "lb_gastos";
            mnuGestGastos_755ME.Click += mnuGestGastos_755ME_Click;
            //
            // mnuReporteGestion_755ME
            //
            mnuReporteGestion_755ME.Name = "mnuReporteGestion_755ME";
            mnuReporteGestion_755ME.Size = new Size(238, 22);
            mnuReporteGestion_755ME.Text = "Reporte de gestión";
            mnuReporteGestion_755ME.Tag = "lb_reporte_gestion";
            mnuReporteGestion_755ME.Click += mnuReporteGestion_755ME_Click;
            // 
            // mnuReporteGlobal_755ME
            // 
            mnuReporteGlobal_755ME.Name = "mnuReporteGlobal_755ME";
            mnuReporteGlobal_755ME.Size = new Size(95, 20);
            mnuReporteGlobal_755ME.Text = "Reporte global";
            mnuReporteGlobal_755ME.Tag = "lb_reporte_global";
            mnuReporteGlobal_755ME.Visible = false;
            mnuReporteGlobal_755ME.Click += AbrirReporteGlobal_755ME;
            // 
            // mnuAyuda_755ME
            // 
            mnuAyuda_755ME.Name = "mnuAyuda_755ME";
            mnuAyuda_755ME.Size = new Size(53, 20);
            mnuAyuda_755ME.Text = "Ayuda";
            mnuAyuda_755ME.Tag = "lb_ayuda";
            mnuAyuda_755ME.Click += AbrirAyuda_755ME;
            //
            // mnuMantenimientoConsorcios_755ME
            //
            mnuMantenimientoConsorcios_755ME.Name = "mnuMantenimientoConsorcios_755ME";
            mnuMantenimientoConsorcios_755ME.Size = new Size(190, 20);
            mnuMantenimientoConsorcios_755ME.Text = "Mantenimiento de consorcios";
            mnuMantenimientoConsorcios_755ME.Tag = "lb_mant_consorcios";
            mnuMantenimientoConsorcios_755ME.Visible = false;
            mnuMantenimientoConsorcios_755ME.Click += AbrirMantenimientoConsorcios_755ME;
            //
            // mnuSerializarExpensas_755ME
            //
            mnuSerializarExpensas_755ME.Name = "mnuSerializarExpensas_755ME";
            mnuSerializarExpensas_755ME.Size = new Size(190, 20);
            mnuSerializarExpensas_755ME.Text = "Serializar/Deserializar expensas";
            mnuSerializarExpensas_755ME.Tag = "lb_ser_menu";
            mnuSerializarExpensas_755ME.Visible = false;
            mnuSerializarExpensas_755ME.Click += AbrirSerializacionExpensas_755ME;
            //
            // mnuServicios_755ME
            //
            mnuServicios_755ME.DropDownItems.AddRange(new ToolStripItem[] { mnuFormalizarSolicitud_755ME, mnuAsignarProveedor_755ME, mnuCargarPrestacion_755ME, mnuAprobarPrestacion_755ME, mnuReporteServicios_755ME });
            mnuServicios_755ME.Name = "mnuServicios_755ME";
            mnuServicios_755ME.Size = new Size(140, 20);
            mnuServicios_755ME.Text = "Gestión de Servicios";
            mnuServicios_755ME.Tag = "lb_menu_servicios";
            mnuServicios_755ME.Visible = false;
            //
            // mnuFormalizarSolicitud_755ME
            //
            mnuFormalizarSolicitud_755ME.Name = "mnuFormalizarSolicitud_755ME";
            mnuFormalizarSolicitud_755ME.Size = new Size(238, 22);
            mnuFormalizarSolicitud_755ME.Text = "Formalizar solicitud de servicio";
            mnuFormalizarSolicitud_755ME.Tag = "lb_formalizar_solicitud";
            mnuFormalizarSolicitud_755ME.Click += mnuFormalizarSolicitud_755ME_Click;
            //
            // mnuAsignarProveedor_755ME
            //
            mnuAsignarProveedor_755ME.Name = "mnuAsignarProveedor_755ME";
            mnuAsignarProveedor_755ME.Size = new Size(238, 22);
            mnuAsignarProveedor_755ME.Text = "Asignar proveedor";
            mnuAsignarProveedor_755ME.Tag = "lb_asignar_proveedor";
            mnuAsignarProveedor_755ME.Click += mnuAsignarProveedor_755ME_Click;
            //
            // mnuCargarPrestacion_755ME
            //
            mnuCargarPrestacion_755ME.Name = "mnuCargarPrestacion_755ME";
            mnuCargarPrestacion_755ME.Size = new Size(238, 22);
            mnuCargarPrestacion_755ME.Text = "Cargar prestación";
            mnuCargarPrestacion_755ME.Tag = "lb_cargar_prestacion";
            mnuCargarPrestacion_755ME.Click += mnuCargarPrestacion_755ME_Click;
            //
            // mnuAprobarPrestacion_755ME
            //
            mnuAprobarPrestacion_755ME.Name = "mnuAprobarPrestacion_755ME";
            mnuAprobarPrestacion_755ME.Size = new Size(238, 22);
            mnuAprobarPrestacion_755ME.Text = "Aprobar prestación";
            mnuAprobarPrestacion_755ME.Tag = "lb_aprobar_prestacion";
            mnuAprobarPrestacion_755ME.Click += mnuAprobarPrestacion_755ME_Click;
            //
            // mnuReporteServicios_755ME
            //
            mnuReporteServicios_755ME.Name = "mnuReporteServicios_755ME";
            mnuReporteServicios_755ME.Size = new Size(238, 22);
            mnuReporteServicios_755ME.Text = "Reporte de servicios";
            mnuReporteServicios_755ME.Tag = "lb_reporte_servicios";
            mnuReporteServicios_755ME.Click += AbrirReporteServicios_755ME;
            //
            // lbdeslog_1
            // 
            lbdeslog_1.AutoSize = true;
            lbdeslog_1.Location = new Point(1458, 868);
            lbdeslog_1.Name = "lbdeslog_1";
            lbdeslog_1.Size = new Size(76, 15);
            lbdeslog_1.TabIndex = 2;
            lbdeslog_1.Tag = "lb_deslog_1";
            lbdeslog_1.Text = "¿Quiere salir?";
            lbdeslog_1.Visible = false;
            // 
            // lbdeslog_2
            // 
            lbdeslog_2.AutoSize = true;
            lbdeslog_2.Location = new Point(1458, 841);
            lbdeslog_2.Name = "lbdeslog_2";
            lbdeslog_2.Size = new Size(29, 15);
            lbdeslog_2.TabIndex = 4;
            lbdeslog_2.Tag = "btn_salir";
            lbdeslog_2.Text = "Salir";
            lbdeslog_2.Visible = false;
            // 
            // frmMdiPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 784);
            Controls.Add(lbdeslog_2);
            Controls.Add(lbdeslog_1);
            Controls.Add(menuPrincipal);
            IsMdiContainer = true;
            MainMenuStrip = menuPrincipal;
            Name = "frmMdiPrincipal";
            Tag = "lb_principal";
            Text = "Principal";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmMdiPrincipal_FormClosing;
            Load += frmMdiPrincipal_Load;
            HelpRequested += frmMdiPrincipal_HelpRequested_755ME;
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private MenuStrip menuPrincipal;
        private ToolStripMenuItem sesiónToolStripMenuItem;
        private ToolStripMenuItem iniciarSesiónToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem familiasToolStripMenuItem;
        private ToolStripMenuItem idiomaToolStripMenuItem;
        private Label lbdeslog_1;
        private Label lbdeslog_2;
        private ToolStripMenuItem nuevoIdiomaToolStripMenuItem;
        private ToolStripMenuItem baseDeDatosToolStripMenuItem;
        private ToolStripMenuItem backupRestoreToolStripMenuItem;
        private ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLiquidacionExpensas_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuAnularExpensa_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuCobrarExpensa_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuGenerarLiquidacion_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuGenerarOrdenPago_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistrarEgreso_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuGestGastos_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuReporteGestion_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuReporteGlobal_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuAyuda_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuMantenimientoConsorcios_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuSerializarExpensas_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuServicios_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuFormalizarSolicitud_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuAsignarProveedor_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuCargarPrestacion_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuAprobarPrestacion_755ME;
        private System.Windows.Forms.ToolStripMenuItem mnuReporteServicios_755ME;
    }
}

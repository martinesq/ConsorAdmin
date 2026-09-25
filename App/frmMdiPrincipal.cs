using BE;
using BLL;
using INT;
using SER;
using SER.Composite;
using System.Windows.Forms;

namespace AppBase
{
    public partial class frmMdiPrincipal : Form, IIdiomaObserver
    {
        UsuarioBLL _userBLL;
        Usuario _usuario;
        TraductorBLL _traductor;
        public frmMdiPrincipal()
        {
            InitializeComponent();

            SessionManager.AgregarObservador(this);

            _userBLL = new UsuarioBLL();
            _traductor = new TraductorBLL();
        }
        private void Logearse(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.MdiParent = this;
            f.Show();
        }
        private void Desloguearse(object sender, EventArgs e)
        {
            if (MessageBox.Show(lbdeslog_1.Text, lbdeslog_2.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _userBLL.Logout();
                CerrarHijosMdi();
                Actualizar();
            }
           // frmMdiPrincipal_Load(sender, e);
        }
        private void frmMdiPrincipal_Load(object sender, EventArgs e)
        {
            Actualizar();
        }
        // se cierra sobre una copia porque Close() modifica MdiChildren
        private void CerrarHijosMdi()
        {
            Form[] hijos = new Form[this.MdiChildren.Length];
            this.MdiChildren.CopyTo(hijos, 0);
            foreach (Form hijo in hijos)
            {
                hijo.Close();
            }
        }
        public void Actualizar()
        {
            // se itera sobre una copia porque el menu se reordena con el merge de los hijos MDI
            ToolStripItem[] itemsMenu = new ToolStripItem[menuPrincipal.Items.Count];
            menuPrincipal.Items.CopyTo(itemsMenu, 0);
            mnuAnularExpensa_755ME.Enabled = false;
            mnuRegistrarPago_755ME.Enabled = false;
            mnuObtenerMorosidad_755ME.Enabled = false;
            mnuGenerarLiquidacion_755ME.Enabled = false;
            mnuEmitirEstadoCuenta_755ME.Enabled = false;
            mnuGenerarOrdenPago_755ME.Enabled = false;
            mnuRegistrarEgreso_755ME.Enabled = false;
            mnuRevisarComposicion_755ME.Enabled = false;
            mnuObtenerEstadoFondo_755ME.Enabled = false;
            mnuGestGastos_755ME.Enabled = false;
            foreach (ToolStripItem c in itemsMenu)
            {
                if (c.Name != "sesiónToolStripMenuItem" && c.Name != "idiomaToolStripMenuItem")
                {
                    c.Visible = false;
                }
            }
            if (SessionManager.EstaLogueado())
            {
                _usuario = _userBLL.CargarUsuario();
                iniciarSesiónToolStripMenuItem.Enabled = false;
                cerrarSesiónToolStripMenuItem.Enabled = true;

                foreach (PermisoCompuesto p in _usuario.Permisos)
                {
                    ValidarPermisos(p);
                }
            }
            else
            {
                iniciarSesiónToolStripMenuItem.Enabled = true;
                cerrarSesiónToolStripMenuItem.Enabled = false;
            }
            ActualizarIdioma(SessionManager.Idioma);
            CargarIdiomas();
        }
        private void ValidarPermisos(PermisoCompuesto p)
        {
            if (p is Familia)
            {
                foreach (PermisoCompuesto h in p.ObtenerHijos)
                {
                    ValidarPermisos(h);
                }
            }
            //--------Familias
            if (p.Permiso == TipoPatente.GestPermisos)
            {
                familiasToolStripMenuItem.Visible = true;
            }
            //--------Usuarios
            if (p.Permiso == TipoPatente.GestUsuarios)
            {
                usuariosToolStripMenuItem.Visible = true;
            }
            //--------Editar Idioma
            if (p.Permiso == TipoPatente.GestIdiomas)
            {
                nuevoIdiomaToolStripMenuItem.Visible = true;
            }
            //--------Base de Datos // Backup y Restore
            if (p.Permiso == TipoPatente.GestBackup)
            {
                baseDeDatosToolStripMenuItem.Visible = true;
            }
            //--------Bitacora
            if (p.Permiso == TipoPatente.GestBitacora)
            {
                bitacoraToolStripMenuItem.Visible = true;
            }
            //--------Liquidacion de Expensas (PN01)
            if (p.Permiso == TipoPatente.AnularExpensa_755ME)
            {
                mnuAnularExpensa_755ME.Enabled = true;
                mnuLiquidacionExpensas_755ME.Visible = true;
            }
            if (p.Permiso == TipoPatente.RegistrarPago_755ME)
            {
                mnuRegistrarPago_755ME.Enabled = true;
                mnuLiquidacionExpensas_755ME.Visible = true;
            }
            if (p.Permiso == TipoPatente.ObtenerMorosidad_755ME)
            {
                mnuObtenerMorosidad_755ME.Enabled = true;
                mnuLiquidacionExpensas_755ME.Visible = true;
            }
            if (p.Permiso == TipoPatente.GenerarLiquidacion_755ME)
            {
                mnuGenerarLiquidacion_755ME.Enabled = true;
                mnuLiquidacionExpensas_755ME.Visible = true;
            }
            if (p.Permiso == TipoPatente.EmitirEstadoCuenta_755ME)
            {
                mnuEmitirEstadoCuenta_755ME.Enabled = true;
                mnuLiquidacionExpensas_755ME.Visible = true;
            }
            if (p.Permiso == TipoPatente.GenerarOrdenPago_755ME)
            {
                mnuGenerarOrdenPago_755ME.Enabled = true;
                mnuLiquidacionExpensas_755ME.Visible = true;
            }
            if (p.Permiso == TipoPatente.RegistrarEgreso_755ME)
            {
                mnuRegistrarEgreso_755ME.Enabled = true;
                mnuLiquidacionExpensas_755ME.Visible = true;
            }
            if (p.Permiso == TipoPatente.RevisarComposicion_755ME)
            {
                mnuRevisarComposicion_755ME.Enabled = true;
                mnuLiquidacionExpensas_755ME.Visible = true;
            }
            if (p.Permiso == TipoPatente.ObtenerEstadoFondo_755ME)
            {
                mnuObtenerEstadoFondo_755ME.Enabled = true;
                mnuLiquidacionExpensas_755ME.Visible = true;
            }
            if (p.Permiso == TipoPatente.GestGastos_755ME)
            {
                mnuGestGastos_755ME.Enabled = true;
                mnuLiquidacionExpensas_755ME.Visible = true;
            }
            //--------Mantenimiento de consorcios (solo Administrador global)
            if (p.Permiso == TipoPatente.GestMantenimientoConsorcios_755ME)
            {
                mnuMantenimientoConsorcios_755ME.Visible = true;
            }
        }

        private void EditarFamilias(object sender, EventArgs e)
        {
            frmFamilias f = new frmFamilias();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void EditarUsuarios(object sender, EventArgs e)
        {
            frmUsuarios f = new frmUsuarios();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void AbrirBackup(object sender, EventArgs e)
        {
            frmBackup f = new frmBackup();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void AbrirBitacora(object sender, EventArgs e)
        {
            frmBitacora f = new frmBitacora();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        // abre un formulario hijo dentro del MDI
        private void AbrirHijo(Form formulario)
        {
            formulario.MdiParent = this;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.Show();
        }

        private void mnuAnularExpensa_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormExpensa_755ME(abrirEnComposicion: false));
        }

        private void mnuRevisarComposicion_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormExpensa_755ME(abrirEnComposicion: true));
        }

        private void mnuRegistrarPago_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormPago_755ME());
        }

        private void mnuObtenerMorosidad_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormMorosidad_755ME());
        }

        private void mnuGenerarLiquidacion_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormLiquidacion_755ME());
        }

        private void mnuEmitirEstadoCuenta_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormEstadoCuenta_755ME());
        }

        private void mnuGenerarOrdenPago_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormOrdenPago_755ME());
        }

        private void mnuRegistrarEgreso_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormEgreso_755ME());
        }

        private void mnuObtenerEstadoFondo_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormFondo_755ME());
        }

        private void mnuGestGastos_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormGasto_755ME());
        }

        private void AbrirMantenimientoConsorcios_755ME(object sender, EventArgs e)
        {
            // se abre con barra de titulo, como Usuarios/Familias
            FormMantenimientoConsorcios_755ME f = new FormMantenimientoConsorcios_755ME();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        public void ActualizarIdioma(IIdioma idioma = null)
        {
            _traductor = new TraductorBLL();
            var mTraducciones = _traductor.ObtenerTraduccion(idioma);
            if (this.Tag != null && mTraducciones.ContainsKey(this.Tag.ToString()))
                this.Text = mTraducciones[this.Tag.ToString()].Texto;

            foreach (ToolStripMenuItem c3 in menuPrincipal.Items)
            {
                CambiarMenu(c3);

                void CambiarMenu(ToolStripMenuItem menu)
                {
                    if (menu.Tag != null && mTraducciones.ContainsKey(menu.Tag.ToString()))
                    {
                        menu.Text = mTraducciones[menu.Tag.ToString()].Texto;
                    }
                    if (menu.HasDropDownItems)
                    {
                        foreach (ToolStripMenuItem menu2 in menu.DropDownItems)
                        {
                            CambiarMenu(menu2);
                        }
                    }
                }
            }
            CambiarIdiomaFormulario(this, idioma);

        }
        public void CambiarIdiomaFormulario(Form formulario, IIdioma idioma)
        {
            if (idioma == null)
            {
                foreach (var item in idiomaToolStripMenuItem.DropDownItems)
                {
                    if (((ToolStripMenuItem)item).Checked)
                    {
                        idioma = new Idioma(((IIdioma)((ToolStripMenuItem)item).Tag).Id);
                    }

                }
            }
            _traductor = new TraductorBLL();
            var mTraducciones = _traductor.ObtenerTraduccion(idioma);
            if (formulario.Tag != null && mTraducciones.ContainsKey(formulario.Tag.ToString()))
                formulario.Text = mTraducciones[formulario.Tag.ToString()].Texto;

            foreach (Control c in formulario.Controls)
            {
                CambiarControl(c);
            }

            void CambiarControl(Control control)
            {
                if (control.Tag != null && mTraducciones.ContainsKey(control.Tag.ToString()))
                {
                    control.Text = mTraducciones[control.Tag.ToString()].Texto;
                }
                // las columnas del DataGridView no son Control, se traducen aparte
                if (control is DataGridView grilla)
                {
                    foreach (DataGridViewColumn columna in grilla.Columns)
                    {
                        if (columna.Tag != null && mTraducciones.ContainsKey(columna.Tag.ToString()))
                        {
                            columna.HeaderText = mTraducciones[columna.Tag.ToString()].Texto;
                        }
                    }
                }
                if (control.HasChildren)
                {
                    foreach (Control c2 in control.Controls)
                    {
                        CambiarControl(c2);
                    }
                }
            }
        }
        private void frmMdiPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
        private void CargarIdiomas()
        {
            this.idiomaToolStripMenuItem.DropDownItems.Clear();
            var idiomas = _traductor.ObtenerIdiomas();
            foreach (var item in idiomas)
            {
                var t = new ToolStripMenuItem();
                t.Text = item.Nombre;
                t.Tag = item;
                t.Checked = item.Default;
                this.idiomaToolStripMenuItem.DropDownItems.Add(t);
                t.Click += idioma_Click;
            }
        }
        private void idioma_Click(object sender, EventArgs e)
        {
            // CambiarIdioma avisa a todos los formularios abiertos (observers), incluido este
            SessionManager.CambiarIdioma((IIdioma)((ToolStripMenuItem)sender).Tag);
            MarcarIdioma();
        }
        private void MarcarIdioma()
        {
            if (SessionManager.Idioma != null)
            {
                foreach (var item in idiomaToolStripMenuItem.DropDownItems)
                {

                    ((ToolStripMenuItem)item).Checked = SessionManager.Idioma.Id.Equals(((IIdioma)((ToolStripMenuItem)item).Tag).Id);
                    if (((ToolStripMenuItem)item).Checked)
                    {
                        ((ToolStripMenuItem)item).Enabled = false;
                    }
                    else
                        ((ToolStripMenuItem)item).Enabled = true;
                }
            }
        }
        private void crearIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditarIdiomas f = new frmEditarIdiomas();
            f.MdiParent = this;
            f.Show();
        }
    }
}

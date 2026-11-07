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
            ToolStripItem[] itemsMenu = new ToolStripItem[menuPrincipal.Items.Count];
            menuPrincipal.Items.CopyTo(itemsMenu, 0);
            if (SessionManager.EstaLogueado())
            {
                _usuario = _userBLL.CargarUsuario();
                iniciarSesiónToolStripMenuItem.Enabled = false;
                cerrarSesiónToolStripMenuItem.Enabled = true;
            }
            else
            {
                iniciarSesiónToolStripMenuItem.Enabled = true;
                cerrarSesiónToolStripMenuItem.Enabled = false;
            }
            HashSet<string> permitidos = ObtenerNombresDePermisos_755ME();
            foreach (ToolStripItem c in itemsMenu)
            {
                if (c.Name != "sesiónToolStripMenuItem" && c.Name != "idiomaToolStripMenuItem")
                {
                    AplicarPermisos_755ME(c, permitidos, false);
                }
            }
            ActualizarIdioma(SessionManager.Idioma);
            CargarIdiomas();
        }
        private HashSet<string> ObtenerNombresDePermisos_755ME()
        {
            List<IPermiso> permisos = new List<IPermiso>();
            if (SessionManager.EstaLogueado())
            {
                foreach (PermisoCompuesto p in _usuario.Permisos)
                {
                    p.AgregarPermisosEn_755ME(permisos);
                }
            }
            return new HashSet<string>(permisos.Select(p => p.Nombre));
        }

        private bool AplicarPermisos_755ME(ToolStripItem item, HashSet<string> permitidos, bool padrePermitido)
        {
            bool permitido = padrePermitido || permitidos.Contains(item.Name);
            bool hijoVisible = false;
            if (item is ToolStripMenuItem menu)
            {
                foreach (ToolStripItem hijo in menu.DropDownItems)
                {
                    if (AplicarPermisos_755ME(hijo, permitidos, permitido)) hijoVisible = true;
                }
            }
            item.Visible = permitido || hijoVisible;
            return permitido || hijoVisible;
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
            AbrirHijo(new FormExpensa_755ME());
        }

        private void mnuRegistrarPago_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormPago_755ME());
        }

        private void mnuGenerarLiquidacion_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormLiquidacion_755ME());
        }

        private void mnuGenerarOrdenPago_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormOrdenPago_755ME());
        }

        private void mnuRegistrarEgreso_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormEgreso_755ME());
        }

        private void mnuReporteGestion_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormReporteGestion_755ME());
        }

        private void mnuGestGastos_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormGasto_755ME());
        }

        private void mnuFormalizarSolicitud_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormSolicitudServicio_755ME());
        }

        private void mnuAsignarProveedor_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormAsignacionProveedor_755ME());
        }

        private void mnuCargarPrestacion_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormPrestacion_755ME());
        }

        private void mnuAprobarPrestacion_755ME_Click(object sender, EventArgs e)
        {
            AbrirHijo(new FormAprobacionPrestacion_755ME());
        }

        private void AbrirMantenimientoConsorcios_755ME(object sender, EventArgs e)
        {
            // se abre con barra de titulo, como Usuarios/Familias
            FormMantenimientoConsorcios_755ME f = new FormMantenimientoConsorcios_755ME();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void AbrirReporteServicios_755ME(object sender, EventArgs e)
        {
            FormReporteServiciosPN02_755ME f = new FormReporteServiciosPN02_755ME();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void AbrirSerializacionExpensas_755ME(object sender, EventArgs e)
        {
            FormSerializacion_755ME f = new FormSerializacion_755ME();
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

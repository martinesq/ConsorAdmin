using INT;
using SER;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AppBase
{
    // D02: ayuda en linea, arbol de temas a la izquierda y el tema a la derecha
    public partial class FormAyuda_755ME : Form, IIdiomaObserver
    {
        // los temas se agrupan por proceso, con los nombres del menu principal; sin etiqueta van sueltos
        private static readonly (string Etiqueta, string PorDefecto, string[] Claves)[] _arbol_755ME =
        {
            ("", "", new[] { "indice" }),
            ("lb_sesion", "Sesión", new[] { "login" }),
            ("lb_ayuda_seguridad", "Seguridad", new[] { "usuarios", "familias", "bitacora" }),
            ("", "", new[] { "idioma" }),
            ("lb_baseDeDatos", "Base de Datos", new[] { "backup", "integridad" }),
            ("lb_mant_consorcios", "Mantenimiento de consorcios", new[] { "maestros", "bitacora-cambios" }),
            ("lb_menu_liquidacion", "Liquidación de Expensas", new[] { "gastos", "liquidacion", "expensas", "pagos", "ordenes-pago", "egresos", "reporte-gestion" }),
            ("lb_menu_servicios", "Gestión de Servicios", new[] { "solicitud-servicio", "asignar-proveedor", "cargar-prestacion", "aprobar-prestacion", "reporte-servicios" }),
            ("", "", new[] { "reporte-global", "serializacion" }),
        };

        private static FormAyuda_755ME? _abierta;
        private readonly AyudaService_755ME _ayuda = new AyudaService_755ME();
        private string _clave;
        private bool _cargando;

        public FormAyuda_755ME(string clave = "indice")
        {
            InitializeComponent();
            _clave = clave;
        }

        // una sola ventana de ayuda: si ya esta abierta se cambia de tema
        public static void Mostrar_755ME(Form desde, string clave = "indice")
        {
            // la ayuda es solo para usuarios logueados
            if (!SessionManager.EstaLogueado()) return;
            if (_abierta == null || _abierta.IsDisposed)
            {
                _abierta = new FormAyuda_755ME(clave);
                _abierta.Show(desde.MdiParent ?? desde);
                return;
            }
            _abierta.MostrarTema_755ME(clave);
            _abierta.Activate();
        }

        private void FormAyuda_755ME_Load(object sender, EventArgs e)
        {
            SessionManager.AgregarObservador(this);
            ActualizarIdioma(SessionManager.Idioma);
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            Text = IdiomaUI_755ME.Texto("lb_ayuda", "Ayuda");
            lblTemas.Text = IdiomaUI_755ME.Texto("lb_ayuda_temas", "Temas");
            btnCerrar.Text = IdiomaUI_755ME.Texto("lb_ayuda_cerrar", "Cerrar");
            CargarTemas_755ME();
            MostrarTema_755ME(_clave);
        }

        // los archivos de ayuda estan por codigo de idioma, la base guarda el nombre
        private static string CodigoIdioma_755ME()
        {
            IIdioma? idioma = SessionManager.Idioma;
            if (idioma == null || idioma.Default) return "es";
            if (idioma.Nombre.StartsWith("Ingl") || idioma.Nombre.StartsWith("Engl")) return "en";
            return idioma.Nombre;
        }

        private void CargarTemas_755ME()
        {
            _cargando = true;
            tvTemas.BeginUpdate();
            tvTemas.Nodes.Clear();
            string idioma = CodigoIdioma_755ME();
            List<string> disponibles = _ayuda.ObtenerTemas_755ME(idioma);
            foreach (var grupo in _arbol_755ME)
            {
                TreeNodeCollection destino = tvTemas.Nodes;
                if (grupo.Etiqueta != "")
                {
                    destino = tvTemas.Nodes.Add(IdiomaUI_755ME.Texto(grupo.Etiqueta, grupo.PorDefecto)).Nodes;
                }
                foreach (string clave in grupo.Claves.Where(c => disponibles.Contains(c)))
                {
                    TreeNode nodo = destino.Add(TituloDe_755ME(_ayuda.ObtenerRutaTema_755ME(clave, idioma), clave));
                    nodo.Tag = clave;
                }
            }
            tvTemas.ExpandAll();
            tvTemas.EndUpdate();
            _cargando = false;
        }

        // el nombre que se muestra en el arbol es el <title> del archivo
        private static string TituloDe_755ME(string ruta, string clave)
        {
            if (!File.Exists(ruta)) return clave;
            Match m = Regex.Match(File.ReadAllText(ruta), "<title>(.*?)</title>");
            return m.Success ? m.Groups[1].Value : clave;
        }

        private void MostrarTema_755ME(string clave)
        {
            _clave = clave;
            SeleccionarEnArbol_755ME(clave);
            wbContenido.Navigate(_ayuda.ObtenerRutaTema_755ME(clave, CodigoIdioma_755ME()));
        }

        private void SeleccionarEnArbol_755ME(string clave)
        {
            _cargando = true;
            tvTemas.SelectedNode = BuscarNodo_755ME(tvTemas.Nodes, clave);
            _cargando = false;
        }

        private static TreeNode? BuscarNodo_755ME(TreeNodeCollection nodos, string clave)
        {
            foreach (TreeNode n in nodos)
            {
                if (clave.Equals(n.Tag)) return n;
                TreeNode? hijo = BuscarNodo_755ME(n.Nodes, clave);
                if (hijo != null) return hijo;
            }
            return null;
        }

        // los nodos de grupo no tienen tema, solo se abren y cierran
        private void tvTemas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_cargando || e.Node?.Tag is not string clave) return;
            MostrarTema_755ME(clave);
        }

        // si se entra a un tema desde un enlace, el arbol acompaña
        private void wbContenido_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url == null || !e.Url.IsFile) return;
            _clave = Path.GetFileNameWithoutExtension(e.Url.LocalPath);
            SeleccionarEnArbol_755ME(_clave);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAyuda_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

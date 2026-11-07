using BE;
using BLL;
using INT;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // A03: exporta a XML las expensas anulables de un consorcio y muestra lo que se lee de un archivo
    public partial class FormSerializacion_755ME : Form, IIdiomaObserver
    {
        private readonly ConsorcioBLL_755ME _consorcioBLL = new ConsorcioBLL_755ME();
        private readonly ExpensaBLL_755ME _expensaBLL = new ExpensaBLL_755ME();

        public FormSerializacion_755ME()
        {
            InitializeComponent();
        }

        private void FormSerializacion_755ME_Load(object sender, EventArgs e)
        {
            SessionManager.AgregarObservador(this);
            ActualizarIdioma(SessionManager.Idioma);
            // el gestor solo ve sus consorcios, el administrador global los ve todos
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            List<ConsorcioBE_755ME> consorcios = usuarioBLL.EsAdministradorGlobal(usuarioBLL.CargarUsuario())
                ? _consorcioBLL.ObtenerTodosLosConsorcios_755ME()
                : _consorcioBLL.ObtenerConsorciosAsignados_755ME();
            cboConsorcio_755ME.DisplayMember = "Nombre_755ME";
            cboConsorcio_755ME.DataSource = consorcios;
            btnSerializar_755ME.Enabled = consorcios.Count > 0;
            btnDeserializar_755ME.Enabled = consorcios.Count > 0;
            lblSinConsorcios.Visible = consorcios.Count == 0;
        }

        // lo deserializado no es del consorcio elegido, asi que no queda a la vista al cambiarlo
        private void cboConsorcio_755ME_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvExpensas_755ME.DataSource = null;
        }

        private void btnSerializar_755ME_Click(object sender, EventArgs e)
        {
            if (cboConsorcio_755ME.SelectedItem is not ConsorcioBE_755ME consorcio) return;
            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = "XML (*.xml)|*.xml";
                if (dialogo.ShowDialog() != DialogResult.OK) return;
                try
                {
                    _expensaBLL.ExportarExpensas_755ME(consorcio.IdConsorcio_755ME, dialogo.FileName);
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_ser_ok_serializar", "Expensas serializadas correctamente"), Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_ser_err_serializar", "No se pudo serializar:") + " " + ex.Message, Text);
                }
            }
        }

        private void btnDeserializar_755ME_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Filter = "XML (*.xml)|*.xml";
                if (dialogo.ShowDialog() != DialogResult.OK) return;
                try
                {
                    dgvExpensas_755ME.DataSource = _expensaBLL.ImportarExpensas_755ME(dialogo.FileName);
                }
                catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
                {
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_ser_err_no_existe", "El archivo no existe"), Text);
                }
                // XmlSerializer informa asi tanto el XML roto como el que no son expensas
                catch (InvalidOperationException)
                {
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_ser_err_formato", "El archivo no tiene un formato de expensas valido"), Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(IdiomaUI_755ME.Texto("lb_ser_err_leer", "No se pudo leer el archivo:") + " " + ex.Message, Text);
                }
            }
        }

        public void ActualizarIdioma(IIdioma idioma)
        {
            frmMdiPrincipal f = (frmMdiPrincipal)this.MdiParent;
            f.CambiarIdiomaFormulario(this, idioma);
        }

        private void FormSerializacion_755ME_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessionManager.QuitarObservador(this);
        }
    }
}

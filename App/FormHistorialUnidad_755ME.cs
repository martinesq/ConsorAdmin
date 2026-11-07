using BE;
using BLL;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    // bitacora de cambios: historial de la unidad a la izquierda, valor vigente a la derecha
    public partial class FormHistorialUnidad_755ME : Form
    {
        private readonly UnidadFuncionalHistBLL_755ME _histBLL = new UnidadFuncionalHistBLL_755ME();
        private readonly UnidadFuncionalBLL_755ME _ufBLL = new UnidadFuncionalBLL_755ME();

        private readonly int _idConsorcio;

        // la busqueda queda limitada al consorcio desde el que se abre
        public FormHistorialUnidad_755ME(int idConsorcio, string nombreConsorcio, int idUnidadFuncionalInicial)
        {
            InitializeComponent();
            _idConsorcio = idConsorcio;
            Text += " - " + nombreConsorcio;
            txtBusqueda.Text = idUnidadFuncionalInicial.ToString();
            MostrarBusqueda_755ME();
        }

        // busca lo que indica la opcion elegida y llena las dos grillas
        private void Buscar_755ME(string valor)
        {
            dgvHistorial.DataSource = null;
            dgvVigente.DataSource = null;
            UnidadFuncionalBE_755ME vigente = rbPorId.Checked ? _ufBLL.BuscarPorId_755ME(valor, _idConsorcio) : _ufBLL.ObtenerPorNumero_755ME(valor, _idConsorcio);
            MostrarUnidad_755ME(vigente);
        }

        private void MostrarUnidad_755ME(UnidadFuncionalBE_755ME vigente)
        {
            dgvVigente.DataSource = new List<UnidadFuncionalBE_755ME> { vigente };
            dgvHistorial.DataSource = _histBLL.ObtenerHistorialPorUnidad_755ME(vigente.IdUnidadFuncional_755ME);
        }

        private void MostrarBusqueda_755ME()
        {
            try
            {
                Buscar_755ME(txtBusqueda.Text.Trim());
            }
            catch (ExcepcionUnidadNoEncontrada_755ME ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.Trim() == "")
            {
                MessageBox.Show(rbPorId.Checked ? "Ingrese el Id a buscar" : "Ingrese el numero a buscar", Text);
                return;
            }
            MostrarBusqueda_755ME();
        }

        // vuelve la unidad a la version elegida en el historial
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow?.DataBoundItem is not UnidadFuncionalHistBE_755ME version)
            {
                MessageBox.Show("Seleccione una version del historial", Text);
                return;
            }
            string pregunta = "Restaurar la unidad " + version.Numero_755ME + " a la version del " + version.Fecha_755ME.ToString("dd/MM/yyyy") + " " + version.Hora_755ME.ToString(@"hh\:mm\:ss") + "?";
            if (MessageBox.Show(pregunta, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                _ufBLL.RestaurarVersion_755ME(version);
                MostrarUnidad_755ME(_ufBLL.ObtenerPorId_755ME(version.IdUnidadFuncional_755ME));
                MessageBox.Show("Version restaurada", Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        // al cambiar de opcion el valor anterior ya no significa lo mismo
        private void rbPorNumero_CheckedChanged(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

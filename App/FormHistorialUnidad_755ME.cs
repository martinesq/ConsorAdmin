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
        private readonly int _idUnidadFuncionalInicial;

        // la busqueda queda limitada al consorcio desde el que se abre
        public FormHistorialUnidad_755ME(int idConsorcio, string nombreConsorcio, int idUnidadFuncionalInicial)
        {
            InitializeComponent();
            _idConsorcio = idConsorcio;
            _idUnidadFuncionalInicial = idUnidadFuncionalInicial;
            Text += " - " + nombreConsorcio;
            FiltroInicial_755ME();
        }

        // el filtro con el que se abre la pantalla: la unidad elegida y sin fechas
        private void FiltroInicial_755ME()
        {
            rbPorId.Checked = true;
            txtBusqueda.Text = _idUnidadFuncionalInicial > 0 ? _idUnidadFuncionalInicial.ToString() : "";
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;
            AplicarFiltro_755ME();
        }

        private void MostrarUnidad_755ME(UnidadFuncionalBE_755ME vigente)
        {
            dgvVigente.DataSource = new List<UnidadFuncionalBE_755ME> { vigente };
            dgvHistorial.DataSource = _histBLL.ObtenerHistorialPorUnidad_755ME(vigente.IdUnidadFuncional_755ME);
        }

        // sin filtros muestra todo el consorcio
        private void AplicarFiltro_755ME()
        {
            dgvHistorial.DataSource = null;
            dgvVigente.DataSource = null;
            string valor = txtBusqueda.Text.Trim();
            DateTime? desde = dtpDesde.Checked ? dtpDesde.Value.Date : null;
            DateTime? hasta = dtpHasta.Checked ? dtpHasta.Value.Date : null;
            int? idUF = null;
            // un Id que no es numero no trae filas, el aviso lo da BuscarPorId_755ME
            if (valor != "" && rbPorId.Checked) idUF = int.TryParse(valor, out int id) ? id : -1;
            string numero = rbPorNumero.Checked ? valor : "";
            try
            {
                // primero el historial: la BLL valida las fechas antes de ir a la base
                List<UnidadFuncionalHistBE_755ME> historial = _histBLL.ObtenerHistorialFiltrado_755ME(_idConsorcio, idUF, numero, desde, hasta);
                List<UnidadFuncionalBE_755ME> unidades;
                if (valor == "")
                    unidades = _ufBLL.ObtenerUnidadesActivas_755ME(_idConsorcio);
                else
                    unidades = new List<UnidadFuncionalBE_755ME> { rbPorId.Checked ? _ufBLL.BuscarPorId_755ME(valor, _idConsorcio) : _ufBLL.ObtenerPorNumero_755ME(valor, _idConsorcio) };
                dgvHistorial.DataSource = historial;
                dgvVigente.DataSource = unidades;
            }
            catch (ExcepcionUnidadNoEncontrada_755ME ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            AplicarFiltro_755ME();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            FiltroInicial_755ME();
        }

        // vuelve la unidad a la version elegida en el historial
        private void btnActivar_Click(object sender, EventArgs e)
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

        private void FormHistorialUnidad_755ME_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            FormAyuda_755ME.Mostrar_755ME(this, "bitacora-cambios");
            hlpevent.Handled = true;
        }
    }
}

using BLL;
using SER;
using System.Windows.Forms;

namespace AppBase
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try
            {
                new ConexionBLL().VerificarConexion();
                var verificador = new VerificadorBLL();
                if (!verificador.EstaInicializado())
                {
                    // primera vez: calcula la linea de base
                    verificador.Inicializar();
                }

                Application.Run(new frmMdiPrincipal());
            }
            catch (ExcepcionesBD)
            {
                MessageBox.Show("No se pudo conectar con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

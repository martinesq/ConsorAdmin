using BLL;
using SER;
using System.Globalization;
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
            // los digitos verificadores se calculan con formato argentino (99000,00 y dd/MM/yyyy):
            // se fija para que den igual en cualquier PC, sin importar su configuracion regional
            CultureInfo cultura = new CultureInfo("es-AR", false);
            CultureInfo.DefaultThreadCurrentCulture = cultura;
            CultureInfo.DefaultThreadCurrentUICulture = cultura;
            CultureInfo.CurrentCulture = cultura;
            CultureInfo.CurrentUICulture = cultura;

            // To customize application configuration such as set high DPI settings or default font,
            ApplicationConfiguration.Initialize();
            try
            {
                new ConexionBLL().VerificarConexion();
                var verificador = new VerificadorBLL();
                if (!verificador.EstaInicializado())
                {
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

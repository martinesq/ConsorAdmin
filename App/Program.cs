using BLL;
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

            // la integridad se verifica en cada login (UsuarioBLL.Login), aca solo se calcula la linea de base
            var verificador = new VerificadorBLL();
            if (!verificador.EstaInicializado())
            {
                // primera vez: calcula la linea de base
                verificador.Inicializar();
            }

            Application.Run(new frmMdiPrincipal());
        }
    }
}

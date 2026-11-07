using System.Data.SqlClient;
using SER;

namespace DAL
{
    internal static class Conexion
    {
        public const string NombreBD = "ConsorAdminDB";
        private const string ServidorPorDefecto = @"(localdb)\MSSQLLocalDB";
        private const string ArchivoConfiguracion = "Configuracion_755ME.txt";

        // El instalador escribe la linea "Servidor=..." en Configuracion_755ME.txt (junto al .exe).
        // Si el archivo no existe o no trae servidor, se usa LocalDB como hasta ahora.
        private static string LeerServidor()
        {
            try
            {
                string ruta = Path.Combine(AppContext.BaseDirectory, ArchivoConfiguracion);
                if (File.Exists(ruta))
                {
                    foreach (string linea in File.ReadAllLines(ruta))
                    {
                        string l = linea.Trim();
                        if (l.StartsWith("Servidor=", StringComparison.OrdinalIgnoreCase))
                        {
                            string valor = l.Substring("Servidor=".Length).Trim();
                            if (valor.Length > 0) return valor;
                        }
                    }
                }
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }
            return ServidorPorDefecto;
        }

        public static SqlConnection AbrirConexion(string baseDeDatos = NombreBD)
        {
            SqlConnection con = new SqlConnection($@"Data Source={LeerServidor()};Initial Catalog={baseDeDatos};Integrated Security=True;Connect Timeout=5;");
            try
            {
                con.Open();
            }
            catch (SqlException ex)
            {
                con.Dispose();
                throw new ExcepcionesBD("No se pudo conectar con la base de datos", ex);
            }
            return con;
        }
    }
}

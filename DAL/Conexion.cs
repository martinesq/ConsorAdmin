using System.Data.SqlClient;
using SER;

namespace DAL
{
    internal static class Conexion
    {
        public const string NombreBD = "AppBaseDB";

        public static SqlConnection AbrirConexion(string baseDeDatos = NombreBD)
        {
            SqlConnection con = new SqlConnection($@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog={baseDeDatos};Integrated Security=True;Connect Timeout=5;");
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

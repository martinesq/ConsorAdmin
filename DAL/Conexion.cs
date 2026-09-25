using System.Data.SqlClient;

namespace DAL
{
    internal static class Conexion
    {
        public const string NombreBD = "AppBaseDB";

        public static SqlConnection AbrirConexion(string baseDeDatos = NombreBD)
        {
            SqlConnection con = new SqlConnection($@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog={baseDeDatos};Integrated Security=True;");
            con.Open();
            return con;
        }
    }
}

using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SER;

namespace DAL
{
    public class DAO
    {
        public void VerificarConexion()
        {
            using (SqlConnection miCon = Conexion.AbrirConexion())
            {
            }
        }
        public int EjecutarQuery(string comando)
        {
            try
            {
                using (SqlConnection miCon = Conexion.AbrirConexion())
                {
                    using (SqlCommand miComando = new SqlCommand(comando, miCon))
                    {
                        return miComando.ExecuteNonQuery();
                    }
                }
            }
            catch (ExcepcionesBD)
            {
                throw;
            }
            catch (Exception e)
            {

                throw new Exception(comando);
            }
        }
        public int EjecutarQuery_SP(SqlCommand comando)
        {
            try
            {
                using (SqlConnection miCon = Conexion.AbrirConexion())
                {
                    using (comando.Connection =  miCon)
                    {
                        return comando.ExecuteNonQuery();
                    }
                }
            }
            catch (ExcepcionesBD)
            {
                throw;
            }
            catch (Exception e)
            {

                throw new Exception(comando.Transaction.ToString());
            }
        }
        public DataSet ObtenerDatos(string comando)
        {
            try
            {                
                using (SqlConnection miCon = Conexion.AbrirConexion())
                {
                    using (SqlDataAdapter miAdaptador = new SqlDataAdapter(comando, miCon))
                    {
                        DataSet ds = new DataSet();
                        miAdaptador.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (ExcepcionesBD)
            {
                throw;
            }
            catch (Exception e)
            {                
                throw new Exception(comando);
            }
        }
        public int UltimoID(string tabla)
        {
            try
            {
                using (SqlConnection miCon = Conexion.AbrirConexion())
                {
                    string comando = "SELECT ISNULL(MAX(" + tabla + "_ID),0) FROM" + tabla;
                    using (SqlCommand miComando = new SqlCommand(comando, miCon))
                    {
                        int resultado = 666;
                        if (miComando.ExecuteScalar().ToString() != null) resultado = Int32.Parse(miComando.ExecuteScalar().ToString());
                        return resultado;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }        

    }
}

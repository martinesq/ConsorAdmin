using DAL;

namespace BLL
{
    public class ConexionBLL
    {
        public void VerificarConexion()
        {
            new DAO().VerificarConexion();
        }
    }
}

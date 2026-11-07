using System.Text.RegularExpressions;
using BE;
using DAL;
using INT;

namespace BLL
{
    public class ConsorcistaBLL_755ME
    {
        private readonly ConsorcistaDAL_755ME _consorcistaDAL = new ConsorcistaDAL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        public List<ConsorcistaBE_755ME> ObtenerTodosLosConsorcistas_755ME()
        {
            return _consorcistaDAL.ObtenerTodos_755ME();
        }

        public int GuardarConsorcista_755ME(ConsorcistaBE_755ME consorcista)
        {
            if (string.IsNullOrWhiteSpace(consorcista.Nombre_755ME) || string.IsNullOrWhiteSpace(consorcista.Apellido_755ME))
            {
                throw new ArgumentException("Debe completar nombre y apellido");
            }
            if (!Regex.IsMatch(consorcista.DNI_755ME ?? "", @"^\d{7,8}$"))
            {
                throw new ArgumentException("El DNI debe tener 7 u 8 digitos");
            }
            bool esNuevo = consorcista.IdConsorcista_755ME == 0;
            if (esNuevo)
            {
                consorcista.Activo_755ME = true;
                _consorcistaDAL.Insertar_755ME(consorcista, _verificador.CalcularDVH(consorcista));
            }
            else
            {
                // la modificacion no toca Activo, se toma el de la base para el DVH
                consorcista.Activo_755ME = _consorcistaDAL.ObtenerPorId_755ME(consorcista.IdConsorcista_755ME).Activo_755ME;
                _consorcistaDAL.Actualizar_755ME(consorcista, _verificador.CalcularDVH(consorcista));
            }
            ActualizarDvvConsorcista_755ME();
            _bitacora.RegistrarDeUsuarioActual(esNuevo ? "Alta de consorcista" : "Modificacion de consorcista", consorcista.IdConsorcista_755ME.ToString(), consorcista.Nombre_755ME + " " + consorcista.Apellido_755ME);
            return consorcista.IdConsorcista_755ME;
        }

        public void InactivarConsorcista_755ME(int idConsorcista)
        {
            if (_consorcistaDAL.EsPropietarioDeUnidadActiva_755ME(idConsorcista))
            {
                throw new InvalidOperationException("No se puede inactivar un consorcista propietario de una unidad funcional activa");
            }
            CambiarActivo_755ME(idConsorcista, false);
            _bitacora.RegistrarDeUsuarioActual("Inactivar consorcista", idConsorcista.ToString());
        }

        public void ReactivarConsorcista_755ME(int idConsorcista)
        {
            CambiarActivo_755ME(idConsorcista, true);
            _bitacora.RegistrarDeUsuarioActual("Reactivar consorcista", idConsorcista.ToString());
        }

        private void CambiarActivo_755ME(int idConsorcista, bool activo)
        {
            ConsorcistaBE_755ME consorcista = _consorcistaDAL.ObtenerPorId_755ME(idConsorcista);
            consorcista.Activo_755ME = activo;
            _consorcistaDAL.ActualizarActivo_755ME(idConsorcista, activo, _verificador.CalcularDVH(consorcista));
            ActualizarDvvConsorcista_755ME();
        }

        private void ActualizarDvvConsorcista_755ME()
        {
            _verificador.ActualizarDVV("CONSORCISTA", _consorcistaDAL.ObtenerTodos_755ME().Cast<IVerificable>().ToList());
        }
    }
}

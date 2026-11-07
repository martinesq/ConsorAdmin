using BE;
using DAL;
using INT;

namespace BLL
{
    // propietario de cada unidad funcional
    public class UnidadConsorcistaBLL_755ME
    {
        private readonly UnidadConsorcistaDAL_755ME _unidadConsorcistaDAL = new UnidadConsorcistaDAL_755ME();
        private readonly UnidadFuncionalBLL_755ME _ufBLL = new UnidadFuncionalBLL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        // una unidad solo puede tener 1 propietario: hay que quitar el actual antes de asignar otro
        public void AsignarPropietario_755ME(int idUnidadFuncional, int idConsorcista)
        {
            int? propietarioActual = _unidadConsorcistaDAL.ObtenerIdPropietarioActual_755ME(idUnidadFuncional);
            if (propietarioActual == idConsorcista) return;
            if (propietarioActual.HasValue)
            {
                throw new InvalidOperationException("La unidad funcional ya tiene un propietario asignado; quítelo antes de asignar uno nuevo");
            }
            UnidadConsorcistaBE_755ME uc = new UnidadConsorcistaBE_755ME
            {
                IdUnidadFuncional_755ME = idUnidadFuncional,
                IdConsorcista_755ME = idConsorcista,
                EsPropietario_755ME = true
            };
            _unidadConsorcistaDAL.AsignarPropietario_755ME(uc, _verificador.CalcularDVH(uc));
            ActualizarDvvUnidadConsorcista_755ME();
            _bitacora.RegistrarDeUsuarioActual("Asignar propietario de unidad funcional", idUnidadFuncional.ToString(), "Consorcista " + idConsorcista);
        }

        // no deja una unidad con expensas pendientes o vencidas sin propietario
        public void QuitarPropietario_755ME(int idUnidadFuncional, int idConsorcista)
        {
            if (_ufBLL.TieneExpensasPendientes_755ME(idUnidadFuncional))
            {
                throw new InvalidOperationException("No se puede quitar el propietario de una unidad funcional con expensas pendientes o vencidas");
            }
            _unidadConsorcistaDAL.QuitarPropietario_755ME(idUnidadFuncional, idConsorcista);
            ActualizarDvvUnidadConsorcista_755ME();
            _bitacora.RegistrarDeUsuarioActual("Quitar propietario de unidad funcional", idUnidadFuncional.ToString(), "Consorcista " + idConsorcista);
        }

        private void ActualizarDvvUnidadConsorcista_755ME()
        {
            _verificador.ActualizarDVV("UNIDAD_CONSORCISTA", _unidadConsorcistaDAL.ObtenerTodos_755ME().Cast<IVerificable>().ToList());
        }
    }
}

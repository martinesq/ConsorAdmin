using BE;
using DAL;
using INT;

namespace BLL
{
    public class ProveedorBLL_755ME
    {
        private readonly ProveedorDAL_755ME _proveedorDAL = new ProveedorDAL_755ME();
        private readonly VerificadorBLL _verificador = new VerificadorBLL();
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        public List<ProveedorBE_755ME> ObtenerHabilitados_755ME()
        {
            return _proveedorDAL.ObtenerHabilitados_755ME();
        }

        public ProveedorBE_755ME ObtenerPorId_755ME(int idProveedor)
        {
            return _proveedorDAL.ObtenerPorId_755ME(idProveedor);
        }

        // ---------- Mantenimiento de proveedores ----------

        public List<ProveedorBE_755ME> ObtenerTodos_755ME()
        {
            return _proveedorDAL.ObtenerTodos_755ME();
        }

        public int GuardarProveedor_755ME(ProveedorBE_755ME proveedor)
        {
            if (string.IsNullOrWhiteSpace(proveedor.Nombre_755ME))
            {
                throw new ArgumentException("Debe completar el nombre");
            }
            proveedor.Nombre_755ME = proveedor.Nombre_755ME.Trim();
            bool repetido = _proveedorDAL.ObtenerTodos_755ME()
                .Any(p => p.IdProveedor_755ME != proveedor.IdProveedor_755ME && string.Equals(p.Nombre_755ME.Trim(), proveedor.Nombre_755ME, StringComparison.OrdinalIgnoreCase));
            if (repetido)
            {
                throw new ArgumentException("Ya existe un proveedor con ese nombre");
            }
            bool esNuevo = proveedor.IdProveedor_755ME == 0;
            if (esNuevo)
            {
                proveedor.Habilitado_755ME = true;
                _proveedorDAL.Insertar_755ME(proveedor, _verificador.CalcularDVH(proveedor));
            }
            else
            {
                // la modificacion no toca Habilitado, se toma el de la base para el DVH
                proveedor.Habilitado_755ME = _proveedorDAL.ObtenerPorId_755ME(proveedor.IdProveedor_755ME).Habilitado_755ME;
                _proveedorDAL.Actualizar_755ME(proveedor, _verificador.CalcularDVH(proveedor));
            }
            ActualizarDvvProveedor_755ME();
            _bitacora.RegistrarDeUsuarioActual(esNuevo ? "Alta de proveedor" : "Modificacion de proveedor", proveedor.IdProveedor_755ME.ToString(), proveedor.Nombre_755ME);
            return proveedor.IdProveedor_755ME;
        }

        // un proveedor inhabilitado deja de aparecer para asignar servicios (CU006)
        public void InhabilitarProveedor_755ME(int idProveedor)
        {
            CambiarHabilitado_755ME(idProveedor, false);
            _bitacora.RegistrarDeUsuarioActual("Inhabilitar proveedor", idProveedor.ToString());
        }

        public void HabilitarProveedor_755ME(int idProveedor)
        {
            CambiarHabilitado_755ME(idProveedor, true);
            _bitacora.RegistrarDeUsuarioActual("Habilitar proveedor", idProveedor.ToString());
        }

        private void CambiarHabilitado_755ME(int idProveedor, bool habilitado)
        {
            ProveedorBE_755ME proveedor = _proveedorDAL.ObtenerPorId_755ME(idProveedor);
            proveedor.Habilitado_755ME = habilitado;
            _proveedorDAL.ActualizarHabilitado_755ME(idProveedor, habilitado, _verificador.CalcularDVH(proveedor));
            ActualizarDvvProveedor_755ME();
        }

        private void ActualizarDvvProveedor_755ME()
        {
            _verificador.ActualizarDVV("PROVEEDOR", _proveedorDAL.ObtenerTodos_755ME().Cast<IVerificable>().ToList());
        }
    }
}

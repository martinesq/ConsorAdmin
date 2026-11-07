using System.Data;
using BE;

namespace DAL
{
    public class ProveedorDAL_755ME
    {
        private static ProveedorBE_755ME Mapear_755ME(DataRow fila)
        {
            ProveedorBE_755ME p = new ProveedorBE_755ME();
            p.IdProveedor_755ME = Convert.ToInt32(fila["IdProveedor"]);
            p.Nombre_755ME = fila["Nombre"].ToString() ?? "";
            p.Habilitado_755ME = Convert.ToBoolean(fila["Habilitado"]);
            p.DVH = fila["DVH"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DVH"]);
            return p;
        }

        private static List<ProveedorBE_755ME> MapearLista_755ME(DataTable tabla)
        {
            List<ProveedorBE_755ME> lista = new List<ProveedorBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public List<ProveedorBE_755ME> ObtenerHabilitados_755ME()
        {
            return MapearLista_755ME(AccesoDatos_755ME.Consultar_755ME("SELECT * FROM PROVEEDOR WHERE Habilitado=1 ORDER BY Nombre"));
        }

        public ProveedorBE_755ME ObtenerPorId_755ME(int idProveedor)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM PROVEEDOR WHERE IdProveedor=@id",
                AccesoDatos_755ME.Parametro_755ME("@id", idProveedor));
            if (tabla.Rows.Count == 0) throw new InvalidOperationException("No existe el proveedor " + idProveedor);
            return Mapear_755ME(tabla.Rows[0]);
        }

        public List<ProveedorBE_755ME> ObtenerTodos_755ME()
        {
            return MapearLista_755ME(AccesoDatos_755ME.Consultar_755ME("SELECT * FROM PROVEEDOR ORDER BY IdProveedor"));
        }

        // ---------- Mantenimiento de proveedores ----------

        public int Insertar_755ME(ProveedorBE_755ME proveedor, int dvh)
        {
            proveedor.DVH = dvh;
            proveedor.IdProveedor_755ME = AccesoDatos_755ME.Insertar_755ME(
                "INSERT INTO PROVEEDOR (Nombre, Habilitado, DVH) VALUES (@nom, @hab, @dvh)",
                AccesoDatos_755ME.Parametro_755ME("@nom", proveedor.Nombre_755ME), AccesoDatos_755ME.Parametro_755ME("@hab", proveedor.Habilitado_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh));
            return proveedor.IdProveedor_755ME;
        }

        public void Actualizar_755ME(ProveedorBE_755ME proveedor, int dvh)
        {
            proveedor.DVH = dvh;
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE PROVEEDOR SET Nombre=@nom, DVH=@dvh WHERE IdProveedor=@id",
                AccesoDatos_755ME.Parametro_755ME("@nom", proveedor.Nombre_755ME), AccesoDatos_755ME.Parametro_755ME("@dvh", dvh),
                AccesoDatos_755ME.Parametro_755ME("@id", proveedor.IdProveedor_755ME));
        }

        public void ActualizarHabilitado_755ME(int idProveedor, bool habilitado, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE PROVEEDOR SET Habilitado=@hab, DVH=@dvh WHERE IdProveedor=@id",
                AccesoDatos_755ME.Parametro_755ME("@hab", habilitado), AccesoDatos_755ME.Parametro_755ME("@dvh", dvh),
                AccesoDatos_755ME.Parametro_755ME("@id", idProveedor));
        }

        public void ActualizarDvh_755ME(int idProveedor, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE PROVEEDOR SET DVH=@dvh WHERE IdProveedor=@id",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idProveedor));
        }
    }
}

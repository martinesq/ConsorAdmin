using System.Data;
using BE;
using SER;

namespace DAL
{
    public class ConsorcioDAL_755ME
    {
        private static ConsorcioBE_755ME Mapear_755ME(DataRow fila)
        {
            ConsorcioBE_755ME c = new ConsorcioBE_755ME();
            c.IdConsorcio_755ME = Convert.ToInt32(fila["IdConsorcio"]);
            c.IdGestor_755ME = Guid.Parse(fila["IdGestor"].ToString()!);
            c.Nombre_755ME = fila["Nombre"].ToString() ?? "";
            c.Direccion_755ME = fila["Direccion"].ToString() ?? "";
            c.CantidadUnidades_755ME = Convert.ToInt32(fila["CantidadUnidades"]);
            c.Activo_755ME = fila.Table.Columns.Contains("Activo") && Convert.ToBoolean(fila["Activo"]);
            c.DVH = fila["DVH"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DVH"]);
            return c;
        }

        // consorcios activos del gestor logueado con al menos una unidad activa
        public List<ConsorcioBE_755ME> ObtenerConsorciosConUnidadesActivas_755ME()
        {
            // IdGestor se pasa como string porque Usuario_ID es nvarchar
            string idGestor = SessionManager.Instancia.Usuario.Id.ToString();
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT c.* FROM CONSORCIO c WHERE c.IdGestor=@gestor AND c.Activo=1 AND EXISTS " +
                "(SELECT 1 FROM UNIDAD_FUNCIONAL u WHERE u.IdConsorcio=c.IdConsorcio AND u.Activa=1) " +
                "ORDER BY c.Nombre",
                AccesoDatos_755ME.Parametro_755ME("@gestor", idGestor));
            List<ConsorcioBE_755ME> lista = new List<ConsorcioBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public void ActualizarDvh_755ME(int idConsorcio, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE CONSORCIO SET DVH=@dvh WHERE IdConsorcio=@id",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idConsorcio));
        }

        public List<ConsorcioBE_755ME> ObtenerTodos_755ME()
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM CONSORCIO ORDER BY IdConsorcio");
            List<ConsorcioBE_755ME> lista = new List<ConsorcioBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        // ---------- Maestros de Administracion (alta/baja) ----------

        public ConsorcioBE_755ME ObtenerPorId_755ME(int idConsorcio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM CONSORCIO WHERE IdConsorcio=@id",
                AccesoDatos_755ME.Parametro_755ME("@id", idConsorcio));
            if (tabla.Rows.Count == 0) throw new InvalidOperationException("No existe el consorcio " + idConsorcio);
            return Mapear_755ME(tabla.Rows[0]);
        }

        public int Insertar_755ME(ConsorcioBE_755ME consorcio)
        {
            consorcio.IdConsorcio_755ME = AccesoDatos_755ME.Insertar_755ME(
                "INSERT INTO CONSORCIO (IdGestor, Nombre, Direccion, CantidadUnidades, Activo, DVH) VALUES (@gestor, @nombre, @dir, @cant, @activo, @dvh)",
                AccesoDatos_755ME.Parametro_755ME("@gestor", consorcio.IdGestor_755ME.ToString()), AccesoDatos_755ME.Parametro_755ME("@nombre", consorcio.Nombre_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dir", consorcio.Direccion_755ME), AccesoDatos_755ME.Parametro_755ME("@cant", consorcio.CantidadUnidades_755ME),
                AccesoDatos_755ME.Parametro_755ME("@activo", consorcio.Activo_755ME), AccesoDatos_755ME.Parametro_755ME("@dvh", consorcio.DVH));
            return consorcio.IdConsorcio_755ME;
        }

        public void Actualizar_755ME(ConsorcioBE_755ME consorcio)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME(
                "UPDATE CONSORCIO SET IdGestor=@gestor, Nombre=@nombre, Direccion=@dir, CantidadUnidades=@cant, DVH=@dvh WHERE IdConsorcio=@id",
                AccesoDatos_755ME.Parametro_755ME("@gestor", consorcio.IdGestor_755ME.ToString()), AccesoDatos_755ME.Parametro_755ME("@nombre", consorcio.Nombre_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dir", consorcio.Direccion_755ME), AccesoDatos_755ME.Parametro_755ME("@cant", consorcio.CantidadUnidades_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dvh", consorcio.DVH), AccesoDatos_755ME.Parametro_755ME("@id", consorcio.IdConsorcio_755ME));
        }

        public void ActualizarActivo_755ME(int idConsorcio, bool activo, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE CONSORCIO SET Activo=@activo, DVH=@dvh WHERE IdConsorcio=@id",
                AccesoDatos_755ME.Parametro_755ME("@activo", activo), AccesoDatos_755ME.Parametro_755ME("@dvh", dvh),
                AccesoDatos_755ME.Parametro_755ME("@id", idConsorcio));
        }

        // no se puede dar de baja un consorcio con unidades activas
        public int ContarUnidadesActivas_755ME(int idConsorcio)
        {
            object? r = AccesoDatos_755ME.Escalar_755ME("SELECT COUNT(*) FROM UNIDAD_FUNCIONAL WHERE IdConsorcio=@id AND Activa=1",
                AccesoDatos_755ME.Parametro_755ME("@id", idConsorcio));
            return Convert.ToInt32(r);
        }
    }
}

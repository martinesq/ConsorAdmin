using System.Data;
using BE;

namespace DAL
{
    // la usan los Maestros y CU006 (datos del propietario)
    public class ConsorcistaDAL_755ME
    {
        private static ConsorcistaBE_755ME Mapear_755ME(DataRow fila)
        {
            ConsorcistaBE_755ME c = new ConsorcistaBE_755ME();
            c.IdConsorcista_755ME = Convert.ToInt32(fila["IdConsorcista"]);
            c.Nombre_755ME = fila["Nombre"].ToString() ?? "";
            c.Apellido_755ME = fila["Apellido"].ToString() ?? "";
            c.DNI_755ME = fila["DNI"].ToString() ?? "";
            c.Activo_755ME = fila.Table.Columns.Contains("Activo") && Convert.ToBoolean(fila["Activo"]);
            c.DVH = fila["DVH"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DVH"]);
            return c;
        }

        public List<ConsorcistaBE_755ME> ObtenerTodos_755ME()
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM CONSORCISTA ORDER BY Apellido, Nombre");
            List<ConsorcistaBE_755ME> lista = new List<ConsorcistaBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public ConsorcistaBE_755ME ObtenerPorId_755ME(int idConsorcista)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM CONSORCISTA WHERE IdConsorcista=@id",
                AccesoDatos_755ME.Parametro_755ME("@id", idConsorcista));
            if (tabla.Rows.Count == 0) throw new InvalidOperationException("No existe el consorcista " + idConsorcista);
            return Mapear_755ME(tabla.Rows[0]);
        }

        public int Insertar_755ME(ConsorcistaBE_755ME consorcista, int dvh)
        {
            consorcista.DVH = dvh;
            consorcista.IdConsorcista_755ME = AccesoDatos_755ME.Insertar_755ME(
                "INSERT INTO CONSORCISTA (Nombre, Apellido, DNI, Activo, DVH) VALUES (@nom, @ape, @dni, @activo, @dvh)",
                AccesoDatos_755ME.Parametro_755ME("@nom", consorcista.Nombre_755ME), AccesoDatos_755ME.Parametro_755ME("@ape", consorcista.Apellido_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dni", consorcista.DNI_755ME), AccesoDatos_755ME.Parametro_755ME("@activo", consorcista.Activo_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh));
            return consorcista.IdConsorcista_755ME;
        }

        public void Actualizar_755ME(ConsorcistaBE_755ME consorcista, int dvh)
        {
            consorcista.DVH = dvh;
            AccesoDatos_755ME.EjecutarNoQuery_755ME(
                "UPDATE CONSORCISTA SET Nombre=@nom, Apellido=@ape, DNI=@dni, DVH=@dvh WHERE IdConsorcista=@id",
                AccesoDatos_755ME.Parametro_755ME("@nom", consorcista.Nombre_755ME), AccesoDatos_755ME.Parametro_755ME("@ape", consorcista.Apellido_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dni", consorcista.DNI_755ME), AccesoDatos_755ME.Parametro_755ME("@dvh", dvh),
                AccesoDatos_755ME.Parametro_755ME("@id", consorcista.IdConsorcista_755ME));
        }

        public void ActualizarActivo_755ME(int idConsorcista, bool activo, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE CONSORCISTA SET Activo=@activo, DVH=@dvh WHERE IdConsorcista=@id",
                AccesoDatos_755ME.Parametro_755ME("@activo", activo), AccesoDatos_755ME.Parametro_755ME("@dvh", dvh),
                AccesoDatos_755ME.Parametro_755ME("@id", idConsorcista));
        }

        public void ActualizarDvh_755ME(int idConsorcista, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE CONSORCISTA SET DVH=@dvh WHERE IdConsorcista=@id",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idConsorcista));
        }

        // no se puede dar de baja un consorcista propietario de una unidad activa
        public bool EsPropietarioDeUnidadActiva_755ME(int idConsorcista)
        {
            object? r = AccesoDatos_755ME.Escalar_755ME(
                "SELECT COUNT(*) FROM UNIDAD_CONSORCISTA uc INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional=uc.IdUnidadFuncional " +
                "WHERE uc.IdConsorcista=@id AND uc.EsPropietario=1 AND u.Activa=1",
                AccesoDatos_755ME.Parametro_755ME("@id", idConsorcista));
            return Convert.ToInt32(r) > 0;
        }
    }
}

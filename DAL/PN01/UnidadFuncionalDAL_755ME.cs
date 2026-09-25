using System.Data;
using BE;

namespace DAL
{
    public class UnidadFuncionalDAL_755ME
    {
        private static UnidadFuncionalBE_755ME Mapear_755ME(DataRow fila)
        {
            UnidadFuncionalBE_755ME u = new UnidadFuncionalBE_755ME();
            u.IdUnidadFuncional_755ME = Convert.ToInt32(fila["IdUnidadFuncional"]);
            u.IdConsorcio_755ME = Convert.ToInt32(fila["IdConsorcio"]);
            u.Numero_755ME = fila["Numero"].ToString() ?? "";
            u.Tipo_755ME = fila["Tipo"].ToString() ?? "";
            u.Coeficiente_755ME = Convert.ToDecimal(fila["Coeficiente"]);
            u.Activa_755ME = Convert.ToBoolean(fila["Activa"]);
            return u;
        }

        public List<UnidadFuncionalBE_755ME> ObtenerUnidadesActivas_755ME(int idConsorcio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT * FROM UNIDAD_FUNCIONAL WHERE IdConsorcio=@con AND Activa=1 ORDER BY Numero",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            List<UnidadFuncionalBE_755ME> lista = new List<UnidadFuncionalBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        // propietario de la unidad (lo usa CU006 para el talon)
        public ConsorcistaBE_755ME ObtenerDatosPropietario_755ME(int idUF)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT c.* FROM CONSORCISTA c INNER JOIN UNIDAD_CONSORCISTA uc ON uc.IdConsorcista=c.IdConsorcista " +
                "WHERE uc.IdUnidadFuncional=@uf AND uc.EsPropietario=1",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF));
            if (tabla.Rows.Count == 0) throw new InvalidOperationException("La unidad funcional " + idUF + " no tiene propietario registrado");
            DataRow fila = tabla.Rows[0];
            ConsorcistaBE_755ME c = new ConsorcistaBE_755ME();
            c.IdConsorcista_755ME = Convert.ToInt32(fila["IdConsorcista"]);
            c.Nombre_755ME = fila["Nombre"].ToString() ?? "";
            c.Apellido_755ME = fila["Apellido"].ToString() ?? "";
            c.DNI_755ME = fila["DNI"].ToString() ?? "";
            return c;
        }

        public List<UnidadFuncionalBE_755ME> ObtenerTodas_755ME()
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM UNIDAD_FUNCIONAL ORDER BY IdUnidadFuncional");
            List<UnidadFuncionalBE_755ME> lista = new List<UnidadFuncionalBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        // ---------- Maestros de Administracion (alta/baja) ----------

        public List<UnidadFuncionalBE_755ME> ObtenerPorConsorcio_755ME(int idConsorcio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM UNIDAD_FUNCIONAL WHERE IdConsorcio=@con ORDER BY Numero",
                AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            List<UnidadFuncionalBE_755ME> lista = new List<UnidadFuncionalBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public int Insertar_755ME(UnidadFuncionalBE_755ME uf)
        {
            uf.IdUnidadFuncional_755ME = AccesoDatos_755ME.Insertar_755ME(
                "INSERT INTO UNIDAD_FUNCIONAL (IdConsorcio, Numero, Tipo, Coeficiente, Activa) VALUES (@con, @num, @tipo, @coef, @activa)",
                AccesoDatos_755ME.Parametro_755ME("@con", uf.IdConsorcio_755ME), AccesoDatos_755ME.Parametro_755ME("@num", uf.Numero_755ME),
                AccesoDatos_755ME.Parametro_755ME("@tipo", uf.Tipo_755ME), AccesoDatos_755ME.Parametro_755ME("@coef", uf.Coeficiente_755ME),
                AccesoDatos_755ME.Parametro_755ME("@activa", uf.Activa_755ME));
            return uf.IdUnidadFuncional_755ME;
        }

        public void Actualizar_755ME(UnidadFuncionalBE_755ME uf)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME(
                "UPDATE UNIDAD_FUNCIONAL SET Numero=@num, Tipo=@tipo, Coeficiente=@coef WHERE IdUnidadFuncional=@id",
                AccesoDatos_755ME.Parametro_755ME("@num", uf.Numero_755ME), AccesoDatos_755ME.Parametro_755ME("@tipo", uf.Tipo_755ME),
                AccesoDatos_755ME.Parametro_755ME("@coef", uf.Coeficiente_755ME), AccesoDatos_755ME.Parametro_755ME("@id", uf.IdUnidadFuncional_755ME));
        }

        public void ActualizarActiva_755ME(int idUF, bool activa)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE UNIDAD_FUNCIONAL SET Activa=@activa WHERE IdUnidadFuncional=@id",
                AccesoDatos_755ME.Parametro_755ME("@activa", activa), AccesoDatos_755ME.Parametro_755ME("@id", idUF));
        }

        // no se puede dar de baja una unidad con expensas pendientes o vencidas
        public int ContarExpensasPendientes_755ME(int idUF)
        {
            object? r = AccesoDatos_755ME.Escalar_755ME("SELECT COUNT(*) FROM EXPENSA WHERE IdUnidadFuncional=@uf AND Estado IN ('Pendiente','Vencida','PagadaParcial')",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF));
            return Convert.ToInt32(r);
        }

        // ---------- Propietario (UNIDAD_CONSORCISTA) ----------

        // IdConsorcista propietario actual de la unidad, o null si todavia no tiene uno asignado.
        public int? ObtenerIdPropietarioActual_755ME(int idUF)
        {
            object? r = AccesoDatos_755ME.Escalar_755ME(
                "SELECT IdConsorcista FROM UNIDAD_CONSORCISTA WHERE IdUnidadFuncional=@uf AND EsPropietario=1",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF));
            return r == null || r == DBNull.Value ? (int?)null : Convert.ToInt32(r);
        }

        public void AsignarPropietario_755ME(int idUF, int idConsorcista)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME(
                "INSERT INTO UNIDAD_CONSORCISTA (IdUnidadFuncional, IdConsorcista, EsPropietario) VALUES (@uf, @cta, 1)",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF), AccesoDatos_755ME.Parametro_755ME("@cta", idConsorcista));
        }

        public void QuitarPropietario_755ME(int idUF, int idConsorcista)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME(
                "DELETE FROM UNIDAD_CONSORCISTA WHERE IdUnidadFuncional=@uf AND IdConsorcista=@cta AND EsPropietario=1",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF), AccesoDatos_755ME.Parametro_755ME("@cta", idConsorcista));
        }

        public List<UnidadFuncionalBE_755ME> ObtenerUnidadesDelPropietario_755ME(int idConsorcista)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(
                "SELECT u.* FROM UNIDAD_FUNCIONAL u INNER JOIN UNIDAD_CONSORCISTA uc ON uc.IdUnidadFuncional=u.IdUnidadFuncional " +
                "WHERE uc.IdConsorcista=@cta AND uc.EsPropietario=1 ORDER BY u.Numero",
                AccesoDatos_755ME.Parametro_755ME("@cta", idConsorcista));
            List<UnidadFuncionalBE_755ME> lista = new List<UnidadFuncionalBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }
    }
}

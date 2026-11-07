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
            u.DVH = fila["DVH"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DVH"]);
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

        public UnidadFuncionalBE_755ME ObtenerPorId_755ME(int idUF)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM UNIDAD_FUNCIONAL WHERE IdUnidadFuncional=@id",
                AccesoDatos_755ME.Parametro_755ME("@id", idUF));
            if (tabla.Rows.Count == 0) throw new InvalidOperationException("No existe la unidad funcional " + idUF);
            return Mapear_755ME(tabla.Rows[0]);
        }

        // el numero no se repite dentro de un consorcio
        public UnidadFuncionalBE_755ME? ObtenerPorNumero_755ME(string numero, int idConsorcio)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM UNIDAD_FUNCIONAL WHERE Numero=@num AND IdConsorcio=@con",
                AccesoDatos_755ME.Parametro_755ME("@num", numero), AccesoDatos_755ME.Parametro_755ME("@con", idConsorcio));
            return tabla.Rows.Count == 0 ? null : Mapear_755ME(tabla.Rows[0]);
        }

        public int Insertar_755ME(UnidadFuncionalBE_755ME uf, int dvh)
        {
            uf.DVH = dvh;
            uf.IdUnidadFuncional_755ME = AccesoDatos_755ME.Insertar_755ME(
                "INSERT INTO UNIDAD_FUNCIONAL (IdConsorcio, Numero, Tipo, Coeficiente, Activa, DVH) VALUES (@con, @num, @tipo, @coef, @activa, @dvh)",
                AccesoDatos_755ME.Parametro_755ME("@con", uf.IdConsorcio_755ME), AccesoDatos_755ME.Parametro_755ME("@num", uf.Numero_755ME),
                AccesoDatos_755ME.Parametro_755ME("@tipo", uf.Tipo_755ME), AccesoDatos_755ME.Parametro_755ME("@coef", uf.Coeficiente_755ME),
                AccesoDatos_755ME.Parametro_755ME("@activa", uf.Activa_755ME), AccesoDatos_755ME.Parametro_755ME("@dvh", dvh));
            return uf.IdUnidadFuncional_755ME;
        }

        public void Actualizar_755ME(UnidadFuncionalBE_755ME uf, int dvh)
        {
            uf.DVH = dvh;
            // el trigger lee la operacion de la sesion para marcar la version en el historial
            AccesoDatos_755ME.EjecutarNoQuery_755ME(
                "EXEC sp_set_session_context N'Operacion', @operacion; " +
                "UPDATE UNIDAD_FUNCIONAL SET Numero=@num, Tipo=@tipo, Coeficiente=@coef, Activa=@activa, DVH=@dvh WHERE IdUnidadFuncional=@id",
                AccesoDatos_755ME.Parametro_755ME("@operacion", uf.EsRestauracion_755ME ? "Restauracion" : "Modificacion"),
                AccesoDatos_755ME.Parametro_755ME("@num", uf.Numero_755ME), AccesoDatos_755ME.Parametro_755ME("@tipo", uf.Tipo_755ME),
                AccesoDatos_755ME.Parametro_755ME("@coef", uf.Coeficiente_755ME), AccesoDatos_755ME.Parametro_755ME("@activa", uf.Activa_755ME),
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh),
                AccesoDatos_755ME.Parametro_755ME("@id", uf.IdUnidadFuncional_755ME));
        }

        public void ActualizarActiva_755ME(int idUF, bool activa, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE UNIDAD_FUNCIONAL SET Activa=@activa, DVH=@dvh WHERE IdUnidadFuncional=@id",
                AccesoDatos_755ME.Parametro_755ME("@activa", activa), AccesoDatos_755ME.Parametro_755ME("@dvh", dvh),
                AccesoDatos_755ME.Parametro_755ME("@id", idUF));
        }

        public void ActualizarDvh_755ME(int idUF, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE UNIDAD_FUNCIONAL SET DVH=@dvh WHERE IdUnidadFuncional=@id",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@id", idUF));
        }

        // no se puede dar de baja una unidad con expensas pendientes o vencidas
        public int ContarExpensasPendientes_755ME(int idUF)
        {
            object? r = AccesoDatos_755ME.Escalar_755ME("SELECT COUNT(*) FROM EXPENSA WHERE IdUnidadFuncional=@uf AND Estado IN ('Pendiente','Vencida','PagadaParcial')",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF));
            return Convert.ToInt32(r);
        }

        // ---------- Propietario ----------

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

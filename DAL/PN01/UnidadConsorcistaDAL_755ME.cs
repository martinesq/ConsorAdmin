using System.Data;
using BE;

namespace DAL
{
    public class UnidadConsorcistaDAL_755ME
    {
        private static UnidadConsorcistaBE_755ME Mapear_755ME(DataRow fila)
        {
            UnidadConsorcistaBE_755ME uc = new UnidadConsorcistaBE_755ME();
            uc.IdUnidadFuncional_755ME = Convert.ToInt32(fila["IdUnidadFuncional"]);
            uc.IdConsorcista_755ME = Convert.ToInt32(fila["IdConsorcista"]);
            uc.EsPropietario_755ME = Convert.ToBoolean(fila["EsPropietario"]);
            uc.DVH = fila["DVH"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DVH"]);
            return uc;
        }

        // propietario actual de la unidad, o null si todavia no tiene
        public int? ObtenerIdPropietarioActual_755ME(int idUF)
        {
            object? r = AccesoDatos_755ME.Escalar_755ME(
                "SELECT IdConsorcista FROM UNIDAD_CONSORCISTA WHERE IdUnidadFuncional=@uf AND EsPropietario=1",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF));
            return r == null || r == DBNull.Value ? (int?)null : Convert.ToInt32(r);
        }

        public void AsignarPropietario_755ME(UnidadConsorcistaBE_755ME uc, int dvh)
        {
            uc.DVH = dvh;
            AccesoDatos_755ME.EjecutarNoQuery_755ME(
                "INSERT INTO UNIDAD_CONSORCISTA (IdUnidadFuncional, IdConsorcista, EsPropietario, DVH) VALUES (@uf, @cta, @prop, @dvh)",
                AccesoDatos_755ME.Parametro_755ME("@uf", uc.IdUnidadFuncional_755ME), AccesoDatos_755ME.Parametro_755ME("@cta", uc.IdConsorcista_755ME),
                AccesoDatos_755ME.Parametro_755ME("@prop", uc.EsPropietario_755ME), AccesoDatos_755ME.Parametro_755ME("@dvh", dvh));
        }

        public void QuitarPropietario_755ME(int idUF, int idConsorcista)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME(
                "DELETE FROM UNIDAD_CONSORCISTA WHERE IdUnidadFuncional=@uf AND IdConsorcista=@cta AND EsPropietario=1",
                AccesoDatos_755ME.Parametro_755ME("@uf", idUF), AccesoDatos_755ME.Parametro_755ME("@cta", idConsorcista));
        }

        public List<UnidadConsorcistaBE_755ME> ObtenerTodos_755ME()
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME("SELECT * FROM UNIDAD_CONSORCISTA ORDER BY IdUnidadFuncional, IdConsorcista");
            List<UnidadConsorcistaBE_755ME> lista = new List<UnidadConsorcistaBE_755ME>();
            foreach (DataRow fila in tabla.Rows) lista.Add(Mapear_755ME(fila));
            return lista;
        }

        public void ActualizarDvh_755ME(int idUF, int idConsorcista, int dvh)
        {
            AccesoDatos_755ME.EjecutarNoQuery_755ME("UPDATE UNIDAD_CONSORCISTA SET DVH=@dvh WHERE IdUnidadFuncional=@uf AND IdConsorcista=@cta",
                AccesoDatos_755ME.Parametro_755ME("@dvh", dvh), AccesoDatos_755ME.Parametro_755ME("@uf", idUF),
                AccesoDatos_755ME.Parametro_755ME("@cta", idConsorcista));
        }
    }
}

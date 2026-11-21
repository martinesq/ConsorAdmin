using BE;
using DAL;

namespace BLL
{
    public class UnidadFuncionalHistBLL_755ME
    {
        private readonly UnidadFuncionalHistDAL_755ME _histDAL = new UnidadFuncionalHistDAL_755ME();

        public List<UnidadFuncionalHistBE_755ME> ObtenerHistorialPorUnidad_755ME(int idUnidadFuncional)
        {
            return _histDAL.ObtenerHistorialPorUnidad_755ME(idUnidadFuncional);
        }

        public UnidadFuncionalHistBE_755ME? ObtenerVersionVigente_755ME(int idUnidadFuncional)
        {
            return _histDAL.ObtenerVersionVigente_755ME(idUnidadFuncional);
        }

        public UnidadFuncionalHistBE_755ME? ObtenerVersionVigenteAFecha_755ME(int idUnidadFuncional, DateTime fecha)
        {
            return _histDAL.ObtenerVersionVigenteAFecha_755ME(idUnidadFuncional, fecha);
        }

        public List<UnidadFuncionalHistBE_755ME> ObtenerHistorialFiltrado_755ME(int idConsorcio, int? idUnidadFuncional, string numero, DateTime? desde, DateTime? hasta)
        {
            if (desde.HasValue && hasta.HasValue && desde.Value.Date > hasta.Value.Date)
            {
                throw new ArgumentException("La fecha desde no puede ser posterior a la fecha hasta");
            }
            return _histDAL.ObtenerHistorialFiltrado_755ME(idConsorcio, idUnidadFuncional, numero, desde, hasta);
        }
    }
}

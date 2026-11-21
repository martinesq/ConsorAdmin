using BE;
using DAL;

namespace BLL
{
    public class ReporteGlobalBLL_755ME
    {
        private readonly ReporteGlobalDAL_755ME _reporteDAL = new ReporteGlobalDAL_755ME();

        // el administrador global ve todos los consorcios, el gestor solo los suyos
        public List<ResumenConsorcioBE_755ME> ObtenerResumenGlobal_755ME(DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date)
            {
                throw new ArgumentException("La fecha desde no puede ser posterior a la fecha hasta");
            }
            List<ResumenConsorcioBE_755ME> resumen = _reporteDAL.ObtenerResumenGlobal_755ME(desde, hasta);
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            if (usuarioBLL.EsAdministradorGlobal(usuarioBLL.CargarUsuario())) return resumen;

            HashSet<int> propios = new ConsorcioBLL_755ME().ObtenerConsorciosAsignados_755ME().Select(c => c.IdConsorcio_755ME).ToHashSet();
            List<ResumenConsorcioBE_755ME> filtrado = resumen.Where(r => propios.Contains(r.IdConsorcio_755ME)).ToList();
            RecalcularPuestos_755ME(filtrado);
            return filtrado;
        }

        // la lista ya viene ordenada por puesto: se renumera igual que RANK(), con empates en el mismo puesto
        private static void RecalcularPuestos_755ME(List<ResumenConsorcioBE_755ME> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                bool empata = i > 0 && Criterio_755ME(lista[i]) == Criterio_755ME(lista[i - 1]) && lista[i].DeudaVencida_755ME == lista[i - 1].DeudaVencida_755ME;
                lista[i].Posicion_755ME = empata ? lista[i - 1].Posicion_755ME : i + 1;
            }
        }

        private static decimal Criterio_755ME(ResumenConsorcioBE_755ME r)
        {
            return r.TotalExpensado_755ME == 0 ? -1 : r.TotalCobrado_755ME * 100 / r.TotalExpensado_755ME;
        }
    }
}

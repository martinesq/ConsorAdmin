using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT
{
    public enum TipoPatente
    {
        None = 0,
        GestPermisos = 1,
        GestUsuarios = 2,
        GestIdiomas = 3,
        GestBackup = 4,
        GestBitacora = 5,
        AnularExpensa_755ME = 6,
        CobrarExpensa_755ME = 7,
        ReporteGestion_755ME = 8,
        GenerarLiquidacion_755ME = 9,
        GenerarOrdenPago_755ME = 11,
        RegistrarEgreso_755ME = 12,
        GestGastos_755ME = 15,
        GestMantenimientoConsorcios_755ME = 16,
        FormalizarSolicitud_755ME = 17,
        AsignarProveedor_755ME = 18,
        CargarPrestacion_755ME = 19,
        AprobarPrestacion_755ME = 20,
        SerializarExpensas_755ME = 21,
        ReporteServicios_755ME = 22,
        ReporteGlobal_755ME = 23,
    }
}

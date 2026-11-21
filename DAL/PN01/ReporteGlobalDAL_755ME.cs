using System.Data;
using BE;

namespace DAL
{
    public class ReporteGlobalDAL_755ME
    {
        // cada CTE agrupa por consorcio antes de unir: con joins planos los pagos y gastos multiplicarian los importes
        private const string Consulta_755ME = @"
WITH Exp AS (
    SELECT u.IdConsorcio,
           SUM(e.Monto) AS TotalExpensado,
           SUM(CASE WHEN e.Estado = 'Vencida' THEN e.Monto ELSE 0 END) AS DeudaVencidaBruta
    FROM EXPENSA e
    INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional = e.IdUnidadFuncional
    WHERE e.Estado <> 'Anulada' AND e.Periodo BETWEEN @desde AND @hasta
    GROUP BY u.IdConsorcio
),
Cob AS (
    SELECT u.IdConsorcio,
           SUM(p.Monto) AS TotalCobrado,
           SUM(CASE WHEN e.Estado = 'Vencida' THEN p.Monto ELSE 0 END) AS CobradoSobreVencidas
    FROM PAGO p
    INNER JOIN EXPENSA e ON e.IdExpensa = p.IdExpensa
    INNER JOIN UNIDAD_FUNCIONAL u ON u.IdUnidadFuncional = e.IdUnidadFuncional
    WHERE e.Estado <> 'Anulada' AND e.Periodo BETWEEN @desde AND @hasta
    GROUP BY u.IdConsorcio
),
Gas AS (
    SELECT IdConsorcio, SUM(Monto) AS TotalGastos
    FROM GASTO
    WHERE Periodo BETWEEN @desde AND @hasta
    GROUP BY IdConsorcio
),
Ser AS (
    SELECT IdConsorcio,
           COUNT(*) AS ServiciosAprobadosPendientes,
           SUM(Costo) AS CostoServiciosPendientes
    FROM SERVICIO
    WHERE Estado = 'Aprobado'
    GROUP BY IdConsorcio
),
Egr AS (
    SELECT IdConsorcio, SUM(Monto) AS TotalEgresos
    FROM EGRESO
    WHERE Fecha BETWEEN @desde AND @hasta
    GROUP BY IdConsorcio
),
Uni AS (
    SELECT IdConsorcio, COUNT(*) AS UnidadesActivas
    FROM UNIDAD_FUNCIONAL
    WHERE Activa = 1
    GROUP BY IdConsorcio
),
Base AS (
    SELECT c.IdConsorcio,
           c.Nombre,
           ISNULL(Uni.UnidadesActivas, 0) AS UnidadesActivas,
           ISNULL(Exp.TotalExpensado, 0) AS TotalExpensado,
           ISNULL(Cob.TotalCobrado, 0) AS TotalCobrado,
           ISNULL(Exp.DeudaVencidaBruta, 0) - ISNULL(Cob.CobradoSobreVencidas, 0) AS DeudaVencida,
           ISNULL(Gas.TotalGastos, 0) AS TotalGastos,
           ISNULL(Ser.ServiciosAprobadosPendientes, 0) AS ServiciosAprobadosPendientes,
           ISNULL(Ser.CostoServiciosPendientes, 0) AS CostoServiciosPendientes,
           ISNULL(Egr.TotalEgresos, 0) AS TotalEgresos
    FROM CONSORCIO c
    LEFT JOIN Uni ON Uni.IdConsorcio = c.IdConsorcio
    LEFT JOIN Exp ON Exp.IdConsorcio = c.IdConsorcio
    LEFT JOIN Cob ON Cob.IdConsorcio = c.IdConsorcio
    LEFT JOIN Gas ON Gas.IdConsorcio = c.IdConsorcio
    LEFT JOIN Ser ON Ser.IdConsorcio = c.IdConsorcio
    LEFT JOIN Egr ON Egr.IdConsorcio = c.IdConsorcio
    WHERE c.Activo = 1
)
SELECT RANK() OVER (ORDER BY CASE WHEN TotalExpensado = 0 THEN -1
                                  ELSE TotalCobrado * 100.0 / TotalExpensado END DESC,
                    DeudaVencida ASC) AS Posicion,
       IdConsorcio,
       Nombre,
       UnidadesActivas,
       TotalExpensado,
       TotalCobrado,
       DeudaVencida,
       CASE WHEN TotalExpensado = 0 THEN 0
            ELSE CAST(TotalCobrado * 100.0 / TotalExpensado AS decimal(5,2)) END AS TasaCobranza,
       TotalGastos,
       ServiciosAprobadosPendientes,
       CostoServiciosPendientes,
       TotalEgresos,
       TotalCobrado - TotalEgresos AS SaldoFondo
FROM Base
ORDER BY Posicion, Nombre;";

        public List<ResumenConsorcioBE_755ME> ObtenerResumenGlobal_755ME(DateTime desde, DateTime hasta)
        {
            DataTable tabla = AccesoDatos_755ME.Consultar_755ME(Consulta_755ME,
                AccesoDatos_755ME.Parametro_755ME("@desde", desde.Date),
                AccesoDatos_755ME.Parametro_755ME("@hasta", hasta.Date));
            List<ResumenConsorcioBE_755ME> lista = new List<ResumenConsorcioBE_755ME>();
            foreach (DataRow fila in tabla.Rows)
            {
                ResumenConsorcioBE_755ME r = new ResumenConsorcioBE_755ME();
                r.Posicion_755ME = Convert.ToInt32(fila["Posicion"]);
                r.IdConsorcio_755ME = Convert.ToInt32(fila["IdConsorcio"]);
                r.Nombre_755ME = fila["Nombre"].ToString() ?? "";
                r.UnidadesActivas_755ME = Convert.ToInt32(fila["UnidadesActivas"]);
                r.TotalExpensado_755ME = Convert.ToDecimal(fila["TotalExpensado"]);
                r.TotalCobrado_755ME = Convert.ToDecimal(fila["TotalCobrado"]);
                r.DeudaVencida_755ME = Convert.ToDecimal(fila["DeudaVencida"]);
                r.TasaCobranza_755ME = Convert.ToDecimal(fila["TasaCobranza"]);
                r.TotalGastos_755ME = Convert.ToDecimal(fila["TotalGastos"]);
                r.ServiciosAprobadosPendientes_755ME = Convert.ToInt32(fila["ServiciosAprobadosPendientes"]);
                r.CostoServiciosPendientes_755ME = Convert.ToDecimal(fila["CostoServiciosPendientes"]);
                r.TotalEgresos_755ME = Convert.ToDecimal(fila["TotalEgresos"]);
                r.SaldoFondo_755ME = Convert.ToDecimal(fila["SaldoFondo"]);
                lista.Add(r);
            }
            return lista;
        }
    }
}

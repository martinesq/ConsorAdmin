namespace BE
{
    // fila del reporte global, no se persiste
    public class ResumenConsorcioBE_755ME
    {
        public int Posicion_755ME { get; set; }
        public int IdConsorcio_755ME { get; set; }
        public string Nombre_755ME { get; set; } = "";
        public int UnidadesActivas_755ME { get; set; }
        public decimal TotalExpensado_755ME { get; set; }
        public decimal TotalCobrado_755ME { get; set; }
        public decimal DeudaVencida_755ME { get; set; }
        public decimal TasaCobranza_755ME { get; set; }
        public decimal TotalGastos_755ME { get; set; }
        public int ServiciosAprobadosPendientes_755ME { get; set; }
        public decimal CostoServiciosPendientes_755ME { get; set; }
        public decimal TotalEgresos_755ME { get; set; }
        public decimal SaldoFondo_755ME { get; set; }
    }
}

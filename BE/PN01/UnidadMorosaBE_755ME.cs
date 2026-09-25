namespace BE
{
    // DTO, no se persiste (CU003).
    public class UnidadMorosaBE_755ME
    {
        public int IdUnidadFuncional_755ME { get; set; }
        public string NumeroUnidad_755ME { get; set; } = "";
        public decimal MontoAdeudado_755ME { get; set; }
        public int DiasAtraso_755ME { get; set; }
        public int CuotasPendientes_755ME { get; set; }
        // periodos que componen MontoAdeudado_755ME, de la mas antigua a la mas nueva
        public List<ExpensaAdeudadaBE_755ME> Detalle_755ME { get; set; } = new List<ExpensaAdeudadaBE_755ME>();
    }

    // DTO, no se persiste: una expensa vencida con saldo, dentro del detalle de morosidad de una unidad.
    public class ExpensaAdeudadaBE_755ME
    {
        public DateTime Periodo_755ME { get; set; }
        public DateTime FechaVencimiento_755ME { get; set; }
        public decimal Monto_755ME { get; set; }
        public decimal Pagado_755ME { get; set; }
        public decimal Saldo_755ME { get; set; }
        public decimal RecargoPorMora_755ME { get; set; }
        public int DiasAtraso_755ME { get; set; }
        public string Estado_755ME { get; set; } = "";
    }
}

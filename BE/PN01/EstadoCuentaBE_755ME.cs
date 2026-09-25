namespace BE
{
    // DTO, no se persiste (CU005).
    public class EstadoCuentaBE_755ME
    {
        public List<ExpensaBE_755ME> Expensas_755ME { get; set; } = new List<ExpensaBE_755ME>();
        public List<PagoBE_755ME> Pagos_755ME { get; set; } = new List<PagoBE_755ME>();
        public List<EgresoBE_755ME> Egresos_755ME { get; set; } = new List<EgresoBE_755ME>();
        public decimal Saldo_755ME { get; set; }
    }
}

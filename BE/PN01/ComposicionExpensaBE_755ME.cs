namespace BE
{
    // DTO, no se persiste (CU008).
    public class ComposicionExpensaBE_755ME
    {
        public List<GastoBE_755ME> Gastos_755ME { get; set; } = new List<GastoBE_755ME>();
        public decimal HonorarioAplicado_755ME { get; set; }
        public decimal Coeficiente_755ME { get; set; }
        public decimal RecargoPorMora_755ME { get; set; }
    }
}

using INT;

namespace BE
{
    // entra en el DVH (ver ConsorcioBE_755ME)
    public class ExpensaBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables =
        {
            "IdUnidadFuncional_755ME", "Periodo_755ME", "Monto_755ME", "FechaVencimiento_755ME", "HonorarioAplicado_755ME",
            "CoeficienteAplicado_755ME", "RecargoPorMora_755ME", "Estado_755ME", "MotivoAnulacion_755ME"
        };

        public int IdExpensa_755ME { get; set; }
        public int IdUnidadFuncional_755ME { get; set; }
        public DateTime Periodo_755ME { get; set; }
        public decimal Monto_755ME { get; set; }
        public DateTime FechaVencimiento_755ME { get; set; }
        public decimal HonorarioAplicado_755ME { get; set; }
        public decimal CoeficienteAplicado_755ME { get; set; }
        public decimal RecargoPorMora_755ME { get; set; }
        public string Estado_755ME { get; set; } = "";
        public string? MotivoAnulacion_755ME { get; set; }
        public int DVH { get; set; }
        // no se persiste: total pagado hasta ahora, lo completa la BLL
        public decimal Pagado_755ME { get; set; }
        public decimal Saldo_755ME { get { return Monto_755ME - Pagado_755ME; } }

        Guid IEntity.Id { get { return new Guid(IdExpensa_755ME, 0, 0, new byte[8]); } }
        TipoEstado IEntity.Estado { get; set; }
        bool IEntity.Baja { get; set; }
        string IVerificable.NombreTabla { get { return "EXPENSA"; } }
        string[] IVerificable.AtributosVerificables { get { return _atributosVerificables; } }
    }
}

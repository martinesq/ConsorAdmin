using INT;

namespace BE
{
    public class PagoBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables =
        {
            "IdExpensa_755ME", "Monto_755ME", "FechaPago_755ME", "MedioPago_755ME", "NumeroComprobante_755ME"
        };

        public int IdPago_755ME { get; set; }
        public int IdExpensa_755ME { get; set; }
        public decimal Monto_755ME { get; set; }
        public DateTime FechaPago_755ME { get; set; }
        public string MedioPago_755ME { get; set; } = "";
        public string NumeroComprobante_755ME { get; set; } = "";
        public int DVH { get; set; }

        Guid IEntity.Id { get { return new Guid(IdPago_755ME, 0, 0, new byte[8]); } }
        TipoEstado IEntity.Estado { get; set; }
        bool IEntity.Baja { get; set; }
        string IVerificable.NombreTabla { get { return "PAGO"; } }
        string[] IVerificable.AtributosVerificables { get { return _atributosVerificables; } }
    }
}

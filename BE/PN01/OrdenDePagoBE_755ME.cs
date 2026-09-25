using INT;

namespace BE
{
    public class OrdenDePagoBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables =
        {
            "IdExpensa_755ME", "NumeroOrden_755ME", "Monto_755ME", "FechaVencimiento_755ME", "Estado_755ME", "PropietarioSnapshot_755ME"
        };

        public int IdOrdenPago_755ME { get; set; }
        public int IdExpensa_755ME { get; set; }
        public int NumeroOrden_755ME { get; set; }
        public decimal Monto_755ME { get; set; }
        public DateTime FechaVencimiento_755ME { get; set; }
        public string Estado_755ME { get; set; } = "";
        public string PropietarioSnapshot_755ME { get; set; } = "";
        public int DVH { get; set; }

        Guid IEntity.Id { get { return new Guid(IdOrdenPago_755ME, 0, 0, new byte[8]); } }
        TipoEstado IEntity.Estado { get; set; }
        bool IEntity.Baja { get; set; }
        string IVerificable.NombreTabla { get { return "ORDEN_PAGO"; } }
        string[] IVerificable.AtributosVerificables { get { return _atributosVerificables; } }
    }
}

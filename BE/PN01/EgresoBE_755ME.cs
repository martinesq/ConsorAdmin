using INT;

namespace BE
{
    public class EgresoBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables =
        {
            "IdConsorcio_755ME", "IdServicio_755ME", "IdProveedor_755ME", "Concepto_755ME", "Monto_755ME", "Fecha_755ME"
        };

        public int IdEgreso_755ME { get; set; }
        public int IdConsorcio_755ME { get; set; }
        public int? IdServicio_755ME { get; set; }
        public int? IdProveedor_755ME { get; set; }
        public string Concepto_755ME { get; set; } = "";
        public decimal Monto_755ME { get; set; }
        public DateTime Fecha_755ME { get; set; }
        public int DVH { get; set; }

        Guid IEntity.Id { get { return new Guid(IdEgreso_755ME, 0, 0, new byte[8]); } }
        TipoEstado IEntity.Estado { get; set; }
        bool IEntity.Baja { get; set; }
        string IVerificable.NombreTabla { get { return "EGRESO"; } }
        string[] IVerificable.AtributosVerificables { get { return _atributosVerificables; } }
    }
}

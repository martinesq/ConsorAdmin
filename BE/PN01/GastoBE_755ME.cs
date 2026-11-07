using INT;

namespace BE
{
    public class GastoBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables =
        {
            "IdConsorcio_755ME", "Descripcion_755ME", "Monto_755ME", "Periodo_755ME", "Rubro_755ME"
        };

        public int IdGasto_755ME { get; set; }
        public int IdConsorcio_755ME { get; set; }
        public string Descripcion_755ME { get; set; } = "";
        public decimal Monto_755ME { get; set; }
        public DateTime Periodo_755ME { get; set; }
        public string Rubro_755ME { get; set; } = "";
        public int DVH { get; set; }

        Guid IEntity.Id { get { return new Guid(IdGasto_755ME, 0, 0, new byte[8]); } }
        TipoEstado IEntity.Estado { get; set; }
        bool IEntity.Baja { get; set; }
        string IVerificable.NombreTabla { get { return "GASTO"; } }
        string[] IVerificable.AtributosVerificables { get { return _atributosVerificables; } }
    }
}

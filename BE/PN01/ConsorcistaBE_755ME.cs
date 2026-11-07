using INT;

namespace BE
{
    public class ConsorcistaBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables =
        {
            "Nombre_755ME", "Apellido_755ME", "DNI_755ME", "Activo_755ME"
        };

        public int IdConsorcista_755ME { get; set; }
        public string Nombre_755ME { get; set; } = "";
        public string Apellido_755ME { get; set; } = "";
        public string DNI_755ME { get; set; } = "";
        public bool Activo_755ME { get; set; } = true;
        public int DVH { get; set; }

        Guid IEntity.Id { get { return new Guid(IdConsorcista_755ME, 0, 0, new byte[8]); } }
        TipoEstado IEntity.Estado { get; set; }
        bool IEntity.Baja { get; set; }
        string IVerificable.NombreTabla { get { return "CONSORCISTA"; } }
        string[] IVerificable.AtributosVerificables { get { return _atributosVerificables; } }
    }
}

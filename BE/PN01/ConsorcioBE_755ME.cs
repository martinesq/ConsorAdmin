using INT;

namespace BE
{
    // IVerificable implementado en forma explicita; IdGestor_755ME es Guid porque Usuario_ID es la PK de Usuario
    public class ConsorcioBE_755ME : IVerificable
    {
        // Activo_755ME entra en el DVH, asi inactivar/reactivar tambien queda cubierto
        private static readonly string[] _atributosVerificables = { "Nombre_755ME", "Direccion_755ME", "CantidadUnidades_755ME", "Activo_755ME" };

        public int IdConsorcio_755ME { get; set; }
        public Guid IdGestor_755ME { get; set; }
        public string Nombre_755ME { get; set; } = "";
        public string Direccion_755ME { get; set; } = "";
        public int CantidadUnidades_755ME { get; set; }
        public bool Activo_755ME { get; set; } = true;
        public int DVH { get; set; }

        Guid IEntity.Id { get { return new Guid(IdConsorcio_755ME, 0, 0, new byte[8]); } }
        TipoEstado IEntity.Estado { get; set; }
        bool IEntity.Baja { get; set; }
        string IVerificable.NombreTabla { get { return "CONSORCIO"; } }
        string[] IVerificable.AtributosVerificables { get { return _atributosVerificables; } }
    }
}

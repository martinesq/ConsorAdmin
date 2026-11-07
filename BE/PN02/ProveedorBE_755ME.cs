using INT;

namespace BE
{
    public class ProveedorBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables = { "Nombre_755ME", "Habilitado_755ME" };

        public int IdProveedor_755ME { get; set; }
        public string Nombre_755ME { get; set; } = "";
        public bool Habilitado_755ME { get; set; }
        public int DVH { get; set; }

        Guid IEntity.Id { get { return new Guid(IdProveedor_755ME, 0, 0, new byte[8]); } }
        TipoEstado IEntity.Estado { get; set; }
        bool IEntity.Baja { get; set; }
        string IVerificable.NombreTabla { get { return "PROVEEDOR"; } }
        string[] IVerificable.AtributosVerificables { get { return _atributosVerificables; } }
    }
}

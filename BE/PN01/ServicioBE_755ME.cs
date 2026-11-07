using INT;

namespace BE
{
    // ciclo de vida: Pendiente de asignacion -> Asignado -> Prestado -> Aprobado / Rechazado -> Pagado
    public class ServicioBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables =
        {
            "IdConsorcio_755ME", "IdProveedor_755ME", "IdUnidadFuncional_755ME", "Categoria_755ME", "Descripcion_755ME",
            "Estado_755ME", "PlazoEstimado_755ME", "FechaAsignacion_755ME", "FechaPrestacion_755ME", "DescripcionTrabajo_755ME",
            "Costo_755ME", "NumeroFactura_755ME", "ArchivoAdjunto_755ME", "MotivoRechazo_755ME"
        };

        public int IdServicio_755ME { get; set; }
        public int IdConsorcio_755ME { get; set; }
        public int? IdProveedor_755ME { get; set; }
        // null cuando el servicio es para un area comun
        public int? IdUnidadFuncional_755ME { get; set; }
        public string Categoria_755ME { get; set; } = "";
        public string Descripcion_755ME { get; set; } = "";
        public string Estado_755ME { get; set; } = "";
        public int? PlazoEstimado_755ME { get; set; }
        public DateTime? FechaAsignacion_755ME { get; set; }
        public DateTime? FechaPrestacion_755ME { get; set; }
        public string DescripcionTrabajo_755ME { get; set; } = "";
        public decimal Costo_755ME { get; set; }
        public string NumeroFactura_755ME { get; set; } = "";
        public string ArchivoAdjunto_755ME { get; set; } = "";
        public string MotivoRechazo_755ME { get; set; } = "";
        public int DVH { get; set; }
        // no se persiste: nombre del proveedor para mostrar en CU009, lo completa la BLL
        public string NombreProveedor_755ME { get; set; } = "";

        Guid IEntity.Id { get { return new Guid(IdServicio_755ME, 0, 0, new byte[8]); } }
        TipoEstado IEntity.Estado { get; set; }
        bool IEntity.Baja { get; set; }
        string IVerificable.NombreTabla { get { return "SERVICIO"; } }
        string[] IVerificable.AtributosVerificables { get { return _atributosVerificables; } }
    }
}

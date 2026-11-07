using INT;

namespace BE
{
    public class UnidadFuncionalBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables =
        {
            "IdConsorcio_755ME", "Numero_755ME", "Tipo_755ME", "Coeficiente_755ME", "Activa_755ME"
        };

        public int IdUnidadFuncional_755ME { get; set; }
        public int IdConsorcio_755ME { get; set; }
        public string Numero_755ME { get; set; } = "";
        public string Tipo_755ME { get; set; } = "";
        public decimal Coeficiente_755ME { get; set; }
        public bool Activa_755ME { get; set; }
        public int DVH { get; set; }

        // no se guarda: le indica al guardado que los valores vienen del historial
        public bool EsRestauracion_755ME { get; set; }

        Guid IEntity.Id { get { return new Guid(IdUnidadFuncional_755ME, 0, 0, new byte[8]); } }
        TipoEstado IEntity.Estado { get; set; }
        bool IEntity.Baja { get; set; }
        string IVerificable.NombreTabla { get { return "UNIDAD_FUNCIONAL"; } }
        string[] IVerificable.AtributosVerificables { get { return _atributosVerificables; } }
    }
}

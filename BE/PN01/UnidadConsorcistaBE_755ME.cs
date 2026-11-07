using INT;

namespace BE
{
    // relacion entre unidad funcional y consorcista (el propietario)
    public class UnidadConsorcistaBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables =
        {
            "IdUnidadFuncional_755ME", "IdConsorcista_755ME", "EsPropietario_755ME"
        };

        public int IdUnidadFuncional_755ME { get; set; }
        public int IdConsorcista_755ME { get; set; }
        public bool EsPropietario_755ME { get; set; }
        public int DVH { get; set; }

        // la clave es doble: la unidad va en el primer bloque y el consorcista en el ultimo
        Guid IEntity.Id { get { return new Guid(IdUnidadFuncional_755ME, 0, 0, BitConverter.GetBytes((long)IdConsorcista_755ME)); } }
        TipoEstado IEntity.Estado { get; set; }
        bool IEntity.Baja { get; set; }
        string IVerificable.NombreTabla { get { return "UNIDAD_CONSORCISTA"; } }
        string[] IVerificable.AtributosVerificables { get { return _atributosVerificables; } }
    }
}

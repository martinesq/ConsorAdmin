using INT;

namespace BE
{
    // fila de Familia_Patente: un permiso hijo dentro de una familia
    public class FamiliaPatenteBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables = { "PadreId", "HijoId" };

        public Guid PadreId { get; set; }
        public Guid HijoId { get; set; }
        public int DVH { get; set; }
        public TipoEstado Estado { get; set; }
        public bool Baja { get; set; }
        public string NombreTabla { get { return "Familia_Patente"; } }
        public string[] AtributosVerificables { get { return _atributosVerificables; } }

        // clave doble: se mezclan las dos claves en un solo Guid para ordenar las filas del DVV
        public Guid Id
        {
            get
            {
                byte[] a = PadreId.ToByteArray();
                byte[] b = HijoId.ToByteArray();
                for (int i = 0; i < 16; i++) a[i] ^= b[i];
                return new Guid(a);
            }
        }
    }
}

using INT;

namespace BE
{
    // fila de Usuario_Permiso: un permiso asignado a un usuario
    public class UsuarioPermisoBE_755ME : IVerificable
    {
        private static readonly string[] _atributosVerificables = { "PermisoId", "UsuarioId" };

        public Guid PermisoId { get; set; }
        public Guid UsuarioId { get; set; }
        public int DVH { get; set; }
        public TipoEstado Estado { get; set; }
        public bool Baja { get; set; }
        public string NombreTabla { get { return "Usuario_Permiso"; } }
        public string[] AtributosVerificables { get { return _atributosVerificables; } }

        // clave doble: se mezclan las dos claves en un solo Guid para ordenar las filas del DVV
        public Guid Id
        {
            get
            {
                byte[] a = PermisoId.ToByteArray();
                byte[] b = UsuarioId.ToByteArray();
                for (int i = 0; i < 16; i++) a[i] ^= b[i];
                return new Guid(a);
            }
        }
    }
}

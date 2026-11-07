using INT;
using System;

namespace BE
{
    public class Traduccion : ITraduccion, IVerificable
    {
        private static readonly string[] _atributosVerificables = { "EtiquetaId", "IdiomaId", "Texto" };

        public Traduccion()
        {

        }
        public IEtiqueta Etiqueta { get; set; }
        public string Texto { get; set; }
        // la clave de la tabla es etiqueta + idioma
        public Guid IdiomaId { get; set; }
        public Guid EtiquetaId { get { return Etiqueta == null ? Guid.Empty : Etiqueta.Id; } }
        public int DVH { get; set; }
        public TipoEstado Estado { get; set; }
        public bool Baja { get; set; }
        public string NombreTabla { get { return "Traduccion"; } }
        public string[] AtributosVerificables { get { return _atributosVerificables; } }

        public Guid Id
        {
            get
            {
                byte[] a = EtiquetaId.ToByteArray();
                byte[] b = IdiomaId.ToByteArray();
                for (int i = 0; i < 16; i++) a[i] ^= b[i];
                return new Guid(a);
            }
        }
    }
}

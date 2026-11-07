using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INT;

namespace SER.Composite
{
    public abstract class PermisoCompuesto : IEntity, IPermiso, IVerificable
    {
        private static readonly string[] _atributosVerificables = { "Nombre", "Permiso" };

        protected Guid _id;
        public Guid Id { get => _id; }

        public TipoEstado Estado { get; set; }
        public string Nombre { get; set; }

        public abstract void AgregarPermiso(IPermiso p);
        public abstract void QuitarPermiso(IPermiso p);
        public abstract void VaciarHijos();
        public TipoPatente Permiso { get; set; }
        public abstract IList<IPermiso> ObtenerHijos { get; }
        public bool Baja { get; set; }
        public int DVH { get; set; }
        public string NombreTabla { get { return "Permiso"; } }
        public string[] AtributosVerificables { get { return _atributosVerificables; } }

        // suma este permiso y todos los que cuelgan de el
        public void AgregarPermisosEn_755ME(List<IPermiso> destino)
        {
            destino.Add(this);
            foreach (PermisoCompuesto hijo in ObtenerHijos)
            {
                hijo.AgregarPermisosEn_755ME(destino);
            }
        }
    }
}

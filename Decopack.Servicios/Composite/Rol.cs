using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios.Composite
{
    public class Rol : Rolpermiso
    {
        private List<Rolpermiso> _rolPermiso = new List<Rolpermiso>();

        public override void Agregar(Rolpermiso rolPermiso)
        {
            _rolPermiso.Add(rolPermiso);
        }

        public override void Remover(Rolpermiso rolPermiso)
        {
            _rolPermiso.Remove(rolPermiso);
        }

        public override object Mostrar()
        {
            return _rolPermiso;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}

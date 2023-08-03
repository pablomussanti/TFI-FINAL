using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios.Composite
{
    public class Permisos : Rolpermiso
    {
        public override void Agregar(Rolpermiso rolPermiso)
        {
            throw new Exception("No se pueden agregar permisos a un permiso");
        }

        public override void Remover(Rolpermiso rolPermiso)
        {
            throw new Exception("Un permiso no contiene permisos");
        }

        public override object Mostrar()
        {
            return Nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }

}

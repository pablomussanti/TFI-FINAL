using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios.Composite
{
    public abstract class Rolpermiso 
    {
        private string _nombre;
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        private string _tipo;
        public string Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
            }
        }


        public override string ToString()
        {
            return Nombre;
        }


        public abstract void Agregar(Rolpermiso rolPermiso);
        public abstract void Remover(Rolpermiso rolPermiso);
        public abstract object Mostrar();
    }
}

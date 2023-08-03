using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
    public partial class Proveedor : IEntity
    {
        public int Id { get; set; }

        public int Cantidaddeerrores { get; set; }

        public string Direccion { get; set; }

        public string Nombre { get; set; }
        public int Telefono { get; set; }

        public string Estado { get; set; }


    }
}

using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
    public partial class MateriaPrimaProveedor : IEntity
    {
        public int Id { get; set; }

        public int CodMateriaPrima { get; set; }

        public int CodProveedor { get; set; }

        public double Precio { get; set; }

        public MateriaPrima MateriaPrima { get; set; }

        public Proveedor Proveedor { get; set; }


    }
}

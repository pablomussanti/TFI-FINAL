using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
   public partial class MateriaPrimaProducto : IEntity
    {
        public int Id { get; set; }

        public int CodProducto { get; set; }

        public int CodMateriaPrima { get; set; }

        public int Cantidad { get; set; }

        public Producto Producto { get; set; }

        public MateriaPrima MateriaPrima { get; set; }

    }
}

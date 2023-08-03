using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
    public partial class StockProductoDeposito : IEntity
    {
        public int Id { get; set; }

        public int CodProducto { get; set; }

        public int CodDeposito { get; set; }

        public int Cantidad { get; set; }

        public Producto Producto { get; set; }

        public Deposito Deposito { get; set; }

    }
}

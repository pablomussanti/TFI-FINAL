using Decopack.EE;
using Decopack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.BLL;

namespace Decopack.Services
{
    public class ProductoService : IProductoService
    {
        public List<Producto> ListarTodos()
        {
            ProductoBLL ProductoBLL = new ProductoBLL();
            return ProductoBLL.ListarTodos();
        }

        public Producto Create(Producto Producto)
        {
            ProductoBLL ProductoBLL = new ProductoBLL();
            return ProductoBLL.Create(Producto);
        }

        public bool Edit(Producto Producto)
        {
            ProductoBLL ProductoBLL = new ProductoBLL();
            return ProductoBLL.Edit(Producto);
        }

        public Producto GetByID(int ID)
        {
            ProductoBLL ProductoBLL = new ProductoBLL();
            return ProductoBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            ProductoBLL ProductoBLL = new ProductoBLL();
            return ProductoBLL.Delete(ID);
        }
    }
}

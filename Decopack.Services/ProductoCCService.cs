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
    public class ProductoCCService : IProductoCCService
    {
        public List<ProductoCC> ListarTodos()
        {
            ProductoCCBLL ProductoCCBLL = new ProductoCCBLL();
            return ProductoCCBLL.ListarTodos();
        }

        public ProductoCC Create(ProductoCC ProductoCC)
        {
            ProductoCCBLL ProductoCCBLL = new ProductoCCBLL();
            return ProductoCCBLL.Create(ProductoCC);
        }

        public bool Edit(ProductoCC ProductoCC)
        {
            ProductoCCBLL ProductoCCBLL = new ProductoCCBLL();
            return ProductoCCBLL.Edit(ProductoCC);
        }

        public ProductoCC GetByID(int ID)
        {
            ProductoCCBLL ProductoCCBLL = new ProductoCCBLL();
            return ProductoCCBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            ProductoCCBLL ProductoCCBLL = new ProductoCCBLL();
            return ProductoCCBLL.Delete(ID);

        }
    }
}

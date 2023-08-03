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
    public class ProductoDVVService : IProductoDVVService
    {
        public List<ProductoDVV> ListarTodos()
        {
            ProductoDVVBLL ProductoDVVBLL = new ProductoDVVBLL();
            return ProductoDVVBLL.ListarTodos();
        }

        public ProductoDVV Create(ProductoDVV ProductoDVV)
        {
            ProductoDVVBLL ProductoDVVBLL = new ProductoDVVBLL();
            return ProductoDVVBLL.Create(ProductoDVV);
        }

        public bool Edit(ProductoDVV ProductoDVV)
        {
            ProductoDVVBLL ProductoDVVBLL = new ProductoDVVBLL();
            return ProductoDVVBLL.Edit(ProductoDVV);
        }

        public ProductoDVV GetByID(int ID)
        {
            ProductoDVVBLL ProductoDVVBLL = new ProductoDVVBLL();
            return ProductoDVVBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            ProductoDVVBLL ProductoDVVBLL = new ProductoDVVBLL();
            return ProductoDVVBLL.Delete(ID);

        }
    }
}

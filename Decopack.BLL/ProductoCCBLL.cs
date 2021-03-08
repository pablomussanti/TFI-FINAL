using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.DAL;

namespace Decopack.BLL
{
    public partial class ProductoCCBLL
    {
        public ProductoCC Create(ProductoCC ProductoCC)
        {
            ProductoCC result = default(ProductoCC);
            var ProductoCCDAL = new ProductoCCDAL();

            result = ProductoCCDAL.Create(ProductoCC);
            return result;
        }

        public List<ProductoCC> ListarTodos()
        {
            List<ProductoCC> result = default(List<ProductoCC>);

            var ProductoCCDAL = new ProductoCCDAL();
            result = ProductoCCDAL.Read();
            return result;

        }

        public ProductoCC GetByID(int ID)
        {
            ProductoCC result = default(ProductoCC);
            var ProductoCCDAL = new ProductoCCDAL();

            result = ProductoCCDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(ProductoCC ProductoCC)
        {
            var ProductoCCDAL = new ProductoCCDAL();
            try
            {
                ProductoCCDAL.Update(ProductoCC);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al editar el elemento");
                return false;
            }

        }

        public bool Delete(int ID)
        {
            var ProductoCCDAL = new ProductoCCDAL();
            try
            {
                ProductoCCDAL.Delete(ID);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }
    }
}

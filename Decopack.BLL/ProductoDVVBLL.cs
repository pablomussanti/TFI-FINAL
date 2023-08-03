using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.DAL;

namespace Decopack.BLL
{
       public partial class ProductoDVVBLL
         {
        public ProductoDVV Create(ProductoDVV ProductoDVV)
        {
            ProductoDVV result = default(ProductoDVV);
            var ProductoDVVDAL = new ProductoDVVDAL();

            result = ProductoDVVDAL.Create(ProductoDVV);
            return result;
        }

        public List<ProductoDVV> ListarTodos()
        {
            List<ProductoDVV> result = default(List<ProductoDVV>);

            var ProductoDVVDAL = new ProductoDVVDAL();
            result = ProductoDVVDAL.Read();
            return result;

        }

        public ProductoDVV GetByID(int ID)
        {
            ProductoDVV result = default(ProductoDVV);
            var ProductoDVVDAL = new ProductoDVVDAL();

            result = ProductoDVVDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(ProductoDVV ProductoDVV)
        {
            var ProductoDVVDAL = new ProductoDVVDAL();
            try
            {
                ProductoDVVDAL.Update(ProductoDVV);
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
            var ProductoDVVDAL = new ProductoDVVDAL();
            try
            {
                ProductoDVVDAL.Delete(ID);
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
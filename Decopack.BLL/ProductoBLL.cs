using Decopack.DAL;
using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
    public partial class ProductoBLL
    {
        public Producto Create(Producto Producto)
        {
            Producto result = default(Producto);
            var ProductoDAL = new ProductoDAL();

            result = ProductoDAL.Create(Producto);
            return result;
        }

        public List<Producto> ListarTodos()
        {
            List<Producto> result = default(List<Producto>);

            var ProductoDAL = new ProductoDAL();
            result = ProductoDAL.Read();
            return result;

        }

        public Producto GetByID(int ID)
        {
            Producto result = default(Producto);
            var ProductoDAL = new ProductoDAL();

            result = ProductoDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Producto Producto)
        {
            var ProductoDAL = new ProductoDAL();
            try
            {
                ProductoDAL.Update(Producto);
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
            var ProductoDAL = new ProductoDAL();
            try
            {
                ProductoDAL.Delete(ID);
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

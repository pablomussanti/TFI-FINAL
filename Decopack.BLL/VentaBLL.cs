using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.DAL;

namespace Decopack.BLL
{
    public partial class VentaBLL
    {
        public Venta Create(Venta Venta)
        {
            Venta result = default(Venta);
            var VentaDAL = new VentaDAL();

            result = VentaDAL.Create(Venta);
            return result;
        }

        public List<Venta> ListarTodos()
        {
            List<Venta> result = default(List<Venta>);

            var VentaDAL = new VentaDAL();
            result = VentaDAL.Read();
            return result;

        }

        public Venta GetByID(int ID)
        {
            Venta result = default(Venta);
            var VentaDAL = new VentaDAL();

            result = VentaDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Venta Venta)
        {
            var VentaDAL = new VentaDAL();
            try
            {
                VentaDAL.Update(Venta);
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
            var VentaDAL = new VentaDAL();
            try
            {
                VentaDAL.Delete(ID);
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

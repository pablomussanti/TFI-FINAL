using Decopack.EE;
using Decopack.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
    public partial class ProveedorBLL
    {
        public Proveedor Create(Proveedor Proveedor)
        {
            Proveedor result = default(Proveedor);
            var ProveedorDAL = new ProveedorDAL();

            result = ProveedorDAL.Create(Proveedor);
            return result;
        }

        public List<Proveedor> ListarTodos()
        {
            List<Proveedor> result = default(List<Proveedor>);

            var ProveedorDAL = new ProveedorDAL();
            result = ProveedorDAL.Read();
            return result;

        }

        public Proveedor GetByID(int ID)
        {
            Proveedor result = default(Proveedor);
            var ProveedorDAL = new ProveedorDAL();

            result = ProveedorDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Proveedor Proveedor)
        {
            var ProveedorDAL = new ProveedorDAL();
            try
            {
                ProveedorDAL.Update(Proveedor);
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
            var ProveedorDAL = new ProveedorDAL();
            try
            {
                ProveedorDAL.Delete(ID);
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

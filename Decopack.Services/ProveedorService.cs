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
    public class ProveedorService : IProveedorService
    {
        public List<Proveedor> ListarTodos()
        {
            ProveedorBLL ProveedorBLL = new ProveedorBLL();
            return ProveedorBLL.ListarTodos();
        }

        public Proveedor Create(Proveedor Proveedor)
        {
            ProveedorBLL ProveedorBLL = new ProveedorBLL();
            return ProveedorBLL.Create(Proveedor);
        }

        public bool Edit(Proveedor Proveedor)
        {
            ProveedorBLL ProveedorBLL = new ProveedorBLL();
            return ProveedorBLL.Edit(Proveedor);
        }

        public Proveedor GetByID(int ID)
        {
            ProveedorBLL ProveedorBLL = new ProveedorBLL();
            return ProveedorBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            ProveedorBLL ProveedorBLL = new ProveedorBLL();
            return ProveedorBLL.Delete(ID);

        }
    }
}

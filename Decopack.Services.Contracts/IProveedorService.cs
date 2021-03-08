using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
 public interface IProveedorService
    {
        List<Proveedor> ListarTodos();
        Proveedor Create(Proveedor Proveedor);
        bool Edit(Proveedor Proveedor);
        Proveedor GetByID(int ID);
        bool Delete(int ID);
    }
}

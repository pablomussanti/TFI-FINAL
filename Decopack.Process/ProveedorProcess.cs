using Decopack.EE;
using Decopack.Services.Contracts;
using Decopack.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Process
{
    public class ProveedorProcess : ProcessComponent
    {

        IProveedorService ProveedorService = Framework.Common.ServiceFactory.Get<IProveedorService>();

        public IList<Proveedor> Listar()
        {
            return ProveedorService.ListarTodos();
        }

        public Proveedor Crear(Proveedor Proveedor)
        {

            return ProveedorService.Create(Proveedor);
        }

        public bool Edit(Proveedor Proveedor)
        {
            return ProveedorService.Edit(Proveedor);
        }

        public Proveedor GetByID(int ID)
        {
            return ProveedorService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return ProveedorService.Delete(ID);
        }
    }
}

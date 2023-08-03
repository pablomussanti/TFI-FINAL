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
    public class VentaProcess : ProcessComponent
    {

        IVentaService VentaService = Framework.Common.ServiceFactory.Get<IVentaService>();

        public IList<Venta> Listar()
        {
            return VentaService.ListarTodos();
        }

        public Venta Crear(Venta Venta)
        {

            return VentaService.Create(Venta);
        }

        public bool Edit(Venta Venta)
        {
            return VentaService.Edit(Venta);
        }

        public Venta GetByID(int ID)
        {
            return VentaService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return VentaService.Delete(ID);
        }
    }
}

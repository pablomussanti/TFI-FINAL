using Decopack.EE;
using Decopack.BLL;
using Decopack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services
{
  public class VentaService : IVentaService
    {
        public List<Venta> ListarTodos()
        {
            VentaBLL VentaBLL = new VentaBLL();
            return VentaBLL.ListarTodos();
        }

        public Venta Create(Venta Venta)
        {
            VentaBLL VentaBLL = new VentaBLL();
            return VentaBLL.Create(Venta);
        }

        public bool Edit(Venta Venta)
        {
            VentaBLL VentaBLL = new VentaBLL();
            return VentaBLL.Edit(Venta);
        }

        public Venta GetByID(int ID)
        {
            VentaBLL VentaBLL = new VentaBLL();
            return VentaBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            VentaBLL VentaBLL = new VentaBLL();
            return VentaBLL.Delete(ID);

        }
    }
}

using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IVentaService
    {
        List<Venta> ListarTodos();
        Venta Create(Venta Venta);
        bool Edit(Venta Venta);
        Venta GetByID(int ID);
        bool Delete(int ID);
    }
}

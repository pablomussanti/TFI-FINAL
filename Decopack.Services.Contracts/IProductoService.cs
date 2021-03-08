using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.EE;

namespace Decopack.Services.Contracts
{
    public interface IProductoService
    {
        List<Producto> ListarTodos();
        Producto Create(Producto Producto);
        bool Edit(Producto Producto);
        Producto GetByID(int ID);
        bool Delete(int ID);
    }
}

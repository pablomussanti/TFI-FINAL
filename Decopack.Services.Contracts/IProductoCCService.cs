using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IProductoCCService
    {
        List<ProductoCC> ListarTodos();
        ProductoCC Create(ProductoCC ProductoCC);
        bool Edit(ProductoCC ProductoCC);
        ProductoCC GetByID(int ID);
        bool Delete(int ID);
    }
}

using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IPedidoService
    {
        List<Pedido> ListarTodos();
        Pedido Create(Pedido Pedido);
        bool Edit(Pedido Pedido);
        Pedido GetByID(int ID);
        bool Delete(int ID);
    }
}

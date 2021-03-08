using Decopack.BLL;
using Decopack.EE;
using Decopack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services
{
    public class PedidoService : IPedidoService
    {
        public List<Pedido> ListarTodos()
        {
            PedidoBLL PedidoBLL = new PedidoBLL();
            return PedidoBLL.ListarTodos();
        }

        public Pedido Create(Pedido Pedido)
        {
            PedidoBLL PedidoBLL = new PedidoBLL();
            return PedidoBLL.Create(Pedido);
        }

        public bool Edit(Pedido Pedido)
        {
            PedidoBLL PedidoBLL = new PedidoBLL();
            return PedidoBLL.Edit(Pedido);
        }

        public Pedido GetByID(int ID)
        {
            PedidoBLL PedidoBLL = new PedidoBLL();
            return PedidoBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {

            PedidoBLL PedidoBLL = new PedidoBLL();
            return PedidoBLL.Delete(ID);
        }
    }
}

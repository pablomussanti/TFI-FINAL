using Decopack.Services.Contracts;
using Decopack.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.Servicios;
using Decopack.EE;

namespace Decopack.Process
{
    public class PedidoProcess : ProcessComponent
    {

        IPedidoService PedidoService = Framework.Common.ServiceFactory.Get<IPedidoService>();

        public IList<Pedido> Listar()
        {
            return PedidoService.ListarTodos();
        }

        public Pedido Crear(Pedido Pedido)
        {

            return PedidoService.Create(Pedido);
        }

        public bool Editar(Pedido Pedido)
        {
            return PedidoService.Edit(Pedido);
        }

        public Pedido GetByID(int ID)
        {
            return PedidoService.GetByID(ID);
        }

        public bool Eliminar(int ID)
        {
            return PedidoService.Delete(ID);
        }
    }
}

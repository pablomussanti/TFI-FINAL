using Decopack.DAL;
using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
    public partial class PedidoBLL
    {
        public Pedido Create(Pedido Pedido)
        {
            Pedido result = default(Pedido);
            var PedidoDAL = new PedidoDAL();

            result = PedidoDAL.Create(Pedido);
            return result;
        }

        public List<Pedido> ListarTodos()
        {
            List<Pedido> result = default(List<Pedido>);

            var PedidoDAL = new PedidoDAL();
            result = PedidoDAL.Read();
            return result;

        }

        public Pedido GetByID(int ID)
        {
            Pedido result = default(Pedido);
            var PedidoDAL = new PedidoDAL();

            result = PedidoDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Pedido Pedido)
        {
            var PedidoDAL = new PedidoDAL();
            try
            {
                PedidoDAL.Update(Pedido);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al editar el elemento");
                return false;
            }

        }

        public bool Delete(int ID)
        {
            var PedidoDAL = new PedidoDAL();
            try
            {
                PedidoDAL.Delete(ID);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }


    }
}

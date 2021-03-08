using Decopack.EE;
using Decopack.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
    public partial class StockProductoDepositoBLL
    {
        public StockProductoDeposito Create(StockProductoDeposito StockProductoDeposito)
        {
            StockProductoDeposito result = default(StockProductoDeposito);
            var StockProductoDepositoDAL = new StockProductoDepositoDAL();

            result = StockProductoDepositoDAL.Create(StockProductoDeposito);
            return result;
        }

        public List<StockProductoDeposito> ListarTodos()
        {
            List<StockProductoDeposito> result = default(List<StockProductoDeposito>);

            var StockProductoDepositoDAL = new StockProductoDepositoDAL();
            result = StockProductoDepositoDAL.Read();
            return result;

        }

        public StockProductoDeposito GetByID(int ID)
        {
            StockProductoDeposito result = default(StockProductoDeposito);
            var StockProductoDepositoDAL = new StockProductoDepositoDAL();

            result = StockProductoDepositoDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(StockProductoDeposito StockProductoDeposito)
        {
            var StockProductoDepositoDAL = new StockProductoDepositoDAL();
            try
            {
                StockProductoDepositoDAL.Update(StockProductoDeposito);
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
            var StockProductoDepositoDAL = new StockProductoDepositoDAL();
            try
            {
                StockProductoDepositoDAL.Delete(ID);
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

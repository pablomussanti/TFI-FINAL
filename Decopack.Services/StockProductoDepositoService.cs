using Decopack.EE;
using Decopack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.BLL;

namespace Decopack.Services
{
 public class StockProductoDepositoService : IStockProductoDepositoService
    {
        public List<StockProductoDeposito> ListarTodos()
        {
            StockProductoDepositoBLL StockProductoDepositoBLL = new StockProductoDepositoBLL();
            return StockProductoDepositoBLL.ListarTodos();
        }

        public StockProductoDeposito Create(StockProductoDeposito StockProductoDeposito)
        {
            StockProductoDepositoBLL StockProductoDepositoBLL = new StockProductoDepositoBLL();
            return StockProductoDepositoBLL.Create(StockProductoDeposito);
        }

        public bool Edit(StockProductoDeposito StockProductoDeposito)
        {
            StockProductoDepositoBLL StockProductoDepositoBLL = new StockProductoDepositoBLL();
            return StockProductoDepositoBLL.Edit(StockProductoDeposito);
        }

        public StockProductoDeposito GetByID(int ID)
        {
            StockProductoDepositoBLL StockProductoDepositoBLL = new StockProductoDepositoBLL();
            return StockProductoDepositoBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            StockProductoDepositoBLL StockProductoDepositoBLL = new StockProductoDepositoBLL();
            return StockProductoDepositoBLL.Delete(ID);

        }
    }
}

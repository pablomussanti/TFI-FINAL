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
 public class StockMateriaPrimaDepositoService : IStockMateriaPrimaDepositoService
    {
        public List<StockMateriaPrimaDeposito> ListarTodos()
        {
            StockMateriaPrimaDepositoBLL StockMateriaPrimaDepositoBLL = new StockMateriaPrimaDepositoBLL();
            return StockMateriaPrimaDepositoBLL.ListarTodos();
        }

        public StockMateriaPrimaDeposito Create(StockMateriaPrimaDeposito StockMateriaPrimaDeposito)
        {
            StockMateriaPrimaDepositoBLL StockMateriaPrimaDepositoBLL = new StockMateriaPrimaDepositoBLL();
            return StockMateriaPrimaDepositoBLL.Create(StockMateriaPrimaDeposito);
        }

        public bool Edit(StockMateriaPrimaDeposito StockMateriaPrimaDeposito)
        {
            StockMateriaPrimaDepositoBLL StockMateriaPrimaDepositoBLL = new StockMateriaPrimaDepositoBLL();
            return StockMateriaPrimaDepositoBLL.Edit(StockMateriaPrimaDeposito);
        }

        public StockMateriaPrimaDeposito GetByID(int ID)
        {
            StockMateriaPrimaDepositoBLL StockMateriaPrimaDepositoBLL = new StockMateriaPrimaDepositoBLL();
            return StockMateriaPrimaDepositoBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            StockMateriaPrimaDepositoBLL StockMateriaPrimaDepositoBLL = new StockMateriaPrimaDepositoBLL();
            return StockMateriaPrimaDepositoBLL.Delete(ID);

        }
    }
}

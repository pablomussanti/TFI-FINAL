using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IStockProductoDepositoService
    {
        List<StockProductoDeposito> ListarTodos();
        StockProductoDeposito Create(StockProductoDeposito StockProductoDeposito);
        bool Edit(StockProductoDeposito StockProductoDeposito);
        StockProductoDeposito GetByID(int ID);
        bool Delete(int ID);
    }
}

using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IStockMateriaPrimaDepositoService
    {
        List<StockMateriaPrimaDeposito> ListarTodos();
        StockMateriaPrimaDeposito Create(StockMateriaPrimaDeposito StockMateriaPrimaDeposito);
        bool Edit(StockMateriaPrimaDeposito StockMateriaPrimaDeposito);
        StockMateriaPrimaDeposito GetByID(int ID);
        bool Delete(int ID);
    }
}

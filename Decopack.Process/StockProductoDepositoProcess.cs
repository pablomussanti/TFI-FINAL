using Decopack.EE;
using Decopack.Services.Contracts;
using Decopack.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Process
{
    public class StockProductoDepositoProcess : ProcessComponent
    {

        IStockProductoDepositoService StockProductoDepositoService = Framework.Common.ServiceFactory.Get<IStockProductoDepositoService>();

        public IList<StockProductoDeposito> Listar()
        {
            return StockProductoDepositoService.ListarTodos();
        }

        public StockProductoDeposito Crear(StockProductoDeposito StockProductoDeposito)
        {

            return StockProductoDepositoService.Create(StockProductoDeposito);
        }

        public bool Edit(StockProductoDeposito StockProductoDeposito)
        {
            return StockProductoDepositoService.Edit(StockProductoDeposito);
        }

        public StockProductoDeposito GetByID(int ID)
        {
            return StockProductoDepositoService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return StockProductoDepositoService.Delete(ID);
        }
    }
}

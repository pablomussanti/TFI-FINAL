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
    public class StockMateriaPrimaDepositoProcess : ProcessComponent
    {

        IStockMateriaPrimaDepositoService StockMateriaPrimaDepositoService = Framework.Common.ServiceFactory.Get<IStockMateriaPrimaDepositoService>();

        public IList<StockMateriaPrimaDeposito> Listar()
        {
            return StockMateriaPrimaDepositoService.ListarTodos();
        }

        public StockMateriaPrimaDeposito Crear(StockMateriaPrimaDeposito StockMateriaPrimaDeposito)
        {

            return StockMateriaPrimaDepositoService.Create(StockMateriaPrimaDeposito);
        }

        public bool Edit(StockMateriaPrimaDeposito StockMateriaPrimaDeposito)
        {
            return StockMateriaPrimaDepositoService.Edit(StockMateriaPrimaDeposito);
        }

        public StockMateriaPrimaDeposito GetByID(int ID)
        {
            return StockMateriaPrimaDepositoService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return StockMateriaPrimaDepositoService.Delete(ID);
        }
    }
}

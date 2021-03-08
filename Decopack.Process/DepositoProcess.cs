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
    public class DepositoProcess : ProcessComponent
    {

        IDepositoService DepositoService = Framework.Common.ServiceFactory.Get<IDepositoService>();

        public IList<Deposito> Listar()
        {
            return DepositoService.ListarTodos();
        }

        public Deposito Crear(Deposito Deposito)
        {

            return DepositoService.Create(Deposito);
        }

        public bool Edit(Deposito Deposito)
        {
            return DepositoService.Edit(Deposito);
        }

        public Deposito GetByID(int ID)
        {
            return DepositoService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return DepositoService.Delete(ID);
        }
    }
}

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
 public class DepositoService : IDepositoService
    {
        public List<Deposito> ListarTodos()
        {
            DepositoBLL DepositoBLL = new DepositoBLL();
            return DepositoBLL.ListarTodos();
        }

        public Deposito Create(Deposito Deposito)
        {
            DepositoBLL DepositoBLL = new DepositoBLL();
            return DepositoBLL.Create(Deposito);
        }

        public bool Edit(Deposito Deposito)
        {
            DepositoBLL DepositoBLL = new DepositoBLL();
            return DepositoBLL.Edit(Deposito);
        }

        public Deposito GetByID(int ID)
        {
            DepositoBLL DepositoBLL = new DepositoBLL();
            return DepositoBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            DepositoBLL DepositoBLL = new DepositoBLL();
            return DepositoBLL.Delete(ID);

        }
    }
}

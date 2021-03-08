using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IDepositoService
    {
        List<Deposito> ListarTodos();
        Deposito Create(Deposito Deposito);
        bool Edit(Deposito Deposito);
        Deposito GetByID(int ID);
        bool Delete(int ID);
    }
}

using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IEnvioService
    {
        List<Envio> ListarTodos();
        Envio Create(Envio Envio);
        bool Edit(Envio Envio);
        Envio GetByID(int ID);
        bool Delete(int ID);
    }
}

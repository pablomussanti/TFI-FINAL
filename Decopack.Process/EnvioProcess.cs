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
    public class EnvioProcess : ProcessComponent
    {

        IEnvioService EnvioService = Framework.Common.ServiceFactory.Get<IEnvioService>();

        public IList<Envio> Listar()
        {
            return EnvioService.ListarTodos();
        }

        public Envio Crear(Envio Envio)
        {

            return EnvioService.Create(Envio);
        }

        public bool Edit(Envio Envio)
        {
            return EnvioService.Edit(Envio);
        }

        public Envio GetByID(int ID)
        {
            return EnvioService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return EnvioService.Delete(ID);
        }
    }
}

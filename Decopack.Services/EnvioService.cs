using Decopack.EE;
using Decopack.BLL;
using Decopack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services
{
    public class EnvioService : IEnvioService
    {
        public List<Envio> ListarTodos()
        {
            EnvioBLL EnvioBLL = new EnvioBLL();
            return EnvioBLL.ListarTodos();
        }

        public Envio Create(Envio Envio)
        {
            EnvioBLL EnvioBLL = new EnvioBLL();
            return EnvioBLL.Create(Envio);
        }

        public bool Edit(Envio Envio)
        {
            EnvioBLL EnvioBLL = new EnvioBLL();
            return EnvioBLL.Edit(Envio);
        }

        public Envio GetByID(int ID)
        {
            EnvioBLL EnvioBLL = new EnvioBLL();
            return EnvioBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            EnvioBLL EnvioBLL = new EnvioBLL();
            return EnvioBLL.Delete(ID);

        }
    }
}

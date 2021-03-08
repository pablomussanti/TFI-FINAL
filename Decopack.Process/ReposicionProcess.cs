using Decopack.Services.Contracts;
using Decopack.Servicios;
using Decopack.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.EE;

namespace Decopack.Process
{
 public class ReposicionProcess : ProcessComponent
    {

        IReposicionService ReposicionService = Framework.Common.ServiceFactory.Get<IReposicionService>();

        public IList<Reposicion> Listar()
        {
            return ReposicionService.ListarTodos();
        }

        public Reposicion Crear(Reposicion Reposicion)
        {

            return ReposicionService.Create(Reposicion);
        }

        public bool Edit(Reposicion Reposicion)
        {
            return ReposicionService.Edit(Reposicion);
        }

        public Reposicion GetByID(int ID)
        {
            return ReposicionService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return ReposicionService.Delete(ID);
        }
    }
}

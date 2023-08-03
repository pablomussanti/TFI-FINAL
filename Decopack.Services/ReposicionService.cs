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
    public class ReposicionService : IReposicionService
    {
        public List<Reposicion> ListarTodos()
        {
            ReposicionBLL ReposicionBLL = new ReposicionBLL();
            return ReposicionBLL.ListarTodos();
        }

        public Reposicion Create(Reposicion Reposicion)
        {
            ReposicionBLL ReposicionBLL = new ReposicionBLL();
            return ReposicionBLL.Create(Reposicion);
        }

        public bool Edit(Reposicion Reposicion)
        {
            ReposicionBLL ReposicionBLL = new ReposicionBLL();
            return ReposicionBLL.Edit(Reposicion);
        }

        public Reposicion GetByID(int ID)
        {
            ReposicionBLL ReposicionBLL = new ReposicionBLL();
            return ReposicionBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            ReposicionBLL ReposicionBLL = new ReposicionBLL();
            return ReposicionBLL.Delete(ID);

        }
    }
}

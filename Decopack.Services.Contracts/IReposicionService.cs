using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IReposicionService
    {
        List<Reposicion> ListarTodos();
        Reposicion Create(Reposicion Reposicion);
        bool Edit(Reposicion Reposicion);
        Reposicion GetByID(int ID);
        bool Delete(int ID);
    }
}

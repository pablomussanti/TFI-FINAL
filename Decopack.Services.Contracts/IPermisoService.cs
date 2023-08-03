using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.EE;
using Decopack.Services;
using Decopack.Servicios;

namespace Decopack.Services.Contracts
{
    public interface IPermisoService
    {
        List<Permiso> ListarTodos();
        Permiso Create(Permiso Permiso);
        bool Edit(Permiso Permiso);
        Permiso GetByID(int ID);
        bool Delete(int ID);

        bool Eliminar(Permiso Permiso);
    }
}

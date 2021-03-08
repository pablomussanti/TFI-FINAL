using Decopack.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
     public interface IUsuarioPermisoService
    {
        List<Permisousuario> ListarTodos();
        Permisousuario Create(Permisousuario Permisousuario);
        bool Edit(Permisousuario Permisousuario);
        Permisousuario GetByID(int ID);
        bool Delete(int ID);

        bool Eliminar(Permisousuario Permisousuario);
    }
}

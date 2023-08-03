using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.Servicios;

namespace Decopack.Services.Contracts
{
    public interface IUsuarioService
    {
        List<Usuario> ListarTodos();
        Usuario Create(Usuario Producto);
        bool Edit(Usuario Producto);
        Usuario GetByID(int ID);
        bool Delete(int ID);
        bool AsignarComprador(Usuario ID);
        bool AsignarEmpleado(Usuario ID);
        bool Desbloquear(Usuario ID);
        bool EliminarUsuario(Usuario ID);

    }
}

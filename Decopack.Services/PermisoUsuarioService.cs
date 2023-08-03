using Decopack.Services.Contracts;
using Decopack.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.BLL;

namespace Decopack.Services
{
    public class PermisoUsuarioService : IUsuarioPermisoService
    {
        public List<Permisousuario> ListarTodos()
        {
            PermisoUsuarioBLL PermisoUsuarioBLL = new PermisoUsuarioBLL();
            return PermisoUsuarioBLL.ListarTodos();
        }

        public Permisousuario Create(Permisousuario Permisousuario)
        {
            PermisoUsuarioBLL PermisoUsuarioBLL = new PermisoUsuarioBLL();
            return PermisoUsuarioBLL.Create(Permisousuario);
        }

        public bool Edit(Permisousuario Permisousuario)
        {
            PermisoUsuarioBLL PermisoUsuarioBLL = new PermisoUsuarioBLL();
            return PermisoUsuarioBLL.Edit(Permisousuario);
        }

        public Permisousuario GetByID(int ID)
        {
            PermisoUsuarioBLL PermisoUsuarioBLL = new PermisoUsuarioBLL();
            return PermisoUsuarioBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            PermisoUsuarioBLL PermisoUsuarioBLL = new PermisoUsuarioBLL();
            return PermisoUsuarioBLL.Delete(ID);

        }

        public bool Eliminar(Permisousuario Permisousuario)
        {
            PermisoUsuarioBLL PermisoUsuarioBLL = new PermisoUsuarioBLL();
            return PermisoUsuarioBLL.Eliminar(Permisousuario);

        }
    }
}

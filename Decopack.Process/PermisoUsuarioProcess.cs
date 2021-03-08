using Decopack.Services.Contracts;
using Decopack.Servicios;
using Decopack.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Process
{
    public class PermisoUsuarioProcess : ProcessComponent
    {

        IUsuarioPermisoService UsuarioPermisoservice = Framework.Common.ServiceFactory.Get<IUsuarioPermisoService>();

        public IList<Permisousuario> Listar()
        {
            return UsuarioPermisoservice.ListarTodos();
        }

        public Permisousuario Crear(Permisousuario Permisousuario)
        {

            return UsuarioPermisoservice.Create(Permisousuario);
        }

        public bool Editar(Permisousuario Permisousuario)
        {
            return UsuarioPermisoservice.Edit(Permisousuario);
        }

        public Permisousuario GetByID(int ID)
        {
            return UsuarioPermisoservice.GetByID(ID);
        }

        public bool Eliminar(int ID)
        {
            return UsuarioPermisoservice.Delete(ID);
        }

        public bool Eliminar(Permisousuario Permisousuario)
        {
            return UsuarioPermisoservice.Eliminar(Permisousuario);
        }
    }
}

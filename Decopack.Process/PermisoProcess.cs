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
    public class PermisoProcess : ProcessComponent
    {

        IPermisoService Permisoservice = Framework.Common.ServiceFactory.Get<IPermisoService>();

        public IList<Permiso> Listar()
        {
            return Permisoservice.ListarTodos();
        }

        public Permiso Crear(Permiso Permiso)
        {

            return Permisoservice.Create(Permiso);
        }

        public bool Editar(Permiso Permiso)
        {
            return Permisoservice.Edit(Permiso);
        }

        public Permiso GetByID(int ID)
        {
            return Permisoservice.GetByID(ID);
        }

        public bool Eliminar(int ID)
        {
            return Permisoservice.Delete(ID);
        }

        public bool Eliminar(Permiso Permiso)
        {
            return Permisoservice.Eliminar(Permiso);
        }
    }
}

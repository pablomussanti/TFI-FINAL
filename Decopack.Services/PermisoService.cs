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
        public class PermisoService : IPermisoService
        {
        public List<Permiso> ListarTodos()
        {
            PermisoBLL PermisoBLL = new PermisoBLL();
            return PermisoBLL.ListarTodos();
        }

        public Permiso Create(Permiso Permiso)
        {
            PermisoBLL PermisoBLL = new PermisoBLL();
            return PermisoBLL.Create(Permiso);
        }

        public bool Edit(Permiso Permiso)
        {
            PermisoBLL PermisoBLL = new PermisoBLL();
            return PermisoBLL.Edit(Permiso);
        }

        public Permiso GetByID(int ID)
        {
            PermisoBLL PermisoBLL = new PermisoBLL();
            return PermisoBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            PermisoBLL PermisoBLL = new PermisoBLL();
            return PermisoBLL.Delete(ID);

        }

        public bool Eliminar(Permiso Permiso)
        {
            PermisoBLL PermisoBLL = new PermisoBLL();
            return PermisoBLL.Eliminar(Permiso);

        }
    }
}

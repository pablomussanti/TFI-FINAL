using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Decopack.DAL;
using System.Threading.Tasks;
using Decopack.Servicios;

namespace Decopack.BLL
{
    public partial class PermisoBLL
    {
        public Permiso Create(Permiso Permiso)
        {
            Permiso result = default(Permiso);
            var PermisoDAL = new PermisoDAL();

            result = PermisoDAL.Create(Permiso);
            return result;
        }

        public List<Permiso> ListarTodos()
        {
            List<Permiso> result = default(List<Permiso>);

            var PermisoDAL = new PermisoDAL();
            result = PermisoDAL.Read();
            return result;

        }

        public Permiso GetByID(int ID)
        {
            Permiso result = default(Permiso);
            var PermisoDAL = new PermisoDAL();

            result = PermisoDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Permiso Permiso)
        {
            var PermisoDAL = new PermisoDAL();
            try
            {
                PermisoDAL.Update(Permiso);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al editar el elemento");
                return false;
            }

        }

        public bool Delete(int ID)
        {
            var PermisoDAL = new PermisoDAL();
            try
            {
                PermisoDAL.Delete(ID);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }

        public bool Eliminar(Permiso Permiso)
        {
            var PermisoDAL = new PermisoDAL();
            try
            {
                PermisoDAL.Eliminar(Permiso);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }


    }
}

using Decopack.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.DAL;


namespace Decopack.BLL
{
    public partial class PermisoUsuarioBLL
    {
        public Permisousuario Create(Permisousuario Permisousuario)
        {
            Permisousuario result = default(Permisousuario);
            var UsuarioPermisoDAL = new UsuarioPermisoDAL();

            result = UsuarioPermisoDAL.Create(Permisousuario);
            return result;
        }

        public List<Permisousuario> ListarTodos()
        {
            List<Permisousuario> result = default(List<Permisousuario>);

            var UsuarioPermisoDAL = new UsuarioPermisoDAL();
            result = UsuarioPermisoDAL.Read();
            return result;

        }

        public Permisousuario GetByID(int ID)
        {
            Permisousuario result = default(Permisousuario);
            var UsuarioPermisoDAL = new UsuarioPermisoDAL();

            result = UsuarioPermisoDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Permisousuario Permisousuario)
        {
            var UsuarioPermisoDAL = new UsuarioPermisoDAL();
            try
            {
                UsuarioPermisoDAL.Update(Permisousuario);
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
            var UsuarioPermisoDAL = new UsuarioPermisoDAL();
            try
            {
                UsuarioPermisoDAL.Delete(ID);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }
        public bool Eliminar(Permisousuario Permisousuario)
        {
            var UsuarioPermisoDAL = new UsuarioPermisoDAL();
            try
            {
                UsuarioPermisoDAL.Eliminar(Permisousuario);
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
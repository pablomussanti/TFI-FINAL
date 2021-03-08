using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.Servicios;
using Decopack.DAL;

namespace Decopack.BLL
{
    public partial class UsuarioBLL
    {
        public Usuario Create(Usuario Usuario)
        {
            Usuario result = default(Usuario);
            var UsuarioDAL = new UsuarioDAL();

            result = UsuarioDAL.Create(Usuario);
            return result;
        }

        public List<Usuario> ListarTodos()
        {
            List<Usuario> result = default(List<Usuario>);

            var UsuarioDAL = new UsuarioDAL();
            result = UsuarioDAL.Read();
            return result;

        }

        public Usuario GetByID(int ID)
        {
            Usuario result = default(Usuario);
            var UsuarioDAL = new UsuarioDAL();

            result = UsuarioDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Usuario Usuario)
        {
            var UsuarioDAL = new UsuarioDAL();
            try
            {
                UsuarioDAL.Update(Usuario);
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
            var UsuarioDAL = new UsuarioDAL();
            try
            {
                UsuarioDAL.Delete(ID);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }

        public bool AsignarEmpleado(Usuario ID)
        {
            var UsuarioDAL = new UsuarioDAL();
            try
            {
                UsuarioDAL.AsignarEmpleado(ID);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }

        public bool AsignarComprador(Usuario ID)
        {
            var UsuarioDAL = new UsuarioDAL();
            try
            {
                UsuarioDAL.AsignarComprador(ID);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }

        public bool DesbloquearUsuario(Usuario ID)
        {
            var UsuarioDAL = new UsuarioDAL();
            try
            {
                UsuarioDAL.DesbloquearUsuario(ID);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }

        public bool EliminarUsuario(Usuario ID)
        {
            var UsuarioDAL = new UsuarioDAL();
            try
            {
                UsuarioDAL.EliminarUsuario(ID);
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

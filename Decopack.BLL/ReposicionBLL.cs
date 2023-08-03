using Decopack.EE;
using Decopack.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
    public partial class ReposicionBLL
    {
        public Reposicion Create(Reposicion Reposicion)
        {
            Reposicion result = default(Reposicion);
            var ReposicionDAL = new ReposicionDAL();

            result = ReposicionDAL.Create(Reposicion);
            return result;
        }

        public List<Reposicion> ListarTodos()
        {
            List<Reposicion> result = default(List<Reposicion>);

            var ReposicionDAL = new ReposicionDAL();
            result = ReposicionDAL.Read();
            return result;

        }

        public Reposicion GetByID(int ID)
        {
            Reposicion result = default(Reposicion);
            var ReposicionDAL = new ReposicionDAL();

            result = ReposicionDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Reposicion Reposicion)
        {
            var ReposicionDAL = new ReposicionDAL();
            try
            {
                ReposicionDAL.Update(Reposicion);
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
            var ReposicionDAL = new ReposicionDAL();
            try
            {
                ReposicionDAL.Delete(ID);
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

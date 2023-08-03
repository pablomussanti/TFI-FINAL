using Decopack.DAL;
using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
        public partial class CompradorBLL
    {
        public Comprador Create(Comprador Comprador)
        {
            Comprador result = default(Comprador);
            var CompradorDAL = new CompradorDAL();

            result = CompradorDAL.Create(Comprador);
            return result;
        }

        public List<Comprador> ListarTodos()
        {
            List<Comprador> result = default(List<Comprador>);

            var CompradorDAL = new CompradorDAL();
            result = CompradorDAL.Read();
            return result;

        }

        public Comprador GetByID(int ID)
        {
            Comprador result = default(Comprador);
            var CompradorDAL = new CompradorDAL();

            result = CompradorDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Comprador Comprador)
        {
            var CompradorDAL = new CompradorDAL();
            try
            {
                CompradorDAL.Update(Comprador);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al editar el elemento");
                return false;
            }

        }

        public bool Delete(int ID)
        {
            var CompradorDAL = new CompradorDAL();
            try
            {
                CompradorDAL.Delete(ID);
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

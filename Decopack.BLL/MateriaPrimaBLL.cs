using Decopack.DAL;
using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
    public partial class MateriaPrimaBLL
    {
        public MateriaPrima Create(MateriaPrima MateriaPrima)
        {
            MateriaPrima result = default(MateriaPrima);
            var MateriaPrimaDAL = new MateriaPrimaDAL();

            result = MateriaPrimaDAL.Create(MateriaPrima);
            return result;
        }

        public List<MateriaPrima> ListarTodos()
        {
            List<MateriaPrima> result = default(List<MateriaPrima>);

            var MateriaPrimaDAL = new MateriaPrimaDAL();
            result = MateriaPrimaDAL.Read();
            return result;

        }

        public MateriaPrima GetByID(int ID)
        {
            MateriaPrima result = default(MateriaPrima);
            var MateriaPrimaDAL = new MateriaPrimaDAL();

            result = MateriaPrimaDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(MateriaPrima MateriaPrima)
        {
            var MateriaPrimaDAL = new MateriaPrimaDAL();
            try
            {
                MateriaPrimaDAL.Update(MateriaPrima);
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
            var MateriaPrimaDAL = new MateriaPrimaDAL();
            try
            {
                MateriaPrimaDAL.Delete(ID);
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

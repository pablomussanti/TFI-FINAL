using Decopack.EE;
using Decopack.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
    public partial class DepositoBLL
    {
        public Deposito Create(Deposito Deposito)
        {
            Deposito result = default(Deposito);
            var DepositoDAL = new DepositoDAL();

            result = DepositoDAL.Create(Deposito);
            return result;
        }

        public List<Deposito> ListarTodos()
        {
            List<Deposito> result = default(List<Deposito>);

            var DepositoDAL = new DepositoDAL();
            result = DepositoDAL.Read();
            return result;

        }

        public Deposito GetByID(int ID)
        {
            Deposito result = default(Deposito);
            var DepositoDAL = new DepositoDAL();

            result = DepositoDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Deposito Deposito)
        {
            var DepositoDAL = new DepositoDAL();
            try
            {
                DepositoDAL.Update(Deposito);
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
            var DepositoDAL = new DepositoDAL();
            try
            {
                DepositoDAL.Delete(ID);
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

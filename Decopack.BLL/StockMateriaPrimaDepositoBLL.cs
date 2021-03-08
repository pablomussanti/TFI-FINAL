using Decopack.EE;
using Decopack.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
    public partial class StockMateriaPrimaDepositoBLL
    {
        public StockMateriaPrimaDeposito Create(StockMateriaPrimaDeposito StockMateriaPrimaDeposito)
        {
            StockMateriaPrimaDeposito result = default(StockMateriaPrimaDeposito);
            var StockMateriaPrimaDepositoDAL = new StockMateriaPrimaDepositoDAL();

            result = StockMateriaPrimaDepositoDAL.Create(StockMateriaPrimaDeposito);
            return result;
        }

        public List<StockMateriaPrimaDeposito> ListarTodos()
        {
            List<StockMateriaPrimaDeposito> result = default(List<StockMateriaPrimaDeposito>);

            var StockMateriaPrimaDepositoDAL = new StockMateriaPrimaDepositoDAL();
            result = StockMateriaPrimaDepositoDAL.Read();
            return result;

        }

        public StockMateriaPrimaDeposito GetByID(int ID)
        {
            StockMateriaPrimaDeposito result = default(StockMateriaPrimaDeposito);
            var StockMateriaPrimaDepositoDAL = new StockMateriaPrimaDepositoDAL();

            result = StockMateriaPrimaDepositoDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(StockMateriaPrimaDeposito StockMateriaPrimaDeposito)
        {
            var StockMateriaPrimaDepositoDAL = new StockMateriaPrimaDepositoDAL();
            try
            {
                StockMateriaPrimaDepositoDAL.Update(StockMateriaPrimaDeposito);
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
            var StockMateriaPrimaDepositoDAL = new StockMateriaPrimaDepositoDAL();
            try
            {
                StockMateriaPrimaDepositoDAL.Delete(ID);
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

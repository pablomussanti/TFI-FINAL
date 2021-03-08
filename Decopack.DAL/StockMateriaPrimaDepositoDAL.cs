using Decopack.Data;
using Decopack.EE;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.DAL
{
    public partial class StockMateriaPrimaDepositoDAL : DataAccessComponent, IRepository<StockMateriaPrimaDeposito>
    {
        public StockMateriaPrimaDeposito Create(StockMateriaPrimaDeposito StockMateriaPrimaDeposito)
        {
            const string StoreProcedure = "s_StockMateriaPrimaDeposito_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@CodDeposito", DbType.Int32, StockMateriaPrimaDeposito.CodDeposito);
                db.AddInParameter(cmd, "@CodMateriaPrima", DbType.Int32, StockMateriaPrimaDeposito.CodMateriaPrima);
                db.AddInParameter(cmd, "@Cantidad", DbType.Int32, StockMateriaPrimaDeposito.Cantidad);
                StockMateriaPrimaDeposito.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return StockMateriaPrimaDeposito;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_StockMateriaPrimaDeposito_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@CodStockMateriaPrimaDeposito", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<StockMateriaPrimaDeposito> Read()
        {
            const string StoreProcedure = "s_StockMateriaPrimaDeposito_Listar";

            List<StockMateriaPrimaDeposito> result = new List<StockMateriaPrimaDeposito>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        StockMateriaPrimaDeposito StockMateriaPrimaDeposito = LoadStockMateriaPrimaDeposito(dr);
                        result.Add(StockMateriaPrimaDeposito);
                    }
                }
            }
            return result;
        }

        public StockMateriaPrimaDeposito ReadBy(int id)
        {
            const string StoreProcedure = "s_StockMateriaPrimaDeposito_TraerUno";
            StockMateriaPrimaDeposito StockMateriaPrimaDeposito = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codstockmateriaprimadeposito", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        StockMateriaPrimaDeposito = LoadStockMateriaPrimaDeposito(dr);
                    }
                }
            }
            return StockMateriaPrimaDeposito;
        }

        public void Update(StockMateriaPrimaDeposito StockMateriaPrimaDeposito)
        {
            const string StoreProcedure = "s_StockMateriaPrimaDeposito_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codmateriaprima", DbType.Int32, StockMateriaPrimaDeposito.CodMateriaPrima);
                db.AddInParameter(cmd, "@coddeposito", DbType.Int32, StockMateriaPrimaDeposito.CodDeposito);
                db.AddInParameter(cmd, "@cantidad", DbType.Int32, StockMateriaPrimaDeposito.Cantidad);

                db.ExecuteNonQuery(cmd);
            }
        }

        private StockMateriaPrimaDeposito LoadStockMateriaPrimaDeposito(IDataReader dr)
        {
            StockMateriaPrimaDeposito StockMateriaPrimaDeposito = new StockMateriaPrimaDeposito();
            StockMateriaPrimaDeposito.Id = GetDataValue<int>(dr, "CodStockMateriaPrimaDeposito");
            StockMateriaPrimaDeposito.CodMateriaPrima = GetDataValue<int>(dr, "CodMateriaPrima");
            StockMateriaPrimaDeposito.CodDeposito = GetDataValue<int>(dr, "CodDeposito");
            StockMateriaPrimaDeposito.Cantidad = GetDataValue<int>(dr, "Cantidad");

            var MTD = new MateriaPrimaDAL();
            var DD = new DepositoDAL();

            foreach (var item in DD.Read())
            {
                StockMateriaPrimaDeposito.Deposito = item;
            }
            StockMateriaPrimaDeposito.MateriaPrima = MTD.ReadBy(StockMateriaPrimaDeposito.CodMateriaPrima);
            return StockMateriaPrimaDeposito;
        }
    }
}

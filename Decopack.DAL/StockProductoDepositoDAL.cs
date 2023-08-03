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
    public partial class StockProductoDepositoDAL : DataAccessComponent, IRepository<StockProductoDeposito>
    {
        public StockProductoDeposito Create(StockProductoDeposito StockProductoDeposito)
        {
            const string StoreProcedure = "s_StockProductoDeposito_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Coddeposito", DbType.Int32, StockProductoDeposito.CodDeposito);
                db.AddInParameter(cmd, "@Codproducto", DbType.Int32, StockProductoDeposito.CodProducto);
                db.AddInParameter(cmd, "@Cantidad", DbType.Int32, StockProductoDeposito.Cantidad);
                StockProductoDeposito.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return StockProductoDeposito;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_StockProductoDeposito_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@CodStockProductoDeposito", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<StockProductoDeposito> Read()
        {
            const string StoreProcedure = "s_StockProductoDeposito_Listar";

            List<StockProductoDeposito> result = new List<StockProductoDeposito>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        StockProductoDeposito StockProductoDeposito = LoadStockProductoDeposito(dr);
                        result.Add(StockProductoDeposito);
                    }
                }
            }
            return result;
        }

        public StockProductoDeposito ReadBy(int id)
        {
            const string StoreProcedure = "s_StockProductoDeposito_TraerUno";
            StockProductoDeposito StockProductoDeposito = null;

            //var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            //using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            //{
            //    db.AddInParameter(cmd, "@Codproducto", DbType.Int32, id);
            //    using (IDataReader dr = db.ExecuteReader(cmd))
            //    {
            //        if (dr.Read())
            //        {
            //            Producto = LoadProducto(dr);
            //        }
            //    }
            //}
            return StockProductoDeposito;
        }

        public void Update(StockProductoDeposito StockProductoDeposito)
        {
            const string StoreProcedure = "s_StockProductoDeposito_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@coddeposito", DbType.Int32, StockProductoDeposito.CodDeposito);
                db.AddInParameter(cmd, "@codproducto", DbType.Int32, StockProductoDeposito.CodProducto);
                db.AddInParameter(cmd, "@cantidad", DbType.Int32, StockProductoDeposito.Cantidad);

                db.ExecuteNonQuery(cmd);
            }
        }

        private StockProductoDeposito LoadStockProductoDeposito(IDataReader dr)
        {
            StockProductoDeposito StockProductoDeposito = new StockProductoDeposito();
            StockProductoDeposito.Id = GetDataValue<int>(dr, "CodStockProductoDeposito");
            StockProductoDeposito.CodProducto = GetDataValue<int>(dr, "CodProducto");
            StockProductoDeposito.CodDeposito = GetDataValue<int>(dr, "CodDeposito");
            StockProductoDeposito.Cantidad = GetDataValue<int>(dr, "Cantidad");
            return StockProductoDeposito;
        }
    }
}

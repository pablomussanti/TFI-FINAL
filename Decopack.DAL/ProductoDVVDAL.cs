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
using Decopack.Servicios;

namespace Decopack.DAL
{
    public partial class ProductoDVVDAL : DataAccessComponent, IRepository<ProductoDVV>
    {
        public ProductoDVV Create(ProductoDVV ProductoDVV)
        {
            const string StoreProcedure = "s_ProductoDVV_Generar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@nombre", DbType.String, ProductoDVV.Entidad);
                db.AddInParameter(cmd, "@dvv", DbType.String, ProductoDVV.DVV);

                ProductoDVV.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return ProductoDVV;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_ProductoDVV_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@coddvv", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<ProductoDVV> Read()
        {
            const string StoreProcedure = "s_ProductoDVV_Listar";

            List<ProductoDVV> result = new List<ProductoDVV>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        ProductoDVV ProductoDVV = LoadProductoDVV(dr);
                        result.Add(ProductoDVV);
                    }
                }
            }
            return result;
        }

        public ProductoDVV ReadBy(int id)
        {
            const string StoreProcedure = "s_ProductoDVV_TraerUno";
            ProductoDVV DVV = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@coddvv", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        DVV = LoadProductoDVV(dr);
                    }
                }
            }
            return DVV;
        }

        public void Update(ProductoDVV DVV)
        {
            const string StoreProcedure = "s_ProductoDVV_Actualizar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {

                db.AddInParameter(cmd, "@nombre", DbType.String, DVV.Entidad);
                db.AddInParameter(cmd, "@dvv", DbType.String, DVV.DVV);

                db.ExecuteNonQuery(cmd);
            }
        }

        private ProductoDVV LoadProductoDVV(IDataReader dr)
        {
            ProductoDVV DVV = new ProductoDVV();
            DVV.Id = GetDataValue<int>(dr, "Coddvv");
            DVV.Entidad = GetDataValue<string>(dr, "Entidad");
            DVV.DVV = GetDataValue<string>(dr, "DVV");


            return DVV;
        }
    }
}

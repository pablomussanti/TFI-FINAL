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
    public partial class ProductoCCDAL : DataAccessComponent, IRepository<ProductoCC>
    {
        public ProductoCC Create(ProductoCC ProductoCC)
        {
            const string StoreProcedure = "s_CCproducto_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@usuario", DbType.String, ProductoCC.Usuario);
                db.AddInParameter(cmd, "@fecha", DbType.DateTime, ProductoCC.Fecha);
                db.AddInParameter(cmd, "@nombre", DbType.String, ProductoCC.Nombre);
                db.AddInParameter(cmd, "@tipo", DbType.String, ProductoCC.Tipo);
                db.AddInParameter(cmd, "@descripcion", DbType.String, ProductoCC.Descripcion);
                ProductoCC.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return ProductoCC;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_CCproducto_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codccproducto", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<ProductoCC> Read()
        {
            const string StoreProcedure = "s_CCproducto_Listar";

            List<ProductoCC> result = new List<ProductoCC>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        ProductoCC ProductoCC = LoadProductoCC(dr);
                        result.Add(ProductoCC);
                    }
                }
            }
            return result;
        }

        public ProductoCC ReadBy(int id)
        {
            const string StoreProcedure = "s_Producto_TraerUno";
            ProductoCC ProductoCC = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Codproducto", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        ProductoCC = LoadProductoCC(dr);
                    }
                }
            }
            return ProductoCC;
        }

        public void Update(ProductoCC ProductoCC)
        {
            const string StoreProcedure = "s_CCproducto_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {

                db.AddInParameter(cmd, "@codccproducto", DbType.Int32, ProductoCC.Id);
                db.AddInParameter(cmd, "@usuario", DbType.String, ProductoCC.Usuario);
                db.AddInParameter(cmd, "@fecha", DbType.DateTime, ProductoCC.Fecha);
                db.AddInParameter(cmd, "@nombre", DbType.String, ProductoCC.Nombre);
                db.AddInParameter(cmd, "@tipo", DbType.String, ProductoCC.Tipo);
                db.AddInParameter(cmd, "@descripcion", DbType.String, ProductoCC.Descripcion);

                db.ExecuteNonQuery(cmd);
            }
        }

        private ProductoCC LoadProductoCC(IDataReader dr)
        {
            ProductoCC ProductoCC = new ProductoCC();
            ProductoCC.Id = GetDataValue<int>(dr, "Codccproducto");
            ProductoCC.Usuario = GetDataValue<string>(dr, "Usuario");
            ProductoCC.Fecha = GetDataValue<DateTime>(dr, "Fecha");
            ProductoCC.Tipo = GetDataValue<string>(dr, "Tipo");
            ProductoCC.Nombre = GetDataValue<string>(dr, "Nombre");
            ProductoCC.Descripcion = GetDataValue<string>(dr, "Descripcion");


            return ProductoCC;
        }
    }
}

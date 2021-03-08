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
    public partial class ProveedorDAL : DataAccessComponent, IRepository<Proveedor>
    {
        public Proveedor Create(Proveedor Proveedor)
        {
            const string StoreProcedure = "s_Proveedor_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@cantidaddeerrores", DbType.Int32, Proveedor.Cantidaddeerrores);
                db.AddInParameter(cmd, "@direccion", DbType.String, Proveedor.Direccion);
                db.AddInParameter(cmd, "@nombre", DbType.String, Proveedor.Nombre);
                db.AddInParameter(cmd, "@telefono", DbType.Int32, Proveedor.Telefono);
                db.AddInParameter(cmd, "@estado", DbType.String, Proveedor.Estado);

                Proveedor.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Proveedor;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_Proveedor_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codproveedor", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Proveedor> Read()
        {
            const string StoreProcedure = "s_Proveedor_Listar";

            List<Proveedor> result = new List<Proveedor>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Proveedor Proveedor = LoadProveedor(dr);
                        result.Add(Proveedor);
                    }
                }
            }
            return result;
        }

        public Proveedor ReadBy(int id)
        {
            const string StoreProcedure = "s_Proveedor_TraerUno";
            Proveedor Proveedor = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codproveedor", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Proveedor = LoadProveedor(dr);
                    }
                }
            }
            return Proveedor;
        }

        public void Update(Proveedor Proveedor)
        {
            const string StoreProcedure = "s_Proveedor_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codproveedor", DbType.Int32, Proveedor.Id);
                db.AddInParameter(cmd, "@cantidaddeerrores", DbType.Int32, Proveedor.Cantidaddeerrores);
                db.AddInParameter(cmd, "@direccion", DbType.String, Proveedor.Direccion);
                db.AddInParameter(cmd, "@nombre", DbType.String, Proveedor.Nombre);
                db.AddInParameter(cmd, "@telefono", DbType.Int32, Proveedor.Telefono);
                db.AddInParameter(cmd, "@estado", DbType.AnsiString, Proveedor.Estado);

                db.ExecuteNonQuery(cmd);
            }
        }

        private Proveedor LoadProveedor(IDataReader dr)
        {
            Proveedor Proveedor = new Proveedor();
            Proveedor.Id = GetDataValue<int>(dr, "CodProveedor");
            Proveedor.Cantidaddeerrores = GetDataValue<int>(dr, "Cantidaddeerrores");
            Proveedor.Direccion = GetDataValue<string>(dr, "Direccion");
            Proveedor.Nombre = GetDataValue<string>(dr, "Nombre");
            Proveedor.Telefono = GetDataValue<int>(dr, "Telefono");
            Proveedor.Estado = GetDataValue<string>(dr, "Estado");
            

            return Proveedor;
        }

       
    }
}

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
    public partial class MateriaPrimaProveedorDAL : DataAccessComponent, IRepository<MateriaPrimaProveedor>
    {
        public MateriaPrimaProveedor Create(MateriaPrimaProveedor MateriaPrimaProveedor)
        {
            const string StoreProcedure = "s_MateriaPrimaProveedor_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Codmateriaprima", DbType.Int32, MateriaPrimaProveedor.CodMateriaPrima);
                db.AddInParameter(cmd, "@Codproveedor", DbType.Int32, MateriaPrimaProveedor.CodProveedor);
                db.AddInParameter(cmd, "@Precio", DbType.Double, MateriaPrimaProveedor.Precio);
                MateriaPrimaProveedor.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return MateriaPrimaProveedor;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_MateriaPrimaProveedor_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codmateriaprimaproveedor", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<MateriaPrimaProveedor> Read()
        {
            const string StoreProcedure = "s_MateriaPrimaProveedor_Listar";

            List<MateriaPrimaProveedor> result = new List<MateriaPrimaProveedor>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        MateriaPrimaProveedor MateriaPrimaProveedor = LoadMateriaPrimaProveedor(dr);
                        result.Add(MateriaPrimaProveedor);
                    }
                }
            }
            return result;
        }

        public MateriaPrimaProveedor ReadBy(int id)
        {
            const string StoreProcedure = "s_MateriaPrimaProveedor_TraerUno";

            MateriaPrimaProveedor result = new MateriaPrimaProveedor();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codmateriaprimaproveedor", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        result = LoadMateriaPrimaProveedor(dr);
                    }
                }
            }
            return result;
        }
        

        public List<MateriaPrimaProveedor> TraerPorMateriaPrima(int id)
        {
            const string StoreProcedure = "s_MateriaPrimaProveedor_Traerpormateriaprima";
            List<MateriaPrimaProveedor> result = new List<MateriaPrimaProveedor>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codmateriaprima", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        MateriaPrimaProveedor MateriaPrimaProveedor = LoadMateriaPrimaProveedor(dr);
                        result.Add(MateriaPrimaProveedor);
                    }
                }
            }
            return result;
        }

        public void Update(MateriaPrimaProveedor MateriaPrimaProveedor)
        {
            const string StoreProcedure = "s_MateriaPrimaProveedor_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codproveedor", DbType.Int32, MateriaPrimaProveedor.CodProveedor);
                db.AddInParameter(cmd, "@codmateriaprima", DbType.Int32, MateriaPrimaProveedor.CodMateriaPrima);
                db.AddInParameter(cmd, "@precio", DbType.Double, MateriaPrimaProveedor.Precio);

                db.ExecuteNonQuery(cmd);
            }
        }

        private MateriaPrimaProveedor LoadMateriaPrimaProveedor(IDataReader dr)
        {
            MateriaPrimaProveedor MateriaPrimaProveedor = new MateriaPrimaProveedor();
            MateriaPrimaProveedor.Id = GetDataValue<int>(dr, "CodMateriaPrimaProveedor");
            MateriaPrimaProveedor.CodProveedor = GetDataValue<int>(dr, "CodProveedor");
            MateriaPrimaProveedor.CodMateriaPrima = GetDataValue<int>(dr, "CodMateriaPrima");
            MateriaPrimaProveedor.Precio = GetDataValue<double>(dr, "Precio");
            var matprimaD = new MateriaPrimaDAL();
            ProveedorDAL proveedord = new ProveedorDAL();
            MateriaPrimaProveedor.MateriaPrima = matprimaD.ReadBy(MateriaPrimaProveedor.CodMateriaPrima);
            MateriaPrimaProveedor.Proveedor = proveedord.ReadBy(MateriaPrimaProveedor.CodProveedor);

            return MateriaPrimaProveedor;
        }
    }
}

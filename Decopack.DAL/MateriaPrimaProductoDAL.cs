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
    public partial class MateriaPrimaProductoDAL : DataAccessComponent, IRepository<MateriaPrimaProducto>
    {
        public MateriaPrimaProducto Create(MateriaPrimaProducto MateriaPrimaProducto)
        {
            const string StoreProcedure = "s_MateriaPrimaProducto_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@CodProducto", DbType.Int32, MateriaPrimaProducto.CodProducto);
                db.AddInParameter(cmd, "@CodMateriaPrima", DbType.Int32, MateriaPrimaProducto.CodMateriaPrima);
                db.AddInParameter(cmd, "@Cantidad", DbType.Int32, MateriaPrimaProducto.Cantidad);
                MateriaPrimaProducto.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return MateriaPrimaProducto;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_MateriaPrimaProducto_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codmateriaprimaproducto", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<MateriaPrimaProducto> Read()
        {
            const string StoreProcedure = "s_MateriaPrimaProducto_Listar";

            List<MateriaPrimaProducto> result = new List<MateriaPrimaProducto>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        MateriaPrimaProducto MateriaPrimaProducto = LoadMateriaPrimaProducto(dr);
                        result.Add(MateriaPrimaProducto);
                    }
                }
            }
            return result;
        }

        public MateriaPrimaProducto ReadBy(int id)
        {
            const string StoreProcedure = "s_MateriaPrimaProducto_TraerUno";
            MateriaPrimaProducto MateriaPrimaProducto = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codmateriaprimaproducto", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        MateriaPrimaProducto = LoadMateriaPrimaProducto(dr);
                    }
                }
            }
            return MateriaPrimaProducto;
        }

        public void Update(MateriaPrimaProducto MateriaPrimaProducto)
        {
            const string StoreProcedure = "s_MateriaPrimaProducto_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codmateriaprima", DbType.Int32, MateriaPrimaProducto.CodMateriaPrima);
                db.AddInParameter(cmd, "@codproducto", DbType.Int32, MateriaPrimaProducto.CodProducto);
                db.AddInParameter(cmd, "@cantidad", DbType.Int32, MateriaPrimaProducto.Cantidad);

                db.ExecuteNonQuery(cmd);
            }
        }

        private MateriaPrimaProducto LoadMateriaPrimaProducto(IDataReader dr)
        {
            MateriaPrimaProducto MateriaPrimaProducto = new MateriaPrimaProducto();
            MateriaPrimaProducto.Id = GetDataValue<int>(dr, "CodMateriaPrimaProducto");
            MateriaPrimaProducto.CodMateriaPrima = GetDataValue<int>(dr, "CodMateriaPrima");
            MateriaPrimaProducto.CodProducto = GetDataValue<int>(dr, "CodProducto");
            MateriaPrimaProducto.Cantidad = GetDataValue<int>(dr, "Cantidad");
            var matprimaD = new MateriaPrimaDAL();
            ProductoDAL productoD = new ProductoDAL();
            MateriaPrimaProducto.MateriaPrima = matprimaD.ReadBy(MateriaPrimaProducto.CodMateriaPrima);
            MateriaPrimaProducto.Producto = productoD.ReadBy(MateriaPrimaProducto.CodProducto);

            return MateriaPrimaProducto;
        }
    }
}

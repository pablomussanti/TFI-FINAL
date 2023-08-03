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

     public partial class MateriaPrimaDAL : DataAccessComponent, IRepository<MateriaPrima>
    {
        public MateriaPrima Create(MateriaPrima MateriaPrima)
        {
            const string StoreProcedure = "s_MateriaPrima_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@nombre", DbType.String, MateriaPrima.Nombre);
                db.AddInParameter(cmd, "@descripcion", DbType.String, MateriaPrima.Descripcion);

                MateriaPrima.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return MateriaPrima;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_MateriaPrima_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@CodMateriaPrima", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<MateriaPrima> Read()
        {
            const string StoreProcedure = "s_MateriaPrima_Listar";

            List<MateriaPrima> result = new List<MateriaPrima>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        MateriaPrima MateriaPrima = LoadMateriaPrima(dr);
                        result.Add(MateriaPrima);
                    }
                }
            }
            return result;
        }

        public MateriaPrima ReadBy(int id)
        {
            const string StoreProcedure = "s_MateriaPrima_TraerUno";
            MateriaPrima MateriaPrima = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@CodMateriaPrima", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        MateriaPrima = LoadMateriaPrima(dr);
                    }
                }
            }
            return MateriaPrima;
        }

        public void Update(MateriaPrima MateriaPrima)
        {
            const string StoreProcedure = "s_MateriaPrima_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@nombre", DbType.String, MateriaPrima.Nombre);
                db.AddInParameter(cmd, "@descripcion", DbType.String, MateriaPrima.Descripcion);
                db.AddInParameter(cmd, "@codmateriaprima", DbType.Int32, MateriaPrima.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        private MateriaPrima LoadMateriaPrima(IDataReader dr)
        {
            MateriaPrima MateriaPrima = new MateriaPrima();
            MateriaPrima.Id = GetDataValue<int>(dr, "CodMateriaPrima");
            MateriaPrima.Nombre = GetDataValue<string>(dr, "Nombre");
            MateriaPrima.Descripcion = GetDataValue<string>(dr, "Descripcion");

            return MateriaPrima;
        }
    }
}

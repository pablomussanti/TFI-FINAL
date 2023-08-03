using Decopack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.Servicios;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Decopack.EE;

namespace Decopack.DAL
{
    public partial class PermisoDAL : DataAccessComponent, IRepository<Permiso>
    {
        public Permiso Create(Permiso Permiso)
        {
            const string StoreProcedure = "s_Permiso_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codpermiso", DbType.String, Permiso.RoleId);
                db.AddInParameter(cmd, "@nombre", DbType.String, Permiso.Nombre);
                db.AddInParameter(cmd, "@tipo", DbType.String, Permiso.Tipo);

                Permiso.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Permiso;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_Permiso_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codpermiso", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Permiso> Read()
        {
            const string StoreProcedure = "s_Permiso_Listar";

            List<Permiso> result = new List<Permiso>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Permiso Permiso = LoadPermiso(dr);
                        result.Add(Permiso);
                    }
                }
            }
            return result;
        }

        public Permiso ReadBy(int id)
        {
            const string StoreProcedure = "s_Permiso_TraerUno";
            Permiso Permiso = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codpermiso", DbType.String, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Permiso = LoadPermiso(dr);
                    }
                }
            }
            return Permiso;
        }

        public void Update(Permiso Permiso)
        {
            const string StoreProcedure = "s_Pedido_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codpermiso", DbType.Int16, Permiso.RoleId);
                db.AddInParameter(cmd, "@nombre", DbType.DateTime, Permiso.Nombre);
                db.AddInParameter(cmd, "@tipo", DbType.Int32, Permiso.Tipo);

                db.ExecuteNonQuery(cmd);
            }
        }

        private Permiso LoadPermiso(IDataReader dr)
        {

            Permiso Permiso = new Permiso();
            Permiso.RoleId = GetDataValue<string>(dr, "Id");
            Permiso.Id = Int32.Parse(Permiso.RoleId);

            Permiso.Nombre = GetDataValue<string>(dr, "Name");
            Permiso.Tipo = GetDataValue<string>(dr, "Tipo");


            return Permiso;
        }

        public void Eliminar(Permiso Permiso)
        {
            const string StoreProcedure = "s_Permiso_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codpermiso", DbType.Int32, Permiso.Id);
                db.ExecuteNonQuery(cmd);
            }
        }


    }
}

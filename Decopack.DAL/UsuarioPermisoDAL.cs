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

namespace Decopack.DAL
{
    public partial class UsuarioPermisoDAL : DataAccessComponent, IRepository<Permisousuario>
    {
        public Permisousuario Create(Permisousuario Permisousuario)
        {
            const string StoreProcedure = "s_Permisousuario_Asignar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codpermiso", DbType.AnsiString, Permisousuario.RoleId);
                db.AddInParameter(cmd, "@codusuario", DbType.AnsiString, Permisousuario.UserId);


                Permisousuario.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Permisousuario;
        }

        public void Eliminar(Permisousuario permisousuario)
        {
            const string StoreProcedure = "s_Permisousuario_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codusuario", DbType.String, permisousuario.UserId);
                db.AddInParameter(cmd, "@codpermiso", DbType.String, permisousuario.RoleId);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Permisousuario> Read()
        {
            const string StoreProcedure = "s_Permisousuario_Listar";

            List<Permisousuario> result = new List<Permisousuario>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Permisousuario Permisousuario = LoadPermisousuario(dr);
                        result.Add(Permisousuario);
                    }
                }
            }
            return result;
        }

        public Permisousuario ReadBy(int id)
        {
            const string StoreProcedure = "s_Permisousuario_TraerUno";
            Permisousuario Permisousuario = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codventa", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Permisousuario = LoadPermisousuario(dr);
                    }
                }
            }
            return Permisousuario;
        }

        public void Update(Permisousuario Permisousuario)
        {
            //const string StoreProcedure = "s_Venta_Modificar";

            //var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            //using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            //{
            //    db.AddInParameter(cmd, "@codventa", DbType.Int16, Venta.Id);
            //    db.AddInParameter(cmd, "@codempleado", DbType.AnsiString, Venta.CodEmpleado);
            //    db.AddInParameter(cmd, "@codpedido", DbType.AnsiString, Venta.CodPedido);
            //    db.AddInParameter(cmd, "@pagado", DbType.Int32, Venta.Pagado);
            //    db.AddInParameter(cmd, "@formadepago", DbType.AnsiString, Venta.Formadepago);
            //    db.AddInParameter(cmd, "@monto", DbType.AnsiString, Venta.Monto);
            //    db.ExecuteNonQuery(cmd);
            //}
        }

        private Permisousuario LoadPermisousuario(IDataReader dr)
        {
            Permisousuario Permisousuario = new Permisousuario();
            Permisousuario.RoleId = GetDataValue<string>(dr, "RoleId");
            Permisousuario.UserId = GetDataValue<string>(dr, "UserId");

            var permisop = new PermisoDAL();
            var usuariop = new UsuarioDAL();

            

            foreach (var item in permisop.Read())
            {
                string stringpermiso = string.Format("{0}", item.RoleId);
                if (stringpermiso == Permisousuario.RoleId)
                {
                    Permisousuario.permiso = item;
                }
            }

            foreach (var item in usuariop.Read())
            {
                if (item.Identificador == Permisousuario.UserId)
                {
                    Permisousuario.usuario = item;
                }
            }


            return Permisousuario;
        }

        public void Delete(int id)
        {
            //const string StoreProcedure = "s_Permisousuario_Eliminar";
            //var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            //using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            //{
            //    db.AddInParameter(cmd, "@codusuario", DbType.String, );
            //    db.AddInParameter(cmd, "@codpermiso", DbType.String, id);
            //    db.ExecuteNonQuery(cmd);
            //}
        }
    }
}

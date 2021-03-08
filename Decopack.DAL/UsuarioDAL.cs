using Decopack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.Servicios;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Decopack.DAL
{
    public partial class UsuarioDAL : DataAccessComponent, IRepository<Usuario>
    {
        public Usuario Create(Usuario Usuario)
        {
            const string StoreProcedure = "s_User_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@CodComprador", DbType.AnsiString, Usuario.CodComprador);
                //db.AddInParameter(cmd, "@CodEmpleado", DbType.AnsiString, Usuario.contraseña);
                //db.AddInParameter(cmd, "@Estadobloqueado", DbType.AnsiString, Usuario.estadobloqueado);
                //db.AddInParameter(cmd, "@User", DbType.AnsiString, Usuario.user);
                Usuario.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Usuario;
        }
        

        public void Delete(int id)
        {
            const string StoreProcedure = "s_User_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codusuario", DbType.String, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Usuario> Read()
        {
            const string StoreProcedure = "s_User_Listar";

            List<Usuario> result = new List<Usuario>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Usuario Usuario = LoadUsuario(dr);
                        result.Add(Usuario);
                    }
                }
            }
            return result;
        }

        public Usuario ReadBy(int id)
        {
            const string StoreProcedure = "s_User_TraerUno";
            Usuario Usuario = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codusuario", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Usuario = LoadUsuario(dr);
                    }
                }
            }
            return Usuario;
        }

        public void Update(Usuario Usuario)
        {
            const string StoreProcedure = "s_Identificacion_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Codusuario", DbType.Int16, Usuario.Id);
                //db.AddInParameter(cmd, "@User", DbType.AnsiString, Usuario.user);

                //db.AddInParameter(cmd, "@Estadobloqueado", DbType.AnsiString, Usuario.estadobloqueado);

                db.ExecuteNonQuery(cmd);
            }
        }

        private Usuario LoadUsuario(IDataReader dr)
        {
            Usuario Usuario = new Usuario();
            Usuario.Identificador = GetDataValue<string>(dr, "Id");
            Usuario.LockoutEndDateUtc = GetDataValue<DateTime>(dr, "LockoutEndDateUtc");
            Usuario.CodComprador = GetDataValue<int>(dr, "CodComprador");
            Usuario.CodEmpleado = GetDataValue<int>(dr, "CodEmpleado");
            Usuario.UserName = GetDataValue<string>(dr, "UserName");
            if (Usuario.CodEmpleado != 0)
            {
                var empleado = new EmpleadoDAL();
                Usuario.Empleado = empleado.ReadBy(Usuario.CodEmpleado);

            }
            if (Usuario.CodComprador != 0)
            {
                var comprador = new CompradorDAL();
                Usuario.Comprador = comprador.ReadBy(Usuario.CodComprador);

            }
            return Usuario;
        }

        public void AsignarEmpleado(Usuario usuario)
        {
            const string StoreProcedure = "s_User_AsignarEmpleado";
            Usuario Usuario = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codusuario", DbType.String, usuario.Identificador);
                db.AddInParameter(cmd, "@codempleado", DbType.String, usuario.CodEmpleado);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Usuario = LoadUsuario(dr);
                    }
                }
            }
            
        }

        public void AsignarComprador(Usuario usuario)
        {
            const string StoreProcedure = "s_User_AsignarComprador";
            Usuario Usuario = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codusuario", DbType.String, usuario.Identificador);
                db.AddInParameter(cmd, "@codcomprador", DbType.String, usuario.CodComprador);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Usuario = LoadUsuario(dr);
                    }
                }
            }
           
        }

        public void DesbloquearUsuario(Usuario usuario)
        {
            const string StoreProcedure = "s_User_Desbloquear";
            Usuario Usuario = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codusuario", DbType.String, usuario.Identificador);
                db.AddInParameter(cmd, "@fecha", DbType.DateTime, usuario.LockoutEndDateUtc);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Usuario = LoadUsuario(dr);
                    }
                }
            }
            
        }

        public void EliminarUsuario(Usuario usuario)
        {
            const string StoreProcedure = "s_User_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codusuario", DbType.String, usuario.Identificador);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
}

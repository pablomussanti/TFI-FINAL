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
    public partial class CompradorDAL : DataAccessComponent, IRepository<Comprador>
    {
        public Comprador Create(Comprador Comprador)
        {
            const string StoreProcedure = "s_Comprador_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, Comprador.Nombre);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, Comprador.Apellido);
                db.AddInParameter(cmd, "@Dni", DbType.Int32, Comprador.Dni);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, Comprador.Domicilio);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, Comprador.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.Int32, Comprador.Telefono);
                db.AddInParameter(cmd, "@SocioEstado", DbType.AnsiString, Comprador.SocioEstado);
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, Comprador.Estado);
                Comprador.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Comprador;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_Comprador_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@CodComprador", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Comprador> Read()
        {
            const string StoreProcedure = "s_Comprador_Listar";

            List<Comprador> result = new List<Comprador>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Comprador Comprador = LoadComprador(dr);
                        result.Add(Comprador);
                    }
                }
            }
            return result;
        }

        public Comprador ReadBy(int id)
        {
            const string StoreProcedure = "s_Comprador_TraerUno";
            Comprador Comprador = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codcomprador", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Comprador = LoadComprador(dr);
                    }
                }
            }
            return Comprador;
        }

        public void Update(Comprador Comprador)
        {
            const string StoreProcedure = "s_Comprador_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@CodComprador", DbType.Int16, Comprador.Id);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, Comprador.Nombre);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, Comprador.Apellido);
                db.AddInParameter(cmd, "@Dni", DbType.Int32, Comprador.Dni);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, Comprador.Domicilio);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, Comprador.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.Int32, Comprador.Telefono);
                db.AddInParameter(cmd, "@SocioEstado", DbType.AnsiString, Comprador.SocioEstado);
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, Comprador.Estado);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Comprador LoadComprador(IDataReader dr)
        {
            Comprador Comprador = new Comprador();
            Comprador.Id = GetDataValue<int>(dr, "CodComprador");
            Comprador.Nombre = GetDataValue<string>(dr, "Nombre");
            Comprador.Apellido = GetDataValue<string>(dr, "Apellido");
            Comprador.Dni = GetDataValue<int>(dr, "Dni");
            Comprador.Domicilio = GetDataValue<string>(dr, "Domicilio");
            Comprador.Email = GetDataValue<string>(dr, "Email");
            Comprador.SocioEstado = GetDataValue<string>(dr, "SocioEstado");
            Comprador.Telefono = GetDataValue<int>(dr, "Telefono");
            Comprador.Estado = GetDataValue<string>(dr, "Estado");
            return Comprador;
        }
    }
}

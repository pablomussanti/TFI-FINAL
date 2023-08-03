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
    public partial class EmpleadoDAL : DataAccessComponent, IRepository<Empleado>
    {
        public Empleado Create(Empleado Empleado)
        {
            const string StoreProcedure = "s_Empleado_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@nombre", DbType.AnsiString, Empleado.Nombre);
                db.AddInParameter(cmd, "@apellido", DbType.AnsiString, Empleado.Apellido);
                db.AddInParameter(cmd, "@telefono", DbType.Int32, Empleado.Telefono);
                db.AddInParameter(cmd, "@fechadeingreso", DbType.AnsiString, Empleado.Fechadeingreso);
                db.AddInParameter(cmd, "@email", DbType.AnsiString, Empleado.Email);
                db.AddInParameter(cmd, "@estado", DbType.String, Empleado.Estado);
                db.AddInParameter(cmd, "@coddeposito", DbType.Int32, Empleado.CodDeposito);
                db.AddInParameter(cmd, "@detalle", DbType.String, Empleado.Detalle);

                Empleado.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Empleado;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_Empleado_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codempleado", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Empleado> Read()
        {
            const string StoreProcedure = "s_Empleado_Listar";

            List<Empleado> result = new List<Empleado>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Empleado Empleado = LoadEmpleado(dr);
                        result.Add(Empleado);
                    }
                }
            }
            return result;
        }

        public Empleado ReadBy(int id)
        {
            const string StoreProcedure = "s_Empleado_TraerUno";
            Empleado Empleado = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codempleado", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Empleado = LoadEmpleado(dr);
                    }
                }
            }
            return Empleado;
        }

        public void Update(Empleado Empleado)
        {
            const string StoreProcedure = "s_Empleado_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codempleado", DbType.Int32, Empleado.Id);
                db.AddInParameter(cmd, "@nombre", DbType.AnsiString, Empleado.Nombre);
                db.AddInParameter(cmd, "@apellido", DbType.AnsiString, Empleado.Apellido);
                db.AddInParameter(cmd, "@telefono", DbType.Int32, Empleado.Telefono);
                db.AddInParameter(cmd, "@fechadeingreso", DbType.DateTime, Empleado.Fechadeingreso);
                db.AddInParameter(cmd, "@email", DbType.AnsiString, Empleado.Email);
                db.AddInParameter(cmd, "@estado", DbType.String, Empleado.Estado);
                db.AddInParameter(cmd, "@coddeposito", DbType.Int32, Empleado.CodDeposito);
                db.AddInParameter(cmd, "@detalle", DbType.AnsiString, Empleado.Detalle);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Empleado LoadEmpleado(IDataReader dr)
        {
            Empleado Empleado = new Empleado();
            Empleado.Id = GetDataValue<int>(dr, "Codempleado");
            Empleado.Nombre = GetDataValue<string>(dr, "Nombre");
            Empleado.Apellido = GetDataValue<string>(dr, "Apellido");
            Empleado.Telefono = GetDataValue<int>(dr, "Telefono");
            Empleado.Fechadeingreso = GetDataValue<DateTime>(dr, "Fechadeingreso");
            Empleado.Email = GetDataValue<string>(dr, "Email");
            Empleado.Estado = GetDataValue<string>(dr, "Estado");
            Empleado.CodDeposito = GetDataValue<int>(dr, "Coddeposito");
            Empleado.Detalle = GetDataValue<string>(dr, "Detalle");

            var depositop = new DepositoDAL();
            foreach (var item in depositop.Read())
            {
                Empleado.Deposito = item;
            }

            return Empleado;
        }
    }
}

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
    public partial class DepositoDAL : DataAccessComponent, IRepository<Deposito>
    {
        public Deposito Create(Deposito Deposito)
        {
            const string StoreProcedure = "s_Deposito_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codigopostal", DbType.Int32, Deposito.CodigoPostal);
                db.AddInParameter(cmd, "@direccion", DbType.String, Deposito.Direccion);
                db.AddInParameter(cmd, "@telefono", DbType.Int32, Deposito.Telefono);
                db.AddInParameter(cmd, "@detalle", DbType.String, Deposito.Detalle);

                Deposito.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Deposito;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_Deposito_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Coddeposito", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Deposito> Read()
        {
            const string StoreProcedure = "s_Deposito_Listar";

            List<Deposito> result = new List<Deposito>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Deposito Deposito = LoadDeposito(dr);
                        result.Add(Deposito);
                    }
                }
            }
            return result;
        }

        public Deposito ReadBy(int id)
        {
            //const string StoreProcedure = "s_Producto_TraerUno";
            Deposito Deposito = null;

            //var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            //using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            //{
            //    db.AddInParameter(cmd, "@Codproducto", DbType.Int32, id);
            //    using (IDataReader dr = db.ExecuteReader(cmd))
            //    {
            //        if (dr.Read())
            //        {
            //            Producto = LoadProducto(dr);
            //        }
            //    }
            //}
            return Deposito;
        }

        public void Update(Deposito Deposito)
        {
            const string StoreProcedure = "s_Deposito_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codigopostal", DbType.Int32, Deposito.CodigoPostal);
                db.AddInParameter(cmd, "@direccion", DbType.String, Deposito.Direccion);
                db.AddInParameter(cmd, "@telefono", DbType.Int32, Deposito.Telefono);
                db.AddInParameter(cmd, "@detalle", DbType.String, Deposito.Detalle);
                db.AddInParameter(cmd, "@coddeposito", DbType.Int32, Deposito.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        private Deposito LoadDeposito(IDataReader dr)
        {
            Deposito Deposito = new Deposito();
            Deposito.Id = GetDataValue<int>(dr, "Coddeposito");
            Deposito.CodigoPostal = GetDataValue<int>(dr, "Codigopostal");
            Deposito.Direccion = GetDataValue<string>(dr, "Direccion");
            Deposito.Telefono = GetDataValue<int>(dr, "Telefono");
            Deposito.Detalle = GetDataValue<string>(dr, "Detalle");

            return Deposito;
        }
    }
}

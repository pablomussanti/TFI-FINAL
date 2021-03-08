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
    public partial class EnvioDAL : DataAccessComponent, IRepository<Envio>
    {
        public Envio Create(Envio Envio)
        {
            const string StoreProcedure = "s_Envio_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@direccion", DbType.String, Envio.Direccion);
                db.AddInParameter(cmd, "@codempleado", DbType.Int32, Envio.CodEmpleadoDeposito);
                db.AddInParameter(cmd, "@estado", DbType.String, Envio.Estado);
                db.AddInParameter(cmd, "@fechadesalida", DbType.DateTime, Envio.Fechadesalida);
                db.AddInParameter(cmd, "@fechadellegada", DbType.DateTime, Envio.Fechadellegada);
                db.AddInParameter(cmd, "@codventa", DbType.Int32, Envio.CodVenta);

                Envio.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Envio;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_Envio_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codenvio", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Envio> Read()
        {
            const string StoreProcedure = "s_Envio_Listar";

            List<Envio> result = new List<Envio>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Envio Envio = LoadEnvio(dr);
                        result.Add(Envio);
                    }
                }
            }
            return result;
        }

        public Envio ReadBy(int id)
        {
            const string StoreProcedure = "s_Envio_TraerUno";
            Envio Envio = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codenvio", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Envio = LoadEnvio(dr);
                    }
                }
            }
            return Envio;
        }

        public void Update(Envio Envio)
        {
            const string StoreProcedure = "s_Envio_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codenvio", DbType.Int16, Envio.Id);
                db.AddInParameter(cmd, "@direccion", DbType.String, Envio.Direccion);
                db.AddInParameter(cmd, "@codempleado", DbType.Int32, Envio.CodEmpleadoDeposito);
                db.AddInParameter(cmd, "@estado", DbType.String, Envio.Estado);
                db.AddInParameter(cmd, "@fechadesalida", DbType.DateTime, Envio.Fechadesalida);
                db.AddInParameter(cmd, "@fechadellegada", DbType.DateTime, Envio.Fechadellegada);
                db.AddInParameter(cmd, "@codventa", DbType.Int32, Envio.CodVenta);

                db.ExecuteNonQuery(cmd);
            }
        }

        private Envio LoadEnvio(IDataReader dr)
        {
            Envio Envio = new Envio();
            Envio.Id = GetDataValue<int>(dr, "Codenvio");
            Envio.Direccion = GetDataValue<string>(dr, "Direccion");
            Envio.CodEmpleadoDeposito = GetDataValue<int>(dr, "Codempleadodeposito");
            Envio.Estado = GetDataValue<string>(dr, "Estado");
            Envio.Fechadesalida = GetDataValue<DateTime>(dr, "Fechadesalida");
            Envio.Fechadellegada = GetDataValue<DateTime>(dr, "Fechadellegada");
            Envio.CodVenta = GetDataValue<int>(dr, "Codventa");

            var ventap = new VentaDAL();
            var empleadop = new EmpleadoDAL();
            var pedidop = new PedidoDAL();

            Envio.Venta = ventap.ReadBy(Envio.CodVenta);
            Envio.EmpleadoDeposito = empleadop.ReadBy(Envio.CodEmpleadoDeposito);
            Envio.Venta.Pedido = pedidop.ReadBy(Envio.Venta.CodPedido);


            return Envio;
        }
    }
}

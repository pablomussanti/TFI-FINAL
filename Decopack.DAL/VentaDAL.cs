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
    public partial class VentaDAL : DataAccessComponent, IRepository<Venta>
    {
        public Venta Create(Venta Venta)
        {
            const string StoreProcedure = "s_Venta_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codempleado", DbType.AnsiString, Venta.CodEmpleado);
                db.AddInParameter(cmd, "@codpedido", DbType.AnsiString, Venta.CodPedido);
                db.AddInParameter(cmd, "@pagado", DbType.String, Venta.Pagado);
                db.AddInParameter(cmd, "@formadepago", DbType.AnsiString, Venta.Formadepago);
                db.AddInParameter(cmd, "@monto", DbType.Double, Venta.Monto);

                Venta.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Venta;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_Venta_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codventa", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Venta> Read()
        {
            const string StoreProcedure = "s_Venta_Listar";

            List<Venta> result = new List<Venta>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Venta Venta = LoadVenta(dr);
                        result.Add(Venta);
                    }
                }
            }
            return result;
        }

        public Venta ReadBy(int id)
        {
            const string StoreProcedure = "s_Venta_TraerUno";
            Venta Venta = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codventa", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Venta = LoadVenta(dr);
                    }
                }
            }
            return Venta;
        }

        public void Update(Venta Venta)
        {
            const string StoreProcedure = "s_Venta_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codventa", DbType.Int16, Venta.Id);
                db.AddInParameter(cmd, "@codempleado", DbType.AnsiString, Venta.CodEmpleado);
                db.AddInParameter(cmd, "@codpedido", DbType.AnsiString, Venta.CodPedido);
                db.AddInParameter(cmd, "@pagado", DbType.Int32, Venta.Pagado);
                db.AddInParameter(cmd, "@formadepago", DbType.AnsiString, Venta.Formadepago);
                db.AddInParameter(cmd, "@monto", DbType.AnsiString, Venta.Monto);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Venta LoadVenta(IDataReader dr)
        {
            Venta Venta = new Venta();
            Venta.Id = GetDataValue<int>(dr, "Codventa");
            Venta.CodEmpleado = GetDataValue<int>(dr, "Codempleado");
            Venta.CodPedido = GetDataValue<int>(dr, "Codpedido");
            Venta.Pagado = GetDataValue<string>(dr, "Pagado");
            Venta.Formadepago = GetDataValue<string>(dr, "Formadepago");
            Venta.Monto = GetDataValue<double>(dr, "Monto");

            var empleadoP = new EmpleadoDAL();
            var pedidoP = new PedidoDAL();

            Venta.Empleado = empleadoP.ReadBy(Venta.CodEmpleado);
            Venta.Pedido = pedidoP.ReadBy(Venta.CodPedido);

            return Venta;
        }
    }
}

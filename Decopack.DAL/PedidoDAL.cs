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
    public partial class PedidoDAL : DataAccessComponent, IRepository<Pedido>
    {
        public Pedido Create(Pedido Pedido)
        {
            const string StoreProcedure = "s_Pedido_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codComprador", DbType.Int16, Pedido.CodComprador);
                db.AddInParameter(cmd, "@fecha", DbType.DateTime, Pedido.Fecha);
                db.AddInParameter(cmd, "@codproducto", DbType.Int32, Pedido.Codproducto);
                db.AddInParameter(cmd, "@monto", DbType.Double, Pedido.Monto);
                db.AddInParameter(cmd, "@estado", DbType.String, Pedido.Estado);
                db.AddInParameter(cmd, "@cantidad", DbType.Int32, Pedido.Cantidad);
                db.AddInParameter(cmd, "@descripcion", DbType.AnsiString, Pedido.Descripcion);
                db.AddInParameter(cmd, "@logo", DbType.Binary, Pedido.Logo);
                db.AddInParameter(cmd, "@aprobado", DbType.String, Pedido.Aprobado);


                Pedido.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Pedido;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_Pedido_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@CodPedido", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Pedido> Read()
        {
            const string StoreProcedure = "s_Pedido_Listar";

            List<Pedido> result = new List<Pedido>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Pedido Pedido = LoadPedido(dr);
                        result.Add(Pedido);
                    }
                }
            }
            return result;
        }

        public Pedido ReadBy(int id)
        {
            const string StoreProcedure = "s_Pedido_TraerUno";
            Pedido Pedido = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@CodPedido", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Pedido = LoadPedido(dr);
                    }
                }
            }
            return Pedido;
        }

        public void Update(Pedido Pedido)
        {
            const string StoreProcedure = "s_Pedido_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codComprador", DbType.Int16, Pedido.CodComprador);
                db.AddInParameter(cmd, "@fecha", DbType.DateTime, Pedido.Fecha);
                db.AddInParameter(cmd, "@codproducto", DbType.Int32, Pedido.Codproducto);
                db.AddInParameter(cmd, "@monto", DbType.Double, Pedido.Monto);
                db.AddInParameter(cmd, "@estado", DbType.String, Pedido.Estado);
                db.AddInParameter(cmd, "@cantidad", DbType.Int32, Pedido.Cantidad);
                db.AddInParameter(cmd, "@descripcion", DbType.AnsiString, Pedido.Descripcion);
                db.AddInParameter(cmd, "@logo", DbType.Binary, Pedido.Logo);
                db.AddInParameter(cmd, "@aprobado", DbType.String, Pedido.Aprobado);
                db.AddInParameter(cmd, "@codpedido", DbType.Int32, Pedido.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Pedido LoadPedido(IDataReader dr)
        {
            CompradorDAL compradordal = new CompradorDAL();
            ProductoDAL productodal = new ProductoDAL();
            Pedido Pedido = new Pedido();
            Pedido.Id = GetDataValue<int>(dr, "CodPedido");
            Pedido.CodComprador = GetDataValue<int>(dr, "CodComprador");
            Pedido.Fecha = GetDataValue<DateTime>(dr, "Fecha");
            Pedido.Codproducto = GetDataValue<int>(dr, "CodProducto");
            Pedido.Monto = GetDataValue<double>(dr, "Monto");
            Pedido.Estado = GetDataValue<string>(dr, "Estado");
            Pedido.Cantidad = GetDataValue<int>(dr, "Cantidad");
            Pedido.Descripcion = GetDataValue<string>(dr, "Descripcion");
            Pedido.Logo = GetDataValue<Byte[]>(dr, "Logo");
            Pedido.Aprobado = GetDataValue<string>(dr, "Aprobado");
            Pedido.Comprador = compradordal.ReadBy(Pedido.CodComprador);
            Pedido.Producto = productodal.ReadBy(Pedido.Codproducto);


            return Pedido;
        }
    }
}

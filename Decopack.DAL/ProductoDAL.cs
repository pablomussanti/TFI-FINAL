using Decopack.EE;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Decopack.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.DAL
{
    public partial class ProductoDAL : DataAccessComponent, IRepository<Producto>
    {
        public Producto Create(Producto Producto)
        {
            const string StoreProcedure = "s_Producto_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, Producto.Nombre);
                db.AddInParameter(cmd, "@Precio", DbType.Double, Producto.Precio);
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, Producto.Estado);
                db.AddInParameter(cmd, "@Descripcion", DbType.AnsiString, Producto.Descripcion);
                db.AddInParameter(cmd, "@DVH", DbType.AnsiString, Producto.DVH);
                db.AddInParameter(cmd, "@Image", DbType.Binary, Producto.ImagenProducto);
                Producto.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Producto;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_Producto_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Codproducto", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Producto> Read()
        {
            const string StoreProcedure = "s_Producto_Listartodo";

            List<Producto> result = new List<Producto>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Producto Producto = LoadProducto(dr);
                        result.Add(Producto);
                    }
                }
            }
            return result;
        }

        public Producto ReadBy(int id)
        {
            const string StoreProcedure = "s_Producto_TraerUno";
            Producto Producto = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Codproducto", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Producto = LoadProducto(dr);
                    }
                }
            }
            return Producto;
        }

        public void Update(Producto Producto)
        {
            const string StoreProcedure = "s_Producto_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, Producto.Nombre);
                db.AddInParameter(cmd, "@Precio", DbType.Double, Producto.Precio);
                db.AddInParameter(cmd, "@Estado", DbType.String, Producto.Estado);
                db.AddInParameter(cmd, "@Codproducto", DbType.Int32, Producto.Id);
                db.AddInParameter(cmd, "@DVH", DbType.String, Producto.DVH);
                db.AddInParameter(cmd, "@Image", DbType.Binary, Producto.ImagenProducto);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, Producto.Descripcion);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Producto LoadProducto(IDataReader dr)
        {
            Producto Producto = new Producto();
            Producto.Id = GetDataValue<int>(dr, "CodProducto");
            Producto.Nombre = GetDataValue<string>(dr, "Nombre");
            Producto.Precio = GetDataValue<double>(dr, "Precio");
            Producto.Estado = GetDataValue<string>(dr, "Estado");
            Producto.Descripcion = GetDataValue<string>(dr, "Descripcion");
            Producto.DVH = GetDataValue<string>(dr, "DVH");
            Producto.ImagenProducto = GetDataValue<Byte[]>(dr, "Imagen");
            
            return Producto;
        }
    }
}

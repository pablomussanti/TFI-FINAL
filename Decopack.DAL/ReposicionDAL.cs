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
    public partial class ReposicionDAL : DataAccessComponent, IRepository<Reposicion>
    {
        public Reposicion Create(Reposicion Reposicion)
        {
            const string StoreProcedure = "s_Reposicion_Crear";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@cantidad", DbType.Int32, Reposicion.Cantidad);
                db.AddInParameter(cmd, "@coddeposito", DbType.Int32, Reposicion.CodDeposito);
                db.AddInParameter(cmd, "@estado", DbType.String, Reposicion.Estado);
                db.AddInParameter(cmd, "@fecha", DbType.DateTime, Reposicion.Fecha);
                db.AddInParameter(cmd, "@codmateriaprima", DbType.Int32, Reposicion.CodMateriaPrima);
                db.AddInParameter(cmd, "@codproveedor", DbType.Int32, Reposicion.CodProveedor);
                db.AddInParameter(cmd, "@monto", DbType.Double, Reposicion.Monto);


                Reposicion.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Reposicion;
        }

        public void Delete(int id)
        {
            const string StoreProcedure = "s_Reposicion_Eliminar";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codreposicion", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Reposicion> Read()
        {
            const string StoreProcedure = "s_Reposicion_Listar";

            List<Reposicion> result = new List<Reposicion>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Reposicion Reposicion = LoadReposicion(dr);
                        result.Add(Reposicion);
                    }
                }
            }
            return result;
        }

        public Reposicion ReadBy(int id)
        {
            const string StoreProcedure = "s_Reposicion_TraerUno";
            Reposicion Reposicion = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codreposicion", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Reposicion = LoadReposicion(dr);
                    }
                }
            }
            return Reposicion;
        }

        public void Update(Reposicion Reposicion)
        {
            const string StoreProcedure = "s_Reposicion_Modificar";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetStoredProcCommand(StoreProcedure))
            {
                db.AddInParameter(cmd, "@codreposicion", DbType.Int32, Reposicion.Id);
                db.AddInParameter(cmd, "@cantidad", DbType.Int32, Reposicion.Cantidad);
                db.AddInParameter(cmd, "@coddeposito", DbType.Int32, Reposicion.CodDeposito);
                db.AddInParameter(cmd, "@estado", DbType.String, Reposicion.Estado);
                db.AddInParameter(cmd, "@fecha", DbType.DateTime, Reposicion.Fecha);
                db.AddInParameter(cmd, "@codmateriaprima", DbType.Int32, Reposicion.CodMateriaPrima);
                db.AddInParameter(cmd, "@codproveedor", DbType.Int32, Reposicion.CodProveedor);
                db.AddInParameter(cmd, "@monto", DbType.Double, Reposicion.Monto);

                db.ExecuteNonQuery(cmd);
            }
        }

        private Reposicion LoadReposicion(IDataReader dr)
        {
            Reposicion Reposicion = new Reposicion();
            Reposicion.Id = GetDataValue<int>(dr, "Codreposicion");
            Reposicion.Cantidad = GetDataValue<int>(dr, "Cantidad");
            Reposicion.CodDeposito = GetDataValue<int>(dr, "Coddeposito");
            Reposicion.Estado = GetDataValue<string>(dr, "Estado");
            Reposicion.Fecha = GetDataValue<DateTime>(dr, "Fecha");
            Reposicion.CodMateriaPrima = GetDataValue<int>(dr, "Codmateriaprima");
            Reposicion.CodProveedor = GetDataValue<int>(dr, "Codproveedor");
            Reposicion.Monto = GetDataValue<double>(dr, "Monto");
            var depositoD = new DepositoDAL();
            var materiaprimaD = new MateriaPrimaDAL();
            var proveedorD = new ProveedorDAL();
            Reposicion.Proveedor = proveedorD.ReadBy(Reposicion.CodProveedor);
            Reposicion.MateriaPrima = materiaprimaD.ReadBy(Reposicion.CodMateriaPrima);
            foreach (var item in depositoD.Read())
            {
                Reposicion.Deposito = item;
            }

            return Reposicion;
        }
    }
}

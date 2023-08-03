using Decopack.EE;
using Decopack.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
    public partial class MateriaPrimaProveedorBLL
    {
        public MateriaPrimaProveedor Create(MateriaPrimaProveedor MateriaPrimaProveedor)
        {
            MateriaPrimaProveedor result = default(MateriaPrimaProveedor);
            var MateriaPrimaProveedorDAL = new MateriaPrimaProveedorDAL();

            result = MateriaPrimaProveedorDAL.Create(MateriaPrimaProveedor);
            return result;
        }

        public List<MateriaPrimaProveedor> ListarTodos()
        {
            List<MateriaPrimaProveedor> result = default(List<MateriaPrimaProveedor>);

            var MateriaPrimaProveedorDAL = new MateriaPrimaProveedorDAL();
            result = MateriaPrimaProveedorDAL.Read();
            return result;

        }

        public List<MateriaPrimaProveedor> Listarpormateriaprima(int id)
        {
            List<MateriaPrimaProveedor> result = default(List<MateriaPrimaProveedor>);

            var MateriaPrimaProveedorDAL = new MateriaPrimaProveedorDAL();
            result = MateriaPrimaProveedorDAL.TraerPorMateriaPrima(id);
            return result;

        }

        public MateriaPrimaProveedor GetByID(int ID)
        {
            MateriaPrimaProveedor result = default(MateriaPrimaProveedor);
            var MateriaPrimaProveedorDAL = new MateriaPrimaProveedorDAL();

            result = MateriaPrimaProveedorDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(MateriaPrimaProveedor MateriaPrimaProveedor)
        {
            var MateriaPrimaProveedorDAL = new MateriaPrimaProveedorDAL();
            try
            {
                MateriaPrimaProveedorDAL.Update(MateriaPrimaProveedor);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al editar el elemento");
                return false;
            }

        }

        public bool Delete(int ID)
        {
            var MateriaPrimaProveedorDAL = new MateriaPrimaProveedorDAL();
            try
            {
                MateriaPrimaProveedorDAL.Delete(ID);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }
    }
}

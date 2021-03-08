using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.DAL;

namespace Decopack.BLL
{
    public partial class MateriaPrimaProductoBLL
    {
        public MateriaPrimaProducto Create(MateriaPrimaProducto MateriaPrimaProducto)
        {
            MateriaPrimaProducto result = default(MateriaPrimaProducto);
            var MateriaPrimaProductoDAL = new MateriaPrimaProductoDAL();

            result = MateriaPrimaProductoDAL.Create(MateriaPrimaProducto);
            return result;
        }

        public List<MateriaPrimaProducto> ListarTodos()
        {
            List<MateriaPrimaProducto> result = default(List<MateriaPrimaProducto>);

            var MateriaPrimaProductoDAL = new MateriaPrimaProductoDAL();
            result = MateriaPrimaProductoDAL.Read();
            return result;

        }

        public MateriaPrimaProducto GetByID(int ID)
        {
            MateriaPrimaProducto result = default(MateriaPrimaProducto);
            var MateriaPrimaProductoDAL = new MateriaPrimaProductoDAL();

            result = MateriaPrimaProductoDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(MateriaPrimaProducto MateriaPrimaProducto)
        {
            var MateriaPrimaProductoDAL = new MateriaPrimaProductoDAL();
            try
            {
                MateriaPrimaProductoDAL.Update(MateriaPrimaProducto);
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
            var MateriaPrimaProductoDAL = new MateriaPrimaProductoDAL();
            try
            {
                MateriaPrimaProductoDAL.Delete(ID);
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

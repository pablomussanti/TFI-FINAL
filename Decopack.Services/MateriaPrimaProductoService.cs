using Decopack.EE;
using Decopack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.BLL;

namespace Decopack.Services
{
    public class MateriaPrimaProductoService : IMateriaPrimaProductoService
    {
        public List<MateriaPrimaProducto> ListarTodos()
        {
            MateriaPrimaProductoBLL MateriaPrimaProductoBLL = new MateriaPrimaProductoBLL();
            return MateriaPrimaProductoBLL.ListarTodos();
        }

        public MateriaPrimaProducto Create(MateriaPrimaProducto MateriaPrimaProducto)
        {
            MateriaPrimaProductoBLL MateriaPrimaProductoBLL = new MateriaPrimaProductoBLL();
            return MateriaPrimaProductoBLL.Create(MateriaPrimaProducto);
        }

        public bool Edit(MateriaPrimaProducto MateriaPrimaProducto)
        {
            MateriaPrimaProductoBLL MateriaPrimaProductoBLL = new MateriaPrimaProductoBLL();
            return MateriaPrimaProductoBLL.Edit(MateriaPrimaProducto);
        }

        public MateriaPrimaProducto GetByID(int ID)
        {
            MateriaPrimaProductoBLL MateriaPrimaProductoBLL = new MateriaPrimaProductoBLL();
            return MateriaPrimaProductoBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            MateriaPrimaProductoBLL MateriaPrimaProductoBLL = new MateriaPrimaProductoBLL();
            return MateriaPrimaProductoBLL.Delete(ID);

        }
    }
}

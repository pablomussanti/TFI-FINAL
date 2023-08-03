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
 public class MateriaPrimaProveedorService : IMateriaPrimaProveedorService
    {
        public List<MateriaPrimaProveedor> ListarTodos()
        {
            MateriaPrimaProveedorBLL MateriaPrimaProveedorBLL = new MateriaPrimaProveedorBLL();
            return MateriaPrimaProveedorBLL.ListarTodos();
        }

        public List<MateriaPrimaProveedor> Listarpormateriaprima(int id)
        {
            MateriaPrimaProveedorBLL MateriaPrimaProveedorBLL = new MateriaPrimaProveedorBLL();
            return MateriaPrimaProveedorBLL.Listarpormateriaprima(id);
        }

        public MateriaPrimaProveedor Create(MateriaPrimaProveedor MateriaPrimaProveedor)
        {
            MateriaPrimaProveedorBLL MateriaPrimaProveedorBLL = new MateriaPrimaProveedorBLL();
            return MateriaPrimaProveedorBLL.Create(MateriaPrimaProveedor);
        }

        public bool Edit(MateriaPrimaProveedor MateriaPrimaProveedor)
        {
            MateriaPrimaProveedorBLL MateriaPrimaProveedorBLL = new MateriaPrimaProveedorBLL();
            return MateriaPrimaProveedorBLL.Edit(MateriaPrimaProveedor);
        }

        public MateriaPrimaProveedor GetByID(int ID)
        {
            MateriaPrimaProveedorBLL MateriaPrimaProveedorBLL = new MateriaPrimaProveedorBLL();
            return MateriaPrimaProveedorBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            MateriaPrimaProveedorBLL MateriaPrimaProveedorBLL = new MateriaPrimaProveedorBLL();
            return MateriaPrimaProveedorBLL.Delete(ID);

        }
    }
}

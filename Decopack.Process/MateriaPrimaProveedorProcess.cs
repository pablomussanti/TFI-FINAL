using Decopack.EE;
using Decopack.Services.Contracts;
using Decopack.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Process
{
    public class MateriaPrimaProveedorProcess : ProcessComponent
    {

        IMateriaPrimaProveedorService MateriaPrimaProveedorService = Framework.Common.ServiceFactory.Get<IMateriaPrimaProveedorService>();

        public IList<MateriaPrimaProveedor> Listar()
        {
            return MateriaPrimaProveedorService.ListarTodos();
        }

        public IList<MateriaPrimaProveedor> Listarpormateriaprima(int id)
        {
            return MateriaPrimaProveedorService.Listarpormateriaprima(id);
        }

        public MateriaPrimaProveedor Crear(MateriaPrimaProveedor MateriaPrimaProveedor)
        {

            return MateriaPrimaProveedorService.Create(MateriaPrimaProveedor);
        }

        public bool Edit(MateriaPrimaProveedor MateriaPrimaProveedor)
        {
            return MateriaPrimaProveedorService.Edit(MateriaPrimaProveedor);
        }

        public MateriaPrimaProveedor GetByID(int ID)
        {
            return MateriaPrimaProveedorService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return MateriaPrimaProveedorService.Delete(ID);
        }
    }
}

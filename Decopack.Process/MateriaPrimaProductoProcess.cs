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
    public class MateriaPrimaProductoProcess : ProcessComponent
    {

        IMateriaPrimaProductoService MateriaPrimaProductoService = Framework.Common.ServiceFactory.Get<IMateriaPrimaProductoService>();

        public IList<MateriaPrimaProducto> Listar()
        {
            return MateriaPrimaProductoService.ListarTodos();
        }

        public MateriaPrimaProducto Crear(MateriaPrimaProducto MateriaPrimaProducto)
        {

            return MateriaPrimaProductoService.Create(MateriaPrimaProducto);
        }

        public bool Editar(MateriaPrimaProducto MateriaPrimaProducto)
        {
            return MateriaPrimaProductoService.Edit(MateriaPrimaProducto);
        }

        public MateriaPrimaProducto GetByID(int ID)
        {
            return MateriaPrimaProductoService.GetByID(ID);
        }

        public bool Eliminar(int ID)
        {
            return MateriaPrimaProductoService.Delete(ID);
        }
    }
}

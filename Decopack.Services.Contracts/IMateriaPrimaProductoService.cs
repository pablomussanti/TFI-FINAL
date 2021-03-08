using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IMateriaPrimaProductoService
    {
        List<MateriaPrimaProducto> ListarTodos();
        MateriaPrimaProducto Create(MateriaPrimaProducto MateriaPrimaProducto);
        bool Edit(MateriaPrimaProducto MateriaPrimaProducto);
        MateriaPrimaProducto GetByID(int ID);
        bool Delete(int ID);
    }
}

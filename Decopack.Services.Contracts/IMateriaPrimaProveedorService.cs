using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IMateriaPrimaProveedorService
    {
        List<MateriaPrimaProveedor> ListarTodos();
        MateriaPrimaProveedor Create(MateriaPrimaProveedor MateriaPrimaProveedor);
        bool Edit(MateriaPrimaProveedor MateriaPrimaProveedor);
        MateriaPrimaProveedor GetByID(int ID);
        bool Delete(int ID);
        List<MateriaPrimaProveedor> Listarpormateriaprima(int id);
    }
}

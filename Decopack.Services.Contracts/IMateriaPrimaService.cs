using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IMateriaPrimaService
    {
        List<MateriaPrima> ListarTodos();
        MateriaPrima Create(MateriaPrima MateriaPrima);
        bool Edit(MateriaPrima MateriaPrima);
        MateriaPrima GetByID(int ID);
        bool Delete(int ID);
    }
}

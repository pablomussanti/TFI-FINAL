using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface ICompradorService
    {
        List<Comprador> ListarTodos();
        Comprador Create(Comprador Comprador);
        bool Edit(Comprador Comprador);
        Comprador GetByID(int ID);
        bool Delete(int ID);
    }
}

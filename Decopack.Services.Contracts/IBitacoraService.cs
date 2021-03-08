using Decopack.Servicios.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IBitacoraService
    {
        List<Bitacora> ListarTodos();
        Bitacora Create(Bitacora Bitacora);
        bool Edit(Bitacora Bitacora);
        Bitacora GetByID(int ID);
        bool Delete(int ID);
    }
}

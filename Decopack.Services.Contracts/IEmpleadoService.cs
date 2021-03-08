using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IEmpleadoService
    {
        List<Empleado> ListarTodos();
        Empleado Create(Empleado Empleado);
        bool Edit(Empleado Empleado);
        Empleado GetByID(int ID);
        bool Delete(int ID);
    }
}

using Decopack.EE;
using Decopack.BLL;
using Decopack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services
{

    public class EmpleadoService : IEmpleadoService
    {
        public List<Empleado> ListarTodos()
        {
            EmpleadoBLL EmpleadoBLL = new EmpleadoBLL();
            return EmpleadoBLL.ListarTodos();
        }

        public Empleado Create(Empleado Empleado)
        {
            EmpleadoBLL EmpleadoBLL = new EmpleadoBLL();
            return EmpleadoBLL.Create(Empleado);
        }

        public bool Edit(Empleado Empleado)
        {
            EmpleadoBLL EmpleadoBLL = new EmpleadoBLL();
            return EmpleadoBLL.Edit(Empleado);
        }

        public Empleado GetByID(int ID)
        {
            EmpleadoBLL EmpleadoBLL = new EmpleadoBLL();
            return EmpleadoBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            EmpleadoBLL EmpleadoBLL = new EmpleadoBLL();
            return EmpleadoBLL.Delete(ID);

        }
    }
}

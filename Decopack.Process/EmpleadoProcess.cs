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
    public class EmpleadoProcess : ProcessComponent
    {

        IEmpleadoService EmpleadoService = Framework.Common.ServiceFactory.Get<IEmpleadoService>();

        public IList<Empleado> Listar()
        {
            return EmpleadoService.ListarTodos();
        }

        public Empleado Crear(Empleado Empleado)
        {

            return EmpleadoService.Create(Empleado);
        }

        public bool Edit(Empleado Empleado)
        {
            return EmpleadoService.Edit(Empleado);
        }

        public Empleado GetByID(int ID)
        {
            return EmpleadoService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return EmpleadoService.Delete(ID);
        }
    }
}

using Decopack.EE;
using Decopack.Servicios.Composite;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios
{

    public class Usuario : IEntity
    {

        public int Id { get; set; }

        public string Identificador { get; set; }

        public string UserName { get; set; }

        public int CodComprador { get; set; }

        public int CodEmpleado { get; set; }

        public Comprador Comprador { get; set; }

        public Empleado Empleado { get; set; }

        public DateTime LockoutEndDateUtc { get; set; }

    }

}

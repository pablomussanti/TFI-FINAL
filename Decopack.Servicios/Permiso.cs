using System;
using System.Collections.Generic;
using System.Linq;
using Safari.Entities;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios
{
    public class Permiso : IEntity
    {
        public int Id { get; set; }

        public string RoleId { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }
    }
}

using Decopack.Servicios.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Entities;

namespace Decopack.Servicios
{
    public class Permisousuario : IEntity
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string RoleId { get; set; }

        public Permiso permiso { get; set; }

        public Usuario usuario { get; set; }

    }

}

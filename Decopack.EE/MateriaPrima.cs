using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
   public partial class MateriaPrima : IEntity
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }


    }
}

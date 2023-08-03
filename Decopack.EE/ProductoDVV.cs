using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
    public partial class ProductoDVV : IEntity
    {
        public int Id { get; set; }
        public string Entidad { get; set; }
        public string DVV { get; set; }
    }
}

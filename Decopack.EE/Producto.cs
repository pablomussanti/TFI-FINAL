using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
    public partial class Producto : IEntity
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public string Estado { get; set; }

        public string Descripcion { get; set; }

        public string DVH { get; set; }

        public Byte[] ImagenProducto { get; set; }


    }
}

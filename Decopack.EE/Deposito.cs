using Safari.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
    public partial class Deposito : IEntity
    {

        public int Id { get; set; }

        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "deposito_detalle")]
        public string Detalle { get; set; }

        public string Direccion { get; set; }

        public int Telefono { get; set; }

        public int CodigoPostal { get; set; }

    }
}

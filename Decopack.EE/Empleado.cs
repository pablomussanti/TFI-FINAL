using Safari.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
    public partial class Empleado : Persona
    {
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "empleado_fechadeingreso")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fechadeingreso { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "empleado_detalle")]
        public string Detalle { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "empleado_coddeposito")]
        public int CodDeposito { get; set; }

        public Deposito Deposito { get; set; }

    }
}

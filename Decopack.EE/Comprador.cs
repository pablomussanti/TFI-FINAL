using Safari.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
    public partial class Comprador : Persona
    {

        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "comprador_dni")]
        public int Dni { get; set; }

        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "comprador_socioestado")]
        public string SocioEstado { get; set; }

        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "comprador_domicilio")]
        public string Domicilio { get; set; }




    }
}

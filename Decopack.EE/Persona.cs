using Safari.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
    public partial class Persona : IEntity
    {

        public int Id { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "persona_nombre")]
        public string Nombre { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "persona_apellido")]
        public string Apellido { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "persona_email")]
        public string Email { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "persona_telefono")]
        public int Telefono { get; set; }

        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "persona_estado")]
        public string Estado { get; set; }

    }
}

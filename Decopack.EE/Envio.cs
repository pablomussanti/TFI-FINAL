using Safari.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
    public partial class Envio : IEntity
    {

        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "envio_codenvio")]
        public int Id { get; set; }

        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "envio_direccion")]
        public string Direccion { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "envio_codventa")]
        public int CodVenta { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "envio_fechadellegada")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fechadellegada { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "envio_fechadesalida")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fechadesalida { get; set; }

        public Venta Venta { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "envio_codempleadodeposito")]
        public int CodEmpleadoDeposito { get; set; }

        public Empleado EmpleadoDeposito { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "envio_estado")]
        public string Estado { get; set; }
    }
}

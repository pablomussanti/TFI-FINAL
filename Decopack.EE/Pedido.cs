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
    public partial class Pedido : IEntity
    {
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "pedido_codigo")]
        public int Id { get; set; }

        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "pedido_fecha")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "pedido_codproducto")]
        public int Codproducto { get; set; }
        public Producto Producto { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "pedido_monto")]
        public double Monto { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "pedido_estado")]
        public string Estado { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "pedido_cantidad")]
        public int Cantidad { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "pedido_descripcion")]
        public string Descripcion { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "pedido_logo")]
        public Byte[] Logo { get; set; }

        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "pedido_aprobado")]
        public string Aprobado { get; set; }
        [Display(ResourceType = typeof(RecursosEntidad.Recurso), Name = "pedido_codcomprador")]
        public int CodComprador { get; set; }

        public Comprador Comprador { get; set; }

    }
}

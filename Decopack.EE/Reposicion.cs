using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Decopack.EE
{
    public partial class Reposicion : IEntity
    {

        public int Id { get; set; }

        public int Cantidad { get; set; }

        public int CodMateriaPrima { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }


        public double Monto  { get; set; }
        public MateriaPrima MateriaPrima { get; set; }

        public int CodDeposito { get; set; }

        public Deposito Deposito { get; set; }

        public string Estado { get; set; }

        public int CodProveedor { get; set; }

        public Proveedor Proveedor { get; set; }

    }
}

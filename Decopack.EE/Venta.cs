using Safari.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.EE
{
    public partial class Venta : IEntity
    {

        public int Id { get; set; }


        public int CodEmpleado { get; set; }

        public Empleado Empleado { get; set; }


        public int CodPedido { get; set; }

        public Pedido Pedido { get; set; }

        public string Pagado { get; set; }

        public string Formadepago { get; set; }

        public double Monto { get; set; }


    }
}

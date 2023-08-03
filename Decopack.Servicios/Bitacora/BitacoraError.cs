using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios.Bitacora
{
    public class BitacoraError : Bitacorageneral
    {
        public BitacoraError(string dato1, string dato2, string dato3, DateTime dato4)
        {
            tipo = dato1;
            descripcion = dato2;
            user = dato3;
            fecha = dato4;
        }
        public BitacoraError()
        {
        }
    }
}

using Decopack.Servicios.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.DAL;

namespace Decopack.BLL
{
    public class BitacoraBLL
    {
        public Bitacora Create(Bitacora Bitacora)
        {
           
            var BitacoraDAL = new BitacoraDAL();

            BitacoraDAL.Create(Bitacora);
            return null;
        }

        public List<Bitacora> ListarTodos()
        {
            List<Bitacora> result = default(List<Bitacora>);

            var BitacoraDAL = new BitacoraDAL();
            result = BitacoraDAL.Read();
            return result;

        }
    }
}

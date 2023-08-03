using Decopack.Services;
using Decopack.Services.Contracts;
using Decopack.Servicios.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Process
{
    public class BitacoraProcess
    {
        IBitacoraService BitacoraService = Framework.Common.ServiceFactory.Get<IBitacoraService>();
        public List<Bitacora> ListarTodos()
        {
            return BitacoraService.ListarTodos();
        }

        public Bitacora Create(Bitacora Bitacora)
        {
            return BitacoraService.Create(Bitacora);
        }
    }
}

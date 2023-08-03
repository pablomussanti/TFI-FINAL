using Decopack.BLL;
using Decopack.Services.Contracts;
using Decopack.Servicios.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services
{
    public class BitacoraService : IBitacoraService
    {
        public List<Bitacora> ListarTodos()
        {
            BitacoraBLL BitacoraComponent = new BitacoraBLL();
            return BitacoraComponent.ListarTodos();
        }

        public Bitacora Create(Bitacora Bitacora)
        {
            BitacoraBLL BitacoraComponent = new BitacoraBLL();
            return BitacoraComponent.Create(Bitacora);
        }

        public bool Edit(Bitacora Bitacora)
        {
            return true;
        }

        public Bitacora GetByID(int ID)
        {
            return new Bitacora();
        }

        public bool Delete(int ID)
        {
            return true;
        }
    }
}

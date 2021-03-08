using Decopack.EE;
using Decopack.Services.Contracts;
using Decopack.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Process
{
     public class CompradorProcess : ProcessComponent
    {

        ICompradorService CompradorService = Framework.Common.ServiceFactory.Get<ICompradorService>();

        public IList<Comprador> Listar()
        {
            return CompradorService.ListarTodos();
        }

        public Comprador Crear(Comprador Comprador)
        {

            return CompradorService.Create(Comprador);
        }

        public bool Editar(Comprador Comprador)
        {
            return CompradorService.Edit(Comprador);
        }

        public Comprador GetByID(int ID)
        {
            return CompradorService.GetByID(ID);
        }

        public bool Eliminar(int ID)
        {
            return CompradorService.Delete(ID);
        }
    }
}

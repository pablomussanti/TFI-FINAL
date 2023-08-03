using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.EE;
using Decopack.BLL;
using Decopack.Services.Contracts;

namespace Decopack.Services
{
    public class CompradorService : ICompradorService
    {
        public List<Comprador> ListarTodos()
        {
            CompradorBLL CompradorBLL = new CompradorBLL();
            return CompradorBLL.ListarTodos();
        }

        public Comprador Create(Comprador Comprador)
        {
            CompradorBLL CompradorBLL = new CompradorBLL();
            return CompradorBLL.Create(Comprador);
        }

        public bool Edit(Comprador Comprador)
        {
            CompradorBLL CompradorBLL = new CompradorBLL();
            return CompradorBLL.Edit(Comprador);
        }

        public Comprador GetByID(int ID)
        {
            CompradorBLL CompradorBLL = new CompradorBLL();
            return CompradorBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            CompradorBLL CompradorBLL = new CompradorBLL();
            return CompradorBLL.Delete(ID);
        }
    }
}

using Decopack.BLL;
using Decopack.EE;
using Decopack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services
{
    public class MateriaPrimaService : IMateriaPrimaService
    {
        public List<MateriaPrima> ListarTodos()
        {
            MateriaPrimaBLL MateriaPrimaBLL = new MateriaPrimaBLL();
            return MateriaPrimaBLL.ListarTodos();
        }

        public MateriaPrima Create(MateriaPrima MateriaPrima)
        {
            MateriaPrimaBLL MateriaPrimaBLL = new MateriaPrimaBLL();
            return MateriaPrimaBLL.Create(MateriaPrima);
        }

        public bool Edit(MateriaPrima MateriaPrima)
        {
            MateriaPrimaBLL MateriaPrimaBLL = new MateriaPrimaBLL();
            return MateriaPrimaBLL.Edit(MateriaPrima);
        }

        public MateriaPrima GetByID(int ID)
        {
            MateriaPrimaBLL MateriaPrimaBLL = new MateriaPrimaBLL();
            return MateriaPrimaBLL.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            MateriaPrimaBLL MateriaPrimaBLL = new MateriaPrimaBLL();
            return MateriaPrimaBLL.Delete(ID);

        }
    }
}

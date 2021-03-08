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
    public class MateriaPrimaProcess : ProcessComponent
    {

        IMateriaPrimaService MateriaPrimaService = Framework.Common.ServiceFactory.Get<IMateriaPrimaService>();

        public IList<MateriaPrima> Listar()
        {
            return MateriaPrimaService.ListarTodos();
        }

        public MateriaPrima Crear(MateriaPrima MateriaPrima)
        {

            return MateriaPrimaService.Create(MateriaPrima);
        }

        public bool Editar(MateriaPrima MateriaPrima)
        {
            return MateriaPrimaService.Edit(MateriaPrima);
        }

        public MateriaPrima GetByID(int ID)
        {
            return MateriaPrimaService.GetByID(ID);
        }

        public bool Eliminar(int ID)
        {
            return MateriaPrimaService.Delete(ID);
        }
    }
}

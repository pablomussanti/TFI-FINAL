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
    public class ProductoCCProcess : ProcessComponent
    {

        IProductoCCService ProductoCCService = Framework.Common.ServiceFactory.Get<IProductoCCService>();

        public IList<ProductoCC> Listar()
        {
            return ProductoCCService.ListarTodos();
        }

        public ProductoCC Crear(ProductoCC ProductoCC)
        {

            return ProductoCCService.Create(ProductoCC);
        }

        public bool Editar(ProductoCC ProductoCC)
        {
            return ProductoCCService.Edit(ProductoCC);
        }

        public ProductoCC GetByID(int ID)
        {
            return ProductoCCService.GetByID(ID);
        }

        public bool Eliminar(int ID)
        {
            return ProductoCCService.Delete(ID);
        }
    }
}

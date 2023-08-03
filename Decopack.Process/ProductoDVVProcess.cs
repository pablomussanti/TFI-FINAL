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
    public class ProductoDVVProcess : ProcessComponent
    {

        IProductoDVVService ProductoDVVService = Framework.Common.ServiceFactory.Get<IProductoDVVService>();

        public IList<ProductoDVV> Listar()
        {
            return ProductoDVVService.ListarTodos();
        }

        public ProductoDVV Crear(ProductoDVV ProductoDVV)
        {

            return ProductoDVVService.Create(ProductoDVV);
        }

        public bool Editar(ProductoDVV ProductoDVV)
        {
            return ProductoDVVService.Edit(ProductoDVV);
        }

        public ProductoDVV GetByID(int ID)
        {
            return ProductoDVVService.GetByID(ID);
        }

        public bool Eliminar(int ID)
        {
            return ProductoDVVService.Delete(ID);
        }
    }
}

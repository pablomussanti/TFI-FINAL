using Decopack.EE;
using Decopack.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decopack.Services.Contracts.Requests;
using Decopack.Services.Contracts.Responses;
using Decopack.Services.Contracts;

namespace Decopack.Process
{
   public class ProductoProcess : ProcessComponent
    {

        IProductoService ProductoService = Framework.Common.ServiceFactory.Get<IProductoService>();

        public IList<Producto> ListarAPI()
        {
            //var response = HttpGet<ListarTodosProductoResponse>("api/Producto/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
            //return response.Result;
            return ProductoService.ListarTodos();
        }

        public Producto AgregarAPI(Producto Producto)
        {

            //AgregarProductoResponse dto = new AgregarProductoResponse();
            //dto.Result = Producto;
            //var request = HttpPost("api/Producto/Agregar", dto, MediaType.Json);
            //return request.Result;

            return ProductoService.Create(Producto);
        }

        public bool Edit(Producto Producto)
        {
            return ProductoService.Edit(Producto);
        }

        public Producto GetByID(int ID)
        {
            return ProductoService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return ProductoService.Delete(ID);
        }
    }
}

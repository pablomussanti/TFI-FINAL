using Decopack.Services.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Decopack.BLL;
using System.Net.Http;
using System.Net;

namespace Decopack.Services.Http
{
    [RoutePrefix("api/Producto")]
    public class ProductoServiceHTTP : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public AgregarProductoResponse Agregar(AgregarProductoResponse dto)
        {
            try
            {

                var bc = new ProductoBLL();
                dto.Result = bc.Create(dto.Result);
                return dto;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422, // UNPROCESSABLE ENTITY
                    ReasonPhrase = ex.Message
                };
                dto.Message = ex.Message;
                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("ListarTodos")]
        public ListarTodosProductoResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosProductoResponse();
                var bc = new ProductoBLL();
                response.Result = bc.ListarTodos();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422, // UNPROCESSABLE ENTITY
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }
    }
}

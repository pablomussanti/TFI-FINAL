using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.EE;
using Decopack.Process;
using Decopack.Servicios;
using Decopack.Servicios.Bitacora;

namespace Decopack.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProductoCCController : Controller
    {
        // GET: Admin/AdminProductoCC
        public ActionResult Index()
        {
            try
            {
                var productoccP = new ProductoCCProcess();
                var lista = productoccP.Listar();
                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla ProductoCC", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

    }
}

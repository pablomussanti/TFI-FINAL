using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.Process;
using Decopack.Servicios.Bitacora;

namespace Decopack.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBitacoraController : Controller
    {
        // GET: Admin/AdminBitacora
        public ActionResult Index()
        {
            try
            {
                //BitacoraProcess
                BitacoraProcess BitacoraProcess = new BitacoraProcess();

                return View(BitacoraProcess.ListarTodos());
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Bitacora", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }


    }
}

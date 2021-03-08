using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.EE;
using Decopack.Process;
using Decopack.Servicios.Bitacora;

namespace Decopack.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "GerenteSucursal")]
    public class AdminVentaController : Controller
    {
        // GET: Admin/AdminVenta
        public ActionResult Index()
        {
            try
            {
                var ventasP = new VentaProcess();
                var lista = ventasP.Listar();
                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Venta", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
                
            }
            
        }

       
    }
}

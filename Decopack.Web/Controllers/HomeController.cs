using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Decopack.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Alert = ViewBag.alerta;
            return View();
        }
        public ActionResult IndexNoti(Boolean operacion)
        {
            if (operacion == true)
            {
                ViewBag.Alert = "La operacion se realizo con exito";
            }
            else
            {
                ViewBag.Alert = "La operacion no se pudo realizar";
            }

            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Ayuda()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
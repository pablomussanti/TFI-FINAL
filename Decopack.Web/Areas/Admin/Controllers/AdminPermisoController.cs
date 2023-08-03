using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.Servicios;
using Decopack.Process;
using Decopack.Servicios.Bitacora;

namespace Decopack.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPermisoController : Controller
    {
        int contador = 0;
        // GET: Admin/AdminPermiso
        public ActionResult Index()
        {
            try
            {
                var permisop = new PermisoProcess();
                var lista = permisop.Listar();
                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Permiso", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        // GET: Admin/AdminPermiso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPermiso/Create
        [HttpPost]
        public ActionResult Create(Permiso permiso)
        {
            try
            {
                var permisop = new PermisoProcess();
                permiso.Tipo = "Permiso";

                foreach (var item in permisop.Listar())
                {
                    if (contador == 0)
                    {
                        permiso.RoleId = string.Format("{0}", item.Id + 1);
                        contador = 1;
                    }
                }
                if (contador == 0)
                {
                    permiso.Id = 1;
                }
                contador = 0;

                permisop.Crear(permiso);

                Bitacora bitacora = new Bitacora("Crear", "Tabla Permiso", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Permiso", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {

                var permisop = new PermisoProcess();
                var permiso = new Permiso();
                permiso.Id = id;
                permisop.Eliminar(permiso);

                Bitacora bitacora = new Bitacora("Eliminar", "Tabla Permiso", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Permiso", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }
    }
}

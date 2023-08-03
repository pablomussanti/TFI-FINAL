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
    public class AdminPermisoUsuarioController : Controller
    {
        // GET: Admin/AdminPermisoUsuario
        public ActionResult Index()
        {
            try
            {
                var usuariopermisop = new PermisoUsuarioProcess();
                var lista = usuariopermisop.Listar();
                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Permiso Usuario", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        // GET: Admin/AdminPermisoUsuario/Create
        public ActionResult Create()
        {
            try
            {
                var usuariop = new UsuarioProcess();
                var usuario = usuariop.Listar();
                var permisop = new PermisoProcess();
                var permiso = permisop.Listar();

                ViewBag.RoleId = new SelectList(permiso, "RoleId", "Nombre");
                ViewBag.UserId = new SelectList(usuario, "Identificador", "UserName");
                return View();
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Permiso Usuario", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        // POST: Admin/AdminPermisoUsuario/Create
        [HttpPost]
        public ActionResult Create(Permisousuario Permisousuario)
        {
            try
            {
                var Permisousuariop = new PermisoUsuarioProcess();
                Permisousuariop.Crear(Permisousuario);

                Bitacora bitacora = new Bitacora("Crear", "Tabla Permiso Usuario", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Permiso Usuario", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: Admin/AdminPermisoUsuario/Edit/5
        public ActionResult Eliminar(string userid, string roleid)
        {
            try
            {
                var Permisousuariop = new PermisoUsuarioProcess();
                var permisousuario = new Permisousuario();
                permisousuario.UserId = userid;
                permisousuario.RoleId = roleid;
                Permisousuariop.Eliminar(permisousuario);

                Bitacora bitacora = new Bitacora("Eliminar", "Tabla Permiso Usuario", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Permiso Usuario", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        
    }
}

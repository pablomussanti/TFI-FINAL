using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.Process;
using Decopack.EE;
using Decopack.Servicios;
using Decopack.Servicios.Bitacora;

namespace Decopack.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUsuarioController : Controller
    {

        // GET: Admin/AdminUsuario
        public ActionResult Index()
        {
            try
            {
                var usuario = new UsuarioProcess();
                var lista = usuario.Listar();
                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Usuario", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }


        // GET: Admin/AdminUsuario/Edit/5
        public ActionResult AsignarComprador(string id)
        {
            try
            {
                var compradorP = new CompradorProcess();
                var lista = compradorP.Listar();
                var usuario = new UsuarioProcess();
                var user = new Usuario();
                foreach (var item in usuario.Listar())
                {
                    if (item.Identificador == id)
                    {
                        user = item;
                    }
                }

                ViewBag.Codcomprador = new SelectList(lista, "Id", "Nombre");
                ViewBag.codigo = user.Identificador;

                return View(user);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Asignar Comprador Tabla Usuario", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        // POST: Admin/AdminUsuario/Edit/5
        [HttpPost]
        public ActionResult AsignarComprador(Usuario usuario, string codigo)
        {
            try
            {
                usuario.Identificador = codigo;
                var usuarioP = new UsuarioProcess();
                usuarioP.AsignarComprador(usuario);

                Bitacora bitacora = new Bitacora("Asignar Comprador", "Tabla Usuario", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Asignar Comprador Tabla Usuario", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        public ActionResult AsignarEmpleado(string id)
        {
            try
            {
                var empleadoP = new EmpleadoProcess();
                var lista = empleadoP.Listar();
                var usuario = new UsuarioProcess();
                var user = new Usuario();
                foreach (var item in usuario.Listar())
                {
                    if (item.Identificador == id)
                    {
                        user = item;
                    }
                }

                ViewBag.codempleado = new SelectList(lista, "Id", "Nombre");
                ViewBag.codigo = user.Identificador;

                return View(user);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Asignar Empleado Tabla Usuario", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        // POST: Admin/AdminUsuario/Edit/5
        [HttpPost]
        public ActionResult AsignarEmpleado(Usuario usuario, string codigo)
        {
            try
            {
                usuario.Identificador = codigo;
                var usuarioP = new UsuarioProcess();
                usuarioP.AsignarEmpleado(usuario);

                Bitacora bitacora = new Bitacora("Asignar Empleado", "Tabla Usuario", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Asignar Empleado Tabla Usuario", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        
        public ActionResult EliminarUsuario(string id)
        {
            try
            {
                var usuario = new UsuarioProcess();
                var user = new Usuario();

                foreach (var item in usuario.Listar())
                {
                    if (item.Identificador == id)
                    {
                        user = item;
                    }
                }

                usuario.EliminarUsuario(user);

                Bitacora bitacora = new Bitacora("Eliminar Usuario", "Tabla Usuario", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return View();
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Usuario", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        public ActionResult Desbloquear(string id)
        {
            try
            {
                var usuario = new UsuarioProcess();
                var user = new Usuario();

                foreach (var item in usuario.Listar())
                {
                    if (item.Identificador == id)
                    {
                        user = item;
                    }
                }
                user.LockoutEndDateUtc = DateTime.Now;

                usuario.Desbloquear(user);

                Bitacora bitacora = new Bitacora("Desbloquear", "Tabla Usuario", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Desbloquear Tabla Usuario", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            

        }




    }
}

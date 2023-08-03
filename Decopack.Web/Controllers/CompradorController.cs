using Decopack.EE;
using Decopack.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.Servicios;
using Decopack.Servicios.Bitacora;

namespace Decopack.Web.Controllers
{
    [Authorize]
    public class CompradorController : Controller
    {
        // GET: Comprador
        [Authorize(Roles = "EmpleadoSucursal")]
        public ActionResult Index()
        {
            try
            {
                var biz = new CompradorProcess();
                var Comprador = new List<Comprador>();
                foreach (var item in biz.Listar())
                {
                    if (item.Estado == "Activo")
                    {
                        Comprador.Add(item);
                    }
                }
                return View(Comprador);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
           
        }

        [Authorize(Roles = "EmpleadoSucursal")]
        // GET: Comprador/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "EmpleadoSucursal")]
        // POST: Comprador/Create
        [HttpPost]
        public ActionResult Create(Comprador Comprador)
        {
            try
            {
                var biz = new CompradorProcess();
                Comprador.Estado = "Activo";
                Comprador.SocioEstado = "No";
                biz.Crear(Comprador);

                Bitacora bitacora = new Bitacora("Crear", "Tabla Comprador", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);


                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: Comprador/Edit/5
        [Authorize(Roles = "EmpleadoSucursal")]
        public ActionResult Edit(int id)
        {
            try
            {
                var biz = new CompradorProcess();
                var Comprador = biz.GetByID(id);
                return View(Comprador);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        // POST: Comprador/Edit/5
        [HttpPost]
        [Authorize(Roles = "EmpleadoSucursal")]
        public ActionResult Edit(Comprador Comprador)
        {
            try
            {
                var biz = new CompradorProcess();
                foreach (var item in biz.Listar())
                {
                    if (item.Id == Comprador.Id)
                    {
                        Comprador.Estado = item.Estado;
                        Comprador.SocioEstado = item.SocioEstado;
                    }
                }

                biz.Editar(Comprador);

                Bitacora bitacora = new Bitacora("Editar", "Tabla Comprador", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);


                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: Comprador/Delete/5
        [Authorize(Roles = "EmpleadoSucursal")]
        public ActionResult Delete(int id)
        {
            try
            {
                var biz = new CompradorProcess();
                var Comprador = biz.GetByID(id);

                

                return View(Comprador);

            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // POST: Comprador/Delete/5
        [HttpPost]
        [Authorize(Roles = "EmpleadoSucursal")]
        public ActionResult Delete(Comprador Comprador)
        {
            try
            {
                var biz = new CompradorProcess();
                var Compradors = biz.GetByID(Comprador.Id);
                Compradors.Estado = "Baja";
                biz.Editar(Compradors);
                Bitacora bitacora = new Bitacora("Eliminar", "Tabla Comprador", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        [Authorize(Roles = "EmpleadoSucursal")]
        public ActionResult IndexBaja()
        {
            try
            {
                var biz = new CompradorProcess();
                var Comprador = new List<Comprador>();
                foreach (var item in biz.Listar())
                {
                    if (item.Estado == "Baja")
                    {
                        Comprador.Add(item);
                    }
                }
                return View(Comprador);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
           
        }

        [Authorize(Roles = "EmpleadoSucursal")]
        public ActionResult Habilitar(int id)
        {
            try
            {
                var biz = new CompradorProcess();
                var Comprador = biz.GetByID(id);
                Comprador.Estado = "Activo";
                biz.Editar(Comprador);

                Bitacora bitacora = new Bitacora("Habilitar", "Tabla Comprador", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Habilitar Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        [Authorize(Roles = "EmpleadoSucursal")]
        public ActionResult AltaSocio(int id)
        {
            try
            {
                var biz = new CompradorProcess();
                var Comprador = biz.GetByID(id);
                Comprador.SocioEstado = "Si";
                biz.Editar(Comprador);
                Bitacora bitacora = new Bitacora("Alta Socio", "Tabla Comprador", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Alta Socio Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        [Authorize(Roles = "EmpleadoSucursal")]
        public ActionResult BajaSocio(int id)
        {
            try
            {
                var biz = new CompradorProcess();
                var Comprador = biz.GetByID(id);
                Comprador.SocioEstado = "No";
                biz.Editar(Comprador);

                Bitacora bitacora = new Bitacora("Baja Socio", "Tabla Comprador", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Baja Socio Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }


         public ActionResult CrearCompradorUsuario(string id)
         {
            try
            {
               ViewBag.codigousuario = id;

               return View();
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("CrearCompradorUsuario Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
         }

        [HttpPost]
        public ActionResult CrearCompradorUsuario(Comprador Comprador, string codigo)
        {
            try
            {
                var biz = new CompradorProcess();
                var usuariop = new UsuarioProcess();
                Comprador.Estado = "Activo";
                Comprador.SocioEstado = "No";
 
                Usuario usuar = new Usuario();
                usuar.Identificador = codigo;
                biz.Crear(Comprador);

                foreach (var item in biz.Listar())
                {
                    if (Comprador.Dni == item.Dni)
                    {
                        Comprador = item;
                    }
                }
                usuar.CodComprador = Comprador.Id;

                usuariop.AsignarComprador(usuar);

                Bitacora bitacora = new Bitacora("Crear CompradorUsuario", "Tabla Comprador", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index","Home");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("CrearCompradorUsuario Tabla Comprador", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }


    }
}

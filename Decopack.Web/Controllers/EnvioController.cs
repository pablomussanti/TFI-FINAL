using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.EE;
using Decopack.Process;
using Decopack.Servicios;
using Decopack.Servicios.Bitacora;

namespace Decopack.Web.Controllers
{
    [Authorize]
    public class EnvioController : Controller
    {
        // GET: Envio
        [Authorize(Roles = "EncargadoDeposito")]
        
        public ActionResult Index()
        {
            try
            {
                var envioP = new EnvioProcess();

                var lista = new List<Envio>();
                var listadeenvios = envioP.Listar();

                foreach (var item in listadeenvios)
                {
                    if (item.EmpleadoDeposito == null)
                    {
                        var empleado = new Empleado();
                        empleado.Nombre = "Sin Asignar";
                        item.EmpleadoDeposito = empleado;

                    }
                    lista.Add(item);
                }

                ViewBag.nombreusuario = "a";
                var usuariop = new UsuarioProcess();
                var listausuario = usuariop.Listar();

                foreach (var item in listausuario)
                {
                    if (item.UserName == User.Identity.Name)
                    {
                        ViewBag.nombreusuario = item.CodEmpleado;
                    }
                }

                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Envio", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }



        // GET: Envio/Edit/5
        [Authorize(Roles = "EncargadoDeposito")]
        public ActionResult Asignar(int id)
        {
            try
            {
                var enviop = new EnvioProcess();
                var empleadoP = new EmpleadoProcess();
                var listaempleados = new List<Empleado>();
                var listadodeempleado = empleadoP.Listar();

                foreach (var item in listadodeempleado)
                {
                    if (item.Estado == "Activo")
                    {
                        listaempleados.Add(item);
                    }
                }

                ViewBag.CodEmpleadoDeposito = new SelectList(listaempleados, "Id", "Nombre"); ;
                var listado = enviop.GetByID(id);
                ViewBag.codigo = id;
                return View(listado);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Asignar Tabla Envio", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        // POST: Envio/Edit/5
        [HttpPost]
        [Authorize(Roles = "EncargadoDeposito")]
        public ActionResult Asignar(Envio Envio)
        {
            try
            {
                var enviop = new EnvioProcess();
                var empleadoP = new EmpleadoProcess();
                var envio = enviop.GetByID(Envio.Id);
                envio.CodEmpleadoDeposito = Envio.CodEmpleadoDeposito;
                envio.Estado = "Asignado";
                enviop.Edit(envio);

                Bitacora bitacora = new Bitacora("Asignar", "Tabla Envio", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                TempData["Message"] = Recursos.Recurso.envio1;

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Asignar Tabla Envio", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }



        public ActionResult Confirmar(int id)
        {
            try
            {
                var enviop = new EnvioProcess();
                var envio = enviop.GetByID(id);
                envio.Estado = "Confirmado";

                enviop.Edit(envio);

                Bitacora bitacora = new Bitacora("Confirmar", "Tabla Envio", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                TempData["Message"] = Recursos.Recurso.envio2;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Confirmar Tabla Envio", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        [Authorize(Roles = "EmpleadoEntrega")]
        public ActionResult IndexEmpleado()
        {
            try
            {
                var envioP = new EnvioProcess();
                var usuarioP = new UsuarioProcess();
                var usuario = new Usuario();
                var lista = new List<Envio>();
                var listadeusuarios = usuarioP.Listar();
                var listadeenvios = envioP.Listar();

                ViewBag.nombreusuario = "a";
                foreach (var item in listadeusuarios)
                {
                    if (User.Identity.Name == item.UserName)
                    {
                        usuario = item;
                        ViewBag.nombreusuario = item.CodEmpleado;
                    }
                }

                foreach (var item in listadeenvios)
                {
                    if (item.CodEmpleadoDeposito == usuario.CodEmpleado)
                    {
                        lista.Add(item);
                    }
                }

                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Envio", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        
        public ActionResult VerEstadoEnvio()
        {
            try
            {
                var envioP = new EnvioProcess();
                var usuarioP = new UsuarioProcess();
                var usuario = new Usuario();
                var lista = new List<Envio>();
                var listadeusuario = usuarioP.Listar();
                var listadeenvio = envioP.Listar();

                foreach (var item in listadeusuario)
                {
                    if (User.Identity.Name == item.UserName)
                    {
                        usuario = item;
                    }
                }

                foreach (var item in listadeenvio)
                {
                    if (item.Venta.Pedido.CodComprador == usuario.CodComprador)
                    {
                        lista.Add(item);
                    }
                }
                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("ver estado envio Tabla Envio", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        [Authorize(Roles = "EmpleadoEntrega")]
        public ActionResult ConfirmarEmpleado(int id)
        {
            try
            {
                var enviop = new EnvioProcess();
                var envio = enviop.GetByID(id);
                envio.Estado = "Confirmado";

                enviop.Edit(envio);

                Bitacora bitacora = new Bitacora("Confirmar", "Tabla Envio", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                TempData["Message"] = Recursos.Recurso.envio2;

                return RedirectToAction("IndexEmpleado");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Confirmar Tabla Envio", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.Process;
using Decopack.EE;
using Decopack.Servicios;
using Decopack.Servicios.Bitacora;

namespace Decopack.Web.Controllers
{
    
    [Authorize(Roles = "EncargadoDeposito")]
    public class EmpleadoController : Controller
    {
        // GET: Empleado

        public ActionResult Index()
        {
            try
            {
                var empleadoP = new EmpleadoProcess();
                var lista = new List<Empleado>();
                foreach (var item in empleadoP.Listar())
                {
                    if (item.Estado == "Activo")
                    {
                        lista.Add(item);
                    }
                }

                return View(lista);

            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Empleado", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }


        // GET: Empleado/Create
        public ActionResult Create()
        {
            try
            {
                var depositoP = new DepositoProcess();
                var deposito = depositoP.Listar();
                ViewBag.coddeposito = new SelectList(deposito, "Id", "Detalle");
                return View();
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Empleado", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // POST: Empleado/Create
        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            try
            {
                var empleadoP = new EmpleadoProcess();
                var empleadoget = empleadoP.GetByID(empleado.Id);
                var depositop = new DepositoProcess();
                var lstdeposito = depositop.Listar();

                foreach (var item in lstdeposito)
                {
                    empleado.CodDeposito = item.Id;
                }
                empleado.Fechadeingreso = DateTime.Now;
                empleado.Estado = "Activo";
                empleadoP.Crear(empleado);

                Bitacora bitacora = new Bitacora("Crear", "Tabla Empleado", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Empleado", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var empleadoP = new EmpleadoProcess();
                var lista = empleadoP.GetByID(id);
                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Empleado", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
           
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {
            try
            {
                var empleadoP = new EmpleadoProcess();
                var depositoP = new DepositoProcess();

                foreach (var item in empleadoP.Listar())
                {
                    if (empleado.Id == item.Id)
                    {
                        empleado.Fechadeingreso = item.Fechadeingreso;
                        empleado.Estado = item.Estado;
                        empleado.CodDeposito = item.CodDeposito;
                    }
                }

                foreach (var item in depositoP.Listar())
                {
                    empleado.CodDeposito = item.Id;
                }


                empleadoP.Edit(empleado);

                Bitacora bitacora = new Bitacora("Editar", "Tabla Empleado", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);


                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Empleado", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var empleadoP = new EmpleadoProcess();
                var lista = empleadoP.GetByID(id);
                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Empleado", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        // POST: Empleado/Delete/5
        [HttpPost]
        public ActionResult Delete(Empleado empleado)
        {
            try
            {

                var empleadoP = new EmpleadoProcess();
                empleado = empleadoP.GetByID(empleado.Id);
                empleado.Estado = "Baja";
                empleadoP.Edit(empleado);

                Bitacora bitacora = new Bitacora("Eliminar", "Tabla Empleado", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Empleado", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        public ActionResult CrearEmpleadoUsuario(string id)
        {
            try
            {
                var depositoP = new DepositoProcess();
                var deposito = depositoP.Listar();
                ViewBag.Coddeposito = new SelectList(deposito, "Id", "Detalle");
                ViewBag.codusuario = id;
                return View();
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crearempleadousuario Tabla Empleado", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        // POST: Empleado/Delete/5
        [HttpPost]
        public ActionResult CrearEmpleadoUsuario(Empleado empleado, string codusuario)
        {
            try
            {
                var empleadoP = new EmpleadoProcess();
                var usuarioP = new UsuarioProcess();
                var usuario = new Usuario();

                empleado.Fechadeingreso = DateTime.Now;
                empleado.Estado = "Activo";
                //empleadoP.Crear(empleado);

                foreach (var item in usuarioP.Listar())
                {
                    if (item.UserName == User.Identity.Name)
                    {
                        usuario = item;
                    }
                }

                usuario.CodEmpleado = empleadoP.Crear(empleado).Id;

                usuarioP.AsignarEmpleado(usuario);

                Bitacora bitacora = new Bitacora("Crear EmpleadoUsuario", "Tabla Empleado", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index","Home");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crearempleadousuario Tabla Empleado", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

    }
}

using Decopack.EE;
using Decopack.Process;
using Decopack.Servicios.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Decopack.Web.Controllers
{
    
    [Authorize(Roles = "EncargadoDeposito")]
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            try
            {
                var biz = new ProveedorProcess();
                var Proveedor = new List<Proveedor>();
                foreach (var item in biz.Listar())
                {
                    if (item.Estado == "Activo")
                    {
                        Proveedor.Add(item);
                    }
                }
                return View(Proveedor);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
           
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        public ActionResult Create(Proveedor Proveedor)
        {
            try
            {
                // TODO: Add insert logic here
                var biz = new ProveedorProcess();
                Proveedor.Cantidaddeerrores = 0;
                Proveedor.Estado = "Activo";
                biz.Crear(Proveedor);

                Bitacora bitacora = new Bitacora("Crear", "Tabla Proveedor", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var biz = new ProveedorProcess();
                var Proveedor = biz.GetByID(id);
                return View(Proveedor);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        // POST: Proveedor/Edit/5
        [HttpPost]
        public ActionResult Edit(Proveedor proveedor)
        {
            try
            {
                var biz = new ProveedorProcess();
                proveedor.Estado = "Activo";
                biz.Edit(proveedor);

                Bitacora bitacora = new Bitacora("Editar", "Tabla Proveedor", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var biz = new ProveedorProcess();
                var Proveedor = biz.GetByID(id);
                return View(Proveedor);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        // POST: Proveedor/Delete/5
        [HttpPost]
        public ActionResult Delete(Proveedor proveedor)
        {
            try
            {
                var biz = new ProveedorProcess();
                var prov = biz.GetByID(proveedor.Id);
                prov.Estado = "Baja";
                biz.Edit(prov);

                Bitacora bitacora = new Bitacora("Eliminar", "Tabla Proveedor", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }
    }
}

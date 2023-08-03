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
    public class MateriaPrimaProveedorController : Controller
    {
        // GET: MateriaPrimaProveedor
        public ActionResult Index()
        {
            try
            {
                var materiaprimaproveedor = new MateriaPrimaProveedorProcess();
                var lista = materiaprimaproveedor.Listar();
                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Materia Prima Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        // GET: MateriaPrimaProveedor/Create
        public ActionResult Create(int id)
        {
            try
            {
                var materiaprimaP = new MateriaPrimaProcess();
                var listamateriaprima = new List<MateriaPrima>();
                listamateriaprima.Add(materiaprimaP.GetByID(id));

                var proveedorP = new ProveedorProcess();
                var proveedorlista = new List<Proveedor>();

                foreach (var item in proveedorP.Listar())
                {
                    if (item.Estado == "Activo")
                    {
                        proveedorlista.Add(item);
                    }
                }

                var materiaprimaproveedor = new MateriaPrimaProveedorProcess();
                foreach (var itemP in proveedorP.Listar())
                {
                    foreach (var item in materiaprimaproveedor.Listarpormateriaprima(id))
                    {
                        if (item.CodMateriaPrima == id)
                        {

                            if (itemP.Id == item.CodProveedor)
                            {

                                proveedorlista.RemoveAll(x => x.Id == itemP.Id);

                            }
                            else
                            {


                            }
                        }
                    }
                }

                ViewBag.Codproveedor = new SelectList(proveedorlista, "Id", "Nombre");
                ViewBag.Codmateriaprima = new SelectList(listamateriaprima, "Id", "Nombre");
                return View();
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Materia Prima Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        // POST: MateriaPrimaProveedor/Create
        [HttpPost]
        public ActionResult Create(MateriaPrimaProveedor MateriaPrimaProveedor)
        {
            try
            {
                var materiaprimaproveedor = new MateriaPrimaProveedorProcess();

                materiaprimaproveedor.Crear(MateriaPrimaProveedor);

                Bitacora bitacora = new Bitacora("Crear", "Tabla Materia Prima Proveedor", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index","MateriaPrima");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Materia Prima Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: MateriaPrimaProveedor/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var materiaprimaproveedor = new MateriaPrimaProveedorProcess();
                var MP = materiaprimaproveedor.GetByID(id);
                return View(MP);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Materia Prima Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

           
        }

        // POST: MateriaPrimaProveedor/Edit/5
        [HttpPost]
        public ActionResult Edit(MateriaPrimaProveedor materiaprimaproveedor)
        {
            try
            {
                var materiaprimaproveedorP = new MateriaPrimaProveedorProcess();
                var MP = materiaprimaproveedorP.GetByID(materiaprimaproveedor.Id);
                MP.Precio = materiaprimaproveedor.Precio;
                materiaprimaproveedorP.Edit(MP);

                Bitacora bitacora = new Bitacora("Editar", "Tabla Materia Prima Proveedor", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Materia Prima Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: MateriaPrimaProveedor/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var materiaprimaproveedorP = new MateriaPrimaProveedorProcess();
                var MP = materiaprimaproveedorP.Delete(id);

                Bitacora bitacora = new Bitacora("Eliminar", "Tabla Materia Prima Proveedor", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Materia Prima Proveedor", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.Process;
using Decopack.EE;
using Decopack.Servicios.Bitacora;

namespace Decopack.Web.Controllers
{
    
    [Authorize(Roles = "EncargadoDeposito")]
    public class MateriaPrimaProductoController : Controller
    {
        // GET: MateriaPrimaProducto
        public ActionResult Index()
        {
            try
            {
                var materiaprimaproductoP = new MateriaPrimaProductoProcess();
                var materiaprimaproducto = materiaprimaproductoP.Listar();
                return View(materiaprimaproducto);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Materia Prima Producto", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }


        // GET: MateriaPrimaProducto/Create
        public ActionResult Create(int id)
        {
            try
            {
                var materiaprimaP = new MateriaPrimaProcess();
                var listamateriaprima = new List<MateriaPrima>();
                listamateriaprima.Add(materiaprimaP.GetByID(id));

                var productoP = new ProductoProcess();
                var productolista = new List<Producto>();
                foreach (var item in productoP.ListarAPI())
                {
                    productolista.Add(item);
                }



                var materiaprimaproductoP = new MateriaPrimaProductoProcess();

                foreach (var itemP in productoP.ListarAPI())
                {
                    foreach (var item in materiaprimaproductoP.Listar())
                    {
                        if (item.CodMateriaPrima == id)
                        {

                            if (itemP.Id == item.CodProducto)
                            {

                                productolista.RemoveAll(x => x.Id == itemP.Id);

                            }
                            else
                            {


                            }
                        }

                    }
                }


                ViewBag.Codproducto = new SelectList(productolista, "Id", "Nombre");
                ViewBag.Codmateriaprima = new SelectList(listamateriaprima, "Id", "Nombre");

                return View();
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Materia Prima Producto", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        // POST: MateriaPrimaProducto/Create
        [HttpPost]
        public ActionResult Create(MateriaPrimaProducto materiaprimaproducto)
        {
            try
            {
                var materiaprimaproductoP = new MateriaPrimaProductoProcess();

                materiaprimaproductoP.Crear(materiaprimaproducto);

                Bitacora bitacora = new Bitacora("Crear", "Tabla Materia Prima Producto", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index","MateriaPrima");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Materia Prima Producto", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: MateriaPrimaProducto/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var biz = new MateriaPrimaProductoProcess();
                var MP = biz.GetByID(id);
                return View(MP);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Materia Prima Producto", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        // POST: MateriaPrimaProducto/Edit/5
        [HttpPost]
        public ActionResult Edit(MateriaPrimaProducto materiaPrimaProducto)
        {
            try
            {
                var biz = new MateriaPrimaProductoProcess();
                var MP = biz.GetByID(materiaPrimaProducto.Id);
                MP.Cantidad = materiaPrimaProducto.Cantidad;
                biz.Editar(MP);

                Bitacora bitacora = new Bitacora("Editar", "Tabla Materia Prima Producto", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Materia Prima Producto", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: MateriaPrimaProducto/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var biz = new MateriaPrimaProductoProcess();
                biz.Eliminar(id);

                Bitacora bitacora = new Bitacora("Eliminar", "Tabla Materia Prima Producto", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Materia Prima Producto", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

    }
}

using Decopack.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.EE;
using Decopack.Servicios.Bitacora;

namespace Decopack.Web.Controllers
{
    
    [Authorize(Roles = "EncargadoDeposito")]
    public class ReposicionController : Controller
    {
        // GET: Reposicion
        public ActionResult Index()
        {
            try
            {
                var biz = new ReposicionProcess();
                var Reposicion = biz.Listar();
                return View(Reposicion);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Reposicion", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }


        // GET: Reposicion/Create
        public ActionResult Create(int id)
        {
            try
            {
                var materiaprimaP = new MateriaPrimaProcess();
                var mat = new List<MateriaPrima>();
                mat.Add(materiaprimaP.GetByID(id));

                var ProveedorP = new ProveedorProcess();
                var proveedorlista = new List<Proveedor>();


                var ProveedormateriaprimaP = new MateriaPrimaProveedorProcess();
                var listaproveedorpormateriaprima = ProveedormateriaprimaP.Listarpormateriaprima(id);

                foreach (var item in listaproveedorpormateriaprima)
                {
                    proveedorlista.Add(ProveedorP.GetByID(item.CodProveedor));
                }

                var depositoP = new DepositoProcess();
                var depositolistado = depositoP.Listar();

                ViewBag.Codmateriaprima = new SelectList(mat, "Id", "Nombre");
                ViewBag.Codproveedor = new SelectList(proveedorlista, "Id", "Nombre");
                ViewBag.Coddeposito = new SelectList(depositolistado, "Id", "Detalle");

                return View();
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Reposicion", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        // POST: Reposicion/Create
        [HttpPost]
        public ActionResult Create(Reposicion reposicion)
        {
            try
            {
                var biz = new ReposicionProcess();
                reposicion.Estado = "Pendiente";
                reposicion.Fecha = DateTime.Now;
                var materiaprimaproducto = new MateriaPrimaProductoProcess();
                var materiaprimaProveedor = new MateriaPrimaProveedorProcess();
                double valor1 = 0;
                var listamateriaprimaproveedor = materiaprimaProveedor.Listar();

                foreach (var itemPROV in listamateriaprimaproveedor)
                {
                    if (itemPROV.CodMateriaPrima == reposicion.CodMateriaPrima && itemPROV.CodProveedor == reposicion.CodProveedor)
                    {
                        valor1 = itemPROV.Precio;
                    }
                }


                reposicion.Monto = valor1 * reposicion.Cantidad;
                biz.Crear(reposicion);

                TempData["Message"] = Recursos.Recurso.reposicion1;

                Bitacora bitacora = new Bitacora("Crear", "Tabla Reposicion", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);


                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {

                Bitacora bitacora = new Bitacora("Crear Tabla Reposicion", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }


        // GET: Reposicion/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var biz = new ReposicionProcess();
                var Reposicion = biz.GetByID(id);
                return View(Reposicion);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Reposicion", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        // POST: Reposicion/Delete/5
        [HttpPost]
        public ActionResult Delete(Reposicion Reposicion)
        {
            try
            {
                var biz = new ReposicionProcess();
                var repo = biz.GetByID(Reposicion.Id);
                
                if (repo.Estado != "Confirmado")
                {
                    repo.Estado = "Cancelado";
                    biz.Edit(repo);

                    TempData["Message"] = Recursos.Recurso.reposicion2;

                    Bitacora bitacora = new Bitacora("Cancelar", "Tabla Reposicion", User.Identity.Name, DateTime.Now);
                    BitacoraProcess bitacorap = new BitacoraProcess();
                    bitacorap.Create(bitacora);

                }
                else
                {
                    ViewBag.advertencia = true;
                    return RedirectToAction("Index");
                }
                


                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Reposicion", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        public ActionResult Confirmar(int id)
        {
            try
            {
                var biz = new ReposicionProcess();
                var Reposicion = biz.GetByID(id);
                Reposicion.Estado = "Confirmado";
                biz.Edit(Reposicion);

                int verificador = 0;

                var stockmateriaprimaP = new StockMateriaPrimaDepositoProcess();
                var stockmateriaprima = new StockMateriaPrimaDeposito();
                var listastock = stockmateriaprimaP.Listar();

                foreach (var item in listastock)
                {
                    if (item.CodMateriaPrima == Reposicion.CodMateriaPrima)
                    {
                        item.Cantidad = item.Cantidad + Reposicion.Cantidad;
                        stockmateriaprimaP.Edit(item);
                        verificador = 1;

                        Bitacora bitacora = new Bitacora("Confirmar", "Tabla Reposicion", User.Identity.Name, DateTime.Now);
                        BitacoraProcess bitacorap = new BitacoraProcess();
                        bitacorap.Create(bitacora);
                    }

                }
                if (stockmateriaprimaP.Listar().Count() == 0)
                {
                    stockmateriaprima.CodDeposito = Reposicion.CodDeposito;
                    stockmateriaprima.CodMateriaPrima = Reposicion.CodMateriaPrima;
                    stockmateriaprima.Cantidad = Reposicion.Cantidad;
                    stockmateriaprimaP.Crear(stockmateriaprima);

                    Bitacora bitacora = new Bitacora("Confirmar", "Tabla Reposicion", User.Identity.Name, DateTime.Now);
                    BitacoraProcess bitacorap = new BitacoraProcess();
                    bitacorap.Create(bitacora);

                    verificador = 1;
                }

                if (verificador != 1)
                {
                    stockmateriaprima.CodDeposito = Reposicion.CodDeposito;
                    stockmateriaprima.CodMateriaPrima = Reposicion.CodMateriaPrima;
                    stockmateriaprima.Cantidad = Reposicion.Cantidad;
                    stockmateriaprimaP.Crear(stockmateriaprima);

                    Bitacora bitacora = new Bitacora("Confirmar", "Tabla Reposicion", User.Identity.Name, DateTime.Now);
                    BitacoraProcess bitacorap = new BitacoraProcess();
                    bitacorap.Create(bitacora);
                }

                TempData["Message"] = "La Reposicion se Confirmo";


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Confirmar Tabla Reposicion", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        public ActionResult Informar(int id)
        {
            try
            {
                var biz = new ReposicionProcess();
                var Reposicion = biz.GetByID(id);
                Reposicion.Estado = "Confirmado-P";
                biz.Edit(Reposicion);

                var stockmateriaprimaP = new StockMateriaPrimaDepositoProcess();
                var stockmateriaprima = new StockMateriaPrimaDeposito();
                var listastock = stockmateriaprimaP.Listar();
                var proveedorP = new ProveedorProcess();

                Reposicion.Proveedor.Cantidaddeerrores = Reposicion.Proveedor.Cantidaddeerrores + 1;
                proveedorP.Edit(Reposicion.Proveedor);

                foreach (var item in listastock)
                {
                    if (item.CodMateriaPrima == Reposicion.CodMateriaPrima)
                    {

                        item.Cantidad = item.Cantidad + Reposicion.Cantidad;
                        stockmateriaprimaP.Edit(item);
                        Bitacora bitacora = new Bitacora("Informar", "Tabla Reposicion", User.Identity.Name, DateTime.Now);
                        BitacoraProcess bitacorap = new BitacoraProcess();
                        bitacorap.Create(bitacora);
                    }
                }
                if (stockmateriaprimaP.Listar().Count() == 0)
                {
                    stockmateriaprima.CodDeposito = Reposicion.CodDeposito;
                    stockmateriaprima.CodMateriaPrima = Reposicion.CodMateriaPrima;
                    stockmateriaprima.Cantidad = Reposicion.Cantidad;
                    stockmateriaprimaP.Crear(stockmateriaprima);
                    Bitacora bitacora = new Bitacora("Informar", "Tabla Reposicion", User.Identity.Name, DateTime.Now);
                    BitacoraProcess bitacorap = new BitacoraProcess();
                    bitacorap.Create(bitacora);
                }


                TempData["Message"] = Recursos.Recurso.reposicion3;


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Informar Tabla Reposicion", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }
    }
}

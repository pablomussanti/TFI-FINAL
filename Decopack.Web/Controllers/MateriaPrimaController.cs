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
    public class MateriaPrimaController : Controller
    {
        // GET: MateriaPrima
        public ActionResult Index()
        {
            try
            {
                var biz = new MateriaPrimaProcess();
                var materiaprima = biz.Listar();
                return View(materiaprima);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Materia Prima", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: MateriaPrima/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MateriaPrima/Create
        [HttpPost]
        public ActionResult Create(MateriaPrima MateriaPrima)
        {
            try
            {
                var biz = new MateriaPrimaProcess();

                var stockP = new StockMateriaPrimaDepositoProcess();
                var stock = new StockMateriaPrimaDeposito();
                var depositoP = new DepositoProcess();

                stock.Cantidad = 0;
                stock.CodMateriaPrima = biz.Crear(MateriaPrima).Id;

                foreach (var item in depositoP.Listar())
                {
                    stock.CodDeposito = item.Id;
                }
                stockP.Crear(stock);

                Bitacora bitacora = new Bitacora("Crear", "Tabla Materia Prima", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Materia Prima", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: MateriaPrima/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var biz = new MateriaPrimaProcess();
                var materiaprima = biz.GetByID(id);
                return View(materiaprima);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Materia Prima", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        // POST: MateriaPrima/Edit/5
        [HttpPost]
        public ActionResult Edit(MateriaPrima MateriaPrima)
        {
            try
            {
                var biz = new MateriaPrimaProcess();
                biz.Editar(MateriaPrima);
                Bitacora bitacora = new Bitacora("Editar", "Tabla Materia Prima", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Materia Prima", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: MateriaPrima/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var biz = new MateriaPrimaProcess();
                var materiaprima = biz.GetByID(id);
                return View(materiaprima);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Materia Prima", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        // POST: MateriaPrima/Delete/5
        [HttpPost]
        public ActionResult Delete(MateriaPrima MateriaPrima)
        {
            try
            {
                var biz = new MateriaPrimaProcess();
                biz.Eliminar(MateriaPrima.Id);

                Bitacora bitacora = new Bitacora("Eliminar", "Tabla Materia Prima", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Materia Prima", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }
    }
}

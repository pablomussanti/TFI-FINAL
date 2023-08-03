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
    public class StockMateriaPrimaDepositoController : Controller
    {
        // GET: StockMateriaPrimaDeposito
        public ActionResult Index()
        {
            try
            {
                var StockMateriaPrimaDeposito = new StockMateriaPrimaDepositoProcess();
                var lista = StockMateriaPrimaDeposito.Listar();
                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Stock Materia Prima Deposito", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        // GET: StockMateriaPrimaDeposito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockMateriaPrimaDeposito/Create
        [HttpPost]
        public ActionResult Create(StockMateriaPrimaDeposito stockmateriaprimadeposito)
        {
            try
            {

                var biz = new StockMateriaPrimaDepositoProcess();
                biz.Crear(stockmateriaprimadeposito);

                Bitacora bitacora = new Bitacora("Crear", "Tabla Stock Materia Prima Deposito", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Stock Materia Prima Deposito", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: StockMateriaPrimaDeposito/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var StockMateriaPrimaDeposito = new StockMateriaPrimaDepositoProcess();
                var lista = StockMateriaPrimaDeposito.GetByID(id);
                return View(lista);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Stock Materia Prima Deposito", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
           
        }

        // POST: StockMateriaPrimaDeposito/Edit/5
        [HttpPost]
        public ActionResult Edit(StockMateriaPrimaDeposito StockMateriaPrimaDeposito)
        {
            try
            {
                var biz = new StockMateriaPrimaDepositoProcess();
                var lista = biz.GetByID(StockMateriaPrimaDeposito.Id);
                lista.Cantidad = StockMateriaPrimaDeposito.Cantidad;
                biz.Edit(lista);

                Bitacora bitacora = new Bitacora("Editar", "Tabla Stock Materia Prima Deposito", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Stock Materia Prima Deposito", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        
    }
}

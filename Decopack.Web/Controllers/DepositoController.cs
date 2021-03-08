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
    public class DepositoController : Controller
    {
        // GET: Deposito
        [Authorize(Roles = "EncargadoDeposito")]
        public ActionResult Index()
        {
            try
            {
                var biz = new DepositoProcess();
                if (biz.Listar().Count == 0)
                {
                    ViewBag.deposito = true;
                }
                else
                {
                    ViewBag.deposito = false;
                }

                var Deposito = biz.Listar();
                return View(Deposito);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Deposito", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        [Authorize(Roles = "EncargadoDeposito")]
        // GET: Deposito/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "EncargadoDeposito")]
        // POST: Deposito/Create
        [HttpPost]
        public ActionResult Create(Deposito Deposito)
        {
            try
            {
                var biz = new DepositoProcess();
                if (biz.Listar().Count == 0)
                {
                    biz.Crear(Deposito);

                    Bitacora bitacora = new Bitacora("Crear", "Tabla Deposito", User.Identity.Name, DateTime.Now);
                    BitacoraProcess bitacorap = new BitacoraProcess();
                    bitacorap.Create(bitacora);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.advertencia = "Deposito creado";
                    return RedirectToAction("Index");
                }

                
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Deposito", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        [Authorize(Roles = "EncargadoDeposito")]
        // GET: Deposito/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var biz = new DepositoProcess();
                Deposito Deposito = new Deposito();
                foreach (var item in biz.Listar())
                {
                    Deposito = item;
                }
                return View(Deposito);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Deposito", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        [Authorize(Roles = "EncargadoDeposito")]
        // POST: Deposito/Edit/5
        [HttpPost]
        public ActionResult Edit(Deposito deposito)
        {
            try
            {
                var biz = new DepositoProcess();
                biz.Edit(deposito);

                Bitacora bitacora = new Bitacora("Editar", "Tabla Deposito", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Deposito", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

       
    }
}

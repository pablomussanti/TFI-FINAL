using Decopack.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.EE;
using Decopack.Process;
using Decopack.Servicios;

namespace Decopack.Web.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminHomeController : Controller
    {
        

        private ILoggingService _loggingService;
        double totalrecaudado;
        double ganancia;
        int cantidaddeproductos;
        int cantidaddemateriaprima;
        string mayorproducto;
        List<StockMateriaPrimaDeposito> stocktest = new List<StockMateriaPrimaDeposito>();

        public AdminHomeController(ILoggingService loggingService)


            {
                _loggingService = loggingService;
            }

            // GET: Admin/Home
            public ActionResult Index()
            {
            var stockp = new StockMateriaPrimaDepositoProcess();
            var reposicionp = new ReposicionProcess();
            var ventap = new VentaProcess();
            var producto = new Producto();
            var productop = new ProductoProcess();
            var materiaprima = new MateriaPrima();
            var listaventas = ventap.Listar();
            var listareposicion = reposicionp.Listar();
            var listamateriaprima = new List<StockMateriaPrimaDeposito>();
            var listaproducto = new List<MateriaPrimaProducto>();
            var productoMP = new MateriaPrimaProducto();
            var listaauxiliar = new List<MateriaPrimaProducto>();


            foreach (var item in listaventas)
            {

                totalrecaudado = totalrecaudado + item.Monto;
                cantidaddeproductos = cantidaddeproductos + item.Pedido.Cantidad;
                if (listaproducto.Count() == 0)
                {
                    productoMP.Cantidad = item.Pedido.Cantidad;
                    productoMP.CodProducto = item.Pedido.Codproducto;
                   
                    listaproducto.Add(productoMP);

                }
                else
                {
                    int contador = 0;
                    var valor = listaproducto.Count();
                    for (int i = 0; i < valor; i++)
                    {
                        var pd = listaproducto[i];
                        
                        if (pd.CodProducto == item.Pedido.Codproducto)
                        {
                            pd.Cantidad = pd.Cantidad + item.Pedido.Cantidad;
                            contador = 1;
                        }
                       

                    }
                    if (contador == 0)
                    {
                        var nuevoprd = new MateriaPrimaProducto();
                        nuevoprd.Cantidad = item.Pedido.Cantidad;
                        nuevoprd.CodProducto = item.Pedido.Codproducto;
                        listaproducto.Add(nuevoprd);
                        contador = 1;
                    }

                }

                
            }

            foreach (var item in listareposicion)
            {
                ganancia = ganancia + item.Monto;
                cantidaddemateriaprima = cantidaddemateriaprima + item.Cantidad;

                foreach (var itemST in stocktest)
                {
                    if (itemST.CodMateriaPrima == item.CodMateriaPrima)
                    {

                    }
                }
                if (stocktest.Count == 0 )
                {
                    var stk = new StockMateriaPrimaDeposito();
                    stk.CodMateriaPrima = item.CodMateriaPrima;
                    stk.Cantidad = item.Cantidad;
                }


            }
            

            
            foreach (var item in listaproducto)
            {
                if (item.Cantidad == listaproducto.Max(x => x.Cantidad))
                {
                    var prd = productop.GetByID(item.CodProducto);
                    mayorproducto = prd.Nombre;
                }
            }

            ViewBag.productomasvendido = mayorproducto;
            ViewBag.cantidaddemateriaprima = cantidaddemateriaprima;
            ViewBag.cantidaddeproductos = cantidaddeproductos;
            ViewBag.totalgastado = ganancia;
            ViewBag.ganancianeta = totalrecaudado - ganancia;
            ViewBag.totalrecaudado = totalrecaudado;

                _loggingService.Log("message");

                return View();
            }
        }
    }

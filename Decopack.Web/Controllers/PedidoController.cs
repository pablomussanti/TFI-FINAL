using Decopack.EE;
using Decopack.Process;
using Decopack.Servicios.Bitacora;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Decopack.Servicios;



namespace Decopack.Web.Controllers
{
    [Authorize]

    public class PedidoController : Controller
    {
        // GET: Pedido

        static string estadopedido;
        static int idpedido;


        [Authorize(Roles = "EmpleadoSucursal")]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            try
            {

                if (searchString != null)
                    page = 1;
                else
                    searchString = currentFilter;

                ViewBag.CurrentFilter = searchString;

                var ep = new PedidoProcess();


                IEnumerable<Pedido> Pedidos = ep.Listar();

                if (!string.IsNullOrEmpty(searchString))
                    Pedidos = Pedidos.Where(s => s.Comprador.Dni.ToString().Contains(searchString));

                int pageSize = 10;
                int pageNumber = (page ?? 1);

                foreach (var item in Pedidos)
                {
                    if (item.Id == idpedido)
                    {
                        item.Estado = estadopedido;
                    }
                }


                return View(Pedidos.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Pedido", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }



        // GET: Pedido/Create
        public ActionResult Create(int CodProducto)
        {
            try
            {
                var usuarioP = new UsuarioProcess();
                var listausuario = usuarioP.Listar();

                foreach (var item in listausuario)
                {
                    if (item.UserName == User.Identity.Name)
                    {
                        if (item.Comprador == null)
                        {
                            return RedirectToAction("CrearCompradorUsuario", "Comprador", new { id = item.Identificador });
                        }
                    }
                }

                
                ViewBag.codigo = CodProducto;
                return View();
            }
            catch (Exception ex )
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Pedido", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
           
        }

        // POST: Pedido/Create
        [HttpPost]
        public ActionResult Create(Pedido pedido, HttpPostedFileBase imagendelproducto, int codigo)
        {
            try
            {

                if (imagendelproducto != null && imagendelproducto.ContentLength > 0)
                {
                    HttpPostedFileBase fileBase = Request.Files[0];
                    WebImage image = new WebImage(fileBase.InputStream);

                    pedido.Logo = image.GetBytes();

                }

                
                pedido.Estado = "En Espera";
                pedido.Fecha = DateTime.Now;
                pedido.Aprobado = "No";

                var usuariop = new UsuarioProcess();
                var listausuario = usuariop.Listar();
                var productop = new ProductoProcess();
                var listaproducto = productop.ListarAPI();
                var biz = new PedidoProcess();
                var compradorP = new CompradorProcess();

                foreach (var item in listausuario)
                {
                    if (item.UserName == User.Identity.Name)
                    {
                        pedido.CodComprador = item.CodComprador;
                    }
                }

                pedido.Codproducto = codigo;

                

                foreach (var item in listaproducto)
                {
                    if (pedido.Codproducto == item.Id)
                    {
                        pedido.Monto = pedido.Cantidad * item.Precio;
                    }
                }

                
                pedido.Comprador = compradorP.GetByID(pedido.CodComprador);

                
                var model = biz.Crear(pedido);

                Bitacora bitacora = new Bitacora("Crear", "Tabla Pedido", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                

                return RedirectToAction("IndexNoti", "Home", new { operacion = true });
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Pedido", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

    

        public ActionResult IndexUsuario()
        {
            try
            {
                var usuariop = new UsuarioProcess();
                Usuario usuario = new Usuario();
                var pedidoP = new PedidoProcess();
                List<Pedido> Pedidos = new List<Pedido>();
                var listausuarios = usuariop.Listar();
                var listapedidos = pedidoP.Listar();




                foreach (var item in listausuarios)
                {
                    if (item.UserName == User.Identity.Name)
                    {
                        usuario = item;
                    }
                }

                if (usuario.CodComprador == 0)
                {
                    return RedirectToAction("CrearCompradorUsuario", "Comprador", new { id = usuario.Identificador });
                }

                foreach (var itemP in listapedidos)
                {
                    if (itemP.CodComprador == usuario.CodComprador)
                    {
                        Pedidos.Add(itemP);
                    }
                }

                foreach (var item in Pedidos)
                {
                    if (estadopedido != null)
                    {
                        if (item.Id == idpedido)
                        {
                            item.Estado = estadopedido;
                        }
                    }

                }


                estadopedido = null;
                

                return View(Pedidos);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Pedido", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        [Authorize(Roles = "EmpleadoSucursal")]
        public ActionResult Aprobar(int id)
        {
            try
            {
                var usuariop = new UsuarioProcess();
                Usuario usuario = new Usuario();
                var listausuarios = usuariop.Listar();

                foreach (var item in listausuarios)
                {
                    if (item.UserName == User.Identity.Name)
                    {
                        usuario = item;
                    }
                }

                if (usuario.CodEmpleado == 0)
                {
                    return RedirectToAction("CrearEmpleadoUsuario", "Empleado", new { id = usuario.Identificador });
                }

                var pedidoP = new PedidoProcess();
                var ped = pedidoP.GetByID(id);


                return View(ped);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Aprobar Tabla Pedido", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        [Authorize(Roles = "EmpleadoSucursal")]
        [HttpPost]
        public ActionResult Aprobar(Pedido pedido)
        {
            try
            {
                var pedidoP = new PedidoProcess();
                var monto = pedido.Monto;

                pedido = pedidoP.GetByID(pedido.Id);
                pedido.Monto = monto;
                pedido.Aprobado = "Si";
                pedido.Estado = "Pendiente de Pago";
                pedidoP.Editar(pedido);


                Bitacora bitacora = new Bitacora("Aprobar", "Tabla Pedido", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                TempData["Message"] = Recursos.Recurso.pedido1;

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Bitacora bitacora = new Bitacora("Aprobar Tabla Pedido", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        public ActionResult Pagar(int id)
        {
            try
            {
                var pedidoP = new PedidoProcess();
                var ped = pedidoP.GetByID(id);
                int salida = 0;

                var depositoP = new DepositoProcess();
                var deposito = new Deposito();
                var listadeposito = depositoP.Listar();


                foreach (var item in listadeposito)
                {
                    deposito = item;
                }

                ped.Estado = "Pagado";



                var ventaP = new VentaProcess();
                var venta = new Venta();
                var usuariop = new UsuarioProcess();
                Usuario usuario = new Usuario();
                var listausuarios = usuariop.Listar();

                foreach (var item in listausuarios)
                {
                    if (item.UserName == User.Identity.Name)
                    {
                        usuario = item;
                    }
                }

                var materiaprimaprodP = new MateriaPrimaProductoProcess();
                var materiaprima = new List<StockMateriaPrimaDeposito>();
                var listamateriaprimaproductodeposito = materiaprimaprodP.Listar();

                foreach (var item in listamateriaprimaproductodeposito)
                {
                    if (item.CodProducto == ped.Codproducto)
                    {
                        var mt = new StockMateriaPrimaDeposito();
                        mt.Cantidad = item.Cantidad * ped.Cantidad;
                        mt.CodMateriaPrima = item.CodMateriaPrima;
                        materiaprima.Add(mt);

                    }
                }


                var stockP = new StockMateriaPrimaDepositoProcess();
                var reposicionP = new ReposicionProcess();

                var ProveedormateriaprimaP = new MateriaPrimaProveedorProcess();
                Proveedor proveedor = new Proveedor();

                var materiaprimaProveedor = new MateriaPrimaProveedorProcess();


                var listastockmateriaprima = stockP.Listar();

                foreach (var item in listastockmateriaprima)
                {
                    double valor1 = 0;
                    double valor2 = 0;
                    foreach (var itemMP in materiaprima)
                    {
                        if (item.CodMateriaPrima == itemMP.CodMateriaPrima)
                        {
                            if (item.Cantidad < itemMP.Cantidad)
                            {
                                var reposicion = new Reposicion();
                                reposicion.CodMateriaPrima = item.CodMateriaPrima;
                                reposicion.CodDeposito = deposito.Id;
                                reposicion.Fecha = DateTime.Now;
                                reposicion.Cantidad = itemMP.Cantidad - item.Cantidad;
                                reposicion.Estado = "Reposicion Compra";

                                foreach (var itemProveedor in ProveedormateriaprimaP.Listarpormateriaprima(itemMP.CodMateriaPrima))
                                {
                                    if (valor2 == 0)
                                    {
                                        reposicion.Proveedor = itemProveedor.Proveedor;
                                        reposicion.CodProveedor = itemProveedor.Proveedor.Id;
                                        valor2 = 1;
                                    }

                                }

                                foreach (var itemPROV in materiaprimaProveedor.Listarpormateriaprima(itemMP.CodMateriaPrima))
                                {
                                    if (itemPROV.CodMateriaPrima == reposicion.CodMateriaPrima && itemPROV.CodProveedor == reposicion.CodProveedor)
                                    {
                                        valor1 = itemPROV.Precio;


                                    }
                                }
                                reposicion.Monto = valor1 * reposicion.Cantidad;
                                reposicionP.Crear(reposicion);
                                item.Cantidad = 0;
                                stockP.Edit(item);
                                salida = 1;

                            }
                            else
                            {
                                item.Cantidad = item.Cantidad - itemMP.Cantidad;
                                stockP.Edit(item);
                            }

                        }
                    }

                }

                venta.CodEmpleado = usuario.CodEmpleado;
                venta.CodPedido = ped.Id;
                venta.Formadepago = "Efectivo";

                if (venta.Formadepago == "Efectivo" && ped.Comprador.SocioEstado == "Si")
                {
                    venta.Monto = ped.Monto * 0.90;

                }
                else
                {
                    if (venta.Formadepago == "Efectivo")
                    {
                        venta.Monto = ped.Monto * 0.95;
                    }
                    if (ped.Comprador.SocioEstado == "Si")
                    {
                        venta.Monto = ped.Monto * 0.95;
                    }
                }

                venta.Pagado = "Si";

                ped.Monto = venta.Monto;
                pedidoP.Editar(ped);

                var envioP = new EnvioProcess();
                var envio = new Envio();

                envio.CodVenta = ventaP.Crear(venta).Id;
                envio.Direccion = ped.Comprador.Domicilio;
                envio.Estado = "En Espera";
                envio.Fechadellegada = DateTime.Now;
                DateTime today = DateTime.Now;
                if (salida == 1)
                {
                    envio.Fechadesalida = today.AddDays(14);
                }
                else
                {
                    envio.Fechadesalida = today.AddDays(7);
                }


                envioP.Crear(envio);

                Bitacora bitacora = new Bitacora("Pagar", "Tabla Pedido", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                TempData["Message"] = Recursos.Recurso.pedido2;


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Pagar Tabla Pedido", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }

        public ActionResult VerEnvio(int id)
        {
            try
            {
                var enviop = new EnvioProcess();
                var listaenvio = enviop.Listar();

                foreach (var item in listaenvio)
                {
                    if (item.Venta.CodPedido == id)
                    {
                        estadopedido = item.Estado;
                        idpedido = id;
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Envio Tabla Pedido", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        public ActionResult VerEnvioUnico(int id)
        {
            try
            {
                var enviop = new EnvioProcess();
                var listaenvio = enviop.Listar();

                foreach (var item in listaenvio)
                {
                    if (item.Venta.CodPedido == id)
                    {
                        estadopedido = item.Estado;
                        idpedido = id;
                    }
                }
                return RedirectToAction("IndexUsuario");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Envio Tabla Pedido", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
           
        }

        public ActionResult PagarUsuario(int id)
        {
            try
            {
                var pedidoP = new PedidoProcess();
                var ped = pedidoP.GetByID(id);
                int salida = 0;

                var depositoP = new DepositoProcess();
                var deposito = new Deposito();
                var listadeposito = depositoP.Listar();

                foreach (var item in listadeposito)
                {
                    deposito = item;
                }

                ped.Estado = "Pagado";



                var ventaP = new VentaProcess();
                var venta = new Venta();

                var usuariop = new UsuarioProcess();
                Usuario usuario = new Usuario();
                var listausuarios = usuariop.Listar();

                foreach (var item in listausuarios)
                {
                    if (item.UserName == User.Identity.Name)
                    {
                        usuario = item;
                    }
                }

                var materiaprimaprodP = new MateriaPrimaProductoProcess();
                var materiaprima = new List<StockMateriaPrimaDeposito>();
                var listamateriaprimaprod = materiaprimaprodP.Listar();


                foreach (var item in listamateriaprimaprod)
                {
                    if (item.CodProducto == ped.Codproducto)
                    {
                        var mt = new StockMateriaPrimaDeposito();
                        mt.Cantidad = item.Cantidad * ped.Cantidad;
                        mt.CodMateriaPrima = item.CodMateriaPrima;
                        materiaprima.Add(mt);

                    }
                }


                var stockP = new StockMateriaPrimaDepositoProcess();
                var reposicionP = new ReposicionProcess();

                var ProveedormateriaprimaP = new MateriaPrimaProveedorProcess();
                Proveedor proveedor = new Proveedor();

                var materiaprimaProveedor = new MateriaPrimaProveedorProcess();


                var listastockmateriaprima = stockP.Listar();

                foreach (var item in listastockmateriaprima)
                {
                    double valor1 = 0;
                    double valor2 = 0;
                    foreach (var itemMP in materiaprima)
                    {
                        if (item.CodMateriaPrima == itemMP.CodMateriaPrima)
                        {
                            if (item.Cantidad < itemMP.Cantidad)
                            {
                                var reposicion = new Reposicion();
                                reposicion.CodMateriaPrima = item.CodMateriaPrima;
                                reposicion.CodDeposito = deposito.Id;
                                reposicion.Fecha = DateTime.Now;
                                reposicion.Cantidad = itemMP.Cantidad - item.Cantidad;
                                reposicion.Estado = "Reposicion Compra";

                                foreach (var itemProveedor in ProveedormateriaprimaP.Listarpormateriaprima(itemMP.CodMateriaPrima))
                                {
                                    if (valor2 == 0)
                                    {
                                        reposicion.Proveedor = itemProveedor.Proveedor;
                                        reposicion.CodProveedor = itemProveedor.Proveedor.Id;
                                        valor2 = 1;
                                    }

                                }

                                foreach (var itemPROV in materiaprimaProveedor.Listarpormateriaprima(itemMP.CodMateriaPrima))
                                {
                                    if (itemPROV.CodMateriaPrima == reposicion.CodMateriaPrima && itemPROV.CodProveedor == reposicion.CodProveedor)
                                    {
                                        valor1 = itemPROV.Precio;


                                    }
                                }
                                reposicion.Monto = valor1 * reposicion.Cantidad;
                                reposicionP.Crear(reposicion);
                                item.Cantidad = 0;
                                stockP.Edit(item);
                                salida = 1;

                            }
                            else
                            {
                                item.Cantidad = item.Cantidad - itemMP.Cantidad;
                                stockP.Edit(item);
                            }

                        }
                    }

                }

                venta.CodEmpleado = usuario.CodEmpleado;
                venta.CodPedido = ped.Id;
                venta.Formadepago = "Efectivo";

                if (venta.Formadepago == "Efectivo" && ped.Comprador.SocioEstado == "Si")
                {
                    venta.Monto = ped.Monto * 0.90;

                }
                else
                {
                    if (venta.Formadepago == "Efectivo")
                    {
                        venta.Monto = ped.Monto * 0.95;
                    }
                    if (ped.Comprador.SocioEstado == "Si")
                    {
                        venta.Monto = ped.Monto * 0.95;
                    }
                }

                venta.Pagado = "Si";

                ped.Monto = venta.Monto;
                pedidoP.Editar(ped);

                var envioP = new EnvioProcess();
                var envio = new Envio();

                envio.CodVenta = ventaP.Crear(venta).Id;
                envio.Direccion = ped.Comprador.Domicilio;
                envio.Estado = "En Espera";
                envio.Fechadellegada = DateTime.Now;
                DateTime today = DateTime.Now;
                if (salida == 1)
                {
                    envio.Fechadesalida = today.AddDays(14);
                }
                else
                {
                    envio.Fechadesalida = today.AddDays(7);
                }


                envioP.Crear(envio);

                TempData["Message"] = Recursos.Recurso.pedido3;

                Bitacora bitacora = new Bitacora("Pagar", "Tabla Pedido", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);


                return RedirectToAction("IndexUsuario");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Pagar Tabla Pedido", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
            
        }


    }
}

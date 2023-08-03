using Decopack.EE;
using Decopack.Process;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Decopack.Servicios;
using Decopack.Servicios.Bitacora;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Helpers;

namespace Decopack.Web.Controllers
{
    
    public class ProductoController : Controller
    {
        // GET: Producto
        bool diferencia;
        string cadena;

        public ActionResult getimage(int id)
        {
            try
            {
                ProductoProcess ProductoProcess = new ProductoProcess();
                Producto producto = new Producto();

                foreach (var item in ProductoProcess.ListarAPI())
                {
                    if (item.Id == id)
                    {
                        producto = item;
                    }
                }

                if (producto.ImagenProducto == null)
                {
                    ProductoProcess.Delete(producto.Id);
                }

                byte[] byteimagen = producto.ImagenProducto;

                MemoryStream memorystream = new MemoryStream(byteimagen);
                Image image = Image.FromStream(memorystream);

                memorystream = new MemoryStream();
                image.Save(memorystream, ImageFormat.Jpeg);
                memorystream.Position = 0;

                return File(memorystream, "image/jpg");
            }
            catch (Exception ex)
            {

                return View();

            }
        }


        [Authorize(Roles = "EncargadoDeposito")]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            try
            {

                ViewBag.CurrentSort = sortOrder;

                ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


                if (searchString != null)
                    page = 1;
                else
                    searchString = currentFilter;


                ViewBag.CurrentFilter = searchString;

                var ep = new ProductoProcess();


                IEnumerable<Producto> Productos = ep.ListarAPI();

                if (!string.IsNullOrEmpty(searchString))
                    Productos = Productos.Where(s => s.Nombre.Contains(searchString));

                switch (sortOrder)
                {
                    case "name_desc":
                        Productos = Productos.OrderByDescending(s => s.Nombre);
                        break;
                    case "Date":
                        Productos = Productos.OrderBy(s => s.Id);
                        break;
                    default:
                        Productos = Productos.OrderBy(s => s.Nombre);
                        break;
                }



                int pageSize = 10;
                int pageNumber = (page ?? 1);


              

                foreach (var item in Productos)
                {
                    if (item.DVH != Decopack.Servicios.Seguridad.GenerarSHA(string.Format("{0}{1}{2}{3}", item.Nombre, item.Precio, item.Estado, item.Descripcion)))
                    {
                        diferencia = true;
                    }
                }

                var productoDVVP = new ProductoDVVProcess();
                var productoDVV = new ProductoDVV();
                var biz = new ProductoProcess();

                foreach (var item in biz.ListarAPI())
                {

                    cadena = string.Format(cadena + "{0}", item.DVH);

                }

                if (biz.ListarAPI().Count() != 0)
                {
                    productoDVV.DVV = Decopack.Servicios.Seguridad.GenerarSHA(cadena);

                    foreach (var item in productoDVVP.Listar())
                    {
                        if (item.Entidad == "Producto")
                        {
                            if (productoDVV.DVV == item.DVV)
                            {

                            }
                            else
                            {
                                Bitacora bitacora = new Bitacora("Listar Tabla Producto", "Error DVV", User.Identity.Name, DateTime.Now);
                                BitacoraProcess bitacorap = new BitacoraProcess();
                                bitacorap.Create(bitacora);
                                ViewBag.showSuccessAlert = true;
                                return View(Productos.ToPagedList(pageNumber, pageSize));
                            }
                        }
                    }
                }

               


                if (diferencia == true)
                {
                    Bitacora bitacora = new Bitacora("Listar Tabla Producto", "Error DVH", User.Identity.Name, DateTime.Now);
                    BitacoraProcess bitacorap = new BitacoraProcess();
                    bitacorap.Create(bitacora);
                    ViewBag.showSuccessAlert = true;
                    return View(Productos.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    ViewBag.showSuccessAlert = false;
                    return View(Productos.ToPagedList(pageNumber, pageSize));
                }

                if(ViewBag.advertencia == true)
                {

                }
                else
                {
                    ViewBag.advertencia = false;
                }

            }
            catch (Exception a)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Producto", a.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

         

        }


        
        // GET: Producto/Create
        [Authorize(Roles = "EncargadoDeposito")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "EncargadoDeposito")]
        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(Producto producto, HttpPostedFileBase imagendelproducto)
        {
            try
            {
       
                if (imagendelproducto != null && imagendelproducto.ContentLength > 0)
                {
                    HttpPostedFileBase fileBase = Request.Files[0];
                    WebImage image = new WebImage(fileBase.InputStream);

                    producto.ImagenProducto = image.GetBytes();

                }

                producto.Estado = "No Disponible";
                producto.Precio = 0;
                producto.DVH = Decopack.Servicios.Seguridad.GenerarSHA(string.Format("{0}{1}{2}{3}", producto.Nombre, producto.Precio, producto.Estado, producto.Descripcion));
                
                var biz = new ProductoProcess();

                var model = biz.AgregarAPI(producto);


                var ProductoCCP = new ProductoCCProcess();
                var productoCC = new ProductoCC();
                productoCC.Descripcion = producto.Descripcion;
                productoCC.Nombre = producto.Nombre;
                productoCC.Fecha = DateTime.Now;
                productoCC.Tipo = "Alta";
                productoCC.Usuario = User.Identity.Name;
                ProductoCCP.Crear(productoCC);

                var productoDVVP = new ProductoDVVProcess();
                var productoDVV = new ProductoDVV();
                
                

                foreach (var item in biz.ListarAPI())
                {
                    
                    cadena = string.Format(cadena + "{0}", item.DVH);
                    
                }

                productoDVV.DVV = Decopack.Servicios.Seguridad.GenerarSHA(cadena);

                foreach (var item in productoDVVP.Listar())
                {
                    if (item.Entidad == "Producto")
                    {
                        productoDVV.Id = item.Id;
                        productoDVV.Entidad = item.Entidad;
                        productoDVVP.Editar(productoDVV);
                    }
                    else
                    {
                        productoDVVP.Crear(productoDVV);
                    }
                }
                if (productoDVVP.Listar().Count == 0)
                {
                    productoDVV.Entidad = "Producto";
                    productoDVVP.Crear(productoDVV);
                }
                

                Bitacora bitacora = new Bitacora("Crear","Tabla Producto",User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);



                return RedirectToAction("Index");


            }
            catch(Exception a)
            {
                Bitacora bitacora = new Bitacora("Crear Tabla Producto", a.Message.ToString() , User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        [Authorize(Roles = "EncargadoDeposito")]
        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var biz = new ProductoProcess();
                var Producto = biz.GetByID(id);
                if (Producto.Precio == 0)
                {
                    ViewBag.advertencia = true;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.advertencia = false;
                    return View(Producto);
                }
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Producto", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
           
        }
        [Authorize(Roles = "EncargadoDeposito")]
        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(Producto producto1, HttpPostedFileBase imagendelproducto)
        {
            try
            {


                var biz = new ProductoProcess();
                var producto = biz.GetByID(producto1.Id);
                if (imagendelproducto != null && imagendelproducto.ContentLength > 0)
                {
                    byte[] imagendata = null;
                    using (var binarypaciente = new BinaryReader(imagendelproducto.InputStream))
                    {
                        imagendata = binarypaciente.ReadBytes(imagendelproducto.ContentLength);

                    }
                    producto.ImagenProducto = imagendata;
                }
                
                if (producto.Precio > producto1.Precio)
                {
                    ViewBag.advertencia = true;
                    return View(producto1);
                }
                else
                {
                    ViewBag.advertencia = false;
                }
                producto.Nombre = producto1.Nombre;
                producto.Precio = producto1.Precio;
                producto.Descripcion = producto1.Descripcion;
                producto.DVH = Decopack.Servicios.Seguridad.GenerarSHA(string.Format("{0}{1}{2}{3}", producto.Nombre, producto.Precio, producto.Estado, producto.Descripcion));
                if (producto.Precio == 0)
                {
                    throw new Exception();
                }


                bool result = biz.Edit(producto);

                var ProductoCCP = new ProductoCCProcess();
                var productoCC = new ProductoCC();
                productoCC.Descripcion = producto.Descripcion;
                productoCC.Nombre = producto.Nombre;
                productoCC.Fecha = DateTime.Now;
                productoCC.Tipo = "Editar";
                productoCC.Usuario = User.Identity.Name;
                ProductoCCP.Crear(productoCC);

                var productoDVVP = new ProductoDVVProcess();
                var productoDVV = new ProductoDVV();



                foreach (var item in biz.ListarAPI())
                {

                    cadena = string.Format(cadena + "{0}", item.DVH);

                }

                productoDVV.DVV = Decopack.Servicios.Seguridad.GenerarSHA(cadena);

                foreach (var item in productoDVVP.Listar())
                {
                    if (item.Entidad == "Producto")
                    {
                        productoDVV.Id = item.Id;
                        productoDVV.Entidad = item.Entidad;
                        productoDVVP.Editar(productoDVV);
                    }
                    else
                    {
                        productoDVVP.Crear(productoDVV);
                    }
                }

                Bitacora bitacora = new Bitacora("Editar", "Tabla Producto", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                if (result) { return RedirectToAction("Index"); }
                else { return View(); }
            }
            catch (Exception a)
            {
                Bitacora bitacora = new Bitacora("Editar Tabla Producto", a.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // GET: Producto/Delete/5
        [Authorize(Roles = "EncargadoDeposito")]
        public ActionResult Delete(int id)
        {
            try
            {
                var biz = new ProductoProcess();
                var Producto = biz.GetByID(id);
                return View(Producto);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Producto", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }

        // POST: Producto/Delete/5
        [Authorize(Roles = "EncargadoDeposito")]
        [HttpPost]
        public ActionResult Delete(Producto producto1)
        {
            try
            {
                var biz = new ProductoProcess();
                var producto = biz.GetByID(producto1.Id);

                if (producto.Estado == "Disponible")
                {
                    producto.Estado = "No Disponible";
                }
                else
                {
                    producto.Estado = "Disponible";
                }
                producto.DVH = Decopack.Servicios.Seguridad.GenerarSHA(string.Format("{0}{1}{2}{3}", producto.Nombre, producto.Precio, producto.Estado, producto.Descripcion));
                bool result = biz.Edit(producto);

                var ProductoCCP = new ProductoCCProcess();
                var productoCC = new ProductoCC();
                productoCC.Descripcion = producto.Descripcion;
                productoCC.Nombre = producto.Nombre;
                productoCC.Fecha = DateTime.Now;
                productoCC.Tipo = "Baja";
                productoCC.Usuario = User.Identity.Name;
                ProductoCCP.Crear(productoCC);

                var productoDVVP = new ProductoDVVProcess();
                var productoDVV = new ProductoDVV();



                foreach (var item in biz.ListarAPI())
                {

                    cadena = string.Format(cadena + "{0}", item.DVH);

                }

                productoDVV.DVV = Decopack.Servicios.Seguridad.GenerarSHA(cadena);

                foreach (var item in productoDVVP.Listar())
                {
                    if (item.Entidad == "Producto")
                    {
                        productoDVV.Id = item.Id;
                        productoDVV.Entidad = item.Entidad;
                        productoDVVP.Editar(productoDVV);
                    }
                    else
                    {
                        productoDVVP.Crear(productoDVV);
                    }
                }

                Bitacora bitacora = new Bitacora("Eliminar", "Tabla Producto", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);

                if (result) { return RedirectToAction("Index"); }
                else { return View(); }
            }
            catch(Exception a)
            {
                Bitacora bitacora = new Bitacora("Eliminar Tabla Producto", a.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
        }


        public ActionResult Catalogo()
        {
            try
            {
                var biz = new ProductoProcess();

                var Productos = new List<Producto>();
                var listadeproductos = biz.ListarAPI();
                foreach (var item in listadeproductos)
                {
                    if (item.Precio != 0)
                    {
                        Productos.Add(item);
                    }
                }
                return View(Productos);
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Listar Tabla Catalogo", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }

        }

        [Authorize(Roles = "EncargadoDeposito")]

        public ActionResult Actualizar()
        {
            try
            {
                var biz = new ProductoProcess();


                if (biz.ListarAPI().Count() != 0)
                {
                    var Producto = biz.ListarAPI();

                    var proveedorlista = new List<Proveedor>();
                    var ProveedormateriaprimaP = new MateriaPrimaProveedorProcess();

                    var materiaprimaproducto = new MateriaPrimaProductoProcess();
                    var proveedorp = new ProveedorProcess();
                    int contadorP = 0;



                    foreach (var itemP in Producto)
                    {
                        itemP.Precio = 0;
                        itemP.Estado = "No Disponible";
                        itemP.DVH = Decopack.Servicios.Seguridad.GenerarSHA(string.Format("{0}{1}{2}{3}", itemP.Nombre, itemP.Precio, itemP.Estado, itemP.Descripcion));

                        foreach (var itemM in materiaprimaproducto.Listar())
                        {
                            if (itemM.CodProducto == itemP.Id)
                            {
                                contadorP = 0;
                                foreach (var item in ProveedormateriaprimaP.Listarpormateriaprima(itemM.CodMateriaPrima))
                                {
                                    foreach (var itemPROV in proveedorp.Listar())
                                    {
                                        if (itemPROV.Id == item.CodProveedor)
                                        {
                                            if (itemPROV.Estado == "Activo")
                                            {
                                                if (contadorP == 0)
                                                {
                                                    itemP.Precio = (item.Precio * itemM.Cantidad) + itemP.Precio;
                                                    itemP.Estado = "Disponible";
                                                    itemP.DVH = Decopack.Servicios.Seguridad.GenerarSHA(string.Format("{0}{1}{2}{3}", itemP.Nombre, itemP.Precio, itemP.Estado, itemP.Descripcion));
                                                    biz.Edit(itemP);
                                                    contadorP = 1;
                                                }
                                            }

                                        }
                                    }
                                }
                            }
                        }
                        if (itemP.Precio == 0)
                        {
                            biz.Edit(itemP);
                        }
                    }

                    var productoDVVP = new ProductoDVVProcess();
                    var productoDVV = new ProductoDVV();



                    foreach (var item in biz.ListarAPI())
                    {

                        cadena = string.Format(cadena + "{0}", item.DVH);

                    }

                    productoDVV.DVV = Decopack.Servicios.Seguridad.GenerarSHA(cadena);

                    foreach (var item in productoDVVP.Listar())
                    {
                        if (item.Entidad == "Producto")
                        {
                            productoDVV.Id = item.Id;
                            productoDVV.Entidad = item.Entidad;
                            productoDVVP.Editar(productoDVV);
                        }
                        else
                        {
                            productoDVVP.Crear(productoDVV);
                        }
                    }
                }

                Bitacora bitacora = new Bitacora("Tabla Producto", "Actualizar Precio", User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Bitacora bitacora = new Bitacora("Actualizar Precio Tabla Producto", ex.Message.ToString(), User.Identity.Name, DateTime.Now);
                BitacoraProcess bitacorap = new BitacoraProcess();
                bitacorap.Create(bitacora);
                return View();
            }
           
        }

       





    }
}

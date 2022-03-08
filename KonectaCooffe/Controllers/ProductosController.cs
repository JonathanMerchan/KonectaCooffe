using KonectaCooffe.Data;
using KonectaCooffe.Models;
using KonectaCooffe.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KonectaCooffe.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context) { _context = context; }

        // GET: ProductosController
        public ActionResult Index()
        {
            //IEnumerable<productoView> LprodView = null;
            IEnumerable<producto> Lproductos = null;
            //productoView p = null;
            try { 
                Lproductos = _context.Productos;
                }
            catch{
                TempData["mensaje"] = "Se ha generado un error";
                //return View(LprodView);
                return View(Lproductos);
            }
            //foreach (var item in Lproductos)
            //{
            //    p.id = item.id;
            //    p.Nombre = item.Nombre;
            //    p.Referencia = item.Referencia;
            //    p.Precio = item.Precio;
            //    p.Peso = item.Peso;
            //    p.Categoria = item.Categoria;
            //    p.Stock = item.Stock;
            //    p.Fecha = item.Fecha;

            //    //LprodView.Add(p);
            //}

            return View(Lproductos);
        }

        // GET: ProductosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(productoView productoData)
        {
            producto product = new producto();
            try
            {
                if (productoData !=null)
                {                  
                    product.Nombre = productoData.Nombre;
                    product.Referencia = productoData.Referencia;
                    product.Precio = productoData.Precio;
                    product.Peso = productoData.Peso;
                    product.Categoria = productoData.Categoria;
                    product.Stock = productoData.Stock;
                    product.Fecha = productoData.Fecha;                   

                    _context.Productos.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else { 
                    return RedirectToAction(nameof(Create),productoData);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id)
        {
            productoView Pv = new productoView();
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }
            Pv.id = producto.productoid;
            Pv.Nombre = producto.Nombre;
            Pv.Referencia = producto.Referencia;
            Pv.Precio = producto.Precio;
            Pv.Peso = producto.Peso;
            Pv.Categoria = producto.Categoria;
            Pv.Stock = producto.Stock;
            Pv.Fecha = producto.Fecha;

            return View(Pv);
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(productoView productoEdit)
        {
            producto product = new producto();
            try
            {
                if (productoEdit != null)
                {
                    product.productoid = productoEdit.id;
                    product.Nombre = productoEdit.Nombre;
                    product.Referencia = productoEdit.Referencia;
                    product.Precio = productoEdit.Precio;
                    product.Peso = productoEdit.Peso;
                    product.Categoria = productoEdit.Categoria;
                    product.Stock = productoEdit.Stock;
                    product.Fecha = productoEdit.Fecha;
                    _context.Productos.Update(product);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Edit), productoEdit);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            productoView Pv = new productoView();
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }
            Pv.id = producto.productoid;
            Pv.Nombre = producto.Nombre;
            Pv.Referencia = producto.Referencia;
            Pv.Precio = producto.Precio;
            Pv.Peso = producto.Peso;
            Pv.Categoria = producto.Categoria;
            Pv.Stock = producto.Stock;
            Pv.Fecha = producto.Fecha;

            return View(Pv);
        }

        // POST: ProductosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                var libro = _context.Productos.Find(id);

                if (libro == null)
                {
                    return NotFound();
                }

                _context.Productos.Remove(libro);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: ProductosController/Details/5
        public productoView Details(int id)
        {
            productoView product = null;
            if (id == null || id == 0)
            {
                return null;
            }
            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return null;
            }
            product.id = producto.productoid;
            product.Nombre = producto.Nombre;
            product.Referencia = producto.Referencia;
            product.Precio = producto.Precio;
            product.Peso = producto.Peso;
            product.Categoria = producto.Categoria;
            product.Stock = producto.Stock;
            product.Fecha = producto.Fecha;

            return product;
           
        }
    }
}

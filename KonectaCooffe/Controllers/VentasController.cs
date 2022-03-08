using KonectaCooffe.Data;
using KonectaCooffe.Models;
using KonectaCooffe.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace KonectaCooffe.Controllers
{
    public class VentasController : Controller
    {

        private readonly ApplicationDbContext _context;
        public VentasController(ApplicationDbContext context) { _context = context; }

        // GET: VentasController
        public ActionResult Index()
        {
            List<ventaView> LVentas = new List<ventaView>();
            IEnumerable<venta> LVen = null;
            try
            {
                ViewData["Productos"] = _context.Productos;

                LVen = _context.Ventas;
                foreach (var item in LVen)
                {
                ventaView v = new ventaView();
                    v.id_venta = item.id_venta;
                    v.id_producto = item.id_producto;
                    v.Cantidad = item.Cantidad;
                    v.Precio_Producto = (item.Valor/item.Cantidad).ToString();
                    v.Valor = item.Valor;
                    //v.Producto_nombre = item.producto.Nombre;

                    LVentas.Add(v);
                }


                //return View(LVentas);
                return View(LVentas);
            }
            catch(Exception ex) {
                return View();
            }
        }

        // GET: VentasController/Details/5
        public ActionResult venta(int Cantidad, int id_producto)
        {
            producto prod = new producto();
            venta venta = new venta();
            try
            {
                if (Cantidad == 0 || Cantidad < 0) 
                {
                    TempData["Alert"] = "Indique una cantidad  valida";
                    return RedirectToAction(nameof(Index));
                }
                if (id_producto == 0 || id_producto == null)
                {
                    TempData["Alert"] = "Selecione un producto";
                    return RedirectToAction(nameof(Index));
                }
                prod = _context.Productos.Find(id_producto);
                if (Cantidad <= prod.Stock)
                {
                    prod.Stock -= Cantidad;
                    venta.id_producto = id_producto;
                    venta.Cantidad = Cantidad;
                    venta.Valor = prod.Precio * Cantidad;
   
                    _context.Productos.Update(prod);
                    _context.Ventas.Add(venta);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                else{
                    TempData["Alert"] = "No es posible realizar la venta, quedan {'"+prod.Stock+"'} unidades del producto Selecionado";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                TempData["Alert"] = "Catch";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: VentasController/Create
        public ActionResult Create()
        {           
            return View();
        }

        // POST: VentasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VentasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VentasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VentasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VentasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

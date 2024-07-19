using Microsoft.AspNetCore.Mvc;
using MiIngresoHitss.Extensions;
using MiIngresoHitss.Models;
using MiIngresoHitss.Extensions;
using MiIngresoHitss.Models;
using System.Collections.Generic;
using System.Linq;
using MiIngresoHitss.Data;

namespace MiIngresoHitssApp.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Simulación del almacenamiento del carrito en la sesión
        private List<CarritoItem> GetCarrito()
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<CarritoItem>>("Carrito");
            if (carrito == null)
            {
                carrito = new List<CarritoItem>();
                HttpContext.Session.SetObjectAsJson("Carrito", carrito);
            }
            return carrito;
        }

        public IActionResult Index()
        {
            var carrito = GetCarrito();
            return View(carrito);
        }

        public IActionResult AgregarAlCarrito(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            var carrito = GetCarrito();
            var item = carrito.FirstOrDefault(p => p.ProductoID == id);
            if (item == null)
            {
                carrito.Add(new CarritoItem { ProductoID = id, Nombre = producto.Nombre, Precio = producto.Precio, Cantidad = 1 });
            }
            else
            {
                item.Cantidad++;
            }
            HttpContext.Session.SetObjectAsJson("Carrito", carrito);

            return RedirectToAction("Index", "Productos");
        }

        public IActionResult Eliminar(int id)
        {
            var carrito = GetCarrito();
            var item = carrito.FirstOrDefault(p => p.ProductoID == id);
            if (item != null)
            {
                carrito.Remove(item);
                HttpContext.Session.SetObjectAsJson("Carrito", carrito);
            }
            return RedirectToAction("Index");
        }
    }
}

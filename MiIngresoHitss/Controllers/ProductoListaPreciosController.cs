using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiIngresoHitss.Data;

namespace MiIngresoHitss.Controllers
{
    public class ProductoListaPreciosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoListaPreciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductoListaPrecios
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductoListaPrecios.ToListAsync());
        }

        // GET: ProductoListaPrecios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoListaPrecio = await _context.ProductoListaPrecios
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (productoListaPrecio == null)
            {
                return NotFound();
            }

            return View(productoListaPrecio);
        }

        // GET: ProductoListaPrecios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductoListaPrecios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoID,ListaPrecioID,Precio")] ProductoListaPrecio productoListaPrecio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoListaPrecio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productoListaPrecio);
        }

        // GET: ProductoListaPrecios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoListaPrecio = await _context.ProductoListaPrecios.FindAsync(id);
            if (productoListaPrecio == null)
            {
                return NotFound();
            }
            return View(productoListaPrecio);
        }

        // POST: ProductoListaPrecios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoID,ListaPrecioID,Precio")] ProductoListaPrecio productoListaPrecio)
        {
            if (id != productoListaPrecio.ProductoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoListaPrecio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoListaPrecioExists(productoListaPrecio.ProductoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productoListaPrecio);
        }

        // GET: ProductoListaPrecios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoListaPrecio = await _context.ProductoListaPrecios
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (productoListaPrecio == null)
            {
                return NotFound();
            }

            return View(productoListaPrecio);
        }

        // POST: ProductoListaPrecios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoListaPrecio = await _context.ProductoListaPrecios.FindAsync(id);
            if (productoListaPrecio != null)
            {
                _context.ProductoListaPrecios.Remove(productoListaPrecio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoListaPrecioExists(int id)
        {
            return _context.ProductoListaPrecios.Any(e => e.ProductoID == id);
        }
    }
}

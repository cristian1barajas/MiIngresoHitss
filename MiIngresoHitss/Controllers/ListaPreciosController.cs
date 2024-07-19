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
    public class ListaPreciosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaPreciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ListaPrecios
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListasPrecios.ToListAsync());
        }

        // GET: ListaPrecios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaPrecio = await _context.ListasPrecios
                .FirstOrDefaultAsync(m => m.ListaPrecioID == id);
            if (listaPrecio == null)
            {
                return NotFound();
            }

            return View(listaPrecio);
        }

        // GET: ListaPrecios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListaPrecios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListaPrecioID,Nombre,FechaCreacion")] ListaPrecio listaPrecio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaPrecio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listaPrecio);
        }

        // GET: ListaPrecios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaPrecio = await _context.ListasPrecios.FindAsync(id);
            if (listaPrecio == null)
            {
                return NotFound();
            }
            return View(listaPrecio);
        }

        // POST: ListaPrecios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListaPrecioID,Nombre,FechaCreacion")] ListaPrecio listaPrecio)
        {
            if (id != listaPrecio.ListaPrecioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaPrecio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaPrecioExists(listaPrecio.ListaPrecioID))
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
            return View(listaPrecio);
        }

        // GET: ListaPrecios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaPrecio = await _context.ListasPrecios
                .FirstOrDefaultAsync(m => m.ListaPrecioID == id);
            if (listaPrecio == null)
            {
                return NotFound();
            }

            return View(listaPrecio);
        }

        // POST: ListaPrecios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaPrecio = await _context.ListasPrecios.FindAsync(id);
            if (listaPrecio != null)
            {
                _context.ListasPrecios.Remove(listaPrecio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaPrecioExists(int id)
        {
            return _context.ListasPrecios.Any(e => e.ListaPrecioID == id);
        }
    }
}

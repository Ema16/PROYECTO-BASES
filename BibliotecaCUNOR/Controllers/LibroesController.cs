using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaCUNOR.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BibliotecaCUNOR.Controllers
{
    public class LibroesController : Controller
    {
        private readonly bd_bibliotecaContext _context;

        public LibroesController(bd_bibliotecaContext context)
        {
            _context = context;
        }

        // GET: Libroes
        public async Task<IActionResult> Index()
        {
            var bd_bibliotecaContext = _context.Libro.Include(l => l.CodClasificacionNavigation).Include(l => l.CodEditorialNavigation).Include(l => l.CodUsuarioNavigation);
            return View(await bd_bibliotecaContext.ToListAsync());
        }

        // GET: Libroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libro
                .Include(l => l.CodClasificacionNavigation)
                .Include(l => l.CodEditorialNavigation)
                .Include(l => l.CodUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libroes/Create
        public IActionResult Create()
        {
            ViewData["CodClasificacion"] = new SelectList(_context.Clasificacion, "CodClasificacion", "Clase");
            ViewData["CodEditorial"] = new SelectList(_context.Editorial, "CodEditorial", "Nombre");
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido");
            ViewData["CodAutor"] = new SelectList(_context.Autor,"CodAutor","Nombre");
            ViewData["CodEdicion"] = new SelectList(_context.Edicion, "CodEdicion", "Edicion1");
            return View();
        }

        // POST: Libroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodLibro,Clave,Titulo,Costo,Estado,Ejemplares,Paginas,Volumen,FechaRegistro,CodEditorial,CodUsuario,CodClasificacion")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodClasificacion"] = new SelectList(_context.Clasificacion, "CodClasificacion", "Clase", libro.CodClasificacion);
            ViewData["CodEditorial"] = new SelectList(_context.Editorial, "CodEditorial", "Nombre", libro.CodEditorial);
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido", libro.CodUsuario);
            return View(libro);
        }

        // GET: Libroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["CodClasificacion"] = new SelectList(_context.Clasificacion, "CodClasificacion", "Clase", libro.CodClasificacion);
            ViewData["CodEditorial"] = new SelectList(_context.Editorial, "CodEditorial", "Nombre", libro.CodEditorial);
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido", libro.CodUsuario);
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodLibro,Clave,Titulo,Costo,Estado,Ejemplares,Paginas,Volumen,FechaRegistro,CodEditorial,CodUsuario,CodClasificacion")] Libro libro)
        {
            if (id != libro.CodLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.CodLibro))
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
            ViewData["CodClasificacion"] = new SelectList(_context.Clasificacion, "CodClasificacion", "Clase", libro.CodClasificacion);
            ViewData["CodEditorial"] = new SelectList(_context.Editorial, "CodEditorial", "Nombre", libro.CodEditorial);
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido", libro.CodUsuario);
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libro
                .Include(l => l.CodClasificacionNavigation)
                .Include(l => l.CodEditorialNavigation)
                .Include(l => l.CodUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libro.FindAsync(id);
            _context.Libro.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libro.Any(e => e.CodLibro == id);
        }

    }
}

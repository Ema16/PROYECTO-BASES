using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaCUNOR.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Dynamic.Core;

namespace BibliotecaCUNOR.Controllers
{
    [Authorize(Roles =("Administrador,Inventarista"))]
    public class AutorsController : Controller
    {
        //Atributos para el JSON
        public string draw = "";
        public string start = "";
        public string length = "";
        public string sortColumn = "";
        public string sortColumnDir = "";
        public string searchValue = "";
        public int pageSize, skip, recordsTotal;
        private readonly bd_bibliotecaContext _context;

        public AutorsController(bd_bibliotecaContext context)
        {
            _context = context;
        }

        // GET: Autors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autor.ToListAsync());
        }

        // GET: Autors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor
                .FirstOrDefaultAsync(m => m.CodAutor == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }


        // GET: Autors/Create
        [HttpGet]
        public IActionResult Create()
        {
            Autor autor = new Autor();
            return PartialView(@"~/Views/Libroes/_AgregarAutor.cshtml", autor);
        }

        // POST: Autors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodAutor,Nombre,Apellido")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autor);
                await _context.SaveChangesAsync();
             //   return RedirectToAction("Secret", "Home");
            }
            return PartialView(@"~/Views/Libroes/_AgregarAutor.cshtml", autor);
        }

        // GET: Autors/Edit/5
        /*
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }
        */

        //Autores del Sistema
        [HttpPost]
        public ActionResult Json()
        {
            try
            {
                List<ListAutores> lst = new List<ListAutores>();

                //Logistica Datatable


                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                pageSize = length != null ? Convert.ToInt32(length) : 0;
                skip = start != null ? Convert.ToInt32(start) : 0;
                recordsTotal = 0;
                IQueryable<ListAutores> query = (from d in _context.Autor
                                             select new ListAutores
                                             {
                                                Nombre = d.Nombre,
                                                Apellido = d.Apellido,
                                             });
                if (searchValue != "")
                {
                    query = query.Where(d => d.Nombre.Contains(searchValue));
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    query = query.OrderBy(sortColumn + " " + sortColumnDirection);
                }

                recordsTotal = query.Count();
                lst = query.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = lst });

            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpGet]
        public IActionResult Details()
        {

            return View();
        }


        /*
        // POST: Autors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodAutor,Nombre,Apellido")] Autor autor)
        {
            if (id != autor.CodAutor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.CodAutor))
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
            return View(autor);
        }

        // GET: Autors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor
                .FirstOrDefaultAsync(m => m.CodAutor == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }
        */

        /*
        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autor = await _context.Autor.FindAsync(id);
            _context.Autor.Remove(autor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id)
        {
            return _context.Autor.Any(e => e.CodAutor == id);
        }
        */


        // GET: Autors/Create1
        [HttpGet]
        public IActionResult Create1()
        {
            if (TempData["mensaje"] != null)
            {
                ViewBag.mensaje = TempData["mensaje"].ToString();
            }
            return View();
        }

        // POST: Autors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1([Bind("CodAutor,Nombre,Apellido")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autor);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Autor Creado!";
                return RedirectToAction("Create1","Autors");
                //   return RedirectToAction("Secret", "Home");
            }
            return View();
        }
    }
}

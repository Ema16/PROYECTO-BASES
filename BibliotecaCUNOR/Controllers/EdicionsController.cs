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
    [Authorize(Roles = ("Administrador,Inventarista"))]
    public class EdicionsController : Controller
    {
        public string draw = "";
        public string start = "";
        public string length = "";
        public string sortColumn = "";
        public string sortColumnDir = "";
        public string searchValue = "";
        public int pageSize, skip, recordsTotal;
        private readonly bd_bibliotecaContext _context;

        public EdicionsController(bd_bibliotecaContext context)
        {
            _context = context;
        }

        // GET: Edicions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Edicion.ToListAsync());
        }

        //Ediciones del Sistema
        [HttpPost]
        public ActionResult Json()
        {
            try
            {
                List<ListEdicion> lst = new List<ListEdicion>();

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
                IQueryable<ListEdicion> query = (from d in _context.Edicion
                                                   select new ListEdicion
                                                   {
                                                        Edicion = d.Edicion1,
                                                       // Count = editorials.Where(d => d.CodEditorial==d.CodEditorial).Count()
                                                   });
                if (searchValue != "")
                {
                    query = query.Where(d => d.Edicion.Contains(searchValue));
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
        // GET: Edicions/Details/5
        public async Task<IActionResult> Details()
        {
            return View();
        }

        // GET: Edicions/Create
        [HttpGet]
        public IActionResult Create()
        {
            Edicion autor = new Edicion();
            return PartialView(@"~/Views/Libroes/_AgregarEdicion.cshtml", autor);
        }

        // POST: Edicions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEdicion,Edicion1")] Edicion edicion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edicion);
                await _context.SaveChangesAsync();
              //  return RedirectToAction(nameof(Index));
            }
            return PartialView(@"~/Views/Libroes/_AgregarEdicion.cshtml", edicion);
        }

        /*

        // GET: Edicions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edicion = await _context.Edicion.FindAsync(id);
            if (edicion == null)
            {
                return NotFound();
            }
            return View(edicion);
        }

        // POST: Edicions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodEdicion,Edicion1")] Edicion edicion)
        {
            if (id != edicion.CodEdicion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(edicion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdicionExists(edicion.CodEdicion))
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
            return View(edicion);
        }

        // GET: Edicions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edicion = await _context.Edicion
                .FirstOrDefaultAsync(m => m.CodEdicion == id);
            if (edicion == null)
            {
                return NotFound();
            }

            return View(edicion);
        }

        // POST: Edicions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var edicion = await _context.Edicion.FindAsync(id);
            _context.Edicion.Remove(edicion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EdicionExists(int id)
        {
            return _context.Edicion.Any(e => e.CodEdicion == id);
        }

*/

        // GET: Edicions/Create1
        [HttpGet]
        public IActionResult Create1()
        {
            if (TempData["mensajeEdic"] != null)
            {
                ViewBag.mensajeEdic = TempData["mensajeEdic"].ToString();
            }
            return View();
        }

        // POST: Edicions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1([Bind("CodEdicion,Edicion1")] Edicion edicion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edicion);
                await _context.SaveChangesAsync();
                TempData["mensajeEdic"] = "Edicion Creada!";
                return RedirectToAction("Create1", "Edicions");
                //  return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

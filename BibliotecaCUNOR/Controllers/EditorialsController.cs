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
    public class EditorialsController : Controller
    {
        public string draw = "";
        public string start = "";
        public string length = "";
        public string sortColumn = "";
        public string sortColumnDir = "";
        public string searchValue = "";
        public int pageSize, skip, recordsTotal;
        private readonly bd_bibliotecaContext _context;

        public EditorialsController(bd_bibliotecaContext context)
        {
            _context = context;
        }

        // GET: Editorials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Editorial.ToListAsync());
        }

        // GET: Editorials/Details/5
        public async Task<IActionResult> Details()
        {
           
            return View();
        }

        //Editoriales del Sistema
        [HttpPost]
        public ActionResult Json()
        {
            try
            {
                List<ListEditorial> lst = new List<ListEditorial>();

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
                IQueryable<ListEditorial> query = (from d in _context.Editorial
                                                 select new ListEditorial
                                                 {
                                                     Nombre = d.Nombre,
                                                    // Count = editorials.Where(d => d.CodEditorial==d.CodEditorial).Count()
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




        // GET: Editorials/Create
        [HttpGet]
        public IActionResult Create()
        {
            Editorial autor = new Editorial();
            return PartialView(@"~/Views/Libroes/_AgregarEditorial.cshtml", autor);
        }

        // POST: Editorials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEditorial,Nombre")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editorial);
                await _context.SaveChangesAsync();
               // return RedirectToAction(nameof(Index));
            }
            return PartialView(@"~/Views/Libroes/_AgregarEditorial.cshtml", editorial);
        }


        /*
        // GET: Editorials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editorial.FindAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return View(editorial);
        }

        // POST: Editorials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodEditorial,Nombre")] Editorial editorial)
        {
            if (id != editorial.CodEditorial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialExists(editorial.CodEditorial))
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
            return View(editorial);
        }

        // GET: Editorials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editorial
                .FirstOrDefaultAsync(m => m.CodEditorial == id);
            if (editorial == null)
            {
                return NotFound();
            }

            return View(editorial);
        }

        // POST: Editorials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editorial = await _context.Editorial.FindAsync(id);
            _context.Editorial.Remove(editorial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialExists(int id)
        {
            return _context.Editorial.Any(e => e.CodEditorial == id);
        }


        */

        // GET: Editorials/Create1
        [HttpGet]
        public IActionResult Create1()
        {
            if (TempData["mensajeEdit"] != null)
            {
                ViewBag.mensajeEdit = TempData["mensajeEdit"].ToString();
            }
            return View();
        }

        // POST: Editorials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1([Bind("CodEditorial,Nombre")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editorial);
                await _context.SaveChangesAsync();
                TempData["mensajeEdit"] = "Editorial Creada!";
                return RedirectToAction("Create1", "Editorials");
                // return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

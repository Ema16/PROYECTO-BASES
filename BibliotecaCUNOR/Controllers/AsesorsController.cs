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
    [Authorize(Roles ="Administrador,Inventarista,Inventarista Trabajo")]
    public class AsesorsController : Controller
    {
        public string draw = "";
        public string start = "";
        public string length = "";
        public string sortColumn = "";
        public string sortColumnDir = "";
        public string searchValue = "";
        public int pageSize, skip, recordsTotal;
        private readonly bd_bibliotecaContext _context;

        public AsesorsController(bd_bibliotecaContext context)
        {
            _context = context;
        }

        // GET: Asesors
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("Create1", "Asesors");
        }

        // GET: Asesors/Details/5
        public async Task<IActionResult> Details()
        {
           
            return View();
        }
        //Asesores del Sistema
        [HttpPost]
        public ActionResult Json()
        {
            try
            {
                List<ListAsesor> lst = new List<ListAsesor>();

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
                IQueryable<ListAsesor> query = (from d in _context.Asesor
                                                 select new ListAsesor
                                                 {
                                                     Asesor = d.Nombre+" "+d.Apellido,
                                                     // Count = editorials.Where(d => d.CodEditorial==d.CodEditorial).Count()
                                                 });
                if (searchValue != "")
                {
                    query = query.Where(d => d.Asesor.Contains(searchValue));
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

        // GET: Asesors/Create
        public IActionResult Create()
        {
            Asesor asesor = new Asesor();
            return PartialView(asesor);
        }

        // POST: Asesors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodAsesor,Nombre,Apellido")] Asesor asesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asesor);
                await _context.SaveChangesAsync();
              //  return RedirectToAction(nameof(Index));
            }
            return PartialView(asesor);
        }

        /*
        // GET: Asesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asesor = await _context.Asesor.FindAsync(id);
            if (asesor == null)
            {
                return NotFound();
            }
            return View(asesor);
        }

        // POST: Asesors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodAsesor,Nombre,Apellido")] Asesor asesor)
        {
            if (id != asesor.CodAsesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsesorExists(asesor.CodAsesor))
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
            return View(asesor);
        }

        // GET: Asesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asesor = await _context.Asesor
                .FirstOrDefaultAsync(m => m.CodAsesor == id);
            if (asesor == null)
            {
                return NotFound();
            }

            return View(asesor);
        }

        // POST: Asesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asesor = await _context.Asesor.FindAsync(id);
            _context.Asesor.Remove(asesor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsesorExists(int id)
        {
            return _context.Asesor.Any(e => e.CodAsesor == id);
        }
        */

        // GET: Asesors/Create1
        public IActionResult Create1()
        {
            if (TempData["mensajeAs"] != null)
            {
                ViewBag.mensajeAs = TempData["mensajeAs"].ToString();
            }
            return View();
        }

        // POST: Asesors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1([Bind("CodAsesor,Nombre,Apellido")] Asesor asesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asesor);
                await _context.SaveChangesAsync();
                TempData["mensajeAs"] = "Asesor Creado!";
                return RedirectToAction("Create1", "Asesors");
                //  return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

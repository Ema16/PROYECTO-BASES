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
    [Authorize(Roles = "Administrador,Inventarista,Inventarista Trabajo")]
    public class CargoesController : Controller
    {
        public string draw = "";
        public string start = "";
        public string length = "";
        public string sortColumn = "";
        public string sortColumnDir = "";
        public string searchValue = "";
        public int pageSize, skip, recordsTotal;
        private readonly bd_bibliotecaContext _context;

        public CargoesController(bd_bibliotecaContext context)
        {
            _context = context;
        }

        // GET: Cargoes
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("Create","Cargoes");
        }

        // GET: Cargoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();
        }


        //Cargos del Sistema
        [HttpPost]
        public ActionResult Json()
        {
            try
            {
                List<ListaCargo> lst = new List<ListaCargo>();

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
                IQueryable<ListaCargo> query = (from d in _context.Cargo
                                                   select new ListaCargo
                                                   {
                                                       Cargo = d.Cargo1,
                                                       // Count = editorials.Where(d => d.CodEditorial==d.CodEditorial).Count()
                                                   });
                if (searchValue != "")
                {
                    query = query.Where(d => d.Cargo.Contains(searchValue));
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

        // GET: Cargoes/Create
        public IActionResult Create()
        {
            if (TempData["mensajeCargo"] != null)
            {
                ViewBag.mensajeCargo = TempData["mensajeCargo"].ToString();
            }
            return View();
        }

        // POST: Cargoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodCargo,Cargo1")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargo);
                await _context.SaveChangesAsync();
                TempData["mensajeCargo"] = "Cargo Creada!";
                return RedirectToAction("Create", "Cargoes");
            }
            return View(cargo);
        }

        /*
        // GET: Cargoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }
            return View(cargo);
        }

        // POST: Cargoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodCargo,Cargo1")] Cargo cargo)
        {
            if (id != cargo.CodCargo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoExists(cargo.CodCargo))
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
            return View(cargo);
        }

        // GET: Cargoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargo
                .FirstOrDefaultAsync(m => m.CodCargo == id);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // POST: Cargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargo = await _context.Cargo.FindAsync(id);
            _context.Cargo.Remove(cargo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargoExists(int id)
        {
            return _context.Cargo.Any(e => e.CodCargo == id);
        }
        */
    }
}

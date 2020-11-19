using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaCUNOR.Models;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Security.Principal;
using Rotativa.AspNetCore;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaCUNOR.Controllers
{
    [Authorize(Roles ="Bibliotecario")]
    public class PrestamoController : Controller
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

        public PrestamoController(bd_bibliotecaContext context)
        {
            _context = context;
        }



        // GET: Prestamo
        public async Task<IActionResult> Index()
        {

            return RedirectToAction("Ficha");
        }

        // GET: Prestamo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamo
                .Include(p => p.CodUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }


        //Buscar Usuario
        [AcceptVerbs("GET","POST")]
        public JsonResult ObtenerInformacion(int idUsuario)
        {
            List<Usuario> lst;
            
                lst = (from d in _context.Usuario
                       where d.CodUsuario==idUsuario
                       select d).ToList();
                return Json(lst);
           
        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult ObtenerInformacionLibro(int[] idLibro)
        {
            
            foreach (var i in idLibro)
            {
                List<Libro> lst;
                lst = (from d in _context.Libro
                       where d.CodLibro == i
                       select d).ToList();
                return Json(lst);
            }
            return Json(true);

        }


        // GET: Prestamo/Create
        public IActionResult Create()
        {
           
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "FullName");
            ViewData["CodLibro"] = new SelectList(_context.Libro, "CodLibro", "Titulo");
            return View();
        }

        // POST: Prestamo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodPrestamo,FechaPrestamo,FechaDevolucion,FechaRecepcion,Mora,Tipo,CodUsuario,Libros")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                bd_bibliotecaContext context2 = new bd_bibliotecaContext();
                foreach (var i in prestamo.Libros)
                {
                    var libro = context2.Libro.Where(w => w.CodLibro == i).FirstOrDefault();
                    if (libro != null)
                    {
                        if (libro.Ejemplares==0 && libro.Estado.Equals("Ocupado"))
                        {
                            //Hacer aca la validacion del modal 
                            TempData["mensajePresE"] = "Creado!";
                            return RedirectToAction("Ficha");
                        }
                        else if(libro.Ejemplares == 0 && libro.Estado.Equals("Perdido"))
                        {
                            //Hacer aca la validacion del modal 
                            TempData["mensajePresE"] = "Error";
                            return RedirectToAction("Ficha");
                        }
                        if (libro.Ejemplares != 0)
                        {
                            prestamo.DetPrestamo.Add(new DetPrestamo { CodLibro = i, Estado = "Ocupado" });
                            libro.Ejemplares = libro.Ejemplares - 1;
                            await context2.SaveChangesAsync();
                        }
                        else if (libro.Ejemplares == 0 && libro.Estado.Equals("Disponible"))
                        {
                            prestamo.DetPrestamo.Add(new DetPrestamo { CodLibro = i, Estado = "Ocupado" });
                            libro.Estado = "Ocupado";
                            await context2.SaveChangesAsync();
                        }
                       

                    }

                    
                }
                // _context.Libro.Update(new Libro {Estado="Dipsonible" });
                DateTime thisDay = DateTime.Today;
                prestamo.FechaPrestamo = thisDay;
                _context.Add(prestamo);
                await _context.SaveChangesAsync();


                return RedirectToAction("ConfirmacionFicha", new { id = prestamo.CodPrestamo });


                /*
                var trabajoGraduacion = await _context.TrabajoGraduacion
                .Include(t => t.CodAsesorNavigation)
                .Include(t => t.CodCarreraNavigation)
                .Include(t => t.CodCatNavigation)
                .Include(t => t.CodTipotrabajoNavigation)
                .Include(t => t.TrabajoPalabraClave)
                .ThenInclude(e => e.CodPalabraClaveNavigation)
                .FirstOrDefaultAsync(m => m.CodRegistro == id);
                */

                //return RedirectToAction(nameof(Index));
            }
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido", prestamo.CodUsuario);
            return View(prestamo);
        }

        /*
        // GET: Prestamo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamo.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido", prestamo.CodUsuario);
            return View(prestamo);
        }

        // POST: Prestamo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodPrestamo,FechaPrestamo,FechaDevolucion,FechaRecepcion,Mora,Tipo,CodUsuario")] Prestamo prestamo)
        {
            if (id != prestamo.CodPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.CodPrestamo))
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
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido", prestamo.CodUsuario);
            return View(prestamo);
        }

        // GET: Prestamo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamo
                .Include(p => p.CodUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamo.FindAsync(id);
            _context.Prestamo.Remove(prestamo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamo.Any(e => e.CodPrestamo == id);
        }

        */


        [AcceptVerbs("GET", "POST")]
        public JsonResult ObtenerInformacion1()
        {
            List<ViewModel> lst;

            lst = (from e in _context.DetPrestamo
                   join d in _context.Libro on e.CodLibro equals d.CodLibro
                   join i in _context.Prestamo on e.CodPrestamo equals i.CodPrestamo
                   join h in _context.Usuario on d.CodUsuario equals h.CodUsuario
                   select new ViewModel
                   {
                       Libro = d.Titulo,
                       NombreUsuario = h.FullName,
                       Tipo = i.Tipo,
                       FechaSolicitud = i.FechaPrestamo,
                       FechaRecepcion = i.FechaRecepcion,

                   }).ToList();
            return Json(lst);

        }


        //PRESTAMO ESTUDIANTE
        [HttpGet]
        public IActionResult Ficha()
        {
            if (TempData["mensajePresE"] != null)
            {
                ViewBag.mensajePresE = TempData["mensajePresE"].ToString();
            }
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "FullName");
            ViewData["CodLibro"] = new SelectList(_context.Libro, "CodLibro", "Titulo");
            return View();
        }

        //DEVOLUCIONES PENDIENTE
        [HttpGet]
        public IActionResult DevolucionesPendientes()
        {

            return View();
        }



        //PRESTAMOS
        public IActionResult Prestamos()
        {

            return View();
        }

        //PRESTAMOS YA DEVUELTOS
        //Usuarios del sistema
        [HttpPost]
        public ActionResult Json()
        {
            try
            {
                List<ViewModel> list = new List<ViewModel>();

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

                IQueryable<ViewModel> query = (from e in _context.DetPrestamo
                                               join d in _context.Libro on e.CodLibro equals d.CodLibro 
                                               join i in _context.Prestamo on e.CodPrestamo equals i.CodPrestamo
                                               join h in _context.Usuario on i.CodUsuario equals h.CodUsuario
                                               where e.Estado.Equals("Devuelto")
                                             select new ViewModel
                                             {
                                                 CodPrestamo=i.CodPrestamo,
                                                 Libro = d.Titulo,
                                                 NombreUsuario= h.Nombre,
                                                 Tipo = i.Tipo,
                                                 FechaSolicitud=i.FechaPrestamo,
                                                 FechaRecepcion=i.FechaRecepcion,

                                             });
                if (searchValue != "")
                {
                    query = query.Where(d => d.Libro.Contains(searchValue));
                }


                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    query = query.OrderBy(sortColumn + " " + sortColumnDirection);
                }

                recordsTotal = query.Count();
                list = query.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = list });

            }
            catch (Exception ex)
            {
                throw;
            }
        }



        //DEVOLUCIONES PENDIENTES
        [HttpPost]
        public ActionResult Json1()
        {
            try
            {
                List<ViewModel> list = new List<ViewModel>();

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

                IQueryable<ViewModel> query = (from e in _context.Prestamo
                                               join a in _context.DetPrestamo on e.CodPrestamo equals a.CodPrestamo
                                               join i in _context.Usuario on e.CodUsuario equals i.CodUsuario
                                               where a.Estado.Equals("Ocupado")
                                               select new ViewModel
                                               {
                                                   CodPrestamo = e.CodPrestamo,
                                                   NombreUsuario = i.Nombre,
                                                   Tipo = e.Tipo,
                                                   FechaSolicitud = e.FechaPrestamo,
                                                   FechaRecepcion = e.FechaRecepcion,

                                               });
                if (searchValue != "")
                {
                    query = query.Where(d => d.Libro.Contains(searchValue));
                }


                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    query = query.OrderBy(sortColumn + " " + sortColumnDirection);
                }

                recordsTotal = query.Count();
                list = query.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = list });

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //Detalles de la ficha de prestamo
        // GET: Prestamo/Details/5
        public async Task<IActionResult> DetalleFicha(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamo
                .Include(p => p.CodUsuarioNavigation)
                .Include(p => p.DetPrestamo)
                .ThenInclude(p => p.CodLibroNavigation)
                .FirstOrDefaultAsync(m => m.CodPrestamo == id);
            DateTime thisDay = DateTime.Today;
            TimeSpan difFechas = prestamo.FechaDevolucion - thisDay;
            int dias = difFechas.Days;
            if (dias<0)
            {
                dias = dias * -1;
                prestamo.Mora = dias * 3;
                prestamo.DiasAtraso = dias;
            }
            else
            {
                prestamo.DiasAtraso = 0;
                prestamo.Mora = 0;
            }

            
            if (prestamo == null)
            {
                return NotFound();
            }

            return PartialView("DetalleFicha", prestamo);
        }

        //DETALLE DEVOLUCION
        [HttpGet]
        public async Task<IActionResult> DetallesPrestamo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamo
                .Include(p => p.CodUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodPrestamo == id);
            
            if (prestamo == null)
            {
                return NotFound();
            }

            return PartialView("Modal_Detalle",prestamo);
        }


        // GET: Prestamo/Edit/5
        public async Task<IActionResult> DevolucionPrestamo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var prestamo = await _context.Prestamo
                .Include(p => p.CodUsuarioNavigation)
                .Include(p => p.DetPrestamo)
                .ThenInclude(p => p.CodLibroNavigation)
                .FirstOrDefaultAsync(m => m.CodPrestamo == id );
        //    var prestamo = await _context.Prestamo.FindAsync(id);
            DateTime thisDay = DateTime.Today;
            TimeSpan difFechas = prestamo.FechaDevolucion - thisDay;
            int dias = difFechas.Days;
            if (dias < 0)
            {
                dias = dias * -1;
                prestamo.Mora = dias * 3;
                prestamo.DiasAtraso = dias;
            }
            else
            {
                prestamo.DiasAtraso = 0;
                prestamo.Mora = 0;
            }
            if (prestamo == null)
            {
                return NotFound();
            }
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido", prestamo.CodUsuario);
            return PartialView("DevolucionPrestamo", prestamo);
        }

        //ACTUALIZACION DE LIBROS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DevolverLibro(int libro, int libro1, int libro12, int mora, int idlibro, int idlibro1, int idlibro12, int codPrestamo)
        {
            int codprestamo = codPrestamo;

            bd_bibliotecaContext _context1 = new bd_bibliotecaContext();
            bd_bibliotecaContext _context2 = new bd_bibliotecaContext();
            bd_bibliotecaContext _context3 = new bd_bibliotecaContext();
            //Libro 1
            
              
                 var detprestamo = _context1.DetPrestamo.Include(x => x.CodLibroNavigation).Include(y => y.CodPrestamoNavigation).AsNoTracking().FirstOrDefault(x => x.CodPrestamo == codPrestamo && x.CodLibro==idlibro);
                        if (libro != 0 && idlibro != 0)
                        {
                            //    var perdido1 = _context.Libro.Where(x => x.CodLibro == libro).FirstOrDefault();

                            if (detprestamo.CodLibroNavigation.Ejemplares == 0 && detprestamo.CodLibroNavigation.Estado.Equals("Ocupado") || detprestamo.CodLibroNavigation.Ejemplares == 0 && detprestamo.CodLibroNavigation.Estado.Equals("Perdido"))
                            {
                                detprestamo.CodLibroNavigation.Estado = "Perdido";
                                detprestamo.Estado = "Perdido";
                                DateTime thisDay = DateTime.Today;
                                detprestamo.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo.CodPrestamoNavigation.Mora = mora;
                                _context1.Update(detprestamo);
                                await _context1.SaveChangesAsync();
                            }
                            else if (detprestamo.CodLibroNavigation.Ejemplares >= 0 && detprestamo.CodLibroNavigation.Estado.Equals("Disponible"))
                            {
                                detprestamo.Estado = "Perdido";
                                DateTime thisDay = DateTime.Today;
                                detprestamo.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo.CodPrestamoNavigation.Mora = mora;
                                _context1.Update(detprestamo);
                                await _context1.SaveChangesAsync();
                            }
                        }
                        else if (libro == 0 && idlibro != 0)
                        {
                            if (detprestamo.CodLibroNavigation.Estado.Equals("Perdido") || detprestamo.CodLibroNavigation.Estado.Equals("Ocupado"))
                            {
                                detprestamo.CodLibroNavigation.Estado = "Disponible";
                                detprestamo.Estado = "Devuelto";
                                DateTime thisDay = DateTime.Today;
                                detprestamo.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo.CodPrestamoNavigation.Mora = mora;
                                _context1.Update(detprestamo);
                                await _context1.SaveChangesAsync();
                            }
                            else if (detprestamo.CodLibroNavigation.Estado.Equals("Disponible") && detprestamo.CodLibroNavigation.Ejemplares >= 0)
                            {
                                detprestamo.Estado = "Devuelto";
                                DateTime thisDay = DateTime.Today;
                                detprestamo.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo.CodPrestamoNavigation.Mora = mora;
                                detprestamo.CodLibroNavigation.Ejemplares = detprestamo.CodLibroNavigation.Ejemplares + 1;
                                _context1.Update(detprestamo);
                                await _context1.SaveChangesAsync();
                            }
                        }



                        //Libro 2
                        var detprestamo1 = _context2.DetPrestamo.Include(x => x.CodLibroNavigation).Include(y => y.CodPrestamoNavigation).FirstOrDefault(x => x.CodPrestamo == codPrestamo && x.CodLibro == idlibro1);
                        if (libro1 != 0 && idlibro1 != 0)
                        {
                            //    var perdido1 = _context.Libro.Where(x => x.CodLibro == libro).FirstOrDefault();

                            if (detprestamo1.CodLibroNavigation.Ejemplares == 0 && detprestamo1.CodLibroNavigation.Estado.Equals("Ocupado") || detprestamo1.CodLibroNavigation.Ejemplares == 0 && detprestamo1.CodLibroNavigation.Estado.Equals("Perdido"))
                            {
                                detprestamo1.CodLibroNavigation.Estado = "Perdido";
                                detprestamo1.Estado = "Perdido";
                                DateTime thisDay = DateTime.Today;
                                detprestamo1.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo1.CodPrestamoNavigation.Mora = mora;
                                _context2.Update(detprestamo1);
                                await _context2.SaveChangesAsync();
                            }
                            else if (detprestamo1.CodLibroNavigation.Ejemplares >= 0 && detprestamo1.CodLibroNavigation.Estado.Equals("Disponible"))
                            {
                                detprestamo1.Estado = "Perdido";
                                DateTime thisDay = DateTime.Today;
                                detprestamo1.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo1.CodPrestamoNavigation.Mora = mora;
                                _context2.Update(detprestamo1);
                                await _context2.SaveChangesAsync();
                            }
                        }
                        else if (libro1 == 0 && idlibro1 != 0)
                        {
                            if (detprestamo1.CodLibroNavigation.Estado.Equals("Perdido") || detprestamo1.CodLibroNavigation.Estado.Equals("Ocupado"))
                            {
                                detprestamo1.CodLibroNavigation.Estado = "Disponible";
                                detprestamo1.Estado = "Devuelto";
                                DateTime thisDay = DateTime.Today;
                                detprestamo1.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo1.CodPrestamoNavigation.Mora = mora;
                                _context2.Update(detprestamo1);
                                await _context2.SaveChangesAsync();
                            }
                            else if (detprestamo1.CodLibroNavigation.Estado.Equals("Disponible") && detprestamo1.CodLibroNavigation.Ejemplares >= 0)
                            {
                                detprestamo1.Estado = "Devuelto";
                                DateTime thisDay = DateTime.Today;
                                detprestamo1.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo1.CodPrestamoNavigation.Mora = mora;
                                detprestamo1.CodLibroNavigation.Ejemplares = detprestamo1.CodLibroNavigation.Ejemplares + 1;
                                _context2.Update(detprestamo1);
                                await _context2.SaveChangesAsync();
                            }
                        }

                        //Libro3
                        var detprestamo2 = _context3.DetPrestamo.Include(x => x.CodLibroNavigation).Include(y => y.CodPrestamoNavigation).FirstOrDefault(x => x.CodPrestamo == codPrestamo && x.CodLibro == idlibro12);
                        if (libro12 != 0 && idlibro12 != 0)
                        {
                            //    var perdido1 = _context.Libro.Where(x => x.CodLibro == libro).FirstOrDefault();

                            if (detprestamo2.CodLibroNavigation.Ejemplares == 0 && detprestamo2.CodLibroNavigation.Estado.Equals("Ocupado") || detprestamo2.CodLibroNavigation.Ejemplares == 0 && detprestamo2.CodLibroNavigation.Estado.Equals("Perdido"))
                            {
                                detprestamo2.CodLibroNavigation.Estado = "Perdido";
                                detprestamo2.Estado = "Perdido";
                                DateTime thisDay = DateTime.Today;
                                detprestamo2.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo2.CodPrestamoNavigation.Mora = mora;
                                _context3.Update(detprestamo2);
                                await _context3.SaveChangesAsync();

                            }
                            else if (detprestamo2.CodLibroNavigation.Ejemplares >= 0 && detprestamo2.CodLibroNavigation.Estado.Equals("Disponible"))
                            {
                                detprestamo2.Estado = "Perdido";
                                DateTime thisDay = DateTime.Today;
                                detprestamo2.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo2.CodPrestamoNavigation.Mora = mora;
                                _context3.Update(detprestamo2);
                                await _context3.SaveChangesAsync();
                            }
                        }
                        else if (libro12 == 0 && idlibro12 != 0)
                        {
                            if (detprestamo2.CodLibroNavigation.Estado.Equals("Perdido") || detprestamo2.CodLibroNavigation.Estado.Equals("Ocupado"))
                            {
                                detprestamo2.CodLibroNavigation.Estado = "Disponible";
                                detprestamo2.Estado = "Devuelto";
                                DateTime thisDay = DateTime.Today;
                                detprestamo2.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo2.CodPrestamoNavigation.Mora = mora;
                                _context3.Update(detprestamo2);
                                await _context3.SaveChangesAsync();

                            }
                            else if (detprestamo2.CodLibroNavigation.Estado.Equals("Disponible") && detprestamo2.CodLibroNavigation.Ejemplares >= 0)
                            {
                                detprestamo2.Estado = "Devuelto";
                                DateTime thisDay = DateTime.Today;
                                detprestamo2.CodPrestamoNavigation.FechaRecepcion = thisDay;
                                detprestamo2.CodPrestamoNavigation.Mora = mora;
                                detprestamo2.CodLibroNavigation.Ejemplares = detprestamo2.CodLibroNavigation.Ejemplares + 1;
                                _context3.Update(detprestamo2);
                                await _context3.SaveChangesAsync();
                            }
                        }
            

            var prestamo1 = _context.Prestamo
              .Include(p => p.CodUsuarioNavigation)
              .Include(p => p.DetPrestamo)
              .ThenInclude(p => p.CodLibroNavigation)
              .FirstOrDefault(m => m.CodPrestamo == codPrestamo);
            return View(prestamo1);
        }


        //COnfirmacion Libro 
        [HttpGet]
        public IActionResult Confirmacion(Prestamo prestamo)
        {
            //
            var prestamo1 =  _context.Prestamo
               .Include(p => p.CodUsuarioNavigation)
               .Include(p => p.DetPrestamo)
               .ThenInclude(p => p.CodLibroNavigation)
               .FirstOrDefaultAsync(m => m.CodPrestamo == prestamo.CodPrestamo);
            return View();
        }


        //COnfirmacion Ficha
        [AcceptVerbs("GET","POST")]
        public async Task<IActionResult>  ConfirmacionFicha(int? id)
        {
            var prestamo1 = _context.Prestamo
                    .Include(t => t.CodUsuarioNavigation)
                    .ThenInclude(t => t.CodRolusuarioNavigation)
                    .Include(t => t.DetPrestamo)
                    .ThenInclude(t => t.CodLibroNavigation)
                    .FirstOrDefault(e => e.CodPrestamo == id);
            return View(prestamo1);
        }

        [HttpPost]
        public IActionResult CreatePDF(int CodPrestamo)
        {
            var prestamo1 = _context.Prestamo
                    .Include(t => t.CodUsuarioNavigation)
                    .ThenInclude(t => t.CodRolusuarioNavigation)
                    .Include(t => t.DetPrestamo)
                    .ThenInclude(t => t.CodLibroNavigation)
                    .FirstOrDefault(e => e.CodPrestamo == CodPrestamo);
            DateTime thisDay = DateTime.Today;
            String Name = "Reporte" + prestamo1.CodUsuarioNavigation.Apellido + " " + prestamo1.CodUsuarioNavigation.Apellido + " " + thisDay;
            return new ViewAsPdf("Boleta", prestamo1)
            {
                FileName = Name + ".pdf"
            };

        }

        //Imprimir Boleta
        [AcceptVerbs("GET", "POST")]
        public ActionResult Imprimir(int CodigoPrestamo)
        {
            var prestamo1 = _context.Prestamo
                               .Include(t => t.CodUsuarioNavigation)
                               .ThenInclude(t => t.CodRolusuarioNavigation)
                               .Include(t => t.DetPrestamo)
                               .ThenInclude(t => t.CodLibroNavigation)
                               .FirstOrDefault(e => e.CodPrestamo == CodigoPrestamo);
            DateTime thisDay = DateTime.Today;
            return new ViewAsPdf("Boleta", prestamo1)
            {
            };
        }

        //Descargar Boleta
        [AcceptVerbs("GET","POST")]
        public ActionResult Descargar(int CodigoPrestamo)
        {
            var prestamo1 = _context.Prestamo
                    .Include(t => t.CodUsuarioNavigation)
                    .ThenInclude(t => t.CodRolusuarioNavigation)
                    .Include(t => t.DetPrestamo)
                    .ThenInclude(t => t.CodLibroNavigation)
                    .FirstOrDefault(e => e.CodPrestamo == CodigoPrestamo);
            DateTime thisDay = DateTime.Today;
            String Name = "Reporte" + prestamo1.CodUsuarioNavigation.Apellido + " " + prestamo1.CodUsuarioNavigation.Apellido + " " + thisDay;
            return new ViewAsPdf("Boleta", prestamo1)
            {
                FileName = Name + ".pdf"
            };
        }

        //Imprimir Reporte
        [AcceptVerbs("GET", "POST")]
        public ActionResult ImprimirReporte(int CodigoPrestamo)
        {
            if (CodigoPrestamo == 0)
            {
                return NotFound();
            }
            var prestamo =  _context.Prestamo
                .Include(p => p.CodUsuarioNavigation)
                .ThenInclude(p => p.CodCarreraNavigation)
                .Include(p => p.DetPrestamo)
                .ThenInclude(p => p.CodLibroNavigation)
                .FirstOrDefault(m => m.CodPrestamo == CodigoPrestamo);
            //    var prestamo = await _context.Prestamo.FindAsync(id);
            DateTime thisDay = DateTime.Today;
            TimeSpan difFechas = prestamo.FechaDevolucion - thisDay;
            int dias = difFechas.Days;
            if (dias < 0)
            {
                dias = dias * -1;
                prestamo.Mora = dias * 3;
                prestamo.DiasAtraso = dias;
            }
            else
            {
                prestamo.DiasAtraso = 0;
                prestamo.Mora = 0;
            }
            if (prestamo == null)
            {
                return NotFound();
            }
            return new ViewAsPdf("ReportePerdida", prestamo)
            {
            };
        }

        //Descargar DescargarReporte
        [AcceptVerbs("GET", "POST")]
        public ActionResult DescargarReporte(int CodigoPrestamo)
        {
            if (CodigoPrestamo == 0)
            {
                return NotFound();
            }
            var prestamo = _context.Prestamo
                .Include(p => p.CodUsuarioNavigation)
                .ThenInclude(p => p.CodCarreraNavigation)
                .Include(p => p.DetPrestamo)
                .ThenInclude(p => p.CodLibroNavigation)
                .FirstOrDefault(m => m.CodPrestamo == CodigoPrestamo);
            //    var prestamo = await _context.Prestamo.FindAsync(id);
            DateTime thisDay = DateTime.Today;
            TimeSpan difFechas = prestamo.FechaDevolucion - thisDay;
            int dias = difFechas.Days;
            if (dias < 0)
            {
                dias = dias * -1;
                prestamo.Mora = dias * 3;
                prestamo.DiasAtraso = dias;
            }
            else
            {
                prestamo.DiasAtraso = 0;
                prestamo.Mora = 0;
            }
            if (prestamo == null)
            {
                return NotFound();
            }
            String Name = "Reporte" + prestamo.CodUsuarioNavigation.Apellido + " " + prestamo.CodUsuarioNavigation.Apellido + " " + thisDay;
            return new ViewAsPdf("ReportePerdida", prestamo)
            {
                FileName = Name + ".pdf"
            };
        }

        //DETALLE DEVUELTO
        [HttpGet]
        public async Task<IActionResult> DetalleDevuelto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamo
                .Include(p => p.CodUsuarioNavigation)
                .Include(p => p.DetPrestamo)
                .ThenInclude(p => p.CodLibroNavigation)
                .FirstOrDefaultAsync(m => m.CodPrestamo == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return PartialView("DetalleDevuelto", prestamo);
        }

    }
}

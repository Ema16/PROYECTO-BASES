using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaCUNOR.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using X.PagedList;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaCUNOR.Controllers
{
    
    public class TrabajoGraduacionsController : Controller
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
        private readonly IWebHostEnvironment HostEnvironment;

        public TrabajoGraduacionsController(bd_bibliotecaContext context, IWebHostEnvironment hostEnvironment)
        {
            this.HostEnvironment = hostEnvironment;
            _context = context;
        }

        [Authorize]
        // GET: TrabajoGraduacions
        [AcceptVerbs("GET","POST")]
        public async Task<IActionResult> Index(int? pagina, string titulo, string autor, string institucion, string Empsearch, int parametro, string parametro1)
        {
            var numeracionpagina = pagina ?? 1;

            if (parametro1!=null)
            {
                var busqueda2 = (from p in _context.TrabajoGraduacion
                                 where p.NombreAutor == parametro1
                                 orderby p.Titulo ascending
                                 select p).ToList();
                var contenidopagina = busqueda2.ToPagedList(numeracionpagina, 20);
                ViewBag.vista = busqueda2;
                return View(contenidopagina);
            }

            if (parametro != 0)
            {
                var busqueda1 = (from p in _context.TrabajoGraduacion
                                join z in _context.TrabajoPalabraClave on p.CodRegistro equals z.CodRegistro
                                where z.CodPalabraClave == parametro
                                 orderby p.Titulo ascending
                                select p).ToList();
                var contenidopagina = busqueda1.ToPagedList(numeracionpagina, 20);
                ViewBag.vista = busqueda1;
                return View(contenidopagina);
            }
            else
            {
                var busqueda = (from p in _context.TrabajoGraduacion.Include(t => t.CodAsesorNavigation).Include(t => t.CodCarreraNavigation).Include(t => t.CodCatNavigation).Include(t => t.CodTipotrabajoNavigation).Include(t => t.CodUsuarioNavigation)
                                where p.RecursoDigital != null
                                orderby p.Titulo ascending
                                select p).ToList();

                if (titulo != null) { ViewBag.Titulo = titulo; busqueda = busqueda.Where(m => m.Titulo.ToLower().Contains(titulo.ToLower())).ToList(); }
                if (autor != null) { ViewBag.NombreAutor = autor; busqueda = busqueda.Where(m => m.NombreAutor.ToLower().Contains(autor.ToLower())).ToList(); }
                if (institucion != null) { ViewBag.NombreInstitucion = institucion; busqueda = busqueda.Where(m => m.NombreInstitucion.ToLower().Contains(institucion.ToLower())).ToList(); }

                if (!String.IsNullOrEmpty(Empsearch))
                {
                    ViewBag.Empresa = Empsearch;

                    busqueda = busqueda.Where(x => x.NombreAutor.ToLower().Contains(Empsearch.ToLower()) || x.NombreInstitucion.ToLower().Contains(Empsearch.ToLower()) || x.Titulo.ToLower().Contains(Empsearch.ToLower())
                    || x.ApellidoAutor.ToLower().Contains(Empsearch.ToLower())).ToList();

                }


                var contenidopagina = busqueda.ToPagedList(numeracionpagina, 20);
                // Console.WriteLine("TrabajoGraduacion: 1 ");
                ViewData["Busqueda1"] = titulo;
                ViewBag.vista = busqueda;
                return View(contenidopagina);
            }

        }

        /*
        // GET: TrabajoGraduacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajoGraduacion = await _context.TrabajoGraduacion
                .Include(t => t.CodAsesorNavigation)
                .Include(t => t.CodCarreraNavigation)
                .Include(t => t.CodCatNavigation)
                .Include(t => t.CodTipotrabajoNavigation)
                .Include(t => t.CodUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodRegistro == id);
            if (trabajoGraduacion == null)
            {
                return NotFound();
            }

            return View(trabajoGraduacion);
        }
        */

        // GET: TrabajoGraduacions/Create
        [Authorize(Roles = "Administrador,Inventarista,Inventarista Trabajo")]
        public IActionResult Create()
        {
            if (TempData["mensajeTra"] != null)
            {
                ViewBag.mensajeTra = TempData["mensajeTra"].ToString();
            }


            ViewData["CodAsesor"] = new SelectList(_context.Asesor, "CodAsesor", "FullName");
            ViewData["CodCarrera"] = new SelectList(_context.Carrera, "CodCarrera", "Carrera1");
            ViewData["CodCat"] = new SelectList(_context.CatTrabajoGraduacion, "CodCat", "Categoria");
            ViewData["CodTipotrabajo"] = new SelectList(_context.TipoTrabajo, "CodTipotrabajo", "Tipo");
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido");
            return View();
        }

        // POST: TrabajoGraduacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador,Inventarista,Inventarista Trabajo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodRegistro,Titulo,Año,RecursoDigital,TokenRecurso,Nota,NombreInstitucion,NombreAutor,ApellidoAutor,CarnetAutor,Observacion,CodCat,CodUsuario,CodAsesor,CodCarrera,CodTipotrabajo,Subir,PalabrasClaves")] TrabajoGraduacion trabajoGraduacion)
        {
            var variable = 0;

            if (ModelState.IsValid)
            {
                if ( trabajoGraduacion.Subir !=null)
                {
                string carpeta = HostEnvironment.WebRootPath;
                string nombrearchivo = Path.GetFileNameWithoutExtension(trabajoGraduacion.Subir.FileName);
                string extension = Path.GetExtension(trabajoGraduacion.Subir.FileName);
                trabajoGraduacion.RecursoDigital = nombrearchivo = nombrearchivo + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(carpeta + "/upload/", nombrearchivo);
                    trabajoGraduacion.TokenRecurso = Crypto.Hash(path);

                using (var hola = new FileStream(path, FileMode.Create))
                {
                    await trabajoGraduacion.Subir.CopyToAsync(hola);
                }
            }
            else
            {
                trabajoGraduacion.RecursoDigital = "default.txt";
            }

                
                bd_bibliotecaContext _context2 = new bd_bibliotecaContext();
                string[] valores = trabajoGraduacion.PalabrasClaves.Split(',');
                foreach (string pa in valores)
                {
                    PalabraClave palabraBD = new PalabraClave();
                    var Paclave = _context.PalabraClave.Where(w => w.PalabraClave1 == pa).FirstOrDefault();
                    if (Paclave!=null)
                    {
                        trabajoGraduacion.TrabajoPalabraClave.Add(new TrabajoPalabraClave { CodPalabraClave=Paclave.CodPalabraclave});
                    }
                    else
                    {
                        palabraBD.PalabraClave1 = pa;
                        _context2.Add(palabraBD);
                        await _context2.SaveChangesAsync();
                        var Paclave2 = _context.PalabraClave.Where(a => a.PalabraClave1 == pa).FirstOrDefault();
                        if (Paclave2!=null)
                        {
                            trabajoGraduacion.TrabajoPalabraClave.Add(new TrabajoPalabraClave { CodPalabraClave = Paclave2.CodPalabraclave });
                        }
                        
                    }
                }
                if (trabajoGraduacion.CodCat!=null)
                {
                    trabajoGraduacion.CodTipotrabajo = 2;
                }
                if (trabajoGraduacion.CodCat==null)
                {
                    trabajoGraduacion.CodTipotrabajo = 1;
                    variable = 1;
                }

                var user = _context.Usuario.Where(t => t.CorreoElectronico == User.Identity.Name).FirstOrDefault();
                trabajoGraduacion.CodUsuario = user.CodUsuario;
                _context.Add(trabajoGraduacion);
                await _context.SaveChangesAsync();
                if (variable==1)
                {
                    TempData["mensajeTesis"] = "Creado!";
                    return RedirectToAction("Tesis", "TrabajoGraduacions");
                }


                TempData["mensajeTra"] = "Creado!";
                return RedirectToAction("Create", "TrabajoGraduacions");
            }
            ViewData["CodAsesor"] = new SelectList(_context.Asesor, "CodAsesor", "Apellido", trabajoGraduacion.CodAsesor);
            ViewData["CodCarrera"] = new SelectList(_context.Carrera, "CodCarrera", "Carrera1", trabajoGraduacion.CodCarrera);
            ViewData["CodCat"] = new SelectList(_context.CatTrabajoGraduacion, "CodCat", "Categoria", trabajoGraduacion.CodCat);
            ViewData["CodTipotrabajo"] = new SelectList(_context.TipoTrabajo, "CodTipotrabajo", "Tipo", trabajoGraduacion.CodTipotrabajo);
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido", trabajoGraduacion.CodUsuario);
            return View(trabajoGraduacion);
        }

        [Authorize(Roles = "Administrador,Inventarista,Inventarista Trabajo")]
        public IActionResult Tesis()
        {
            if (TempData["mensajeTesis"] != null)
            {
                ViewBag.mensajeTes = TempData["mensajeTesis"].ToString();
            }
            ViewData["CodAsesor"] = new SelectList(_context.Asesor, "CodAsesor", "FullName");
            ViewData["CodCarrera"] = new SelectList(_context.Carrera, "CodCarrera", "Carrera1");
            ViewData["CodCat"] = new SelectList(_context.CatTrabajoGraduacion, "CodCat", "Categoria");
            ViewData["CodTipotrabajo"] = new SelectList(_context.TipoTrabajo, "CodTipotrabajo", "Tipo");
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido");
            return View();
        }

        /*
        // GET: TrabajoGraduacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajoGraduacion = await _context.TrabajoGraduacion.FindAsync(id);
            if (trabajoGraduacion == null)
            {
                return NotFound();
            }
            ViewData["CodAsesor"] = new SelectList(_context.Asesor, "CodAsesor", "Apellido", trabajoGraduacion.CodAsesor);
            ViewData["CodCarrera"] = new SelectList(_context.Carrera, "CodCarrera", "Carrera1", trabajoGraduacion.CodCarrera);
            ViewData["CodCat"] = new SelectList(_context.CatTrabajoGraduacion, "CodCat", "Categoria", trabajoGraduacion.CodCat);
            ViewData["CodTipotrabajo"] = new SelectList(_context.TipoTrabajo, "CodTipotrabajo", "Tipo", trabajoGraduacion.CodTipotrabajo);
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido", trabajoGraduacion.CodUsuario);
            return View(trabajoGraduacion);
        }
        */

        /*
        // POST: TrabajoGraduacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodRegistro,Titulo,Año,RecursoDigital,TokenRecurso,Nota,NombreInstitucion,NombreAutor,ApellidoAutor,CarnetAutor,Observacion,CodCat,CodUsuario,CodAsesor,CodCarrera,CodTipotrabajo")] TrabajoGraduacion trabajoGraduacion)
        {
            if (id != trabajoGraduacion.CodRegistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajoGraduacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajoGraduacionExists(trabajoGraduacion.CodRegistro))
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
            ViewData["CodAsesor"] = new SelectList(_context.Asesor, "CodAsesor", "Apellido", trabajoGraduacion.CodAsesor);
            ViewData["CodCarrera"] = new SelectList(_context.Carrera, "CodCarrera", "Carrera1", trabajoGraduacion.CodCarrera);
            ViewData["CodCat"] = new SelectList(_context.CatTrabajoGraduacion, "CodCat", "Categoria", trabajoGraduacion.CodCat);
            ViewData["CodTipotrabajo"] = new SelectList(_context.TipoTrabajo, "CodTipotrabajo", "Tipo", trabajoGraduacion.CodTipotrabajo);
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido", trabajoGraduacion.CodUsuario);
            return View(trabajoGraduacion);
        }
        */
        /*
        // GET: TrabajoGraduacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajoGraduacion = await _context.TrabajoGraduacion
                .Include(t => t.CodAsesorNavigation)
                .Include(t => t.CodCarreraNavigation)
                .Include(t => t.CodCatNavigation)
                .Include(t => t.CodTipotrabajoNavigation)
                .Include(t => t.CodUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodRegistro == id);

            if (trabajoGraduacion == null)
            {
                return NotFound();
            }

            return View(trabajoGraduacion);
        }

        // POST: TrabajoGraduacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabajoGraduacion = await _context.TrabajoGraduacion.FindAsync(id);
            _context.TrabajoGraduacion.Remove(trabajoGraduacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //Envio de Alerta Controlador Vista
        [TempData]
        public string Mensaje { get; set; }
        */

        //BUSQUEDA NORMAL
        [Authorize]
        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Busqueda(int? pagina, string bookName)
        {
            var numeracionpagina = pagina ?? 1;
            var busqueda = (from p in _context.TrabajoGraduacion.Include(t => t.CodAsesorNavigation).Include(t => t.CodCarreraNavigation).Include(t => t.CodCatNavigation).Include(t => t.CodTipotrabajoNavigation).Include(t => t.CodUsuarioNavigation)
                            where p.RecursoDigital != null
                            orderby p.Titulo ascending
                            select p).ToList();

            if (!String.IsNullOrEmpty(bookName))
            {
                ViewBag.Empresa = bookName;

                busqueda = busqueda.Where(x => x.NombreAutor.ToLower().Contains(bookName.ToLower()) || x.NombreInstitucion.ToLower().Contains(bookName.ToLower()) || x.Titulo.ToLower().Contains(bookName.ToLower())
                || x.ApellidoAutor.ToLower().Contains(bookName.ToLower())).ToList();

            }
            var contenidopagina = busqueda.ToPagedList(numeracionpagina, 20);
            // Console.WriteLine("TrabajoGraduacion: 1 ");

          //  Mensaje = bookName;
            ViewBag.vista = busqueda;
            ViewData["Busqueda1"] = bookName;
            return View(contenidopagina);
        }

        [Authorize]
        //DETALLE BUSQUEDA USUARIO
        public async Task<IActionResult> DetailsTrabajo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trabajoGraduacion = await _context.TrabajoGraduacion
                .Include(t => t.CodAsesorNavigation)
                .Include(t => t.CodCarreraNavigation)
                .Include(t => t.CodCatNavigation)
                .Include(t => t.CodTipotrabajoNavigation)
                .Include(t => t.TrabajoPalabraClave)
                .ThenInclude(e=>e.CodPalabraClaveNavigation)
                .FirstOrDefaultAsync(m => m.CodRegistro == id);

            if (trabajoGraduacion == null)
            {
                return NotFound();
            }
            return PartialView("DetailsTrabajo", trabajoGraduacion);
        }

        [Authorize]
        public async Task<IActionResult> ListTrabajo()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> ListTesis()
        {
            return View();
        }

        //Listado de Trabajos de Graduacion
        [Authorize(Roles = "Administrador,Inventarista,Inventarista Trabajo")]
        [HttpPost]
        public ActionResult Json()
        {
            try
            {
                List<ViewModelTrabajo> list = new List<ViewModelTrabajo>();

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

                IQueryable<ViewModelTrabajo> query = (from e in _context.TrabajoGraduacion
                                                      join l in _context.TipoTrabajo on e.CodTipotrabajo equals l.CodTipotrabajo
                                                      where l.Tipo.Equals("Trabajo de Graduacion")
                                                     orderby e.CodRegistro descending
                                                     select new ViewModelTrabajo
                                                     {
                                                         CodRegistro = e.CodRegistro,
                                                         Titulo = e.Titulo,
                                                         Institucion = e.NombreInstitucion,
                                                         NombreAutor = e.NombreAutor,
                                                         ApellidoAutor = e.ApellidoAutor,
                                                         Año = e.Año,

                                                     });
                if (searchValue != "")
                {
                    query = query.Where(d => d.Titulo.Contains(searchValue));
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

        [Authorize(Roles = "Administrador,Inventarista,Inventarista Trabajo")]
        [HttpPost]
        public ActionResult Json1()
        {
            try
            {
                List<ViewModelTrabajo> list = new List<ViewModelTrabajo>();

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

                IQueryable<ViewModelTrabajo> query = (from e in _context.TrabajoGraduacion
                                                      join l in _context.TipoTrabajo on e.CodTipotrabajo equals l.CodTipotrabajo
                                                      where l.Tipo.Equals("Tesis")
                                                      orderby e.CodRegistro descending
                                                      select new ViewModelTrabajo
                                                      {
                                                          CodRegistro = e.CodRegistro,
                                                          Titulo = e.Titulo,
                                                          Institucion = e.NombreInstitucion,
                                                          NombreAutor = e.NombreAutor,
                                                          ApellidoAutor = e.ApellidoAutor,
                                                          Año = e.Año,

                                                      });
                if (searchValue != "")
                {
                    query = query.Where(d => d.Titulo.Contains(searchValue));
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




        private bool TrabajoGraduacionExists(int id)
        {
            return _context.TrabajoGraduacion.Any(e => e.CodRegistro == id);
        }
    }
}

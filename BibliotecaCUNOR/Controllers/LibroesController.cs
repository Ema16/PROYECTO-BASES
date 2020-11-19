using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaCUNOR.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using X.PagedList;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaCUNOR.Controllers
{
   
    public class LibroesController : Controller
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

        public LibroesController(bd_bibliotecaContext context)
        {
            _context = context;
        }

        // GET: Libroes
        [Authorize]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        /*
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
        */
        // GET: Libroes/Create
        [Authorize(Roles = "Administrador,Inventarista")]
        public IActionResult Create()
        {
            if (TempData["mensajeLibro"] != null)
            {
                ViewBag.mensajeLi = TempData["mensajeLibro"].ToString();
            }
            // ViewData["CodClasificacion"] = new SelectList(_context.Clasificacion, "CodClasificacion", "Clase");
            ViewData["CodClasificacion"] = new SelectList(_context.Clasificacion, "CodClasificacion", "ClasificacionFull");
            ViewData["CodEditorial"] = new SelectList(_context.Editorial, "CodEditorial", "Nombre");
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido");
            //   ViewData["CodAutor"] = new SelectList(_context.Autor,"CodAutor","Nombre"); FullName
            ViewData["CodAutor"] = new SelectList(_context.Autor, "CodAutor", "FullName");
            ViewData["CodEdicion"] = new SelectList(_context.Edicion, "CodEdicion", "Edicion1");
            return View();
        }

        // POST: Libroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador,Inventarista")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodLibro,Clave,Titulo,Costo,Estado,Ejemplares,Paginas,Volumen,FechaRegistro,CodEditorial,CodUsuario,CodClasificacion,Observacion,EdicionLibro,MultiAutores")] Libro libro)
        {
            var user = _context.Usuario.Where(t => t.CorreoElectronico == User.Identity.Name).FirstOrDefault();
            if (ModelState.IsValid)
            {
                foreach (var c in libro.MultiAutores)
                {
                    libro.LibroAutor.Add(new LibroAutor {CodAutor=c });
                }

                libro.CodUsuario = user.CodUsuario;
                libro.Estado = "Disponible";
                libro.Clave = "15H-"+libro.Clave ;
                libro.FechaRegistro = DateTime.Today;
                _context.Add(libro);

                await _context.SaveChangesAsync();
                TempData["mensajeLibro"] = "Creado!";
                return RedirectToAction("Create", "Libroes");
            }
            ViewData["CodClasificacion"] = new SelectList(_context.Clasificacion, "CodClasificacion", "ClasificacionFull");
            ViewData["CodEditorial"] = new SelectList(_context.Editorial, "CodEditorial", "Nombre");
            ViewData["CodUsuario"] = new SelectList(_context.Usuario, "CodUsuario", "Apellido");
            //   ViewData["CodAutor"] = new SelectList(_context.Autor,"CodAutor","Nombre"); FullName
            ViewData["CodAutor"] = new SelectList(_context.Autor, "CodAutor", "FullName");
            ViewData["CodEdicion"] = new SelectList(_context.Edicion, "CodEdicion", "Edicion1");
            return View(libro);
        }

        /*
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
        */
        // POST: Libroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /*
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
        */



        //BUSQUEDA NORMAL
        [Authorize]
        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Busqueda(int? pagina, string bookName, int parametro)
        {
            var numeracionpagina = pagina ?? 1;

            if(parametro != 0)
            {
                var busqueda1 = (from p in _context.Libro
                                join z in _context.LibroAutor on p.CodLibro equals z.CodLibro
                                where z.CodAutor == parametro
                                orderby p.Titulo ascending
                                select p).ToList();
                var contenidopagina = busqueda1.ToPagedList(numeracionpagina, 20);
                ViewBag.vista = busqueda1;
                return View(contenidopagina);
            }
            else
            {
                var busqueda = (from p in _context.Libro.Include(l => l.CodClasificacionNavigation).Include(l => l.CodEditorialNavigation).Include(l => l.CodUsuarioNavigation)
                                where p.Titulo != null
                                orderby p.Titulo ascending
                                select p).ToList();

                if (!String.IsNullOrEmpty(bookName))
                {
                    ViewBag.Empresa = bookName;

                    busqueda = busqueda.Where(x => x.Titulo.ToLower().Contains(bookName.ToLower()) || x.Clave.ToLower().Contains(bookName.ToLower())).ToList();

                }
                var contenidopagina = busqueda.ToPagedList(numeracionpagina, 20);
                // Console.WriteLine("TrabajoGraduacion: 1 ");
                ViewData["Busqueda"] = bookName;
                ViewBag.vista = busqueda;

                return View(contenidopagina);
            }
           
        }

        // GET: Libroes/Details/5
        [Authorize]
        public async Task<IActionResult> DetailsLibro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libro
                .Include(l => l.CodClasificacionNavigation)
                .Include(l => l.CodEditorialNavigation)
                .Include(l => l.CodUsuarioNavigation)
                .Include(l => l.Observacion)
                .Include(l => l.LibroAutor)
                .ThenInclude(l => l.CodAutorNavigation)
                .Include(l => l.EdicionLibro)
                .ThenInclude(l => l.CodEdicionNavigation)
                .FirstOrDefaultAsync(m => m.CodLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return PartialView("DetailsLibro", libro);
        }


        [Authorize(Roles = "Administrador,Inventarista")]
        public async Task<IActionResult> Listlibros()
        {
            return View();
        }

        [Authorize(Roles = "Administrador,Inventarista")]
        [AcceptVerbs("GET", "POST")]
        public JsonResult ObtenerInformacion1()
        {
            List<ViewModelLibros> lst;

            lst = ((from e in _context.Libro
                    join d in _context.Editorial on e.CodEditorial equals d.CodEditorial
                    join i in _context.EdicionLibro on e.CodLibro equals i.CodLibro
                    join l in _context.Edicion on i.CodEdicion equals l.CodEdicion
                    select new ViewModelLibros
                    {
                        CodLibro = e.CodLibro,
                        Clave = e.Clave,
                        Titulo = e.Titulo,
                        Ejemplares = e.Ejemplares,
                        Editorial = d.Nombre,
                        Edicion = l.Edicion1,

                    })).ToList();
            return Json(lst);

        }


        //Libros del Sistema
        [Authorize(Roles = "Administrador,Inventarista")]
        [HttpPost]
        public ActionResult Json()
        {
            try
            {
                List<ViewModelLibros> list = new List<ViewModelLibros>();

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

                IQueryable<ViewModelLibros> query = (from e in _context.Libro
                                               join d in _context.Editorial on e.CodEditorial equals d.CodEditorial
                                               join i in _context.EdicionLibro on e.CodLibro equals i.CodLibro
                                               join l in _context.Edicion on i.CodEdicion equals l.CodEdicion
                                               orderby e.Clave descending
                                               select new ViewModelLibros
                                               {
                                                   CodLibro = e.CodLibro,
                                                   Clave = e.Clave,
                                                   Titulo = e.Titulo,
                                                   Ejemplares = e.Ejemplares,
                                                   Editorial = d.Nombre,
                                                   Edicion = l.Edicion1,

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


        private bool LibroExists(int id)
        {
            return _context.Libro.Any(e => e.CodLibro == id);
        }

    }
}

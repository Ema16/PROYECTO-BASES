using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaCUNOR.Models;
using System.Net.Mail;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaCUNOR.Controllers
{
    
    public class UsuariosController : Controller
    {
        
        //Atributos para el JSON
        public string draw = "";
        public string start = "";
        public string length = "";
        public string sortColumn = "";
        public string sortColumnDir = "";
        public string searchValue = "";
        public int pageSize, skip, recordsTotal;

        string urlDomain = "http://178.128.0.56/";
        private readonly bd_bibliotecaContext _context;

        public UsuariosController(bd_bibliotecaContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var user = User.Identity.Name;
            ModelosIndex datos = new ModelosIndex();
            var countAdmin = (from e in _context.Usuario
                        where e.CodRolusuarioNavigation.Rol.Equals("Administrador")
                           select e).Count();

            var countEs = (from e in _context.Usuario
                              where e.CodTipousuarioNavigation.Tipo.Equals("Estudiante")
                           select e).Count();

            var countPer = (from e in _context.Usuario
                           where e.CodTipousuarioNavigation.Tipo.Equals("Empleado CUNOR")
                            select e).Count();

            var countDev = (from e in _context.DetPrestamo
                            where e.Estado.Equals("Ocupado") && e.CodPrestamoNavigation.CodUsuarioNavigation.CorreoElectronico == user
                            select e).Count();

            var countPre = (from e in _context.Prestamo
                            where e.CodUsuarioNavigation.CorreoElectronico==user
                            select e).Count();

            var countAutores = (from e in _context.Autor
                            select e).Count();

            var countDevGe = (from e in _context.DetPrestamo
                            where e.Estado.Equals("Ocupado")
                            select e).Count();

            var countLibros = (from e in _context.Libro
                                select e).Count();

            var countTotalPre = (from e in _context.Prestamo
                              select e).Count();

            var counttraba = (from e in _context.TrabajoGraduacion
                                 select e).Count();

            var countTotalAses = (from e in _context.Asesor
                                 select e).Count();


            if (TempData["mensaje"] != null)
            {
                ViewBag.mensaje = TempData["mensaje"].ToString();
            }


            datos.Administradors.Add(new Administrador { countAdmin = countAdmin , countEstu=countEs, countPersonal=countPer});
            datos.Estudiantes.Add(new Estudiante { countDevPen = countDev, countPres = countPre });
            datos.Bibliotecarios.Add(new Bibliotecario {countAutores = countAutores, countLibros = countLibros, countDevPen = countDevGe, countPresGe = countTotalPre });
            datos.Inventaristas.Add(new Inventarista { countLibro = countLibros, countAsesores = countTotalAses, countTraba = counttraba, countAutor = countAutores });
            //var bd_bibliotecaContext = _context.Usuario.Include(u => u.CodCarreraNavigation).Include(u => u.CodRolusuarioNavigation).Include(u => u.CodTipousuarioNavigation);
            // return View(await bd_bibliotecaContext.ToListAsync());
            return View(datos);
        }


        //Validacion de Carnet
        
        [AcceptVerbs("GET", "POST")]
        public JsonResult VerificarUsuario(int Usuario1)
        {
            if (_context.Usuario.Any(u => u.Usuario1 == Usuario1))
            {
                return Json($"Carnet {Usuario1} ya existe");
            }
            return Json(true);

        }

        //Action si el correo ya existe
        [AcceptVerbs("GET", "POST")]
        public JsonResult VerificarCorreo(string CorreoElectronico)
        {
            if (_context.Usuario.Any(u => u.CorreoElectronico == CorreoElectronico))
            {
                return Json($"Correo {CorreoElectronico} ya existe");
            }
            //devuleve true si encuentra alguna coincidencia
            return Json(true);

        }



        //Usuarios del sistema
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Json()
        {
            try
            {
                List<Usuario> lst = new List<Usuario>();

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

                IQueryable<Usuario> query = (from d in _context.Usuario
                       select new Usuario
                       {
                           CodUsuario = d.CodUsuario,
                           Nombre = d.Nombre,
                           Apellido = d.Apellido,
                           CorreoElectronico=d.CorreoElectronico,
                           Usuario1 = d.Usuario1,
                           Telefono = d.Telefono,
                       });
                if (searchValue != "")
                {
                    query = query.Where(d => d.Nombre.Contains(searchValue) );
                }
                       
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    query = query.OrderBy(sortColumn + " " + sortColumnDirection);
                }

                recordsTotal = query.Count();
                lst = query.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = lst });

            }
            catch ( Exception ex)
            {
                throw;
            }
           
        }

        //Personal Administrativo del sistema
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult JsonPersonal()
        {
            try
            {
                List<Usuario> lst = new List<Usuario>();

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

                IQueryable<Usuario> query = (from d in _context.Usuario
                                             join l in _context.Cargo on d.CodCargo equals l.CodCargo
                                             where d.CodTipousuarioNavigation.Tipo.Equals("Empleado CUNOR")
                                             select new Usuario
                                             {
                                                 CodUsuario = d.CodUsuario,
                                                 Usuario1 = d.Usuario1,
                                                 Apellido = d.Apellido,
                                                 Nombre = d.Nombre,
                                                 CorreoElectronico = d.CorreoElectronico,
                                                 cargo1 = l.Cargo1,
                                                 Telefono = d.Telefono,
                                                 Estado = d.Estado,
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


        //Administradores del sistema
        [Authorize(Roles = "Administrador")]
        [AcceptVerbs("GET","POST")]
        public ActionResult JsonAdministrador()
        {
            try
            {
                List<Usuario> lst = new List<Usuario>();

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

                IQueryable<Usuario> query = (from d in _context.Usuario
                                             where d.CodRolusuarioNavigation.Rol.Equals("Administrador")
                                             select new Usuario
                                             {
                                                 CodUsuario = d.CodUsuario,
                                                 Usuario1 = d.Usuario1,
                                                 Apellido = d.Apellido,
                                                 Nombre = d.Nombre,
                                                 CorreoElectronico = d.CorreoElectronico,
                                                 Telefono = d.Telefono,
                                                 Estado = d.Estado,
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

        /*
        // GET: Usuarios/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.CodCarreraNavigation)
                .Include(u => u.CodRolusuarioNavigation)
                .Include(u => u.CodTipousuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }
        */

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["CodCarrera"] = new SelectList(_context.Carrera, "CodCarrera", "Carrera1");
            ViewData["CodRolusuario"] = new SelectList(_context.RolUsuario, "CodRolusuario", "Rol");
            ViewData["CodTipousuario"] = new SelectList(_context.TipoUsuario, "CodTipousuario", "Tipo");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodUsuario,Nombre,Apellido,CorreoElectronico,Contraseña,Contraseña2,Usuario1,Telefono,Foto,ActivarUsuario,Estado,CodRolusuario,CodCarrera,CodCargo,CodTipousuario,RecContraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.CodTipousuario ==2 )
                { //Empleado CUNOR
                    usuario.CodRolusuario = 4;
                    usuario.CodCarrera = null;
                }
                if(usuario.CodTipousuario==1)
                {
                    //Usario
                    usuario.CodRolusuario = 4;
                }

                usuario.Estado = "Activo";
                usuario.Contraseña = Crypto.Hash(usuario.Contraseña);
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                var rol = _context.RolUsuario.FirstOrDefault(e => e.CodRolusuario == usuario.CodRolusuario);
                var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, usuario.CorreoElectronico), new Claim(ClaimTypes.Role, rol.Rol),
                        new Claim(ClaimTypes.NameIdentifier, ""+usuario.CodUsuario)
                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                TempData["mensaje"] = "Usuario Creado!";
                return RedirectToAction("Index", "Usuarios");

            }
            ViewData["CodCarrera"] = new SelectList(_context.Carrera, "CodCarrera", "Carrera1", usuario.CodCarrera);
            ViewData["CodRolusuario"] = new SelectList(_context.RolUsuario, "CodRolusuario", "Rol", usuario.CodRolusuario);
            ViewData["CodTipousuario"] = new SelectList(_context.TipoUsuario, "CodTipousuario", "Tipo", usuario.CodTipousuario);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
        
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _context.Usuario.Include(t => t.CodCarreraNavigation)
                                             .Include(t => t.CodTipousuarioNavigation)
                                             .Include(t => t.CodRolusuarioNavigation)
                                             .FirstOrDefault(t => t.CodUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["CodRolusuario"] = new SelectList(_context.RolUsuario, "CodRolusuario", "Rol", usuario.CodRolusuario);
            ViewData["CodTipousuario"] = new SelectList(_context.TipoUsuario, "CodTipousuario", "Tipo", usuario.CodTipousuario);
            return PartialView("Edit", usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            var usuario1 = _context.Usuario.Where(t => t.CodUsuario == usuario.CodUsuario).FirstOrDefault();
            if (usuario.CodRolusuario != 0 && usuario.CodTipousuario!=0)
            {
                usuario1.CodRolusuario = usuario.CodRolusuario;
                usuario1.CodTipousuario = usuario.CodTipousuario;
                _context.Update(usuario1);
                await _context.SaveChangesAsync();
            }
            TempData["mensajeActualizacion"] = "Actualizado!";
            return RedirectToAction("UsuariosBiblioteca");
        }

        /*
        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.CodCarreraNavigation)
                .Include(u => u.CodRolusuarioNavigation)
                .Include(u => u.CodTipousuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }
        */
        /*

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.CodUsuario == id);
        }

        */

        //Administradores
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Administrador()
        {
            ViewData["CodRolusuario"] = new SelectList(_context.RolUsuario, "CodRolusuario", "Rol");

            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Personal()
        {

            ViewData["CodRolusuario"] = new SelectList(_context.RolUsuario, "CodRolusuario", "Rol");
            ViewData["CodCargo"] = new SelectList(_context.Cargo, "CodCargo", "Cargo1");

            return View();
        }


        //Detalle De Usuario
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> UsuarioDetalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.CodCarreraNavigation)
                .Include(u => u.CodRolusuarioNavigation)
                .Include(u => u.CodTipousuarioNavigation)
                .FirstOrDefaultAsync(m => m.CodUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return PartialView("UsuarioDetalle", usuario);
        }


        //Habilitar Deshabilitar Usuarios
        [Authorize(Roles = "Administrador")]
        [AcceptVerbs("GET","POST")]
        public async Task<IActionResult> EstadoUsuario(int? id)
        {
            var estadousuario = _context.Usuario.Where(w => w.CodUsuario == id).FirstOrDefault();

            if (id == null)
            {
                return NotFound();
            }

            if (estadousuario.Estado.Equals("Activo"))
            {
                estadousuario.Estado = "Inactivo";
                await _context.SaveChangesAsync();
            }
            else if(estadousuario.Estado.Equals("Inactivo"))
            {
                estadousuario.Estado = "Activo";
                await _context.SaveChangesAsync();
            }

            return PartialView("EstadoUsuario", estadousuario);
        }


        //LOGIN
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            bd_bibliotecaContext db = new bd_bibliotecaContext();
            var usuario = db.Usuario.FirstOrDefault(e => e.CorreoElectronico == email);
            if (usuario != null)
            {
                if (string.Compare(Crypto.Hash(password), usuario.Contraseña) == 0)
                {
                    var rol = db.RolUsuario.FirstOrDefault(e => e.CodRolusuario == usuario.CodRolusuario);
                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, usuario.CorreoElectronico), new Claim(ClaimTypes.Role, rol.Rol),
                        new Claim(ClaimTypes.NameIdentifier, ""+usuario.CodUsuario)
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Usuarios");
                }
                else
                {
                    TempData["mensaje"] = "Datos erróneos. Por favor, inténtelo nuevamente!";
                    return RedirectToAction("Index","Home");
                }
            }
            else
            {
                 TempData["mensaje"] = "Datos erróneos. Por favor, inténtelo nuevamente!";
                return RedirectToAction("Index","Home");
            }
        }

        //LOGOUT
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout(string j)
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }



        //Recuperar Contraseña-cuando enviamos el correo

        [HttpPost]
        public async Task<IActionResult> StartRecovery(string correo)
        {
            if (ModelState.IsValid)
            {
                bd_bibliotecaContext bd = new bd_bibliotecaContext();
                var user = bd.Usuario.Where(w => w.CorreoElectronico == correo).FirstOrDefault();
                if (user != null)
                {
                    string token = Crypto.Hash(Guid.NewGuid().ToString());
                    user.RecContraseña = token;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    EnviarCorreo(user.CorreoElectronico, token);
                    

                    TempData["mensaje1"] = "Se ha enviado la informacion de recuperacion de contraseña a su correo Electronico!";
                    return RedirectToAction("Index", "Home");
                    //return RedirectToAction(nameof(Index));
                    //enviar correo

                }
                else
                {
                    TempData["mensaje"] = "No se ha podido encontrar tu cuenta. Por favor, inténtelo nuevamente!";
                    return RedirectToAction("Index", "Home");
                }
                

            }

            return View();
        }


        [HttpGet]
        public ActionResult StartRecovery()
        {
            return View();
        }

        //Cuando ya cambiamos la contraseña
        [HttpPost]
        public async Task<IActionResult> Recovery(RecoveryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _context.Usuario.Where(d => d.RecContraseña == model.token).FirstOrDefault();
                    if (user != null)
                    {
                        user.Contraseña = Crypto.Hash(model.Password);
                        user.RecContraseña = null;
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        //Mensaje = "Este token ha Expirado";
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult Recovery(string token)
        {
            RecoveryViewModel model = new RecoveryViewModel();
            model.token = token;
            if (model.token == null || model.token.Trim().Equals(""))
            {
                //Mensaje = "Token Vencido";
                return View("Index");
            }
            var user = _context.Usuario.Where(d => d.RecContraseña == model.token).FirstOrDefault();
            if (user != null)
            {
                return View(model);

            }
            else
            {
               // Mensaje = "Token Vencido";
                return View("Index");
            }

        }

        #region
        //Método para el envio del correo de cambio de contraseña
        private void EnviarCorreo(string CorreoDestino, string token)
        {
            string CorreoOrigen = "chubjonathan1998@gmail.com";
            string Contraseña = "jonathanfranciscod09";
            string url = urlDomain + "Home/Recovery/?token=" + token;
            MailMessage oMailMessage = new MailMessage(CorreoOrigen, CorreoDestino, "Recuperar Contraseña",
                "<p>Correo para recuperacion de contraseña<p><br>" +
                "<a href='" + url + "'>Click para reucperar</a>");
            oMailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(CorreoOrigen, Contraseña);

            smtpClient.Send(oMailMessage);
            smtpClient.Dispose();
        }
        #endregion




        //Verificar Correo
        //Action si el correo ya existe
        [AcceptVerbs("GET", "POST")]
        public JsonResult VerificarCorreo1(string CorreoElectronico)
        {
            if (_context.Usuario.Any(u => u.CorreoElectronico == CorreoElectronico))
            {
                return Json($"Este Correo {CorreoElectronico} No existe");
            }
            //devuleve true si encuentra alguna coincidencia
            return Json(true);
        }

        //Lista Administradores
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> Listadmin()
        {
            return View();
        }


        //Lista Personal Administrativo
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Listpersonal()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult UsuariosBiblioteca()
        {
            if (TempData["mensajeActualizacion"] != null)
            {
                ViewBag.mensajeActu = TempData["mensajeActualizacion"].ToString();
            }

            return View();
        }

    }
}

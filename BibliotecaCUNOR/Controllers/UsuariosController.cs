using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaCUNOR.Models;
using System.Net.Mail;

namespace BibliotecaCUNOR.Controllers
{
    public class UsuariosController : Controller
    {
        string urlDomain = "https://localhost:44382/";
        private readonly bd_bibliotecaContext _context;

        public UsuariosController(bd_bibliotecaContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var bd_bibliotecaContext = _context.Usuario.Include(u => u.CodCarreraNavigation).Include(u => u.CodRolusuarioNavigation).Include(u => u.CodTipousuarioNavigation);
            return View(await bd_bibliotecaContext.ToListAsync());
        }

        //Envio de Alerta Controlador Vista
        [TempData]
        public string Mensaje { get; set; }

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


        // GET: Usuarios/Details/5
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
                usuario.Contraseña = Crypto.Hash(usuario.Contraseña);
                usuario.Estado = "Inactivo";
                usuario.CodRolusuario = 4;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodCarrera"] = new SelectList(_context.Carrera, "CodCarrera", "Carrera1", usuario.CodCarrera);
            ViewData["CodRolusuario"] = new SelectList(_context.RolUsuario, "CodRolusuario", "Rol", usuario.CodRolusuario);
            ViewData["CodTipousuario"] = new SelectList(_context.TipoUsuario, "CodTipousuario", "Tipo", usuario.CodTipousuario);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["CodCarrera"] = new SelectList(_context.Carrera, "CodCarrera", "Carrera1", usuario.CodCarrera);
            ViewData["CodRolusuario"] = new SelectList(_context.RolUsuario, "CodRolusuario", "Rol", usuario.CodRolusuario);
            ViewData["CodTipousuario"] = new SelectList(_context.TipoUsuario, "CodTipousuario", "Tipo", usuario.CodTipousuario);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodUsuario,Nombre,Apellido,CorreoElectronico,Contraseña,Usuario1,Telefono,Foto,ActivarUsuario,Estado,CodRolusuario,CodCarrera,CodCargo,CodTipousuario,RecContraseña")] Usuario usuario)
        {
            if (id != usuario.CodUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.CodUsuario))
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
            ViewData["CodCarrera"] = new SelectList(_context.Carrera, "CodCarrera", "Carrera1", usuario.CodCarrera);
            ViewData["CodRolusuario"] = new SelectList(_context.RolUsuario, "CodRolusuario", "Rol", usuario.CodRolusuario);
            ViewData["CodTipousuario"] = new SelectList(_context.TipoUsuario, "CodTipousuario", "Tipo", usuario.CodTipousuario);
            return View(usuario);
        }

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

    }
}

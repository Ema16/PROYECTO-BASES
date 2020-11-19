using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BibliotecaCUNOR.Models;
using System.Net.Mail;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibliotecaCUNOR.Controllers
{
    public class HomeController : Controller
    {
        string urlDomain = "https://localhost:44382/";
        private readonly ILogger<HomeController> _logger;
        private readonly bd_bibliotecaContext _context;

        public HomeController(ILogger<HomeController> logger, bd_bibliotecaContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (TempData["mensaje"]!=null)
            {
                ViewBag.mensaje = TempData["mensaje"].ToString();
            }

            if (TempData["mensaje1"]!=null)
            {
                ViewBag.mensaje1 = TempData["mensaje1"].ToString();
            }

            ViewData["CodCarrera"] = new SelectList(_context.Carrera, "CodCarrera", "Carrera1");
            ViewData["CodRolusuario"] = new SelectList(_context.RolUsuario, "CodRolusuario", "Rol");
            ViewData["CodTipousuario"] = new SelectList(_context.TipoUsuario, "CodTipousuario", "Tipo");
            return View();
        }


        [TempData]
        public string Mensaje { get; set; }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Error1()
        {
            
            return View();
        }


        //Esto se mostrara siempre y cuando estemos autenticados
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult SecretRoleAdministrador()
        {
            return View("Secret");
        }


        [Authorize(Roles = "Estudiante")]
        public IActionResult SecretRoleEstudiante()
        {
            return View("Secret");
        }


        public IActionResult Authenthicate()
        {
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Authenthicate1()
        {
            return RedirectToAction("Index","Usuarios");
        }


        //Action si el correo ya existe
        [AcceptVerbs("GET", "POST")]
        public JsonResult VerificarCorreo(string CorreoElectronico)
        {
            if (_context.Usuario.Any(u => u.CorreoElectronico == CorreoElectronico))
            {
                return Json($"Este Correo {CorreoElectronico} No existe");
            }
            //devuleve true si encuentra alguna coincidencia
            return Json(true);
        }

    }
}

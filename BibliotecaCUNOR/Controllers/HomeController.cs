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
            return View();
        }


        [TempData]
        public string Mensaje { get; set; }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            bd_bibliotecaContext db = new bd_bibliotecaContext();
            var usuario = db.Usuario.FirstOrDefault(e => e.CorreoElectronico == login.Correo);
            if (usuario != null)
            {
                if (string.Compare(Crypto.Hash(login.Contraseña), usuario.Contraseña) == 0)
                {
                    var rol = db.RolUsuario.FirstOrDefault(e => e.CodRolusuario == usuario.CodRolusuario);
                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, usuario.CorreoElectronico), new Claim(ClaimTypes.Role, rol.Rol)
                        }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Secret", "Home");
                }
                else
                {
                    Mensaje = "Contraseña Incorrecta";
                    return RedirectToAction("Login");
                }
            }
            else
            {
                Mensaje = "Usuario No Encontrado";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout(string j)
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

        //Recuperar Contraseña-cuando enviamos el correo

        [HttpPost]
        public async Task<IActionResult> StartRecovery(StartRecoveryViewModel model)
        {
            if (ModelState.IsValid)
            {
                bd_bibliotecaContext bd = new bd_bibliotecaContext();
                var user = bd.Usuario.Where(w => w.CorreoElectronico == model.CorreoElectornico).FirstOrDefault();
                if (user != null)
                {
                    string token = Crypto.Hash(Guid.NewGuid().ToString());
                    user.RecContraseña = token;
                    _context.Update(user);
                    EnviarCorreo(user.CorreoElectronico, token);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                    //enviar correo
                    
                }
                Mensaje = "Usuario No Encontrado";
                return View(model);

            }

            return View(model);
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
                        Mensaje = "Este token ha Expirado";
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
                Mensaje = "Token Vencido";
                return View("Index");
            }
            var user = _context.Usuario.Where(d => d.RecContraseña == model.token).FirstOrDefault();
            if (user !=null)
            {
                return View(model);

            }
            else
            {
                Mensaje = "Token Vencido";
                return View("Index");
            }
           
        }

        #region
        //Método para el envio del correo de cambio de contraseña
        private void EnviarCorreo(string CorreoDestino, string token)
        {
            string CorreoOrigen = "chubjonathan1998@gmail.com";
            string Contraseña = "jonathanfranciscod09";
            string url = urlDomain + "Home/Recovery/?token="+token;
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

    }
}

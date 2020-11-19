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

namespace BibliotecaCUNOR.Controllers
{
    public class ReporteController : Controller
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
        public ReporteController(bd_bibliotecaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reporte()
        {
            return View();
        }

        public IActionResult ReportePrestamo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Json(string tipo, string inicio, string final)
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
                                                   CodPrestamo = i.CodPrestamo,
                                                   Libro = d.Titulo,
                                                   NombreUsuario = h.Nombre,
                                                   Tipo = i.Tipo,
                                                   FechaSolicitud = i.FechaPrestamo,
                                                   FechaRecepcion = i.FechaRecepcion,

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
    }
}

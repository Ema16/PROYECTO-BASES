using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace BibliotecaCUNOR.Controllers
{
    public class CrearPDFController : Controller
    {
        // GET: CrearPDF
        public ActionResult Index()
        {
            string Name = "Emanuel Amperez Tahuico";
            return new ViewAsPdf("ReportePerdida")
            { 
         
                // FileName = Name + ".pdf"
            };
        }

        // GET: CrearPDF/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CrearPDF/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrearPDF/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CrearPDF/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CrearPDF/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CrearPDF/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CrearPDF/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

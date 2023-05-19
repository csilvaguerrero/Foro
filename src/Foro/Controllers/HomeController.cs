using Foro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foro.Controllers
{
    public class HomeController : Controller
    {
        ForoEntities db = new ForoEntities();
        public ActionResult Index()
        {
            List<Preguntas> preguntas = db.Preguntas.ToList();

            return View("Pantalla", preguntas);
        }
        
    }
}
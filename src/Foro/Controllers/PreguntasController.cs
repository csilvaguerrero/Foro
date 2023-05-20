using Foro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foro.Controllers
{
    public class PreguntasController : Controller
    {
        ForoEntities bd = new ForoEntities();
        public ActionResult Index()
        {
            return View();
        }

        public int ContarPreguntas(int idCategoria)
        {
            List<Preguntas> preguntas = bd.Preguntas.Where(x => x.idCategoria == idCategoria).ToList();            

            return preguntas.Count;
        }

        public List<Preguntas> ListarPreguntas()
        {
            List<Preguntas> preguntas = bd.Preguntas.ToList();

            return preguntas;
        }
    }
}
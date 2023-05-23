using Foro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foro.Controllers
{
    public class CategoriaController : Controller
    {
        ForoEntities bd = new ForoEntities();
        public ActionResult Index()
        {
            return View();
        }

        public List<Categorias> ListarCategorías()
        {
            List<Categorias> categorias = bd.Categorias.ToList();

            return categorias;

        }

        public ActionResult VerCategoria(int idCategoria, string categoria)
        {
            List<Preguntas> preguntas = new PreguntasController().ListarPreguntas();
            
            preguntas = preguntas.Where(x => x.idCategoria == idCategoria).ToList();

            return View("VerCategoria", new Tuple<List<Preguntas>, string>(preguntas, categoria));
            //return View("~/Views/Categoria/VerCategoria.cshtml", new Tuple<List<Preguntas>, string>(preguntas, categoria));
        }
    }
}
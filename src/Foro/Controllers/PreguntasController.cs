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

        public ActionResult VerPregunta(int idPregunta)
        {
            Preguntas pregunta = bd.Preguntas.FirstOrDefault(x => x.idPregunta == idPregunta);

            return View(pregunta);
        }

        public ActionResult AñadirPregunta()
        {
            if (Session["usuario"] == null)
            {                
                ViewBag.ruta = "~/Views/Preguntas/AñadirPregunta.cshtml";
                return View("~/Views/Login/InicioSesion.cshtml");
            }
            else
            {
                return View("AñadirPregunta");
            }            
        }

        [HttpPost]
        public ActionResult AñadirPregunta(string titulo, int idCategoria, string descripcion)
        {
            Categorias categoria = bd.Categorias.FirstOrDefault(x => x.idCategoria == idCategoria);            

            Preguntas pregunta = new Preguntas();                                  

            int idUsu = ((Usuarios)Session["usuario"]).idUsuario;

            pregunta.titulo = titulo;
            pregunta.descripcion = descripcion;
            pregunta.fechaPublicacion = DateTime.Now;
            pregunta.idCategoria = (byte)idCategoria;
            pregunta.idUsuario = (byte)idUsu;
            
            bd.Preguntas.Add(pregunta);
            bd.SaveChanges();

            return RedirectToAction("VerPregunta", new {idPregunta = pregunta.idPregunta});
            //Tuple<List<Preguntas>, string> datos = new CategoriaController().VerCategoria(idCategoria, categoria.nombre.ToString());

            //return View("~/Views/Home/VistaInicio.cshtml");
            //return View("~/Views/Categoria/VerCategoria.cshtml", datos);
            //return View(new CategoriaController().VerCategoria(idCategoria, cat.nombre.ToString()));
            // return View("~/Views/Categoria/VerCategoria.cshtml",new CategoriaController().VerCategoria(idCategoria, cat.nombre.ToString()));
        }

        public List<Preguntas> HilosMasRespondidos()
        {
            List<Preguntas> preguntas = bd.Preguntas.OrderBy(x => x.Comentarios.Count).ToList();

            return preguntas;
        }
    }
}
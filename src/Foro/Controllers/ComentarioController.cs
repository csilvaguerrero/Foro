using Foro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foro.Controllers
{
    public class ComentarioController : Controller
    {        
        ForoEntities db = new ForoEntities();
        public ActionResult Index()
        {
            return View();
        }

        public List<Comentarios> ListarComentarios()
        {
            List<Comentarios> comentarios = db.Comentarios.ToList();

            return comentarios;
        }

        [HttpPost]
        public ActionResult CrearComentario(string descripcion)
        {
            Comentarios comentario = new Comentarios();

            comentario.descripcion = descripcion;
            comentario.fechaPublicacion = DateTime.Now;
            comentario.idPregunta

            return View();
        }
    }
}
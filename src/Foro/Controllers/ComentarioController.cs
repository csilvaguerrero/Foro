using Foro.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
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
        public ActionResult CrearComentario(string descripcion, int idPregunta, int idUsuario)
        {
            Comentarios comentario = new Comentarios();

            comentario.descripcion = descripcion;
            comentario.fechaPublicacion = DateTime.Now;
            comentario.idPregunta = Convert.ToInt16(idPregunta);
            comentario.idUsuario = (byte)idUsuario;

            db.Comentarios.Add(comentario);
            db.SaveChanges();
            
            return new PreguntasController().VerPregunta(comentario.idPregunta);            
        }
    }
}
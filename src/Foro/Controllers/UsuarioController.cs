using Foro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foro.Controllers
{
    public class UsuarioController : Controller
    {        
        ForoEntities db = new ForoEntities();
        public ActionResult Index()
        {
            return View();
        }

        public List<Usuarios> ListarUsuarios()
        {
            List<Usuarios> usuario = db.Usuarios.ToList();

            return usuario;
        }

        public ActionResult MiPerfil()
        {
            return View();
        }

        public string GetRango(int idUsuario)
        {
            Usuarios usu = db.Usuarios.FirstOrDefault(x => x.idUsuario == idUsuario);
            string rol = "";

            switch (usu.rol)
            {
                case "b":
                    {
                        rol = "Bronce";
                        break;
                    }
                case "p":
                    {
                        rol = "Plata";
                        break;
                    }
                case "o":
                    {
                        rol = "Oro";
                        break;
                    }
            }
            return rol;
        }

        [HttpGet]
        public JsonResult DevolverDato()
        {
            int datos = 0;

            if (Session["usuario"] != null)
            {
                int idUsuario = ((Usuarios)Session["usuario"]).idUsuario;

                List<Preguntas> preguntas = db.Preguntas.Where(x => x.idUsuario == idUsuario).ToList();
                List<Comentarios> comentarios = db.Comentarios.Where(x => x.idUsuario == idUsuario).ToList();

                datos = preguntas.Count + comentarios.Count;               
            }
            else
            {
                datos = 0;
            }            
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CambiarRol(int datos)
        {
            int idUsuario = ((Usuarios)Session["usuario"]).idUsuario;

            Usuarios user = db.Usuarios.FirstOrDefault(x => x.idUsuario == idUsuario);

            if (datos >= 10 && user.rol.Equals("b"))
            {
                user.rol = "p";                
                db.SaveChanges();
            }
            else if (datos >= 30 && user.rol.Equals("p"))
            {
                user.rol = "o";               
                db.SaveChanges();
            }

            return View("~/Views/Home/VistaInicio.cshtml");
        }

        public double PorcentajeUsuarios(string rango)
        {            
            List<Usuarios> usuariosRango = db.Usuarios.Where(x => x.rol == rango.ToLower().Substring(0,1)).ToList();
            List<Usuarios> usuarios = db.Usuarios.ToList();

            double media = (usuariosRango.Count * 100) / usuarios.Count;

            return media;
        }

    }
}
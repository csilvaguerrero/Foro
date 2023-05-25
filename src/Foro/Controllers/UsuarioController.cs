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
                        rol = "BRONCE";
                        break;
                    }
                case "p":
                    {
                        rol = "PLATA";
                        break;
                    }
                case "o":
                    {
                        rol = "ORO";
                        break;
                    }
            }

            return rol;
        }
    }
}
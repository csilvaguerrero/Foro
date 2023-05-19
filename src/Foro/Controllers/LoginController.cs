using Foro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foro.Controllers
{
    public class LoginController : Controller
    {
        ForoEntities bd = new ForoEntities();        
        public ActionResult Index()
        {            
            return View("InicioSesion");
        }        

        [HttpPost]
        public ActionResult IniciarSesion(string usuario, string contrasenia)
        {

            Usuarios usu = bd.Usuarios.FirstOrDefault(x => x.usuario == usuario);

            if (usu != null)
            {
                if (usu.contrasenia == contrasenia)
                {
                    Session.Add("usuario", usu);
                    usu = null;

                    return View("Pantalla");
                }
                else
                {
                    return RedirectToAction("Index");
                }                
            }
            else
            {
                return View("InicioSesion");
            }             
        }
    }
}
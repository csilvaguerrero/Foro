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

        public ActionResult IniciarSesion()
        {
            return View("InicioSesion");
        }

        [HttpPost]
        public ActionResult IniciarSesion(string usuario, string contrasenia)
        {
            Usuarios usu = bd.Usuarios.FirstOrDefault(x => x.usuario == usuario);

            if (usu != null)
            {
                if (Desencriptar(usu.contrasenia) == contrasenia)
                {
                    Session.Add("usuario", usu);
                    usu = null;

                    return View("~/Views/Home/VistaInicio.cshtml");
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

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(string nombrePersona, string apellidosPersona, string correo, string usuario, string contrasenia)
        {
            Usuarios user = new Usuarios();

            user.nombre = nombrePersona;
            user.apellidos = apellidosPersona;
            user.correo = correo;
            user.usuario = usuario;
            user.fechaRegistro = DateTime.Now;
            user.contrasenia = Encriptar(contrasenia);

            bd.Usuarios.Add(user);
            bd.SaveChanges();

            return IniciarSesion(user.usuario, contrasenia);
        }
        
        public ActionResult CerrarSesion()
        {            
            Session["usuario"] = null;            

            return View("~/Views/Home/VistaInicio.cshtml");
        }

        public string Encriptar(string mensaje)
        {
            string result = string.Empty;

            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(mensaje);

            result = Convert.ToBase64String(encrypted);

            return result;
        }

        public string Desencriptar(string contrasenna)
        {
            string result = string.Empty;

            byte[] decrypted = Convert.FromBase64String(contrasenna);

            result = System.Text.Encoding.Unicode.GetString(decrypted);

            return result;

        }
    }
}
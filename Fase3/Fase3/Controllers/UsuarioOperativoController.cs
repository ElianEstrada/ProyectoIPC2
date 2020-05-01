using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fase3.Controllers
{
    public class UsuarioOperativoController : Controller
    {

        UsuarioOperativoLogic usuario = new UsuarioOperativoLogic();

        // GET: UsuarioOperativo
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Index()
        {
            Session["usuarioOperativo"] = null;
            return Content("<script> window.location.href = '/Index/Index' </script>");
        }

        public ActionResult Bodega()
        {
            return Content("<script> window.location.href = '/Bodega/Bodega' </script>");
        }

        public ActionResult listaBodega()
        {
            return RedirectToAction("listaBodega", "Bodega");
        }

        public ActionResult Entrada()
        {
            return RedirectToAction("Entrada", "Entrada");
        }

        public ActionResult Perfil()
        {
            return View(usuario.buscarUsuario(Session["usuarioOperativo"].ToString()));
        }

        public ActionResult updatePassword(string passActual, string nuevaPass, string verificarPass, string email)
        {
            if (passActual.Equals(usuario.buscarUsuario(email).contraseña))
            {
                if (nuevaPass.Equals(verificarPass))
                {
                    if(usuario.updatePassword(email, nuevaPass))
                    {
                        return Content("<script> alert('Contraseña Actualizada'); " +
                        "window.location.href='Perfil' </script>");
                    }
                    else
                    {
                        return Content("<script> alert('No se pudo actualizar la contraseña'); " +
                        "window.location.href='Perfil' </script>");
                    }
                    
                }
                else
                {
                    return Content("<script> alert('No coniciden la nueva contraseña'); " +
                        "window.location.href='Perfil' </script>");
                }
            }
            else
            {
                return Content("<script> alert('La contraseña Actual no coincide'); " +
                        "window.location.href='Perfil' </script>");
            }
        }
    }
}
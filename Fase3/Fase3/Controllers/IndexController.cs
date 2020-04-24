using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logica;

namespace Fase3.Controllers
{
    public class IndexController : Controller
    {

        UsuarioOperativoLogic usuarioOperativo = new UsuarioOperativoLogic();
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string email, string password)
        {
            UsuarioOperativoLogic usuarioOperativoLogic = new UsuarioOperativoLogic();

            if (usuarioOperativoLogic.verificarUsuarioOperativo(email, password))
            {
                Session["usuarioOperativo"] = email;
                Session["Usuario"] = usuarioOperativo.buscarUsuario(email).usuario;
                return RedirectToAction("Home", "UsuarioOperativo");
                //return Content("<script> window.location.href = '/UsuarioOperativo/Home'; </script>");
            }


            return Content("");
        }
    }
}
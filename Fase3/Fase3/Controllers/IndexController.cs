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
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string email, string password)
        {
          UsuarioOperativoLogic usuarioOperativoLogic = new UsuarioOperativoLogic();

            if(usuarioOperativoLogic.verificarUsuarioOperativo(email, password))
            {
                Session["usuarioOperativo"] = email;
                return Content("<script> window.location.href = '/UsuarioOperativo/Home'; </script>");
            }
            

            return Content("");
        }
    }
}
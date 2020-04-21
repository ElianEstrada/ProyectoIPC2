using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fase3.Controllers
{
    public class UsuarioOperativoController : Controller
    {
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
            return View();
        }

        public ActionResult registrarBodega(int codigoBodega, string nombreBodega, string descripcion, string direccion)
        {
            return Content("<script> alert('Bodega Registrada') </script>");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fase3.Controllers
{
    public class BodegaController : Controller
    {
        // GET: Bodega
        public ActionResult Bodega()
        {
            return View();
        }

        public ActionResult registrarBodega(int codigoBodega, string nombreBodega, string descripcion, string direccion)
        {
            return Content("<script> alert('Bodega Registrada') </script>");
        }

        public ActionResult Pasillo()
        {
            return View();
        }

        public ActionResult Index()
        {
            Session["usuarioOperativo"] = null;
            return Content("<script> window.location.href = '/Index/Index' </script>");
        }
    }
}
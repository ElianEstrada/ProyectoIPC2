using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fase3.Controllers
{

    public class BodegaController : Controller
    {
        static int codigo = 0;

        public ActionResult Home()
        {
            return Content("<script> window.location.href='/UsuarioOperativo/Home' </script>");
        }

        // GET: Bodega
        public ActionResult Bodega()
        {
            return View();
        }

        [HttpPost]
        public ActionResult registrarBodega(int codigoBodega, string nombreBodega, string descripcion, string direccion)
        {
            codigo = codigoBodega;
            return Content("<script> alert('Bodega Registrada'); " +
                " window.location.href= 'Bodega'</script>");
        }

        public ActionResult Pasillo()
        {
            return View();
        }

        public ActionResult registrarPasillo()
        {
            return Content("<script> alert('Pasillo Creado'); " +
                "window.location.href= 'Pasillo' </script>");
        }

        public ActionResult Estante()
        {
            return View();
        }

        public ActionResult registrarEstante()
        {
            return Content("<script> alert('Estante Registrado'); </script>");
        }

        public ActionResult Nivel()
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
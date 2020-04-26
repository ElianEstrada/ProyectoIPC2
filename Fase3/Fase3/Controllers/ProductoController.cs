using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fase3.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Producto()
        {
            return View();
        }

        public ActionResult registrarProducto()
        {
            return Content("");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
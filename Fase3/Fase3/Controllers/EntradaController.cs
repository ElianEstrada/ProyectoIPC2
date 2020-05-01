using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fase3.Controllers
{
    public class EntradaController : Controller
    {
        ProveedorLogic proveedor = new ProveedorLogic();

        public ActionResult Entrada()
        {
            return View(proveedor.listaProveedores(int.Parse(Session["Usuario"].ToString())));
        }

        // GET: Entrada
        public ActionResult Index()
        {
            return View();
        }
    }
}
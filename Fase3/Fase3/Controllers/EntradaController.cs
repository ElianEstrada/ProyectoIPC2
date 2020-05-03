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
        EntradaBodegaLogic entrada = new EntradaBodegaLogic();
        UsuarioOperativoLogic usuario = new UsuarioOperativoLogic();
        ProductoLogic producto = new ProductoLogic();

        public ActionResult Entrada()
        {
            return View(proveedor.listaProveedores(int.Parse(Session["Usuario"].ToString())));
        }


        public ActionResult registrarEntrada(int codigoEntrada, string proveedor, string fecha)
        {
            Session["idEntrada"] = codigoEntrada;
            if(entrada.agregarEntrada(codigoEntrada, fecha, proveedor, usuario.buscarUsuario(Session["usuarioOperativo"].ToString()).cui, int.Parse(Session["usuario"].ToString())))
            {
                return Content("<script> alert('Entrada Registrada');" +
                    "window.location.href='DetalleEntrada' </script>");
            }
            else
            {
                return Content("<script> alert('No se pudo registrar la Entrada');" +
                    "window.location.href='Entrada' </script>");
            }
        }

        public ActionResult DetalleEntrada()
        {
            return View(producto.listaProductos(int.Parse(Session["usuario"].ToString())));
        }

        // GET: Entrada
        public ActionResult Index()
        {
            return View();
        }


        
    }
}
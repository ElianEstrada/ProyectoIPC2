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
        DetalleEntradaLogic detalle = new DetalleEntradaLogic();
        NivelLogic nivel = new NivelLogic();
        AsignarNivelLogic asignar = new AsignarNivelLogic();

        public ActionResult Entrada()
        {
            return View(proveedor.listaProveedores(int.Parse(Session["Usuario"].ToString())));
        }


        public ActionResult registrarEntrada(int codigoEntrada, string proveedor, string fecha)
        {
            Session["idEntrada"] = codigoEntrada;
            if (entrada.agregarEntrada(codigoEntrada, fecha, proveedor, usuario.buscarUsuario(Session["usuarioOperativo"].ToString()).cui, int.Parse(Session["usuario"].ToString())))
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

        public ActionResult registrarDetalle(double precio, int tipoCosteo, int cantidad, int? logica, string producto)
        {
            if (detalle.addDetalleEntrada(precio, cantidad, producto, int.Parse(Session["idEntrada"].ToString()), tipoCosteo, logica, int.Parse(Session["usuario"].ToString())))
            {
                return Content("<script> alert('Detalle Registrado'); " +
                    "window.location.href='DetalleEntrada' </script>");
            }
            else
            {
                return Content("<script> alert('No se pudo registrar el detalle'); " +
                    "window.location.href='DetalleEntrada' </script>");
            }
        }


        public ActionResult asignarNivel()
        {
            ViewBag.niveles = nivel.idNiveles(int.Parse(Session["usuario"].ToString()));
            return View(detalle.listaDetalles(int.Parse(Session["idEntrada"].ToString())));
        }

        public ActionResult Asignar(int cantidad, int idDetalle, int idNivel)
        {
            if (asignar.asignarNivel(cantidad, idNivel, idDetalle))
            {
                return Content("<script> alert('Asignado');" +
                "window.location.href='asignarNivel' </script>");
            }
            else
            {
                return Content("<script> alert('No se pudo asignar');" +
                "window.location.href='asignarNivel' </script>");
            }
        }

        // GET: Entrada
        public ActionResult Index()
        {
            return View();
        }


        
    }
}
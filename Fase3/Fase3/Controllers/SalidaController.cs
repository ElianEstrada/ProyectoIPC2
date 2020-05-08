using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fase3.Controllers
{
    public class SalidaController : Controller
    {

        ClienteLogic cliente = new ClienteLogic();
        SalidaBodegaLogic salida = new SalidaBodegaLogic();
        UsuarioOperativoLogic usuario = new UsuarioOperativoLogic();
        DetalleEntradaLogic detalleEntrada = new DetalleEntradaLogic();
        UbicacionLogic ubicacion = new UbicacionLogic();
        AsignarNivelLogic asignacion = new AsignarNivelLogic();
        DetalleSalidaLogic detalleSalida = new DetalleSalidaLogic();


        public ActionResult Salida()
        {
            return View(cliente.listaClientes(int.Parse(Session["usuario"].ToString())));
        }

        public ActionResult registrarSalida(int idSalidaBodega, string fecha, string cliente)
        {
            Session["idSalida"] = idSalidaBodega;
            if (salida.addSalidaBodega(idSalidaBodega, fecha, cliente, usuario.buscarUsuario(Session["UsuarioOperativo"].ToString()).cui, int.Parse(Session["usuario"].ToString())))
            {
                return Content("<script> alert('Salida Registrada');" +
                    "window.location.href='DetalleSalida'; </script>");
            }
            else
            {
                return Content("<script> alert('No se pudo registrar la salida');" +
                    "window.location.href='Salida'; </script>");
            }
        }


        public ActionResult DetalleSalida()
        {
            return View(detalleEntrada.productosAsignados(int.Parse(Session["usuario"].ToString())));
        }

        public ActionResult ubicaciones(int codigoProducto)
        {
            Session["codigoProducto"] = codigoProducto;
            return View(ubicacion.listaUbicaciones(int.Parse(Session["usuario"].ToString()), codigoProducto));
        }

        public ActionResult agregarDetalleSalida(int idNivel, int cantidad)
        {
            if (detalleSalida.add_DetalleSalida(cantidad, int.Parse(Session["idSalida"].ToString()), asignacion.idAsignacion(idNivel, int.Parse(Session["codigoProducto"].ToString()))))
            {
                return Content("<script> alert('Agregado al detalle');" +
                    "window.location.href='DetalleSalida' </script>");
            }
            else
            {

                return Content("<script> alert('No se pudo agregar');" +
                    "window.location.href='DetalleSalida' </script>");

            }
        }

        // GET: Salida
        public ActionResult Index()
        {
            return View();
        }
    }
}
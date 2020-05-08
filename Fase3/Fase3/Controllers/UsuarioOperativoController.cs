using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web.HtmlReportRender;

namespace Fase3.Controllers
{
    public class UsuarioOperativoController : Controller
    {

        UsuarioOperativoLogic usuario = new UsuarioOperativoLogic();
        ProductoLogic producto = new ProductoLogic();


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
            return Content("<script> window.location.href = '/Bodega/Bodega' </script>");
        }

        public ActionResult listaBodega()
        {
            return RedirectToAction("listaBodega", "Bodega");
        }

        public ActionResult Entrada()
        {
            return RedirectToAction("Entrada", "Entrada");
        }

        public ActionResult Salida()
        {
            return RedirectToAction("Salida", "Salida");
        }

        public ActionResult Perfil()
        {
            return View(usuario.buscarUsuario(Session["usuarioOperativo"].ToString()));
        }

        public ActionResult updatePassword(string passActual, string nuevaPass, string verificarPass, string email)
        {
            if (passActual.Equals(usuario.buscarUsuario(email).contraseña))
            {
                if (nuevaPass.Equals(verificarPass))
                {
                    if (usuario.updatePassword(email, nuevaPass))
                    {
                        return Content("<script> alert('Contraseña Actualizada'); " +
                        "window.location.href='Perfil' </script>");
                    }
                    else
                    {
                        return Content("<script> alert('No se pudo actualizar la contraseña'); " +
                        "window.location.href='Perfil' </script>");
                    }

                }
                else
                {
                    return Content("<script> alert('No coniciden la nueva contraseña'); " +
                        "window.location.href='Perfil' </script>");
                }
            }
            else
            {
                return Content("<script> alert('La contraseña Actual no coincide'); " +
                        "window.location.href='Perfil' </script>");
            }
        }


        public ActionResult inventarioBodega()
        {
            return View();
        }

        public ActionResult verBodega(int idBodega)
        {
            return View(producto.inventarioBodega(int.Parse(Session["usuario"].ToString()), idBodega));

        }

        public ActionResult inventarioProducto()
        {
            return View();
        }

        public ActionResult verProducto(int codigoProducto)
        {
            return View(producto.inventarioProductos(int.Parse(Session["usuario"].ToString()), codigoProducto));
        }
    }
}
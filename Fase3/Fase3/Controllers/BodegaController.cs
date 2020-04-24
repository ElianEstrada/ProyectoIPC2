using Logica;
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
        UsuarioOperativoLogic usuarioOperativo = new UsuarioOperativoLogic();
        BodegaLogic bodega = new BodegaLogic();
        PasilloLogic pasillo = new PasilloLogic();
        EstanteLogic estante = new EstanteLogic();
        NivelLogic nivel = new NivelLogic();
        string email = string.Empty;

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
            email = Session["usuarioOperativo"].ToString();
            if (bodega.addBodega(codigoBodega, nombreBodega, descripcion, direccion, usuarioOperativo.buscarUsuario(email).cui))
            {
                return Content("<script> alert('Bodega Registrada'); " +
                " window.location.href= 'Bodega'</script>");
            }
            else
            {
                return Content("<script> alert('No se pudo registrar la bodega'); " +
                " window.location.href= 'Bodega'</script>");
            }
            
        }

        public ActionResult listaBodega()
        {
            return View(bodega.idBodegas(int.Parse(Session["Usuario"].ToString())));
        }

        public ActionResult Pasillo()
        {
            //email = Session["usuarioOperativo"].ToString();
            //Session["Usuario"] =  usuarioOperativo.buscarUsuario(email).usuario;

            return View(bodega.idBodegas(int.Parse(Session["Usuario"].ToString())));
        }

        public ActionResult registrarPasillo(int numeroPasillo, double largo, double ancho, int codigoBodega)
        {
            //return RedirectToAction("Pasillo", "Bodega");
            return Content("<script> alert('Pasillo Creado'); " +
                "window.location.href= 'Pasillo' </script>");
        }

        public ActionResult Estante()
        {
            return View(pasillo.idPasillos(int.Parse(Session["Usuario"].ToString())));
        }

        public ActionResult registrarEstante()
        {
            return Content("<script> alert('Estante Registrado'); </script>");
        }

        public ActionResult Nivel()
        {
            return View(estante.letrasEstantes(int.Parse(Session["Usuario"].ToString())));
        }

        public ActionResult Index()
        {
            Session["usuarioOperativo"] = null;
            return RedirectToAction("Index", "Index");
            //return Content("<script> window.location.href = '/Index/Index' </script>");
        }
    }
}
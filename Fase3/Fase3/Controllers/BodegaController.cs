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

        public ActionResult modificarBodega()
        {
            return RedirectToAction("listaBodega", "Bodega");
        }

        public ActionResult Pasillo()
        {
            //email = Session["usuarioOperativo"].ToString();
            //Session["Usuario"] =  usuarioOperativo.buscarUsuario(email).usuario;

            return View(bodega.idBodegas(int.Parse(Session["Usuario"].ToString())));
        }

        public ActionResult registrarPasillo(int numeroPasillo, double largo, double ancho, int codigoBodega)
        {
            if(pasillo.addPasillo(numeroPasillo, largo, ancho, codigoBodega))
            {
                return Content("<script> alert('Pasillo Creado'); " +
                "window.location.href= 'Pasillo' </script>");
            }
            else
            {
                return Content("<script> alert('No se pudo agregar el Pasillo'); " +
                "window.location.href= 'Pasillo' </script>");
            }   
        }

        public ActionResult listaPasillos(int idBodega)
        {
            return View(pasillo.pasillosBodega(int.Parse(Session["Usuario"].ToString()), idBodega));
        }

        public ActionResult Estante()
        {
            return View(pasillo.idPasillos(int.Parse(Session["Usuario"].ToString())));
        }

        public ActionResult registrarEstante(int numeroPasillo, string letra, double alto, double largo, double ancho)
        {
            if(estante.addEstante(letra, largo, ancho, alto, numeroPasillo))
            {
                return Content("<script> alert('Estante Registrado'); " +
                    "window.location.href='Estante' </script>");
            }
            else
            {
                return Content("<script> alert('No se pudo registrar el Estante'); " +
                    "window.location.href='Estante' </script>");
            }
        }

        public ActionResult listaEstantes(int idPasillo)
        {
            return View(estante.estantePasillo(int.Parse(Session["Usuario"].ToString()), idPasillo));
        }

        public ActionResult Nivel()
        {
            return View(estante.letrasEstantes(int.Parse(Session["Usuario"].ToString())));
        }

        public ActionResult registrarNivel(int idNivel, double alto, string letra)
        {
            if (nivel.addNivel(idNivel, alto, letra))
            {
                return Content("<script> alert('Nivel Registrado'); " +
                    "window.location.href='Nivel' </script>");
            }
            else
            {
                return Content("<script> alert('No se pudo registrar el Nivel'); " +
                    "window.location.href='Nivel' </script>");
            }
            
        }

        public ActionResult Index()
        {
            Session["usuarioOperativo"] = null;
            return RedirectToAction("Index", "Index");
        }
    }
}
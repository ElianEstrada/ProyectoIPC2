using Acceso_Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DetalleEntradaLogic
    {

        DetalleEntradaDA detalleEntradaDA = new DetalleEntradaDA();

        public LinkedList<DetalleEntrada> listaDetalles(int idEntrada)
        {
            return detalleEntradaDA.listaDetalleEntrada(idEntrada);
        }

    }
}

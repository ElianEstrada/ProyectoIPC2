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


        public bool addDetalleEntrada(double precio, int cantidad, string producto, int entrada, int costeo, int? logica, int idUsuario)
        {
            return detalleEntradaDA.addDetalleEntrada(precio, cantidad, arreglarProducto(producto), entrada, costeo, logica, idUsuario);
        }

        public int arreglarProducto(string producto)
        {
            string[] id = new string[2];
            id = producto.Split(',');

            return int.Parse(id[0]);
        }

    }
}

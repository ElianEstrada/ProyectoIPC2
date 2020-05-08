using Acceso_Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class UbicacionLogic
    {

        UbicacionDA ubicacionDA = new UbicacionDA();

        public LinkedList<Ubicacion> listaUbicaciones(int idUsuario, int idProducto)
        {
            return ubicacionDA.listaUbicaciones(idUsuario, idProducto);
        }

    }
}

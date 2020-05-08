using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class AsignarNivelLogic
    {

        AsignarNivelDA asignarNivelDA = new AsignarNivelDA();

        public bool asignarNivel(int cantidad, int nivel, int detalle)
        {
            return asignarNivelDA.asignarNivel(cantidad, nivel, detalle);
        }

        public int idAsignacion(int nivel, int idProducto)
        {
            return asignarNivelDA.searchAsginacion(nivel, idProducto);
        }

    }
}

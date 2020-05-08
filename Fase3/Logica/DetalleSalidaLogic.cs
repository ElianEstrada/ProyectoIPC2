using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DetalleSalidaLogic
    {

        DetalleSalidaDA detalleSalidaDA = new DetalleSalidaDA();


        public bool add_DetalleSalida(int cantidad, int salida, int asignacion)
        {
            return detalleSalidaDA.add_DetalleSalida(cantidad, salida, asignacion);
        }

    }
}

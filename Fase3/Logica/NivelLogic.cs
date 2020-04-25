using Acceso_Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class NivelLogic
    {

        NivelDA nivelDA = new NivelDA();

        public LinkedList<Nivel> idNiveles(int idUsuario)
        {
            return nivelDA.listaNiveles(idUsuario);
        }

        public bool addNivel(int idNivel, double alto, string letra)
        {
            return nivelDA.addNivel(idNivel, alto, letra);
        }

    }
}

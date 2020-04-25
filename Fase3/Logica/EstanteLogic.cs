using Acceso_Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class EstanteLogic
    {

        EstanteDA estanteDA = new EstanteDA();

        public LinkedList<Estante> letrasEstantes(int idUsuario)
        {
            return estanteDA.listaEstantes(idUsuario);
        }

        public bool addEstante(string letra, double largo, double ancho, double alto, int idPasillo)
        {
            return estanteDA.addEstante(letra, largo, ancho, alto, idPasillo);
        }

    }
}

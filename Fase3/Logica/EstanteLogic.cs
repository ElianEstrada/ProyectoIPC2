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

        public LinkedList<Estante> estantePasillo (int idUsuario, int idPasillo)
        {
            LinkedList<Estante> estantes = new LinkedList<Estante>();

            foreach(var item in estanteDA.listaEstantes(idUsuario))
            {
                if(item.idPasillo == idPasillo)
                {
                    estantes.AddLast(item);
                }
            }

            return estantes;
        }


    }
}

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

    }
}

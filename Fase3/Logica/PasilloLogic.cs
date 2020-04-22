using Acceso_Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PasilloLogic
    {

        PasilloDA pasilloDA = new PasilloDA();

        public LinkedList<Pasillo> idPasillos(int idUsuario)
        {
            return pasilloDA.listaPasillos(idUsuario);
        }

    }
}

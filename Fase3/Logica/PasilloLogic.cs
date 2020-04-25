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

        public bool addPasillo(int idPasillo, double largo, double ancho, int idBodega)
        {
            return pasilloDA.addPasillo(idPasillo, largo, ancho, idBodega);
        }

        public LinkedList<Pasillo> pasillosBodega(int idUsuario, int idBodega)
        {
            LinkedList<Pasillo> pasillos = new LinkedList<Pasillo>();

            foreach(var item in pasilloDA.listaPasillos(idUsuario))
            {
                if(item.idBodega == idBodega)
                {
                    pasillos.AddLast(item);
                }
            }

            return pasillos;
        }
    }
}

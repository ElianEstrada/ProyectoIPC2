using Acceso_Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class BodegaLogic
    {

        BodegaDA bodegaDA = new BodegaDA();

        public LinkedList<Bodega> idBodegas(int idUsuario)
        {
            return bodegaDA.listaBodegas(idUsuario);
        }

        public int buscarUsuario (string email)
        {
            return bodegaDA.usuarioOperativo(email);
        }

    }
}

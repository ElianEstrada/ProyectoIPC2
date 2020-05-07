using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class SalidaBodegaLogic
    {

        SalidaBodegaDA salidaBodegaDA = new SalidaBodegaDA();

        public bool addSalidaBodega(int idsalidaBodega, string fecha, string cliente, int usuarioOperativo, int usuario)
        {
            return salidaBodegaDA.addSalidaBodega(idsalidaBodega, fecha, arreglarCliente(cliente), usuarioOperativo, usuario);
        }


        public int arreglarCliente(string cliente)
        {
            string[] nit = new string[2];
            nit = cliente.Split(',');

            return int.Parse(nit[0]);
        }
    }
}

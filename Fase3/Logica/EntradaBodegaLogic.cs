using Acceso_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class EntradaBodegaLogic
    {
        EntradaBodegaDA entradaBodegaDA = new EntradaBodegaDA();

        public bool agregarEntrada(int idEntrada, string fecha, string proveedor, int usuarioOperativo, int usuario)
        {
            return entradaBodegaDA.agregarEntradaBodega(idEntrada, fecha, arreglarProveedor(proveedor), usuarioOperativo, usuario);
        }


        public int arreglarProveedor(string proveedor)
        {
            string[] nit = new string[2];
            nit = proveedor.Split(',');

            return int.Parse(nit[0]);
        }

        //public string arreglarFormato(string fecha)
        //{
        //    string[] formato = new string[3];
        //    formato = fecha.Split('/');

        //    return formato[2] + "-" + formato[1] + "-" + formato[0];
        //}

    }
}

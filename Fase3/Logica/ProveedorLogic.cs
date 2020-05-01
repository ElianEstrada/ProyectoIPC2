using Acceso_Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ProveedorLogic
    {

        ProveedorDA proveedorDA = new ProveedorDA();

        public LinkedList<Proveedor> listaProveedores(int idUsuario)
        {
            return proveedorDA.listaProveedores(idUsuario);
        }

    }
}

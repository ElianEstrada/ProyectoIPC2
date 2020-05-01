using Acceso_Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ProductoLogic
    {
        ProductoDA productoDA = new ProductoDA();
        public LinkedList<Producto> listaProductos(int idUsuario)
        {
            return productoDA.listaProductos(idUsuario);
        }

    }
}

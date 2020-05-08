using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class InventarioProducto
    {

        public int codigoProducto { get; set; }
        public int codigoBarras { get; set; }
        public string nombreProducto { get; set; }
        public int bodega { get; set; }
        public int pasillo { get; set; }
        public string letra { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public int nivel { get; set; }
        public string costeo { get; set; }
        public string logica { get; set; }

    }
}

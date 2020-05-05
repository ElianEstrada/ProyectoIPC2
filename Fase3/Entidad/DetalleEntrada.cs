using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class DetalleEntrada
    {

        public int idDetalleEntrada { get; set; }
        public double precio { get; set; }
        public int cantidad{ get; set; }
        public string producto { get; set; }
        public string costeo { get; set; }
        public string  logica { get; set; }

    }
}

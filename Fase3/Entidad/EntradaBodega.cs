using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EntradaBodega
    {

        public int idEntrada { get; set; }
        public string fecha { get; set; }
        public string proveedor { get; set; }
        public int usuarioOperativo { get; set; }
        public int usuario { get; set; }

    }
}

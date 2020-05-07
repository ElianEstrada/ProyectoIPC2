using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class SalidaBodega
    {

        public int idSalidaBodega { get; set; }
        public string fechaSalida { get; set; }
        public int cliente { get; set; }
        public int usuario { get; set; }
        public int usuarioOperativo { get; set; }
    }
}

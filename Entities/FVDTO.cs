using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTum.Entities
{
    public class FVDTO
    {
        public int ClaveFolioViaje { get; set; }
        public string FolioViaje { get; set; }
        public string Operador { get; set; }
        public string Unidad { get; set; }
        public string Placa { get; set; }
        public string Ruta { get; set; }
        public DateTime SalidaProgramada { get; set; }
    }
}

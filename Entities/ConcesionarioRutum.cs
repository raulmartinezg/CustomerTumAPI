using System;
using System.Collections.Generic;

#nullable disable

namespace ClientTum.Entities
{
    public partial class ConcesionarioRutum
    {
        public int Id { get; set; }
        public int ClaveFolioViaje { get; set; }
        public string NumeroConcCte { get; set; }
        public string RazonSocial { get; set; }
        public string FolioViaje { get; set; }
    }
}

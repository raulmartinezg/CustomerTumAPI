using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTum.Entities
{
    public class ShipUnitLine
    {
        public string tag1 { get; set; }
        public string itemId { get; set; }
        public string itemDescription { get; set; }
        public int packagingUnitCount { get; set; }
        public int totalPackageCount { get; set; }
    }
}

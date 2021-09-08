using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTum.Entities
{
    public class ShipUnit
    {
        public string shipUnitId { get; set; }
        public List<ShipUnitLine> shipUnitLine { get; set; }
    }
}

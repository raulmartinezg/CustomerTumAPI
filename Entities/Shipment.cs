using System.Collections.Generic;

namespace ClientTum.Entities
{
    public class Shipment
    {
        public string shipmentId { get; set; }
        public List<ShipUnit> shipUnit { get; set; }
    }
}

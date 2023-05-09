using CsvHelper.Configuration.Attributes;

namespace SearchOrders.Models
{
    public class PurchaseOrder
    {
        public string Number { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public DateTime OrderDate { get; set; }
        [Optional]
        public DateTime? ShipmentDate { get; set; }
        public int Quantity { get; set; }
        public bool Confirmed { get; set; }
        public double Value { get; set; }
    }
}

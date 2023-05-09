using SearchOrders.Models;

namespace SearchOrders.Mediators.SearchPurchaseOrders
{
    public class SearchPurchaseOrderResult
    {
        public IEnumerable<PurchaseOrder>? Orders { get; set; }
        public int TotalCount { get; set; }
    }
}

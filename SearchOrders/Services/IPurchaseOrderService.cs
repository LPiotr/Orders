using SearchOrders.Models;

namespace SearchOrders.Services
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrder>> SearchPurchaseOrders(string number, List<string> clientCodes, DateTime? fromDate, DateTime? toDate);
    }
}

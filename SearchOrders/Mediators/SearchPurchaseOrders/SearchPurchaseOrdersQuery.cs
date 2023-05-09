using MediatR;
using SearchOrders.Models;

namespace SearchOrders.Mediators.SearchPurchaseOrders
{
    public class SearchPurchaseOrdersQuery : IRequest<IEnumerable<PurchaseOrder>>
    {
        public string Number { get; }
        public DateTime? FromDate { get; }
        public DateTime? ToDate { get; }
        public List<string> ClientCodes { get; }

        public SearchPurchaseOrdersQuery(string number, List<string> clientCodes, DateTime? fromDate, DateTime? toDate)
        {
            Number = number;
            ClientCodes = clientCodes;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}

using MediatR;
using SearchOrders.Models;
using SearchOrders.Services;

namespace SearchOrders.Mediators.SearchPurchaseOrders
{
    public class SearchPurchaseOrdersQueryHandler : IRequestHandler<SearchPurchaseOrdersQuery, IEnumerable<PurchaseOrder>>
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public SearchPurchaseOrdersQueryHandler(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        public async Task<IEnumerable<PurchaseOrder>> Handle(SearchPurchaseOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _purchaseOrderService.SearchPurchaseOrders(request.Number, request.ClientCodes, request.FromDate, request.ToDate);

            return orders;
        }
    }
}

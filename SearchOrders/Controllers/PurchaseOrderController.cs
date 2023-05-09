using MediatR;
using Microsoft.AspNetCore.Mvc;
using SearchOrders.Mediators.SearchPurchaseOrders;
using SearchOrders.Models;

namespace SearchOrders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrder>>> SearchOrders(string number, List<string> clientCodes, DateTime? startDate, DateTime? endDate)
        {
            var query = new SearchPurchaseOrdersQuery(number, clientCodes, startDate, endDate);
            var orders = await _mediator.Send(query);
           
            return Ok(orders);
        }
    }
}

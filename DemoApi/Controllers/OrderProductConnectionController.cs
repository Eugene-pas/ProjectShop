using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.CreateOrderProductConnections;
using Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.DeleteOrderProductConnections;
using Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.UpdateOrderProductConnections;
using Shop.Application.Commands_and_Queries.OrderProductConnections.Queries.GetOrdersListProductConnections;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductConnectionController : BaseController
    {
        public OrderProductConnectionController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<long> Create(long orderId, long productId)
        {
            return await _mediator.Send(
                new CreateOrderProductConnectionsCommand
                {
                    ProductId = productId,
                    OrderId = orderId

                });
        }

        [HttpDelete("delete")]
        public async Task<Unit> Delete(long id)
        {
            return await _mediator.Send(new DeleteOrderProductConnectionsCommand { Id = id });
        }

        [HttpPost("update")]
        public async Task<Unit> Update(long id, long productId, long orderId)
        {
            return await _mediator.Send(new UpdateOrderProductConnectionsCommand
            {
                Id = id,
                ProductId = productId,
                OrderId = orderId
            });
        }

        [HttpGet("get")]
        public async Task<ActionResult<OrderProductConnectionListVm>> Get()
        {
            return await _mediator.Send(new GetOrderProductConnectionsListQuery {});
        }
    }
}

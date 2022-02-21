using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.Application.Commands.OrderProductConnections.Commands.CreateOrderProductConnections;
using Shop.Application.Commands.OrderProductConnections.Commands.DeleteOrderProductConnections;
using Shop.Application.Commands.OrderProductConnections.Commands.UpdateOrderProductConnections;
using Shop.Application.Commands.OrderProductConnections.Queries;
using Shop.Application.Commands.OrderProductConnections.Queries.GetOrdersListProductConnections;
using Shop.Application.Commands.OrderProductConnections.Queries.GetProductsListbyOrder;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductConnectionController : BaseController
    {
        public OrderProductConnectionController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<OrderProductConnectionVm> Create(long orderId, long productId)
        {
            return await _mediator.Send(
                new CreateOrderProductConnectionsCommand
                {
                    ProductId = productId,
                    OrderId = orderId

                });
        }

        [HttpDelete("delete")]
        public async Task<OrderProductConnectionVm> Delete(long id)
        {
            return await _mediator.Send(new DeleteOrderProductConnectionsCommand { Id = id });
        }

        [HttpPost("update")]
        public async Task<OrderProductConnectionVm> Update(long id, long productId, long orderId)
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

        [HttpGet("getproduct")]
        public async Task<ActionResult<GetProductListOrderVm>> GetList(long orderId)
        {
            return await _mediator.Send(new GetProductListOrderQuery { OrderId = orderId });
        }
    }
}

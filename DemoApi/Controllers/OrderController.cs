using DemoApi.Models.OrderModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Application.Orders.Commands.DeleteOrder;
using Shop.Application.Orders.Commands.UpdateOrder;
using Shop.Application.Orders.Queries.GetAllOrder;
using Shop.Application.Orders.Queries.GetOrder;
using System;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<OrderVm> CreateOrder([FromBody] CreateOrderModel order)
        {
            return await _mediator.Send(
            new CreateOrderCommand
            {
                Adress = order.Adress,
                CustomerId = order.CustomerId,
                DeliveryId = order.DeliveryId
            });
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<OrderVm>> Delete(long id)
        {
            return await _mediator.Send(new DeleteOrderCommand { Id = id });
        }

        [HttpPut("update")]
        public async Task<OrderVm> UpdateOrder([FromBody] UpdateOrderModel order)
        {
            return await _mediator.Send(
            new UpdateOrderCommand
            {
                Id = order.Id,
                Adress = order.Adress,
                CustomerId = order.CustomerId,
                DeliveryId = order.DeliveryId,
                Date = DateTime.Now
            });
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<OrderVm>> Get(long id)
        {
            return await _mediator.Send(new GetOrderQuery { Id = id });
        }

        [HttpGet("GetOrdersList")]
        public async Task<ActionResult<OrderListVm>> GetAllOrder()
        {
            return await _mediator.Send(new GetOrdersListQuery { });
        }

    }
}

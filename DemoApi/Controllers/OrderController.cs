using DemoApi.Models;
using DemoApi.Models.OrderModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Application.Orders.Commands.DeleteOrder;
using Shop.Application.Orders.Commands.UpdateOrder;
using Shop.Application.Orders.Queries.GetAllOrder;
using System;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<long> CreateOrder([FromBody] CreatOrderModel order)
        {          
            return await _mediator.Send(
                new CreateOrderCommand
                {
                    Adress = order.Adress,                 
                });
        }

        [HttpDelete("delete")]
        public async Task<Unit> Delete(long id)
        {
            return await _mediator.Send(new DeleteOrderCommand { Id = id });
        }

        [HttpPut("update")]
        public async Task<Unit> UpdateOrder([FromBody] UpdateOrderModel order)
        {           
            return await _mediator.Send(
                new UpdateOrderCommand
                {
                   Id = order.Id,
                   Adress = order.Adress,
                   Customer = null,
                   Delivery = null,
                   Date = DateTime.Now
                });
        }

        [HttpPost("GetAllIdPerson")]
        public async Task<OrderVm> GetAllOrder([FromBody] IdModel order)
        {
            return await _mediator.Send(
                new GetAllOrderCommand
                {
                    IdCustomer = order.Id
                });
        }

    }
}

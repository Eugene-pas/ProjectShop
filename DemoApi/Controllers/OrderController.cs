using DemoApi.Models.OrderModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Shop.Application.Commands.Orders.Commands.CreateOrder;
using Shop.Application.Commands.Orders.Commands.DeleteOrder;
using Shop.Application.Commands.Orders.Commands.UpdateOrder;
using Shop.Application.Commands.Orders.Queries.GetOrder;
using Shop.Application.Commands.Orders.Queries.GetOrderPaginatedList;
using Shop.Application.Commands.Orders.Queries.GetOrderPaginatedListForCustomer;
using Shop.Application.Commands.Orders.Queries.GetOrdersList;
using Shop.Application.Commands.Orders.Queries.GetOrdersListForCustomer;

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

        [HttpGet("getOrdersListForCustomer/{CustomerId}")]
        public async Task<ActionResult<OrderListVm>> GetOrdersListForCustomer(long CustomerId)
        {
            return await _mediator.Send(new GetOrdersListForCustomerQuery { customerId = CustomerId });
        }

        [HttpGet("GetOrdersList")]
        public async Task<ActionResult<OrderListVm>> GetAllOrder()
        {
            return await _mediator.Send(new GetOrdersListQuery { });
        }

        [HttpGet("getOrdersPaginatedListForCustomer/{customerId}")]
        public async Task<ActionResult<GetOrderPaginatedListForCustomerVm>> GetOrdersPaginatedListForCustomer(long customerId,int page, int pageSize)
        {
            return await _mediator.Send(new GetOrderPaginatedListForCustomerQuery
            {
                CustomerId = customerId,
                Page = page,
                PageSize = pageSize
            });
        }

        [HttpGet("GetOrdersPaginatedList")]
        public async Task<ActionResult<GetOrderPaginatedListVm>> GetPaginatedOrder(int page, int pageSize)
        {
            return await _mediator.Send(new GetOrderPaginatedListQuery
            {
                Page = page,
                PageSize = pageSize
            });
        }
    }
}

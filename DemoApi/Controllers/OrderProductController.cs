//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using Shop.Application.Commands.OrderProducts.Commands.CreateOrderProduct;
//using Shop.Application.Commands.OrderProducts.Commands.DeleteOrderProduct;
//using Shop.Application.Commands.OrderProducts.Commands.UpdateOrderProduct;
//using Shop.Application.Commands.OrderProducts.Queries;
//using Shop.Application.Commands.OrderProducts.Queries.GetOrdersProductList;
//using Shop.Application.Commands.OrderProducts.Queries.GetProductsListbyOrder;

//namespace DemoApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrderProductController : BaseController
//    {
//        public OrderProductController(IMediator mediator) : base(mediator) { }

//        [HttpPost("create")]
//        public async Task<OrderProductVm> Create(long orderId, long productId)
//        {
//            return await _mediator.Send(
//                new CreateOrderProductCommand
//                {
//                    ProductId = productId,
//                    OrderId = orderId

//                });
//        }

//        [HttpDelete("delete")]
//        public async Task<OrderProductVm> Delete(long id)
//        {
//            return await _mediator.Send(new DeleteOrderProductCommand { Id = id });
//        }

//        [HttpPost("update")]
//        public async Task<OrderProductVm> Update(long id, long productId, long orderId)
//        {
//            return await _mediator.Send(new UpdateOrderProductCommand
//            {
//                Id = id,
//                ProductId = productId,
//                OrderId = orderId
//            });
//        }

//        [HttpGet("get")]
//        public async Task<ActionResult<OrderProductListVm>> Get()
//        {
//            return await _mediator.Send(new GetOrderProductListQuery {});
//        }

//        [HttpGet("getproductlistbyorder")]
//        public async Task<ActionResult<ProductListByOrderVm>> GetList(long orderId)
//        {
//            return await _mediator.Send(new GetProductListOrderQuery { OrderId = orderId });
//        }
//    }
//}

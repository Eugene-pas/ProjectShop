using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands.BasketItems.Commands.CreateBasketItem;
using Shop.Application.Commands.BasketItems.Commands.DeleteBasketItem;
using Shop.Application.Commands.BasketItems.Commands.UpdateBasketItem;
using Shop.Application.Commands.Baskets;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemController : BaseController
    {
        public BasketItemController(IMediator mediator) : base(mediator) { }
        [HttpPost("create")]
        public async Task<BasketItemVm> Create(long productId, long basketId, int count)
        {
            return await _mediator.Send(new CreateBasketItemCommand
            {
                ProductId = productId,
                BasketId = basketId,
                Count = count
            });
        }

        [HttpDelete("delete/{id}")]
        public async Task<BasketItemVm> Delete(long id)
        {
            return await _mediator.Send(new DeleteBasketItemCommand { Id = id });
        }

        [HttpPost("update")]
        public async Task<BasketItemVm> Update(long id, int count)
        {
            return await _mediator.Send(new UpdateBasketItemCommand
            {
                Id = id,
                Count = count
            });
        }
    }
}

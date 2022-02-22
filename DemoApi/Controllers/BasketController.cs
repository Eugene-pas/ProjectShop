using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands.Baskets;
using Shop.Application.Commands.Baskets.Commands.CreateBasket;
using Shop.Application.Commands.Baskets.Commands.DeleteBasket;
using Shop.Application.Commands.Baskets.Quersies.GetBasket;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseController
    {
        public BasketController(IMediator mediator) : base(mediator) { }
        [HttpPost("create")]

        public async Task<BasketVm> Create(long Id)
        {
            return await _mediator.Send(new CreateBasketCommand
            {
                CustomerId = Id,

            });
        }

        [HttpDelete("delete/{id}")]
        public async Task<BasketVm> Delete(long id)
        {
            return await _mediator.Send(new DeleteBasketCommand { Id = id });
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<BasketVm>> Get(long id)
        {
            return await _mediator.Send(new GetBasketQuery { Id = id });
        }
    }
}

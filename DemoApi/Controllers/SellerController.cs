using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DemoApi.Models.SellerModels;
using Shop.Application.Commands.Sellers.Commands.CreateSeller;
using Shop.Application.Commands.Sellers.Commands.DeleteSeller;
using Shop.Application.Commands.Sellers.Commands.UpdateSeller;
using Shop.Application.Commands.Sellers.Queries.GetSeller;
using Shop.Application.Commands.Sellers.Queries.GetSellersList;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : BaseController
    {
        public SellerController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<SellerVm> Create([FromBody] CreateSellerModel seller)
        {
            return await _mediator.Send(new CreateSellerCommand
            {
                Name = seller.Name,
                Description = seller.Description,
                Contact = seller.Contact
            });
        }

        [HttpGet("get")]
        public async Task<ActionResult<SellerVm>> Get(long id)
        {
            return await _mediator.Send(new GetSellerQuery { Id = id });
        }

        [HttpGet("getlist")]
        public async Task<ActionResult<SellersListVm>> GetAll()
        {
            return await _mediator.Send(new GetSellersListQuery { });
        }

        [HttpPost("update")]
        public async Task<SellerVm> Update([FromBody] UpdateSellerModel seller)
        {
            return await _mediator.Send(new UpdateSellerCommand
            {
                Id = seller.Id,
                Name = seller.Name,
                Description= seller.Description,
                Contact= seller.Contact
            });
        }

        [HttpDelete("delete")]
        public async Task<SellerVm> Delete(long id)
        {
            return await _mediator.Send(new DeleteSellerCommand { Id = id });
        }
    }
}

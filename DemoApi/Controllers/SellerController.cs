using DemoApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Application.Sellers.Queries.GetSellersList;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Sellers.Queries.GetSeller;
using DemoApi.Models.SellerModels;
using Shop.Application.Sellers.Commands.CreateSeller;
using Shop.Application.Sellers.Commands.DeleteSeller;
using Shop.Application.Sellers.Commands.UpdateSeller;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SellerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        public async Task<long> Create([FromBody] CreateSellerModel seller)
        {
            return await _mediator.Send(new CreateSellerCommand
            {
                Name = seller.Name,
                Description = seller.Description,
                Contact = seller.Contact
            });
        }

        [HttpDelete("delete/{id}")]
        public async Task<Unit> Delete(long id)
        {
            return await _mediator.Send(new DeleteSellerCommand { Id = id });
        }

        [HttpPost("update")]
        public async Task<Unit> Update([FromBody] UpdateSellerModel seller)
        {
            await _mediator.Send(new UpdateSellerCommand
            {
                Id = seller.Id,
                Name = seller.Name,
                Description= seller.Description,
                Contact= seller.Contact
            });
            return Unit.Value;
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<SellerVm>> Get(long id)
        {
            return await _mediator.Send(new GetSeller { Id = id });
        }

        [HttpGet("getList")]
        public async Task<ActionResult<SellersListVm>> GetAll()
        {
            return await _mediator.Send(new GetSellersListQuery { });
        }
    }
}

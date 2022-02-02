using DemoApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Application.Sellers.Queries.GetSellerList;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Sellers.Queries.GetSellerDetails;

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

        [HttpGet]
        public async Task<ActionResult<SellerDetailsVm>> GetAll()
        {
            return await _mediator.Send(new GetSellerDetailsQuery { });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SellerListVm>> Get(long id)
        {
            return await _mediator.Send(new GetSellerListQuery { Id = id });
        }
    }
}

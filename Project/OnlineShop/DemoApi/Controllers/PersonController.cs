
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Customers.Commands.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
                
        [HttpPost("create")]
        public async Task<Guid> Create([FromBody] CustomerModel customer)
        {
           return await _mediator.Send(
               new CreateCustomerCommand
               {
                   Name = customer.Name,
                   Email = customer.Email,
                   PhoneNumber = customer.PhoneNumber
               });
        } 
        
        // POST api/<PersonController>
        //[HttpPost]
        //public async Task<PersonModel> Post([FromBody] PersonModel value)
        //{
        //    var model = new InsertPersonCommand(value.FirstName, value.LastName);
        //    return await _mediator.Send(model);
        //}
    }
}

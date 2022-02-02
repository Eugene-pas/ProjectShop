using DemoApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Customers.Commands.CreateCustomer;
using Shop.Application.Customers.Commands.DeleteCustomer;
using Shop.Application.Customers.Commands.UpdateCustomer;
using Shop.Application.Customers.Queries.GetCustomer;
using Shop.Application.Customers.Queries.GetCustomersList;
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
        public async Task<long> Create([FromBody] CustomerModel customer)
        {
           return await _mediator.Send(
               new CreateCustomerCommand
               {
                   Name = customer.Name,
                   Email = customer.Email,
                   PhoneNumber = customer.PhoneNumber
               });
        } 
        
        [HttpDelete("delete/{id}")]
        public async Task<Unit> Delete(long id)
        {
            return await _mediator.Send(new DeleteCustomerCommand { Id = id });
        }
        [HttpPost("update")]
        public async Task<Unit> Update([FromBody] UpdateCustomerModel customer)
        {
            await _mediator.Send(new UpdateCustomerCommand
            {
                Id =customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            });
            return Unit.Value;
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<CustomerVm>> Get(long id)
        {
            return await _mediator.Send(new GetCustomerQuery { Id = id });
        }
        [HttpGet("getlist")]
        public async Task<ActionResult<CustomersListVm>> GetAll()
        {
            return await _mediator.Send(new GetCustomersListQuery { });
        }
        
    }
}

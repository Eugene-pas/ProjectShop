using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.Application.Commands.Customers.Commands.CreateCustomer;
using Shop.Application.Commands.Customers.Commands.DeleteCustomer;
using Shop.Application.Commands.Customers.Commands.UpdateCustomer;
using Shop.Application.Commands.Customers.Queries.GetCustomer;
using Shop.Application.Commands.Customers.Queries.GetCustomersList;


namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        public CustomerController(IMediator mediator) : base(mediator) { }
            
        [HttpPost("create")]
        public async Task<CustomerVm> Create(string name, string email, string phone)
        {
           return await _mediator.Send(
               new CreateCustomerCommand
               {
                   Name = name,
                   Email = email,
                   PhoneNumber = phone
               });
        }

        

        [HttpDelete("delete")]
        public async Task<CustomerVm> Delete(long id)
        {
            return await _mediator.Send(new DeleteCustomerCommand { Id = id });
        }

        [HttpPost("update")]
        public async Task<CustomerVm> Update(long id, string name, string email, string phone)
        {
            return await _mediator.Send(new UpdateCustomerCommand
            {
                Id = id,
                Name = name,
                Email = email,
                PhoneNumber = phone
            });
        }

        [HttpGet("get")]
        public async Task<ActionResult<CustomerVm>> Get(long id)
        {
            return await _mediator.Send(new GetCustomerQuery { Id = id });
        }

        [HttpGet("getlist")]
        public async Task<ActionResult<CustomersListVm>> GetList()
        {
            return await _mediator.Send(new GetCustomersListQuery());
        }
        
    }
}

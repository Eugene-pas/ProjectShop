using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.Application.Commands.Deliveries.Commands.CreateDelivery;
using Shop.Application.Commands.Deliveries.Commands.DeleteDelivery;
using Shop.Application.Commands.Deliveries.Commands.UpdateDelivery;
using Shop.Application.Commands.Deliveries.Queries.GetDeliveriesList;
using Shop.Application.Commands.Deliveries.Queries.GetDelivery;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : BaseController
    {
        public DeliveryController(IMediator mediator) : base(mediator) { }

        [HttpPost("create")]
        public async Task<DeliveryVm> Create(string Name)
        {
            return await _mediator.Send(
                new CreateDeliveryCommand
                {
                    Name = Name
                });
        }

        [HttpDelete("delete/{id}")]
        public async Task<DeliveryVm> Delete(long id)
        {
            return await _mediator.Send(new DeleteDeliveryCommand { Id = id });
        }

        [HttpPost("update")]
        public async Task<DeliveryVm> Update(long id, string name)
        {
            return await _mediator.Send(new UpdateDeliveryCommand
            {
                Id = id,
                Name = name
            });
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<DeliveryVm>> Get(long id)
        {
            return await _mediator.Send(new GetDeliveryQuery { Id = id });
        }

        [HttpGet("getlist")]
        public async Task<ActionResult<DeliveriesListVm>> GetAll()
        {
            return await _mediator.Send(new GetDeliveriesListQuery { });
        }
    }
}

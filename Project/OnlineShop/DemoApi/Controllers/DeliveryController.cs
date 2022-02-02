using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Deliveries.Commands.CreateDelivery;
using Shop.Application.Deliveries.Commands.DeleteDelivery;
using Shop.Application.Deliveries.Commands.UpdateDelivery;
using Shop.Application.Deliveries.Queries.GetDeliveriesList;
using Shop.Application.Deliveries.Queries.GetDelivery;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeliveryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<long> Create(string Name)
        {
            return await _mediator.Send(
                new CreateDeliveryCommand
                {
                    Name = Name
                });
        }

        [HttpDelete("delete/{id}")]
        public async Task<Unit> Delete(long id)
        {
            return await _mediator.Send(new DeleteDeliveryCommand { Id = id });
        }

        [HttpPost("update")]
        public async Task<Unit> Update(long id, string name)
        {
            await _mediator.Send(new UpdateDeliveryCommand
            {
                Id = id,
                Name = name
            });
            return Unit.Value;
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

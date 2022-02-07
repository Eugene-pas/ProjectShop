using DemoApi.Models.DeliveryProductConnectionModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Commands_and_Queries.DeliveryConnections;
using Shop.Application.Commands_and_Queries.DeliveryConnections.Commands.DeleteDeliveryProductConnection;
using Shop.Application.Commands_and_Queries.DeliveryConnections.Commands.UpdateDeliveryProductConnection;
using Shop.Application.Commands_and_Queries.DeliveryConnections.Queries.GetDeliveryProductConnectionsList;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryProductConnectionController : BaseController
    {
        public DeliveryProductConnectionController(IMediator mediator) : base(mediator) { }

        
        [HttpPost("create")]
        public async Task<long> Create([FromBody] CreateDeliveryProductConnectionModel connection)
        {
            return await _mediator.Send(new CreateDeliveryProductConnectionCommand
            {
                DeliveryId = connection.DeliveryId,
                ProductId = connection.ProductId,
            });

        }

        [HttpDelete("delete/{id}")]
        public async Task<Unit> Delete(long id)
        {
            return await _mediator.Send(new DeleteDeliveryProductConnectionCommand { Id = id });
        }
        [HttpPost("update")]
        public async Task<Unit> Update([FromBody] DeliveryProductConnectionModel connection)
        {
            await _mediator.Send(new UpdateDeliveryProductConnectionCommand
            {
                Id = connection.Id,
                DeliveryId = connection.DeliveryId,
                ProductId=connection.ProductId,
            });
            return Unit.Value;
        }

        [HttpGet("getList")]
        public async Task<ActionResult<DeliveryProductConnectionsListVm>> GetAll()
        {
            return await _mediator.Send(new GetDeliveryProductConnectionsListQuery { });
        }
    }
}

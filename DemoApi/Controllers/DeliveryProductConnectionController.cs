using DemoApi.Models.DeliveryProductConnectionModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.Application.Commands.DeliveryConnections.Commands.CreatDeliveryProductConnection;
using Shop.Application.Commands.DeliveryConnections.Commands.DeleteDeliveryProductConnection;
using Shop.Application.Commands.DeliveryConnections.Commands.UpdateDeliveryProductConnection;
using Shop.Application.Commands.DeliveryConnections.Queries;
using Shop.Application.Commands.DeliveryConnections.Queries.GetDeliveryProductConnectionsList;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryProductConnectionController : BaseController
    {
        public DeliveryProductConnectionController(IMediator mediator) : base(mediator) { }

        
        [HttpPost("create")]
        public async Task<DeliveryProductConnectionVm> Create([FromBody] CreateDeliveryProductConnectionModel connection)
        {
            return await _mediator.Send(new CreateDeliveryProductConnectionCommand
            {
                DeliveryId = connection.DeliveryId,
                ProductId = connection.ProductId,
            });

        }

        [HttpDelete("delete/{id}")]
        public async Task<DeliveryProductConnectionVm> Delete(long id)
        {
            return await _mediator.Send(new DeleteDeliveryProductConnectionCommand { Id = id });
        }
        [HttpPost("update")]
        public async Task<DeliveryProductConnectionVm> Update([FromBody] DeliveryProductConnectionModel connection)
        {
            return await _mediator.Send(new UpdateDeliveryProductConnectionCommand
            {
                Id = connection.Id,
                DeliveryId = connection.DeliveryId,
                ProductId=connection.ProductId,
            });
        }

        [HttpGet("getList")]
        public async Task<ActionResult<DeliveryProductConnectionsListVm>> GetAll()
        {
            return await _mediator.Send(new GetDeliveryProductConnectionsListQuery { });
        }
    }
}

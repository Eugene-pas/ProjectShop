using MediatR;
using Shop.Application.Commands.Deliveries.Queries.GetDelivery;

namespace Shop.Application.Commands.Deliveries.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommand
        : IRequest<DeliveryVm>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}

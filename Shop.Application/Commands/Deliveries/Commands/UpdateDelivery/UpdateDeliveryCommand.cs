using MediatR;
using Shop.Application.Deliveries.Queries.GetDelivery;

namespace Shop.Application.Deliveries.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommand
        : IRequest<DeliveryVm>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}

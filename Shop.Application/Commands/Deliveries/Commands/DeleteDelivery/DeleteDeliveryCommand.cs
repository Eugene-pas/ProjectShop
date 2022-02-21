using MediatR;
using Shop.Application.Commands.Deliveries.Queries.GetDelivery;

namespace Shop.Application.Commands.Deliveries.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommand
        : IRequest<DeliveryVm>
    {
        public long Id { get; set; }
    }
}

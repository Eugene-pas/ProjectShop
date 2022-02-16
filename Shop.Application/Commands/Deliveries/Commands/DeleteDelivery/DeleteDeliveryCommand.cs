using MediatR;
using Shop.Application.Deliveries.Queries.GetDelivery;

namespace Shop.Application.Deliveries.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommand
        : IRequest<DeliveryVm>
    {
        public long Id { get; set; }
    }
}

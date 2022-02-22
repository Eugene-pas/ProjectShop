using MediatR;

namespace Shop.Application.Commands.Deliveries.Queries.GetDelivery
{
    public class GetDeliveryQuery : IRequest<DeliveryVm>
    {
        public long Id { get; set; }
    }
}

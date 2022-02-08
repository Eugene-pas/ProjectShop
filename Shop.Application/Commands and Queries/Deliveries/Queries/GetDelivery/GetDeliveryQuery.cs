using MediatR;
using Shop.Application.Commands_and_Queries.Deliveries;

namespace Shop.Application.Deliveries.Queries.GetDelivery
{
    public class GetDeliveryQuery : IRequest<DeliveryVm>
    {
        public long Id { get; set; }
    }
}

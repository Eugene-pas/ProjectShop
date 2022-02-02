using MediatR;

namespace Shop.Application.Delivery.Commands.CreateDelivery
{
    public class CreateDeliveryCommand : IRequest<long>
    {
        public long Id { get; set; }

    }
}

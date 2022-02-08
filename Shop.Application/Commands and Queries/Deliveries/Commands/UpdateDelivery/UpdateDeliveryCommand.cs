using MediatR;
using Shop.Application.Commands_and_Queries.Deliveries;

namespace Shop.Application.Deliveries.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommand
        : IRequest<DeliveryVm>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}

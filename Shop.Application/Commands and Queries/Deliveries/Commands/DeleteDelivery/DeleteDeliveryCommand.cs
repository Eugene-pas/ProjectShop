using MediatR;
using Shop.Application.Commands_and_Queries.Deliveries;

namespace Shop.Application.Deliveries.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommand
        : IRequest<DeliveryVm>
    {
        public long Id { get; set; }
    }
}

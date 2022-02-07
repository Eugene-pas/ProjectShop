using MediatR;

namespace Shop.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
        : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}

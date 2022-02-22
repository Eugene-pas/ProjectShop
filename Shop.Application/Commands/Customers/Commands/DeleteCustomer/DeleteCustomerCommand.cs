using MediatR;
using Shop.Application.Commands.Customers.Queries.GetCustomer;

namespace Shop.Application.Commands.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
        : IRequest<CustomerVm>
    {
        public long Id { get; set; }
    }
}

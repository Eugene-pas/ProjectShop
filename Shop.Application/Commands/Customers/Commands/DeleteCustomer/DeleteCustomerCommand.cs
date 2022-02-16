using MediatR;
using Shop.Application.Customers.Queries.GetCustomer;

namespace Shop.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
        : IRequest<CustomerVm>
    {
        public long Id { get; set; }
    }
}

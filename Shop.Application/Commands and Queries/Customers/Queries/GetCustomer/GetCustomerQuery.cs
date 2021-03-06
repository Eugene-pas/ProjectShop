using MediatR;

namespace Shop.Application.Customers.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<CustomerVm>
    {
        public long Id { get; set; }
    }
}

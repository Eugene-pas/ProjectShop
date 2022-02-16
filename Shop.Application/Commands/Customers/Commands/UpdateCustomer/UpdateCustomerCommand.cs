using MediatR;
using Shop.Domain.Entities;
using System.Collections.Generic;
using Shop.Application.Customers.Queries.GetCustomer;

namespace Shop.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
        : IRequest<CustomerVm>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Order> Order { get; set; }

    }
}

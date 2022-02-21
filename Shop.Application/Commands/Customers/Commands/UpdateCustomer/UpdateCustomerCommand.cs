using System.Collections.Generic;
using MediatR;
using Shop.Application.Commands.Customers.Queries.GetCustomer;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Customers.Commands.UpdateCustomer
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

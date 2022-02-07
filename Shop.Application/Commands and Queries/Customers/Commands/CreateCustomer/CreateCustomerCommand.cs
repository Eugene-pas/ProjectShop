using MediatR;
using Shop.Domain.Entities;
using System.Collections.Generic;

namespace Shop.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand 
        : IRequest<long>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Order> Order { get; set; }

    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
        : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}

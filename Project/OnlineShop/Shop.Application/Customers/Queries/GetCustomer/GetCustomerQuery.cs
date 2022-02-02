using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<CustomerVm>
    {
        public long Id { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Queries.GetAllOrder
{
    public class GetAllOrderCommand
        : IRequest<OrderVm>
    {
        public long IdCustomer { get; set; }
        public long IdDelivery { get; set; }
    }
}

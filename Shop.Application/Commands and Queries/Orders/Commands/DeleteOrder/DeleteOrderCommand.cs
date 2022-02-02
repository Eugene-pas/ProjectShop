using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand
        : IRequest
    {
        public long Id { get; set; }
    }
}

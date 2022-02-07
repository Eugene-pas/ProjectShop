using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.UpdateOrderProductConnections
{
    public class UpdateOrderProductConnectionsCommand
        : IRequest
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
    }
}

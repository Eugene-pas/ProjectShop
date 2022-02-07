using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections
{
    public class CreateDeliveryProductConnectionCommand
        : IRequest<long>
    {       
        public long DeliveryId { get; set; }
        public long ProductId { get; set; }
    }
}

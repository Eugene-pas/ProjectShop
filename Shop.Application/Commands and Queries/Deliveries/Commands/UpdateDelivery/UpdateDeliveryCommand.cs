using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Deliveries.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommand
        : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}

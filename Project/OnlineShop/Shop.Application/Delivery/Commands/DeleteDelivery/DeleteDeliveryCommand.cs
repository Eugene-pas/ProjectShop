using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Delivery.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommand
        : IRequest
    {
        public long Id { get; set; }
    }
}

using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand
        : IRequest
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Adress { get; set; }
        public  long CustomerId { get; set; }
        public long DeliveryId { get; set; }
    }
}

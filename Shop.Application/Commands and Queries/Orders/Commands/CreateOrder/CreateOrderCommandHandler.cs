using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
    {
        private readonly IDataBaseContext _dbContext;
        public CreateOrderCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Date = DateTime.Now,
                Adress = request.Adress,
                Customer = AddCustomer(request.CustomerId),
                Delivery = AddDelivery(request.DeliveryId)
            };
            await _dbContext.Order.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
        private Customer AddCustomer(long id)
        {            
            return _dbContext.Customer.Find(id);
        }
        private Delivery AddDelivery(long id)
        {
            return _dbContext.Delivery.Find(id);
        }
    }
}

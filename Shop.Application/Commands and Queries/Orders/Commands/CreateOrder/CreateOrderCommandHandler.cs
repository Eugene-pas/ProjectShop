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
                Customer = null,
                Delivery = null
            };
            await _dbContext.Order.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}

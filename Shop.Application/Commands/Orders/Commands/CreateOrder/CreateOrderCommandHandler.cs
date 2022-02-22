using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Commands.Orders.Queries.GetOrder;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : HandlersBase, IRequestHandler<CreateOrderCommand, OrderVm>
    {
        public CreateOrderCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderVm> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Date = DateTime.Now,
                Adress = request.Adress,
                Customer = _dbContext.Customer.Find(request.CustomerId),
                Delivery = _dbContext.Delivery.Find(request.DeliveryId)
            };

            await _dbContext.Order.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<OrderVm>(order);
        }      
    }
}

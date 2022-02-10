using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Orders.Queries.GetOrder;
using Shop.Application.Exceptions;
using Shop.Application.Common;
using Shop.Domain.Entities;

namespace Shop.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler
        : HandlersBase, IRequestHandler<UpdateOrderCommand, OrderVm>
    {
        public UpdateOrderCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderVm> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Order
                .FirstOrDefaultAsync(order =>
            order.Id == request.Id, cancellationToken);

            _ = order ?? throw new NotFoundException(nameof(Order), order.Id);

            order.Date = DateTime.Now;
            order.Adress = request.Adress;
            order.Customer = _dbContext.Customer.Find(request.CustomerId);
            order.Delivery = _dbContext.Delivery.Find(request.DeliveryId);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderVm>(order);
        }
    }
}

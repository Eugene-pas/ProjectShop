using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Orders.Queries.GetOrder;
using Shop.Application.Exceptions;
using Shop.Application.Common;
using Shop.Domain.Entities;

namespace Shop.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler
        : HandlersBase, IRequestHandler<DeleteOrderCommand, OrderVm>
    {
        public DeleteOrderCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderVm> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Order
               .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = order ?? throw new NotFoundException(nameof(Order), order.Id);

            _dbContext.Order.Remove(order);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<OrderVm>(order);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Application.Common;

namespace Shop.Application.Orders.Queries.GetOrder
{
    public class GetOrderQueryHandler : HandlersBase, IRequestHandler<GetOrderQuery, OrderVm>
    {
        public GetOrderQueryHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderVm> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Order
                .FirstOrDefaultAsync(order =>
                order.Id == request.Id, cancellationToken);

            _ = entity ?? throw new NotFoundException(nameof(Order), request.Id);

            return _mapper.Map<OrderVm>(entity);
        }
    }
}

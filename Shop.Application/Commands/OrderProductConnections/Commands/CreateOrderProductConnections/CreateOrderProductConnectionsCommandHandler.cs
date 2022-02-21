using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Commands.OrderProductConnections.Queries;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.OrderProductConnections.Commands.CreateOrderProductConnections
{
    public class CreateOrderProductConnectionsCommandHandler
        : HandlersBase, IRequestHandler<CreateOrderProductConnectionsCommand, OrderProductConnectionVm>
    {
        public CreateOrderProductConnectionsCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderProductConnectionVm> Handle(CreateOrderProductConnectionsCommand request,
            CancellationToken cancellationToken)
        {
            var connection = new OrderProductConnection
            {
                Order = _dbContext.Order.Find(request.OrderId),
                Product = _dbContext.Product.Find(request.ProductId)
            };

            await _dbContext.OrderProductConnection.AddAsync(connection, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderProductConnectionVm>(connection);
        }
    }
}

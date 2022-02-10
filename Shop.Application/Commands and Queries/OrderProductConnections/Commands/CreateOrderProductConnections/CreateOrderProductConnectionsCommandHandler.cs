using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Application.OrderProductConnections.Queries;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.CreateOrderProductConnections
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

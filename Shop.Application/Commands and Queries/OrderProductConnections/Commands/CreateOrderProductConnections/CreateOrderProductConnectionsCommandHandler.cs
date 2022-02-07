using MediatR;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.CreateOrderProductConnections
{
    public class CreateOrderProductConnectionsCommandHandler
        : IRequestHandler<CreateOrderProductConnectionsCommand, long>
    {
        private readonly IDataBaseContext _dbContext;

        public CreateOrderProductConnectionsCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<long> Handle(CreateOrderProductConnectionsCommand request, CancellationToken cancellationToken)
        {
            var connection = new OrderProductConnection
            {
                Order = _dbContext.Order.Find(request.OrderId),
                Product = _dbContext.Product.Find(request.ProductId)
            };
            await _dbContext.OrderProductConnection.AddAsync(connection, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return connection.Id;
        }
    }
}

using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.DeleteOrderProductConnections
{
    public class DeleteOrderProductConnectionsCommandHandler
    : IRequestHandler<DeleteOrderProductConnectionsCommand>
    {
        private readonly IDataBaseContext _dbContext;

        public DeleteOrderProductConnectionsCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteOrderProductConnectionsCommand request, CancellationToken cancellationToken)
        {
            var connection = await _dbContext.OrderProductConnection
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = connection ?? throw new NotFoundException(nameof(OrderProductConnection), connection.Id);

            _dbContext.OrderProductConnection.Remove(connection);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

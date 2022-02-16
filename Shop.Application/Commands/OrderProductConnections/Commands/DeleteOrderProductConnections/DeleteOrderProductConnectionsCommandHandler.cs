using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.OrderProductConnections.Queries;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.DeleteOrderProductConnections
{
    public class DeleteOrderProductConnectionsCommandHandler
    : HandlersBase, IRequestHandler<DeleteOrderProductConnectionsCommand, OrderProductConnectionVm>
    {
        public DeleteOrderProductConnectionsCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderProductConnectionVm> Handle(DeleteOrderProductConnectionsCommand request, 
            CancellationToken cancellationToken)
        {
            var connection = await _dbContext.OrderProductConnection
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = connection ?? throw new NotFoundException(nameof(OrderProductConnection), connection.Id);

            _dbContext.OrderProductConnection.Remove(connection);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderProductConnectionVm>(connection);
        }
    }
}

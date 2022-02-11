using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Application.DeliveryConnections.Queries;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Commands.DeleteDeliveryProductConnection
{
    public class DeleteDeliveryProductConnectionCommandHandler
         : HandlersBase, IRequestHandler<DeleteDeliveryProductConnectionCommand, DeliveryProductConnectionVm>
    {
        public DeleteDeliveryProductConnectionCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<DeliveryProductConnectionVm> Handle(DeleteDeliveryProductConnectionCommand request, CancellationToken cancellationToken)
        {
            var connection = await _dbContext.DeliveryProductConnection
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = connection ?? throw new NotFoundException(nameof(Product), connection.Id);

            _dbContext.DeliveryProductConnection.Remove(connection);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<DeliveryProductConnectionVm>(connection);
        }
    }
}

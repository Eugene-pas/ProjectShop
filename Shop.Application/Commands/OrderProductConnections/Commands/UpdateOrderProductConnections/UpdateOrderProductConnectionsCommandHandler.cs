using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.OrderProductConnections.Queries;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Commands.UpdateOrderProductConnections
{
    public class UpdateOrderProductConnectionsCommandHandler
    : HandlersBase, IRequestHandler<UpdateOrderProductConnectionsCommand, OrderProductConnectionVm>
    {
        public UpdateOrderProductConnectionsCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderProductConnectionVm> Handle(UpdateOrderProductConnectionsCommand request, CancellationToken cancellationToken)
        {
            var connection = await _dbContext.OrderProductConnection
                .FirstOrDefaultAsync(customer =>
            customer.Id == request.Id, cancellationToken);

            _ = connection ?? throw new NotFoundException(nameof(OrderProductConnection), connection.Id);

            connection.Product = _dbContext.Product.Find(request.ProductId);
            connection.Order = _dbContext.Order.Find(request.OrderId);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderProductConnectionVm>(connection);
        }
    }
}

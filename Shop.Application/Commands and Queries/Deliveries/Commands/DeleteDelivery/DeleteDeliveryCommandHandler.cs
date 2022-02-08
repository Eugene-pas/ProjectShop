using MediatR;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Customers.Commands;
using Shop.Application.Exceptions;

namespace Shop.Application.Deliveries.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommandHandler
        : HandlersBase, IRequestHandler<DeleteDeliveryCommand>
    {
        public DeleteDeliveryCommandHandler(IDataBaseContext dbContext) : base(dbContext) { }
     
        public async Task<Unit> Handle(DeleteDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _dbContext.Delivery
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = delivery ?? throw new NotFoundException(nameof(DeleteDeliveryCommand), request.Id);
            _dbContext.Delivery.Remove(delivery);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

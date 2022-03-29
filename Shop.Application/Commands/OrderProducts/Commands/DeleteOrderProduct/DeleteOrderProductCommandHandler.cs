using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Commands.OrderProducts.Queries;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.OrderProducts.Commands.DeleteOrderProduct
{
    public class DeleteOrderProductCommandHandler
        : HandlersBase, IRequestHandler<DeleteOrderProductCommand, OrderProductVm>
    {
        public DeleteOrderProductCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderProductVm> Handle(DeleteOrderProductCommand request, 
            CancellationToken cancellationToken)
        {
            var product = await _dbContext.OrderProduct
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = product ?? throw new NotFoundException(nameof(OrderProduct), product.Id);

            _dbContext.OrderProduct.Remove(product);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderProductVm>(product);
        }
    }
}

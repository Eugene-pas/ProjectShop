using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.OrderProducts.Queries;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.OrderProducts.Commands.UpdateOrderProduct
{
    public class UpdateOrderProductCommandHandler
    : HandlersBase, IRequestHandler<UpdateOrderProductCommand, OrderProductVm>
    {
        public UpdateOrderProductCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderProductVm> Handle(UpdateOrderProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.OrderProduct
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            _ = product ?? throw new NotFoundException(nameof(OrderProduct), product.Id);

            product.Product = _dbContext.Product.Find(request.ProductId);
            product.Order = _dbContext.Order.Find(request.OrderId);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderProductVm>(product);
        }
    }
}

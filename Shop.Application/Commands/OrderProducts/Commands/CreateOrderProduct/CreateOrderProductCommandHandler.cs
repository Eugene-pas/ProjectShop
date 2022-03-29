using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Commands.OrderProducts.Queries;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.OrderProducts.Commands.CreateOrderProduct
{
    public class CreateOrderProductCommandHandler
        : HandlersBase, IRequestHandler<CreateOrderProductCommand, OrderProductVm>
    {
        public CreateOrderProductCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderProductVm> Handle(CreateOrderProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new OrderProduct
            {
                Order = _dbContext.Order.Find(request.OrderId),
                Product = _dbContext.Product.Find(request.ProductId)
            };

            await _dbContext.OrderProduct.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<OrderProductVm>(product);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler 
        : HandlersBase, IRequestHandler<DeleteProductCommand, ProductVm>
    {
        public DeleteProductCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ProductVm> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Product
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = product ?? throw new NotFoundException(nameof(Product), request.Id);

            _dbContext.Product.Remove(product);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductVm>(product);
        }
    }
}

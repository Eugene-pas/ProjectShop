using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;

namespace Shop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler 
        : IRequestHandler<DeleteProductCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteProductCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Product
                .FindAsync(new object[] { request.Id }, cancellationToken);
            _ = product ?? throw new NotFoundException(nameof(Product), product.Id);
            _dbContext.Product.Remove(product);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

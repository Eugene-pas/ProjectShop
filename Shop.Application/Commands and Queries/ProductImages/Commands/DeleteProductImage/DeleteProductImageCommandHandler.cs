using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.ProductImages.Commands.DeleteProductImage
{
    public class DeleteProductImageCommandHandler
        : IRequestHandler<DeleteProductImageCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteProductImageCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = await _dbContext.ProductImage
                .FindAsync(new object[] {request.Id}, cancellationToken);

            _ = productImage ?? throw new NotFoundException(nameof(Customer), productImage.Id);
            _dbContext.ProductImage.Remove(productImage);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

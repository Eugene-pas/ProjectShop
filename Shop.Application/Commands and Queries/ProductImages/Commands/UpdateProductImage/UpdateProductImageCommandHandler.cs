using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.ProductImages.Commands.UpdateProductImage
{
    public class UpdateProductImageCommandHandler
        : IRequestHandler<UpdateProductImageCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public UpdateProductImageCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = await _dbContext.ProductImage
                .FirstOrDefaultAsync(productImage =>
            productImage.Id == request.Id,cancellationToken);

            _ = productImage ?? throw new NotFoundException(nameof(ProductImage), productImage.Id);

            productImage.Image = request.Image;
            productImage.SortOrder = request.SortOrder;  
            productImage.Product = _dbContext.Product.Find(request.ProductId);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

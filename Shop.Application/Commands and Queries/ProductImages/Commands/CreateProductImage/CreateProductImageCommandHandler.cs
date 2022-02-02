using MediatR;
using Shop.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.ProductImages.Commands.CreateProductImage
{
    public class CreateProductImageCommandHandler
        : IRequestHandler<CreateProductImageCommand, long>
    {
        private readonly IDataBaseContext _dbContext;
        public CreateProductImageCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<long> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = new ProductImage 
            {                
                Image = request.Image,
                SortOrder = request.SortOrder,
                Product = null
            };
            await _dbContext.ProductImage.AddAsync(productImage, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return productImage.Id;
        }
    }
}

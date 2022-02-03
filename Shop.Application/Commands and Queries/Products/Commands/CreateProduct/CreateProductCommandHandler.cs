using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Entities;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler 
        : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IDataBaseContext _dbContext;
        public CreateProductCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<long> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                OnStorageCount = request.OnStorageCount,
                Rating = request.Rating
            };

            await _dbContext.Product.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}

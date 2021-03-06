using AutoMapper;
using MediatR;
using Shop.Application.Commands_and_Queries.Products;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Common;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler 
        : HandlersBase, IRequestHandler<CreateProductCommand, ProductVm>
    {
        public CreateProductCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }
        public async Task<ProductVm> Handle(CreateProductCommand request,
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
            return _mapper.Map<ProductVm>(product);
        }
    }
}

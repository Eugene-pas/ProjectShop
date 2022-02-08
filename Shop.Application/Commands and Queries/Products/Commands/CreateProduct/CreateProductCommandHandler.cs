using AutoMapper;
using MediatR;
using Shop.Application.Commands_and_Queries.Products;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler 
        : IRequestHandler<CreateProductCommand, ProductVm>
    {
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        private readonly IDataBaseContext _dbContext;
        public CreateProductCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
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

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.ProductImages.Queries.GetProductImageListForProduct
{
    public class GetProductImagesListForProductQueryHandler
        : IRequestHandler<GetProductImagesListForPruductQuery, ProductImageForProductVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductImagesListForProductQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductImageForProductVm> Handle(GetProductImagesListForPruductQuery request,
            CancellationToken cancellationToken)
        {
            
            var productImage = await _dbContext.ProductImage
                .Include(x => x.Product)
                .Where(x => x.Product.Id == request.ProductId)
                .ProjectTo<ProductImageForProductLookupDto>(_mapper.ConfigurationProvider)               
                .ToListAsync(cancellationToken);

            _ = productImage ?? throw new NotFoundException(nameof(ProductImage), productImage.ToString());

            return new ProductImageForProductVm { ProductImages = productImage };
        }
    }
}

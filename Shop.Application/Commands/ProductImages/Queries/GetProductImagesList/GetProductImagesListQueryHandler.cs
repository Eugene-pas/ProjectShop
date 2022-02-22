using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.ProductImages.Queries.GetProductImagesList
{
    public class GetProductImagesListQueryHandler
        : IRequestHandler<GetProductImagesListQuery, ProductImageVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductImagesListQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductImageVm> Handle(GetProductImagesListQuery request,
            CancellationToken cancellationToken)
        {
            var productImage = await _dbContext.ProductImage
                .ProjectTo<ProductImageLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProductImageVm { ProductImage = productImage };
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands_and_Queries.ProductImages.Queries;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.ProductImages.Queries.GetProducImagesList
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

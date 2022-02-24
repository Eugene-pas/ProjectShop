using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shop.Application.Commands.Products.Queries.GetProductsList;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;
using Shop.Application.Common.Pagination;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Filters.FiltrationByPrice
{
    public class GetFiltrationByPriceQueryHandler :
        IRequestHandler<GetFiltrationByPriceQuery, ProductPaginatedVm>
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseContext _dbContext;
        public GetFiltrationByPriceQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductPaginatedVm> Handle(GetFiltrationByPriceQuery request, CancellationToken cancellationToken)
        {
            var minPrice = request.MinPrice;
            var maxPrice = request.MaxPrice;

            if (maxPrice == 0)
                maxPrice = _dbContext.Product.Max(x => x.Price);

            var productList = _dbContext.Product
                .Include(x => x.Category)
                .Where(x => x.Category.Id == request.CategoryId)
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .ProjectTo<ProductsLookupDto>(_mapper.ConfigurationProvider);
                

            var paginatedList = await PaginatedList<ProductsLookupDto>
                .CreateAsync(productList, request.PageNumber, request.PageSize);

            return new ProductPaginatedVm
            {
                Products = paginatedList,
                Page = paginatedList.PageIndex,
                TotalPagesAmount = paginatedList.TotalPages,
                HasNextPage = paginatedList.HasNextPage,
                HasPreviousPage = paginatedList.HasPreviousPage
            };
        }
    }
}

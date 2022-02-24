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

namespace Shop.Application.Commands.Filters.FiltrationBySeller
{
    public class GetFiltrationBySellerQueryHandler :
        IRequestHandler<GetFiltrationBySellerQuery, ProductPaginatedVm>
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseContext _dbContext;
        public GetFiltrationBySellerQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async  Task<ProductPaginatedVm> Handle(GetFiltrationBySellerQuery request, CancellationToken cancellationToken)
        {
            var productList =  _dbContext.Product
                .Include(x => x.Category)
                .Include(x => x.Seller)
                .Where(x => x.Category.Id == request.CategoryId)
                .Where(x => x.Seller.Id == request.SellerId)
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

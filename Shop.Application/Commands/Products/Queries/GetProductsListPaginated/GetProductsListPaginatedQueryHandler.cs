using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Products.Queries.GetProductsList;
using Shop.Application.Common.Pagination;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Queries.GetProductsListPaginated
{
    public class GetProductsListPaginatedQueryHandler 
        : IRequestHandler<GetProductsListPaginatedQuery, ProductPaginatedVm>
    {
        private readonly IDataBaseContext _dbContext;

        public GetProductsListPaginatedQueryHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<ProductPaginatedVm> Handle(GetProductsListPaginatedQuery request, 
            CancellationToken cancellationToken)
        {
            var productQuery = _dbContext.Product
                .Include(x => x.Category)
                .Include(x => x.Seller)
                .Select(product => product);

            var paginatedList = await PaginatedList<Product>
                .CreateAsync(productQuery, request.PageNumber, request.PageSize);

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

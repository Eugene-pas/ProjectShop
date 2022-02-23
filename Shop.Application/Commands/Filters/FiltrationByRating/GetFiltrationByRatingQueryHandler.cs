using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;
using Shop.Application.Common.Pagination;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Filters.FiltrationByRating
{
    internal class GetFiltrationByRatingQueryHandler
    : IRequestHandler<GetFiltrationByRatingQuery, ProductPaginatedVm>
    {
        private readonly IDataBaseContext _dbContext;
        public GetFiltrationByRatingQueryHandler(IDataBaseContext dbContext) => _dbContext = dbContext;

        public async Task<ProductPaginatedVm> Handle(GetFiltrationByRatingQuery request, CancellationToken cancellationToken)
        {
            var productList = _dbContext.Product
                .Include(x => x.Category)
                .Where(x => x.Category.Id == request.CategoryId)               
                .Where(x => Math.Round(x.Rating) == request.Rating);

            var paginatedList = await PaginatedList<Product>
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

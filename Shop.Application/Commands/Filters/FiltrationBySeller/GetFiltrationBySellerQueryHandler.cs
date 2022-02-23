using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;
using Shop.Application.Common.Pagination;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Filters.FiltrationBySeller
{
    public class GetFiltrationBySellerQueryHandler :
        IRequestHandler<GetFiltrationBySellerQuery, ProductPaginatedVm>
    {
        private readonly IDataBaseContext _dbContext;
        public GetFiltrationBySellerQueryHandler(IDataBaseContext dbContext) => _dbContext = dbContext;
        public async  Task<ProductPaginatedVm> Handle(GetFiltrationBySellerQuery request, CancellationToken cancellationToken)
        {
            var productList =  _dbContext.Product
                .Include(x => x.Category)
                .Include(x => x.Seller)
                .Where(x => x.Category.Id == request.CategoryId)
                .Where(x => x.Seller.Id == request.SellerId);

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

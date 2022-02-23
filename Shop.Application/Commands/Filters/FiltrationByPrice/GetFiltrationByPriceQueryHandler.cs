using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;
using Shop.Application.Common.Pagination;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Filters.FiltrationByPrice
{
    public class GetFiltrationByPriceQueryHandler :
        IRequestHandler<GetFiltrationByPriceQuery, ProductPaginatedVm>
    {
        private readonly IDataBaseContext _context;

        public GetFiltrationByPriceQueryHandler(IDataBaseContext context) => _context = context;

        public async Task<ProductPaginatedVm> Handle(GetFiltrationByPriceQuery request, CancellationToken cancellationToken)
        {
            var minPrice = request.MinPrice;
            var maxPrice = request.MaxPrice;

            if (maxPrice == 0)
                maxPrice = _context.Product.Max(x => x.Price);

            var productList = _context.Product
                .Include(x => x.Category)
                .Where(x => x.Category.Id == request.CategoryId)
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice);

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

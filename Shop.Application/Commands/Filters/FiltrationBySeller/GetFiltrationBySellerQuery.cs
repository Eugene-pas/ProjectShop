using MediatR;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;

namespace Shop.Application.Commands.Filters.FiltrationBySeller
{
    public class GetFiltrationBySellerQuery : IRequest<ProductPaginatedVm>
    {
        public int PageNumber { get; set; }
        
        public int PageSize { get; set; }

        public long CategoryId { get; set; }

        public long SellerId { get; set; }
    }
}

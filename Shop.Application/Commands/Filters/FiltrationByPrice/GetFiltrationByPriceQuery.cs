using MediatR;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;

namespace Shop.Application.Commands.Filters.FiltrationByPrice
{
    public class GetFiltrationByPriceQuery : IRequest<ProductPaginatedVm>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long CategoryId { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}

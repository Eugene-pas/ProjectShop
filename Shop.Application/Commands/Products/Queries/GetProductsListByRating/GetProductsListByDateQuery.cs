using MediatR;
using Shop.Application.Commands.Products.Queries.GetProductsList;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByRating
{
    public class GetProductsListByRatingQuery 
        : IRequest<ProductPaginatedVm>
    {
        public long CategoryId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

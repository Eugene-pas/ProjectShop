using MediatR;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByCategory
{
    public class GetProductsListByCategoryQuery
    : IRequest<GetProductsListByCategoryVm> 
    {
        public long CategoryId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}


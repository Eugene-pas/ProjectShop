using System;
using MediatR;

namespace Shop.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<ProductsListVm>
    {
        public long Id { get; set; }
    }
}

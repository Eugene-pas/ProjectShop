using MediatR;
using Shop.Domain.Entities;
using System.Collections.Generic;
using Shop.Application.Commands.Products.Queries.GetProductsList;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByCategory
{
    public class GetProductsListByCategoryQuery
    : IRequest<ProductsListVm> 
    {
        public long CategoryId { get; set; }
    }
}


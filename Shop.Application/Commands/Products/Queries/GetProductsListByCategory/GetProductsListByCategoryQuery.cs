using MediatR;
using Shop.Domain.Entities;
using System.Collections.Generic;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByCategory
{
    public class GetProductsListByCategoryQuery
    : IRequest<List<Product>> 
    {
        public long CategoryId { get; set; }
    }
}


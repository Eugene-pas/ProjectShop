﻿using MediatR;
using Shop.Application.Products.Queries.GetProductsList;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByPrice
{
    public class GetProductsListByPriceIncreaseQuery : IRequest<ProductsListVm>
    {
        public long CategoryId { get; set; }
    }
}

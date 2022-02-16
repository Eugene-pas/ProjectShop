﻿using MediatR;
using Shop.Application.Products.Queries.GetProductsList;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByRating
{
    public class GetProductsListByRatingQuery : IRequest<ProductsListVm>
    {
        public long CategoryId { get; set; }
    }
}
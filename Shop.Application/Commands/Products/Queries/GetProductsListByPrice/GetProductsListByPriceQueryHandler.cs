﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Products.Queries.GetProductsList;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByPrice
{
    public class GetProductsListByPriceQueryHandler
        : IRequestHandler<GetProductsListByPriceQuery, ProductsListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseContext _dbContext;

        public GetProductsListByPriceQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductsListVm> Handle(GetProductsListByPriceQuery request, CancellationToken cancellationToken)
        {
            var productQuery = await _dbContext.Product
                .Include(x => x.Category)
                .Where(x => x.Category.Id == request.CategoryId)
                .ProjectTo<ProductsLookupDto>(_mapper.ConfigurationProvider)
                .OrderBy(x => x.Price)
                .ToListAsync(cancellationToken);

            return new ProductsListVm { Products = productQuery };
        }
    }
}
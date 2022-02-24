﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;
using Shop.Application.Common.Pagination;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shop.Application.Commands.Products.Queries.GetProductsList;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByPrice
{
    public class GetProductsListByPriceIncreaseQueryHandler
        : IRequestHandler<GetProductsListByPriceIncreaseQuery, ProductPaginatedVm>
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseContext _dbContext;
        public GetProductsListByPriceIncreaseQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductPaginatedVm> Handle(GetProductsListByPriceIncreaseQuery request, CancellationToken cancellationToken)
        {
            var productQuery = _dbContext.Product
                .Include(x => x.Category)
                .Where(x => x.Category.Id == request.CategoryId)
                .OrderBy(x => x.Price)
                .ProjectTo<ProductsLookupDto>(_mapper.ConfigurationProvider);
                


            var paginatedList = await PaginatedList<ProductsLookupDto>
                .CreateAsync(productQuery, request.PageNumber, request.PageSize);

            return new ProductPaginatedVm
            {
                Products = paginatedList,
                Page = paginatedList.PageIndex,
                TotalPagesAmount = paginatedList.TotalPages,
                HasNextPage = paginatedList.HasNextPage,
                HasPreviousPage = paginatedList.HasPreviousPage
            };
        }
    }
}

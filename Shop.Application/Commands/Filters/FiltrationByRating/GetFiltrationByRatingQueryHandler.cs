using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;
using Shop.Application.Common.Pagination;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shop.Application.Commands.Products.Queries.GetProductsList;

namespace Shop.Application.Commands.Filters.FiltrationByRating
{
    internal class GetFiltrationByRatingQueryHandler
    : IRequestHandler<GetFiltrationByRatingQuery, FiltrationByRatingVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetFiltrationByRatingQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FiltrationByRatingVm> Handle(GetFiltrationByRatingQuery request, CancellationToken cancellationToken)
        {
            var productList = _dbContext.Product
                .Include(x => x.Category)
                .Include(x => x.Review)
                .Include(x => x.Seller)
                .Where(x => x.Category.Id == request.CategoryId)
                .Where(x =>
                    Math.Round((double) x.Review.Sum(y => y.Rating)
                               / (x.Review.Count == 0 ? 1 : x.Review.Count)) == request.Rating);
            
            var paginatedList = await PaginatedList<Product>
                .CreateAsync(productList, request.PageNumber, request.PageSize);

            return new FiltrationByRatingVm
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

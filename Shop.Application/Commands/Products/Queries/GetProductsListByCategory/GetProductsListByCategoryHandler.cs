using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Products.Queries.GetProductsListPaginated;
using Shop.Application.Common;
using Shop.Application.Common.Pagination;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Shop.Application.Commands.Products.Queries.GetProductsList;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByCategory
{
    public class GetProductsListByCategoryHandler
    : HandlersBase, IRequestHandler<GetProductsListByCategoryQuery, GetProductsListByCategoryVm>
    {
        public GetProductsListByCategoryHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<GetProductsListByCategoryVm> Handle(GetProductsListByCategoryQuery request, CancellationToken cancellationToken)
        {
            var listCategories = SubcategoriesFind(_dbContext, request.CategoryId, new List<Category>());
            listCategories.Add(await _dbContext.Category
                .Include(x => x.Product)
                .ThenInclude(x => x.Review)
                .FirstOrDefaultAsync(x => x.Id == request.CategoryId, cancellationToken));

            var productsPerPage = listCategories
                .SelectMany(category => category.Product)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .AsQueryable()
                .ToList();
            var paginatedList = new PaginatedList<Product>(productsPerPage, productsPerPage.Count, request.PageNumber, request.PageSize);
            
            return new GetProductsListByCategoryVm
            {
                Products = productsPerPage,
                Page = request.PageNumber,
                TotalPagesAmount = paginatedList.TotalPages,
                HasNextPage = paginatedList.HasNextPage,
                HasPreviousPage = paginatedList.HasPreviousPage
            };
        }
    }
}

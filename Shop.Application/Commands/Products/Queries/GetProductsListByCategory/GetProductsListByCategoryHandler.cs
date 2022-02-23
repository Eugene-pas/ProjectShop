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

namespace Shop.Application.Commands.Products.Queries.GetProductsListByCategory
{
    public class GetProductsListByCategoryHandler
    : HandlersBase, IRequestHandler<GetProductsListByCategoryQuery, ProductPaginatedVm>
    {
        public GetProductsListByCategoryHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ProductPaginatedVm> Handle(GetProductsListByCategoryQuery request, CancellationToken cancellationToken)
        {
            var listCategories = SubcategoriesFind(_dbContext, request.CategoryId, new List<Category>());
            listCategories.Add(await _dbContext.Category
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == request.CategoryId, cancellationToken));
            if (listCategories.Count == 0)
            {
                var category = await _dbContext.Category
                    .Include(x => x.Product)
                    .FirstOrDefaultAsync(x => x.Id == request.CategoryId, cancellationToken);
                if (category != null)
                {
                    listCategories.Add(category);
                }
            }

            var listProduct = listCategories.SelectMany(category => category.Product).AsQueryable();
            var paginatedList = await PaginatedList<Product>
                .CreateAsync(listProduct, request.PageNumber, request.PageSize);

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

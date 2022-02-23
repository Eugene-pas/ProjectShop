﻿using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Products.Queries.GetProductsList;
using Shop.Application.Common.Pagination;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByCategory
{
    public class GetProductsListByCategoryHandler
    : HandlersBase, IRequestHandler<GetProductsListByCategoryQuery, ProductsListVm>
    {
        public GetProductsListByCategoryHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ProductsListVm> Handle(GetProductsListByCategoryQuery request, CancellationToken cancellationToken)
        {
            var listProduct = new List<Product>();
            var listCategories = SubcategoriesFind(_dbContext, request.CategoryId, new List<Category>());
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
            foreach (var category in listCategories)
            {
                foreach (var item in category.Product)
                {
                    listProduct.Add(item);
                }
            }

            // var paginatedList = await PaginatedList<Product>
            //     .CreateAsync(listCategories, )
            return new ProductsListVm{Products = listProduct};
        }
    }
}

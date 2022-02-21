using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Application.Products.Queries.GetProductsList;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Products.Queries.GetProductsListByCategory
{
    public class GetProductsListByCategoryHandler
    : HandlersBase, IRequestHandler<GetProductsListByCategoryQuery, List<Product>>
    {
        public GetProductsListByCategoryHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<List<Product>> Handle(GetProductsListByCategoryQuery request, CancellationToken cancellationToken)
        {
            var listProduct = new List<Product>();
            var listCategories = SubcategoriesFind(_dbContext, request.CategoryId, new List<Category>());
            foreach (var category in listCategories)
            {
                foreach (var item in category.Product)
                {
                    listProduct.Add(item);
                }
            }
            return listProduct;
        }
    }
}

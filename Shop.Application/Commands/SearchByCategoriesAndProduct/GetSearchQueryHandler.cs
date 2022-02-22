using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.SearchByCategoriesAndProduct
{
    internal class GetSearchQueryHandler
        : IRequestHandler<GetSearchQuery, SearchVm>
    {
        private readonly IDataBaseContext _dbContext;

        private readonly IMapper _mapper;

        public GetSearchQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<SearchVm> Handle(GetSearchQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = new();
            List<Product> products = new();

            var items = _dbContext.Category.Where(x => x.Name == request.Serach)
                .Select(x => new Category
                {
                    Id = x.Id
                }).ToList();

            foreach (var item in _dbContext.Category)
            {
                if (item.Name.Contains(request.Serach,StringComparison.CurrentCultureIgnoreCase))
                {
                    categories.Add(item);
                }
            }

            foreach (var item in _dbContext.Product)
            {
                if (item.Name.Contains(request.Serach, StringComparison.CurrentCultureIgnoreCase))
                {
                    products.Add(item);
                }
            }


            return new SearchVm { Categories = categories, Products = products };
        }
        
    }
}

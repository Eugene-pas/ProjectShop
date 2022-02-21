﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.SearchByCategoriesAndProduct
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

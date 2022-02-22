using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

            var categories = from c in _dbContext.Category select c;
            if (!String.IsNullOrEmpty(request.Serach))
            {
                categories = categories.Where(x =>
                    x.Name!.Contains(request.Serach));
            }

            var products = from p in _dbContext.Product select p;
            if (!String.IsNullOrEmpty(request.Serach))
            {
                products = products.Where(x =>
                    x.Name!.Contains(request.Serach));
            }

            return  new SearchVm { Categories = await categories.ToListAsync(), Products = await products.ToListAsync() };
        }
        
    }
}

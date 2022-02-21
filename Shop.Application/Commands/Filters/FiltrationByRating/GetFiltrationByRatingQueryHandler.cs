using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Filters.FiltrationByRating
{
    internal class GetFiltrationByRatingQueryHandler
    : IRequestHandler<GetFiltrationByRatingQuery, FilteredProductsListVm>
    {
        private readonly IDataBaseContext _dbContext;
        public GetFiltrationByRatingQueryHandler(IDataBaseContext dbContext) => _dbContext = dbContext;

        public async Task<FilteredProductsListVm> Handle(GetFiltrationByRatingQuery request, CancellationToken cancellationToken)
        {
            var productList = await _dbContext.Product
                .Include(x => x.Category)
                .Where(x => x.Category.Id == request.CategoryId)               
                .Where(x => Math.Round(x.Rating) == request.Rating)
                .ToListAsync(cancellationToken);

            return new FilteredProductsListVm {Products = productList};
        }
    }
}

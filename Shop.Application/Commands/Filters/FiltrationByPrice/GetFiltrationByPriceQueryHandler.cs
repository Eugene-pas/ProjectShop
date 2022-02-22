using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Filters.FiltrationByPrice
{
    public class GetFiltrationByPriceQueryHandler :
        IRequestHandler<GetFiltrationByPriceQuery, FilteredProductsListVm>
    {
        private readonly IDataBaseContext _context;

        public GetFiltrationByPriceQueryHandler(IDataBaseContext context) => _context = context;

        public async Task<FilteredProductsListVm> Handle(GetFiltrationByPriceQuery request, CancellationToken cancellationToken)
        {
            request.MinPrice ??= 0;
            request.MaxPrice ??= _context.Product.Max(x => x.Price);

            var productList = await _context.Product
                .Include(x => x.Category)
                .Where(x => x.Category.Id == request.CategoryId)
                .Where(x => x.Price >= request.MinPrice && x.Price <= request.MaxPrice)
                .ToListAsync(cancellationToken);

            return new FilteredProductsListVm { Products = productList };
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Filters.FiltrationBySeller
{
    public class GetFiltrationBySellerQueryHandler :
        IRequestHandler<GetFiltrationBySellerQuery, FilteredProductsListVm>
    {
        private readonly IDataBaseContext _dbContext;
        public GetFiltrationBySellerQueryHandler(IDataBaseContext dbContext) => _dbContext = dbContext;
        public async  Task<FilteredProductsListVm> Handle(GetFiltrationBySellerQuery request, CancellationToken cancellationToken)
        {
            var productList = await _dbContext.Product
                .Include(x => x.Category)
                .Include(x => x.Seller)
                .Where(x => x.Category.Id == request.CategoryId)
                .Where(x => x.Seller.Id == request.SellerId)
                .ToListAsync(cancellationToken);

            return new FilteredProductsListVm { Products = productList };
        }
    }
}

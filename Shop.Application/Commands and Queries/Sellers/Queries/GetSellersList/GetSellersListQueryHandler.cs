using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Sellers.Queries.GetSellersList
{
    public class GetSellersListQueryHandler 
        : IRequestHandler<GetSellersListQuery, SellersListVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetSellersListQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<SellersListVm> Handle(GetSellersListQuery request, 
            CancellationToken cancellationToken)
        {
            var sellerQuery = await _dbContext.Seller
                .ProjectTo<SellersLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new SellersListVm { Sellers = sellerQuery };
        }
    }
}

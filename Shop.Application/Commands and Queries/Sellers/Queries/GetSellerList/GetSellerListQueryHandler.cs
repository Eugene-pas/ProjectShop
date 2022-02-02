using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Sellers.Queries.GetSellerList
{
    public class GetSellerListQueryHandler 
        : IRequestHandler<GetSellerListQuery, SellerListVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetSellerListQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<SellerListVm> Handle(GetSellerListQuery request, 
            CancellationToken cancellationToken)
        {
            var sellerQuery = await _dbContext.Seller
                .Where(seller => seller.Id == request.Id)
                .ProjectTo<SellerLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new SellerListVm { Sellers = sellerQuery };
        }
    }
}

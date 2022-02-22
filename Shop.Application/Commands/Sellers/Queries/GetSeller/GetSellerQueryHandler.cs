using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Sellers.Queries.GetSeller
{
    public class GetSellerQueryHandler : HandlersBase, IRequestHandler<GetSellerQuery, SellerVm>
    {
        public GetSellerQueryHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<SellerVm> Handle(GetSellerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Seller
                .FirstOrDefaultAsync(sellor => 
                sellor.Id == request.Id, cancellationToken);

            _ = entity ?? throw new NotFoundException(nameof(Seller), request.Id);

            return _mapper.Map<SellerVm>(entity);
        }
    }
}

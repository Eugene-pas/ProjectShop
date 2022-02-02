using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;

namespace Shop.Application.Seller.Queries.GetSellerDetails
{
    public class GetSellerDetailsQueryHandler : IRequestHandler<GetSellerDetailsQuery, SellerDetailsVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetSellerDetailsQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<SellerDetailsVm> Handle(GetSellerDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Sellers.FirstOrDefaultAsync(sellor => sellor.Id == request.Id, cancellationToken);
            _ = entity ?? throw new NotFoundException(nameof(Sellers), request.Id);

            return _mapper.Map<SellerDetailsVm>(entity);
        }
    }
}

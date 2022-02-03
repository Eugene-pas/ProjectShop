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

namespace Shop.Application.Sellers.Queries.GetSellerDetails
{
    public class GetSellerQueryHandler : IRequestHandler<GetSeller, SellerVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetSellerQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<SellerVm> Handle(GetSeller request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Seller
                .FirstOrDefaultAsync(sellor => 
            sellor.Id == request.Id, cancellationToken);
            _ = entity ?? throw new NotFoundException(nameof(Seller), request.Id);

            return _mapper.Map<SellerVm>(entity);
        }
    }
}

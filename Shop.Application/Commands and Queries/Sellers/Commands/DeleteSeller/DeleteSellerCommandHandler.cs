using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;

namespace Shop.Application.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommandHandler 
        : IRequestHandler<DeleteSellerCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteSellerCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Seller
                .FindAsync(new object[] { request.Id }, cancellationToken);
            _ = seller ?? throw new NotFoundException(nameof(Seller), seller.Id);
            _dbContext.Seller.Remove(seller);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

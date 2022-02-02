using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;

namespace Shop.Application.Seller.Commands.DeleteSeller
{
    public class DeleteSellerCommandHandler 
        : IRequestHandler<DeleteSellerCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteSellerCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteSellerCommand request, CancellationToken cancellationToken)
        {
            var sellers = await _dbContext.Sellers
                .FindAsync(new object[] { request.Id }, cancellationToken);
            _ = sellers ?? throw new NotFoundException(nameof(Customer), sellers.Id);
            _dbContext.Sellers.Remove(sellers);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

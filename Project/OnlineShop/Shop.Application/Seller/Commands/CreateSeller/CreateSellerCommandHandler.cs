using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Entities;

namespace Shop.Application.Seller.Commands.CreateSeller
{
    internal class DeleteSellerCommandHandler 
        : IRequestHandler<DeleteSellerCommand, long>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteSellerCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<long> Handle(DeleteSellerCommand request,
            CancellationToken cancellationToken)
        {
            var seller = new Sellers
            {
                Name = request.Name,
                Description = request.Description,
                Contact = request.Contact,
                Product = null
            };

            await _dbContext.Sellers.AddAsync(seller, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return seller.Id;
        }
    }
}

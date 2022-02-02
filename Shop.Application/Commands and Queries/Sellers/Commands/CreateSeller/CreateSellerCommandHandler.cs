using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Entities;

namespace Shop.Application.Sellers.Commands.CreateSeller
{
    public class CreateSellerCommandHandler 
        : IRequestHandler<CreateSellerCommand, long>
    {
        private readonly IDataBaseContext _dbContext;
        public CreateSellerCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<long> Handle(CreateSellerCommand request,
            CancellationToken cancellationToken)
        {
            var seller = new Seller
            {
                Name = request.Name,
                Description = request.Description,
                Contact = request.Contact,
                Product = null
            };

            await _dbContext.Seller.AddAsync(seller, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return seller.Id;
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommandHandler
        : IRequestHandler<UpdateSellerCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public UpdateSellerCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Seller
                .FirstOrDefaultAsync(seller =>
            seller.Id == request.Id, cancellationToken);

            _ = seller ?? throw new NotFoundException(nameof(Seller), seller.Id);

            seller.Name = request.Name;
            seller.Description = request.Description;
            seller.Contact = request.Contact;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

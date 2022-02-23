using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Sellers.Queries.GetSeller;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommandHandler
        : HandlersBase, IRequestHandler<UpdateSellerCommand, SellerVm>
    {
        public UpdateSellerCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<SellerVm> Handle(UpdateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Seller
                .FirstOrDefaultAsync(seller =>
                seller.Id == request.Id, cancellationToken);

            _ = seller ?? throw new NotFoundException(nameof(Seller), seller.Id);

            seller.StoreName = request.Name;
            seller.Description = request.Description;
            seller.Contact = request.Contact;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SellerVm>(seller);
        }
    }
}

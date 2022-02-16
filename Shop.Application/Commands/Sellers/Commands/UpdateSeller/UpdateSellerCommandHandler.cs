using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Sellers.Queries.GetSeller;
using Shop.Application.Exceptions;
using Shop.Application.Common;
using Shop.Domain.Entities;

namespace Shop.Application.Sellers.Commands.UpdateSeller
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

            seller.Name = request.Name;
            seller.Description = request.Description;
            seller.Contact = request.Contact;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SellerVm>(seller);
        }
    }
}

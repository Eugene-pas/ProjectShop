using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Commands.Sellers.Queries.GetSeller;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Sellers.Commands.CreateSeller
{
    public class CreateSellerCommandHandler 
        : HandlersBase, IRequestHandler<CreateSellerCommand, SellerVm>
    {
        public CreateSellerCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<SellerVm> Handle(CreateSellerCommand request,
            CancellationToken cancellationToken)
        {
            var seller = new Seller
            {
                StoreName = request.Name,
                Description = request.Description,
                Contact = request.Contact,
                Product = null
            };

            await _dbContext.Seller.AddAsync(seller, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<SellerVm>(seller);
        }
    }
}

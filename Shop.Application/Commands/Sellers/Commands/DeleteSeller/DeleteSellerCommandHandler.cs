using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Sellers.Queries.GetSeller;
using Shop.Application.Exceptions;
using Shop.Application.Common;
using Shop.Domain.Entities;

namespace Shop.Application.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommandHandler
        : HandlersBase, IRequestHandler<DeleteSellerCommand, SellerVm>
    {
        public DeleteSellerCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<SellerVm> Handle(DeleteSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Seller
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = seller ?? throw new NotFoundException(nameof(Seller), seller.Id);

            _dbContext.Seller.Remove(seller);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<SellerVm>(seller);
        }
    }
}

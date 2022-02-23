using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProductVm> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Product
                .Include(x => x.Category)
                .Include(x => x.Seller)
                .Include(x => x.Review).ThenInclude(x => x.Customer)
                .Include(x => x.Review).ThenInclude(x => x.ReviewComments)
                .Include(x => x.Review).ThenInclude(x => x.ReviewLikes)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            _ = product ?? throw new NotFoundException(nameof(Product), request.Id);

            return _mapper.Map<ProductVm>(product);
        }
    }
}

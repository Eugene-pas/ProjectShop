using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Baskets.Quersies.GetBasket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, BasketVm>
    {
        private readonly IMapper _mapper;
        private readonly IDataBaseContext _dbContext;
        public GetBasketQueryHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BasketVm> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var basket = await _dbContext.Basket
                .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.ProductImage)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(basket =>
                basket.Id == request.Id, cancellationToken);

            _ = basket ?? throw new NotFoundException(nameof(Basket), request.Id);

            basket.TotalSum = basket.Items.Sum(x => x.Product.Price * x.Count);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BasketVm>(basket);
        }
    }
}

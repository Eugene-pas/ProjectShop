using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Baskets.Commands.CreateBasket
{
    public class CreateBasketCommandHandler
        :HandlersBase, IRequestHandler<CreateBasketCommand, BasketVm>
    {
        public CreateBasketCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }
        public async Task<BasketVm> Handle(CreateBasketCommand request,
            CancellationToken cancellationToken)
        {
            var basket = new Basket
            {
                Customer = _dbContext.Customer.Find(request.CustomerId)
            };
            await _dbContext.Basket.AddAsync(basket, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<BasketVm>(basket);
        }
    }
}
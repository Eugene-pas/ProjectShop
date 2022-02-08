using AutoMapper;
using MediatR;
using Shop.Application.Commands_and_Queries.Deliveries;
using Shop.Application.Customers.Commands;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Deliveries.Commands.CreateDelivery
{
    public class CreateDeliveryCommandHandler
        : HandlersBase, IRequestHandler<CreateDeliveryCommand, DeliveryVm>
    {
        private readonly IMapper _mapper;

        public CreateDeliveryCommandHandler(IDataBaseContext dbContext, IMapper mapper) : base(dbContext) 
            => _mapper = mapper;


        public async Task<DeliveryVm> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = new Delivery
            {
                Name = request.Name,
                Order = null,
                DeliveryProductConnection = null
            };
            await _dbContext.Delivery.AddAsync(delivery, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<DeliveryVm>(delivery);
        }
    }
}

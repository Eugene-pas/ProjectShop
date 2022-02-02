using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace Shop.Application.Orders.Queries.GetAllOrder
{
    public class GetAllOrderCommandHandler
        : IRequestHandler<GetAllOrderCommand, OrderVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllOrderCommandHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderVm> Handle(GetAllOrderCommand request, CancellationToken cancellationToken)
        {
            //var listProductImage = await _dbContext.ProductImage
            //    .Include(images => images.Product)
            //    .Where(images => images.Product.Id != request.IdProduct)
            //    .ToListAsync();

            var order = await _dbContext.Order.Include(x => x.Customer)
                .Where(x => x.Customer.Id == request.IdCustomer)
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            _ = order ?? throw new NotFoundException(
                nameof(ProductImage), request.IdCustomer);

            
            return new OrderVm { Order = order };
        }
    }
}

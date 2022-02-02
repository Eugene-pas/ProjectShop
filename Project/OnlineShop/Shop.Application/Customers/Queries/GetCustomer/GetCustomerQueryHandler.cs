using AutoMapper;
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

namespace Shop.Application.Customers.Queries.GetCustomer
{
    public class GetCustomerQueryHandler
        : IRequestHandler<GetCustomerQuery, CustomerVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(IDataBaseContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CustomerVm> Handle(GetCustomerQuery request,
            CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customer
                .FirstOrDefaultAsync(customer =>
                customer.Id == request.Id, cancellationToken);

            _ = customer ?? throw new NotFoundException(nameof(Customer), request.Id);


            return _mapper.Map<CustomerVm>(customer);
        }
    }
}

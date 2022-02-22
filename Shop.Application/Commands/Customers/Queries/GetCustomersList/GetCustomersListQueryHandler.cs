using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler
        : IRequestHandler<GetCustomersListQuery, CustomersListVm>
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(IDataBaseContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<CustomersListVm> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var customersQuery = await _dbContext.Customer
                .ProjectTo<CustomersLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CustomersListVm { Customers = customersQuery };
        }
    }
}

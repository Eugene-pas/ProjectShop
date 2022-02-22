using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Commands.Customers.Queries.GetCustomer;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler
        : HandlersBase, IRequestHandler<CreateCustomerCommand, CustomerVm>
    {
        public CreateCustomerCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<CustomerVm> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer 
            {                
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Order = null
            };

            await _dbContext.Customer.AddAsync(customer,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CustomerVm>(customer);
        }
    }
}

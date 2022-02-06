using MediatR;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler
        : IRequestHandler<CreateCustomerCommand, long>
    {
        private readonly IDataBaseContext _dbContext;
        public CreateCustomerCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;

        public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
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

            return customer.Id;
        }
    }
}

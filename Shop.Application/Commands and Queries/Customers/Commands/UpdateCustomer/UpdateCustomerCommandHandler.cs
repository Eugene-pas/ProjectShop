using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler
        : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public UpdateCustomerCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customer
                .FirstOrDefaultAsync(customer => 
            customer.Id == request.Id,cancellationToken);

            _ = customer ?? throw new NotFoundException(nameof(Customer), customer.Id);

            customer.Name = request.Name;
            customer.Email = request.Email;
            customer.PhoneNumber = request.PhoneNumber;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

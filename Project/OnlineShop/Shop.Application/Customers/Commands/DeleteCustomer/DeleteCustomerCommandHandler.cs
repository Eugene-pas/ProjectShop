using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler
        : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteCustomerCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customer
                .FindAsync(new object[] {request.Id}, cancellationToken);

            _ = customer ?? throw new NotFoundException(nameof(Customer), customer.Id);
            _dbContext.Customer.Remove(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

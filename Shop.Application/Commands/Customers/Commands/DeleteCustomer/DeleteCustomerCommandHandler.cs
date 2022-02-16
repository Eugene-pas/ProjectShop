using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Customers.Queries.GetCustomer;
using Shop.Application.Exceptions;
using Shop.Application.Common;
using Shop.Domain.Entities;

namespace Shop.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler
        : HandlersBase, IRequestHandler<DeleteCustomerCommand, CustomerVm>
    {
        public DeleteCustomerCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<CustomerVm> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customer
                .FindAsync(new object[] { request.Id }, cancellationToken);

            _ = customer ?? throw new NotFoundException(nameof(Customer), customer.Id);

            _dbContext.Customer.Remove(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CustomerVm>(customer);
        }
    }
}

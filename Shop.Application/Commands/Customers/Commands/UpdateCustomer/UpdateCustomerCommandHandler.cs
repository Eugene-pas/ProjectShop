﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Commands.Customers.Queries.GetCustomer;
using Shop.Application.Common;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler
        : HandlersBase, IRequestHandler<UpdateCustomerCommand, CustomerVm>
    {
        public UpdateCustomerCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<CustomerVm> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _dbContext.Customer
                .FirstOrDefaultAsync(customer => 
            customer.Id == request.Id,cancellationToken);

            _ = customer ?? throw new NotFoundException(nameof(Customer), customer.Id);

            customer.Name = request.Name;
            customer.Email = request.Email;
            customer.PhoneNumber = request.PhoneNumber;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CustomerVm>(customer);
        }
    }
}

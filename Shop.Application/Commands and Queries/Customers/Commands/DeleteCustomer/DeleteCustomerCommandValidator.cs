using FluentValidation;
using Shop.Application.Customers.Commands.DeleteCustomer;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator
        : AbstractValidator<DeleteCustomerCommand>
    {
        private readonly CustomerExistTask existTask;
        public DeleteCustomerCommandValidator(IDataBaseContext dbContext)
        {
            existTask = new CustomerExistTask(dbContext);

            RuleFor(deleteCustomerCammandValidator =>
            deleteCustomerCammandValidator.Id)
            .NotEmpty().WithMessage("ID is required.")
            .NotNull().WithMessage("ID can not be equeal null.")
            .GreaterThan(0).WithMessage("ID must be greater than zero.")
            .MustAsync(existTask.Exist).WithMessage("There is no field with this ID.")
            .WithMessage("The specified customerId doesn't exist.");
        }
    }
}

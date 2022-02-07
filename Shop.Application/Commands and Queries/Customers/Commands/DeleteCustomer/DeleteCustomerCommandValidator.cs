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
            deleteCustomerCammandValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .NotEqual(0).WithMessage("There is no field with this ID")
            .MustAsync(existTask.Exist)
            .WithMessage("The specified customerId doesn't exist");
        }
    }
}

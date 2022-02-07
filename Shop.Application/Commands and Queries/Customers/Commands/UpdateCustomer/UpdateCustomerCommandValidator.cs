using FluentValidation;
using Shop.Application.Customers.Commands.UpdateCustomer;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator
        : AbstractValidator<UpdateCustomerCommand>
    {
        private CustomerExistTask existTask;
        public UpdateCustomerCommandValidator(IDataBaseContext dbContext)
        {
            existTask = new CustomerExistTask(dbContext);

            RuleFor(updateCustomerCammandValidator =>
            updateCustomerCammandValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .NotEqual(0).WithMessage("There is no field with this ID")
            .MustAsync(existTask.Exist).WithMessage("The specified customerId doesn't exist");

            RuleFor(updateCustomerCammandValidator =>
            updateCustomerCammandValidator.Name).NotEmpty()
            .NotNull().WithMessage("Name is required.");

            RuleFor(updateCustomerCammandValidator =>
            updateCustomerCammandValidator.Email).NotEmpty()
            .NotNull().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email not valid");

            RuleFor(updateCustomerCammandValidator =>
            updateCustomerCammandValidator.PhoneNumber).NotEmpty()
            .NotNull().WithMessage("Phone Number is required.")
            .MinimumLength(12).WithMessage("PhoneNumber must not be less than 12 characters.")
            .MaximumLength(12).WithMessage("PhoneNumber must not exceed 12 characters.");
            //.Matches(new Regex(@"^\+\d{2}\(\d{3}\)\d{3}-\d{2}-\d{2}$")).WithMessage("PhoneNumber not valid");
        }
    }
}

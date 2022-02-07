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
            updateCustomerCammandValidator.Id)
            .NotEmpty().WithMessage("ID is required.")
            .NotNull().WithMessage("ID can not be aqueal null.")
            .NotEqual(0).WithMessage("There is no field with this ID")
            .MustAsync(existTask.Exist).WithMessage("The specified customerId doesn't exist");

            RuleFor(updateCustomerCammandValidator =>
            updateCustomerCammandValidator.Name)
            .NotEmpty().WithMessage("Name is required.")
            .NotNull().WithMessage("Name can not be aqueal null.");

            RuleFor(updateCustomerCammandValidator =>
            updateCustomerCammandValidator.Email)
            .NotEmpty().WithMessage("Email is required.")
            .NotNull().WithMessage("Email can not be aqueal null.")
            .EmailAddress().WithMessage("Email not valid");

            RuleFor(updateCustomerCammandValidator =>
            updateCustomerCammandValidator.PhoneNumber)
            .NotEmpty().WithMessage("Phone numbe is required.")
            .NotNull().WithMessage("Phone numbe can not be aqueal null.")
            .MinimumLength(10).WithMessage("Phone number must not be less than 10 characters.")
            .MaximumLength(12).WithMessage("Phone number must not exceed 12 characters.");
            //.Matches(new Regex(@"^\+\d{2}\(\d{3}\)\d{3}-\d{2}-\d{2}$")).WithMessage("PhoneNumber not valid");
        }
    }
}

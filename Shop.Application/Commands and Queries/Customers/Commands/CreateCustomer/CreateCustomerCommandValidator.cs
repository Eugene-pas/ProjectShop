using FluentValidation;
using Shop.Application.Customers.Commands.CreateCustomer;
using System.Text.RegularExpressions;

namespace Shop.Application.Commands_and_Queries.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator
        : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(updateCustomerCommandValidator =>
            updateCustomerCommandValidator.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull().WithMessage("Name can not be aqueal null.");

            RuleFor(updateCustomerCommandValidator =>
            updateCustomerCommandValidator.Email)
                .NotEmpty().WithMessage("Email is required.")
                .NotNull().WithMessage("Email can not be aqueal null.")
                .EmailAddress().WithMessage("Email not valid.");

            RuleFor(updateCustomerCommandValidator =>
            updateCustomerCommandValidator.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .NotNull().WithMessage("Phone number can not be aqueal null.")
                .MinimumLength(10).WithMessage("Phone number must not be less than 10 characters.")
                .MaximumLength(12).WithMessage("Phone number must not exceed 12 characters.");
                //.Matches(new Regex(@"^\+\d{2}\(\d{3}\)\d{3}-\d{2}-\d{2}$")).WithMessage("PhoneNumber not valid");
        }
    }
}

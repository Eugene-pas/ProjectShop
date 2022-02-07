using FluentValidation;
using Shop.Application.Customers.Commands.CreateCustomer;
using System.Text.RegularExpressions;

namespace Shop.Application.Commands_and_Queries.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCammandValidator
        : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCammandValidator()
        {
            RuleFor(createCustomerCammandValidator =>
            createCustomerCammandValidator.Name).NotEmpty()
            .NotNull().WithMessage("Name is required.");

            RuleFor(createCustomerCammandValidator =>
            createCustomerCammandValidator.Email).NotEmpty()
            .NotNull().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email not valid");

            RuleFor(createCustomerCammandValidator =>
            createCustomerCammandValidator.PhoneNumber).NotEmpty()
            .NotNull().WithMessage("Phone Number is required.")
            .MinimumLength(13).WithMessage("PhoneNumber must not be less than 13 characters.")
            .MaximumLength(13).WithMessage("PhoneNumber must not exceed 13 characters.")
            .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");
        }
    }
}

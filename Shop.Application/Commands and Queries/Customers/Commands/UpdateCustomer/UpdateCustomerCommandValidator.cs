using FluentValidation;
using Shop.Application.Customers.Commands.UpdateCustomer;
using System.Text.RegularExpressions;

namespace Shop.Application.Commands_and_Queries.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator
        : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(updateCustomerCammandValidator =>
            updateCustomerCammandValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .NotEqual(0).WithMessage("There is no field with this ID");

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
            .MinimumLength(13).WithMessage("PhoneNumber must not be less than 13 characters.")
            .MaximumLength(13).WithMessage("PhoneNumber must not exceed 13 characters.")
            .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");
        }
    }
}

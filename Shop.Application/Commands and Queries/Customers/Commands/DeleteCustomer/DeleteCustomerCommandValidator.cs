using FluentValidation;
using Shop.Application.Customers.Commands.DeleteCustomer;

namespace Shop.Application.Commands_and_Queries.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator
        : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(deleteCustomerCammandValidator =>
            deleteCustomerCammandValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .NotEqual(0).WithMessage("There is no field with this ID");
        }
    }
}

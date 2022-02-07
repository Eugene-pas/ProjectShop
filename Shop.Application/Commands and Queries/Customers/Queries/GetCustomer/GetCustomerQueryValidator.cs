using FluentValidation;
using Shop.Application.Customers.Queries.GetCustomer;

namespace Shop.Application.Commands_and_Queries.Customers.Queries.GetCustomer
{
    public class GetCustomerQueryValidator
        : AbstractValidator<GetCustomerQuery>
    {
        public GetCustomerQueryValidator()
        {
            RuleFor(getCustomerQueryValidator =>
            getCustomerQueryValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .NotEqual(0).WithMessage("There is no field with this ID");
        }
    }
}

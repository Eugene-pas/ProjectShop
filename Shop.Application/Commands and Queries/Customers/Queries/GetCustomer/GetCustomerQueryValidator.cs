using FluentValidation;
using Shop.Application.Customers.Queries.GetCustomer;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.Customers.Queries.GetCustomer
{
    public class GetCustomerQueryValidator
        : AbstractValidator<GetCustomerQuery>
    {
        private CustomerExistTask existTask;
        public GetCustomerQueryValidator(IDataBaseContext dbContext)
        {
            existTask = new CustomerExistTask(dbContext);

            RuleFor(getCustomerQueryValidator =>
            getCustomerQueryValidator.Id)
            .NotEmpty().WithMessage("ID is required.")
            .NotNull().WithMessage("ID can not be aqueal null.")
            .NotEqual(0).WithMessage("There is no field with this ID")
            .MustAsync(existTask.Exist).WithMessage("The specified customerId doesn't exist");
        }
    }
}

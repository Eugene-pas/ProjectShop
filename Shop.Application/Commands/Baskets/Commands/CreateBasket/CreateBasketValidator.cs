using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Baskets.Commands.CreateBasket
{
    public class CreateBasketValidator
        : AbstractValidator<CreateBasketCommand>
    {
        private readonly BasketExistTask existTask;
        public CreateBasketValidator(IDataBaseContext dbContext)
        {
            existTask = new BasketExistTask(dbContext);

            RuleFor(createBasketCommandValidator =>
            createBasketCommandValidator.CustomerId)
            .NotEmpty().NotNull().WithMessage("Customer Id is required.")
            .NotEqual(0).WithMessage("There is no customer with this ID")
            .WithMessage("The specified customer doesn't exist");
        }
    }
}

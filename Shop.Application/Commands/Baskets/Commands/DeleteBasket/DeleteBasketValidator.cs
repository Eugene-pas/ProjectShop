using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Baskets.Commands.DeleteBasket
{
    public class DeleteBasketValidator
        : AbstractValidator<DeleteBasketCommand>
    {
        private readonly BasketExistTask existTask;

        public DeleteBasketValidator(IDataBaseContext dbContext)
        {
            existTask = new BasketExistTask(dbContext);

            RuleFor(deleteBasketCammandValidator =>
            deleteBasketCammandValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .NotEqual(0).WithMessage("Id can not be equal 0")
            .MustAsync(existTask.Exist)
            .WithMessage("The specified basket doesn't exist");
        }
    }
}

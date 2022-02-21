using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.BasketItems.Commands.DeleteBasketItem
{
    public class DeleteBasketItemValidator
        : AbstractValidator<DeleteBasketItemCommand>
    {
        private readonly BasketItemExistTask existTask;

        public DeleteBasketItemValidator(IDataBaseContext dbContext)
        {
            existTask = new BasketItemExistTask(dbContext);

            RuleFor(deleteBasketItemCammandValidator =>
            deleteBasketItemCammandValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .NotEqual(0).WithMessage("Id can not be equal 0")
            .MustAsync(existTask.ExistBasketItem)
            .WithMessage("The specified Item doesn't exist");
        }
    }
}

using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.BasketItems.Commands.CreateBasketItem
{
    public class CreateBasketItemValidator
        : AbstractValidator<CreateBasketItemCommand>
    {
        private readonly BasketItemExistTask existTask;
        public CreateBasketItemValidator(IDataBaseContext dbContext)
        {
            existTask = new BasketItemExistTask(dbContext);

            _ = RuleFor(createBasketItemCommandValidator =>
              createBasketItemCommandValidator.BasketId)
            .NotEmpty().NotNull().WithMessage("Basket Id is required.")
            .NotEqual(0).WithMessage("There is no basket with this ID")
            .MustAsync(existTask.ExistBasket)
            .WithMessage("The specified basket doesn't exist");

            RuleFor(createBasketCommandValidator =>
            createBasketCommandValidator.ProductId)
            .NotEmpty().NotNull().WithMessage("Product Id is required.")
            .NotEqual(0).WithMessage("There is no product with this ID")
            .MustAsync(existTask.ExistProduct)
            .WithMessage("The specified product doesn't exist");

            RuleFor(createBasketCommandValidator =>
            createBasketCommandValidator.Count)
            .NotEmpty().NotNull().WithMessage("Product count is required.")
            .NotEqual(0).WithMessage("Count can not be equal 0");
            
        }
    }
}

using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Baskets.Quersies.GetBasket
{
    public class GetBasketValidator
        : AbstractValidator<GetBasketQuery>
    {
        private readonly BasketExistTask existTask;
        public GetBasketValidator(IDataBaseContext dbContext)
        {
            existTask = new BasketExistTask(dbContext);

            RuleFor(GetBasketQueryValidator =>
            GetBasketQueryValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .NotEqual(0).WithMessage("Id can not be equal 0")
            .MustAsync(existTask.Exist)
            .WithMessage("The specified basket doesn't exist");
        }
    }
}

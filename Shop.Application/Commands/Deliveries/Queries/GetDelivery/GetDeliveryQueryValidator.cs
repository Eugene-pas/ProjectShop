using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Deliveries.Queries.GetDelivery
{
    public class GetDeliveryQueryValidator
        : AbstractValidator<GetDeliveryQuery>
    {
        public GetDeliveryQueryValidator(IDataBaseContext dbContext)
        {
            var existTask = new DeliveryExistTask(dbContext);

            RuleFor(delivery => delivery.Id)
                .NotEmpty().WithMessage("ID is required.")
                .MustAsync(existTask.Exist)
                .WithMessage("The specified delivery doesn't exist");
        }
    }
}

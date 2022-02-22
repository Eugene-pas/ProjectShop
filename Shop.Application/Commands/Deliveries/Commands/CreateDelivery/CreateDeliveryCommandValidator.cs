using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Deliveries.Commands.CreateDelivery
{
    public class CreateDeliveryCommandValidator
        : AbstractValidator<CreateDeliveryCommand>
    {
        public CreateDeliveryCommandValidator(IDataBaseContext dbContext)
        {
            RuleFor(deliveryCommand =>
                deliveryCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}

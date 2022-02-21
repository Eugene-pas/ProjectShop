using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.Deliveries.Commands.UpdateDelivery
{
    public class UpdateDeliveryCommandValidator
        : AbstractValidator<UpdateDeliveryCommand>
    {
        public UpdateDeliveryCommandValidator(IDataBaseContext dbContext)
        {
            var existTask = new DeliveryExistTask(dbContext);

            RuleFor(delivery =>
                delivery.Id).NotEmpty()
                .WithMessage("ID is required.")
                .MustAsync(existTask.Exist)
                .WithMessage("The specified delivery doesn't exists");

            RuleFor(deliveryCommand =>
                deliveryCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}

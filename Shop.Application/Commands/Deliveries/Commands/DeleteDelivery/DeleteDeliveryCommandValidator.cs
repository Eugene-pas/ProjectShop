using FluentValidation;

namespace Shop.Application.Commands.Deliveries.Commands.DeleteDelivery
{
    public class DeleteDeliveryCommandValidator
        : AbstractValidator<DeleteDeliveryCommand>
    {
        public DeleteDeliveryCommandValidator()
        {
            RuleFor(delivery =>
                delivery.Id).NotEmpty();
        }
    }
}

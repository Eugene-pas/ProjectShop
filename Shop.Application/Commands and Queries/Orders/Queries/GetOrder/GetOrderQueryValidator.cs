using FluentValidation;

namespace Shop.Application.Orders.Queries.GetOrder
{
    public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator()
        {
            RuleFor(Order =>
                Order.Id).NotEmpty();
        }
    }
}

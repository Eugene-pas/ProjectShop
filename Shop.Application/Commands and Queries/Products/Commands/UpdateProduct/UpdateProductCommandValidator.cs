using FluentValidation;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator
        : AbstractValidator<UpdateProductCommand>
    {
        private readonly ProductExistTask existTask;
        public UpdateProductCommandValidator(IDataBaseContext dbContext)
        {
            existTask = new ProductExistTask(dbContext);

            RuleFor(deleteProductCammandValidator =>
            deleteProductCammandValidator.Id).NotEmpty()
            .NotNull().WithMessage("ID is required.")
            .NotEqual(0).WithMessage("There is no field with this ID")
            .MustAsync(existTask.Exist)
            .WithMessage("The specified customerId doesn't exist");

            RuleFor(createProductCammandValidator =>
            createProductCammandValidator.Name)
            .NotEmpty()
            .NotNull().WithMessage("Name can not be equeal null.");

            RuleFor(createProductCammandValidator =>
            createProductCammandValidator.Price).NotEmpty()
            .NotNull().WithMessage("Price is required.")
            .GreaterThan(0).WithMessage("Prise must be > 0");

            RuleFor(createProductCammandValidator =>
            createProductCammandValidator.Description).NotEmpty()
            .NotNull().WithMessage("Description is required.");

            RuleFor(createProductCammandValidator =>
            createProductCammandValidator.OnStorageCount)
            .GreaterThan(-1).WithMessage("Count must be => 0");

            RuleFor(createProductCammandValidator =>
            createProductCammandValidator.Rating).InclusiveBetween(1, 5)
            .WithMessage("1<= rating <=5");
        }
    }
}

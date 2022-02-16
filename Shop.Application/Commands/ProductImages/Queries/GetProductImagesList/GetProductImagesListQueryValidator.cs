using FluentValidation;
using Shop.Application.ProductImages.Commands.DeleteProductImage;

namespace Shop.Application.Commands_and_Queries.ProductImages.Queries
{
    public class GetProductImagesListQueryValidator
    : AbstractValidator<DeleteProductImageCommand>
    {
        public GetProductImagesListQueryValidator()
        {
            RuleFor(creatProductImageCommand =>
            creatProductImageCommand.Id).NotEmpty();
        }
    }
} 

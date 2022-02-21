using FluentValidation;
using Shop.Application.Commands.ProductImages.Commands.DeleteProductImage;

namespace Shop.Application.Commands.ProductImages.Queries.GetProductImagesList
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

using FluentValidation;
using Shop.Application.ProductImages.Commands.CreateProductImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.ProductImages.Commands.CreateProductImage
{
    public class CreateProductImageCommandValidator
    : AbstractValidator<CreateProductImageCommand>
    {
        public CreateProductImageCommandValidator()
        {
            RuleFor(creatProductImageCommand =>
            creatProductImageCommand.Image).NotEmpty().MaximumLength(250);           
        }
    }
}

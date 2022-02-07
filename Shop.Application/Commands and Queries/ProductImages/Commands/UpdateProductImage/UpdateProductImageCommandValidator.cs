using FluentValidation;
using Shop.Application.ProductImages.Commands.UpdateProductImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.ProductImages.Commands.UpdateProductImage
{
    public class UpdateProductImageCommandValidator
    : AbstractValidator<UpdateProductImageCommand>
    {
        public UpdateProductImageCommandValidator()
        {
            RuleFor(creatProductImageCommand =>
            creatProductImageCommand.Image).NotEmpty().MaximumLength(250);
        }
    }
}

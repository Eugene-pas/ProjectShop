using FluentValidation;
using Shop.Application.ProductImages.Commands.DeleteProductImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.ProductImages.Commands.DeleteProductImage
{
    public class DeleteProductImageCommandValidator
   : AbstractValidator<DeleteProductImageCommand>
    {
        public DeleteProductImageCommandValidator()
        {
            RuleFor(creatProductImageCommand =>
            creatProductImageCommand.Id).NotEmpty();
        }
    }
}

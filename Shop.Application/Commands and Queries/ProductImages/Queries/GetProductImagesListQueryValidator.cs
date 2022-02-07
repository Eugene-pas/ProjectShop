using FluentValidation;
using Shop.Application.ProductImages.Commands.DeleteProductImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

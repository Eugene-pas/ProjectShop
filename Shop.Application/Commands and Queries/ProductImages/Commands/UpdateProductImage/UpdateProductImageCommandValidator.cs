using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.ProductImages.Commands.UpdateProductImage;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.ProductImages.Commands.UpdateProductImage
{
    public class UpdateProductImageCommandValidator
    : AbstractValidator<UpdateProductImageCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public UpdateProductImageCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(creatProductImageCommand =>
            creatProductImageCommand.Id).NotEmpty().NotEqual(0)
                .WithMessage("The Id value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified Id doesn't exist.");
            RuleFor(creatProductImageCommand =>
            creatProductImageCommand.Image).NotEmpty().MaximumLength(250);
            RuleFor(creatProductImageCommand =>
            creatProductImageCommand.SortOrder).NotEmpty();
            RuleFor(creatProductImageCommand =>
           creatProductImageCommand.ProductId).NotEmpty()
                .WithMessage("The ProductId value must not equal to 0")
                .MustAsync(ProductExist)
                .WithMessage("The specified ProductId doesn't exist.");
        }
        public async Task<bool> Exist(long ProductImageId, CancellationToken cancellationToken)
        {
            return await _dbContext.ProductImage
                .AnyAsync(c => c.Id == ProductImageId);
        }
        public async Task<bool> ProductExist(long ProductId, CancellationToken cancellationToken)
        {
            return await _dbContext.Product
                .AnyAsync(c => c.Id == ProductId);
        }
    }
}

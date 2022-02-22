using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.ProductImages.Commands.DeleteProductImage
{
    public class DeleteProductImageCommandValidator
   : AbstractValidator<DeleteProductImageCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteProductImageCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(creatProductImageCommand =>
            creatProductImageCommand.Id).NotEmpty().NotEqual(0)
                .WithMessage("The ProductImageId value must not equal to 0")
                .MustAsync(Exist)
                .WithMessage("The specified ProductImageId doesn't exist.");
        }
        public async Task<bool> Exist(long ProductImage, CancellationToken cancellationToken)
        {
            return await _dbContext.ProductImage
                .AnyAsync(c => c.Id == ProductImage);
        }
    }
}

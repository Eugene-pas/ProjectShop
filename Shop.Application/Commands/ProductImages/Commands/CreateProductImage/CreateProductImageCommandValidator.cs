using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Commands.ProductImages.Commands.CreateProductImage
{
    public class CreateProductImageCommandValidator
    : AbstractValidator<CreateProductImageCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public CreateProductImageCommandValidator(IDataBaseContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(creatProductImageCommand =>
            creatProductImageCommand.FormFiles.FileName).NotEmpty()
            .Must(ExistValidFormat)
            .WithMessage("Image format is not supported.");
            RuleFor(creatProductImageCommand =>
            creatProductImageCommand.SortOrder).NotEmpty();
            RuleFor(creatProductImageCommand =>
            creatProductImageCommand.ProductId).NotEmpty().NotEqual(0)
                .WithMessage("The ProductId value must not equal to 0.")
                .MustAsync(Exist)
                .WithMessage("The specified ProductId doesn't exist.");
        }
        public async Task<bool> Exist(long Product, CancellationToken cancellationToken)
        {
            return await _dbContext.Product
                .AnyAsync(c => c.Id == Product);
        }
        public bool ExistValidFormat(string imageName)
        {
            string format = imageName.Split('.')[1].ToLower();
            List<string> formats = new List<string>() { "jpg", "png" };
            return formats.Any(f => f == format);
        }
    }
}

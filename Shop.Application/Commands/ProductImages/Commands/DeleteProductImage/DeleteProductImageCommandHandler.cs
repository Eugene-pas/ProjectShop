using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Syroot.Windows.IO;

namespace Shop.Application.Commands.ProductImages.Commands.DeleteProductImage
{
    public class DeleteProductImageCommandHandler
        : IRequestHandler<DeleteProductImageCommand>
    {
        private readonly IDataBaseContext _dbContext;
        public DeleteProductImageCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = await _dbContext.ProductImage
                .FindAsync(new object[] {request.Id}, cancellationToken);
           
            _ = productImage ?? throw new NotFoundException(nameof(ProductImage), productImage.Id);

            if(_dbContext.ProductImage.Where(x => x.Image == productImage.Image).ToList().Count == 1)
            File.Delete(new KnownFolder(KnownFolderType.Downloads)
                .Path + @"\ShopImage"+$"\\{productImage.Image}");
            
            _dbContext.ProductImage.Remove(productImage);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

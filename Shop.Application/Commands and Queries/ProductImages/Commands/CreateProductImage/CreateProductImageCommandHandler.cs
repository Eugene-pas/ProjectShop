using DemoApi.FileSrvice;
using MediatR;
using Shop.Domain.Entities;
using Syroot.Windows.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.ProductImages.Commands.CreateProductImage
{
    public class CreateProductImageCommandHandler
        : IRequestHandler<CreateProductImageCommand, long>
    {
        private readonly IFileService _fileService;
        private readonly IDataBaseContext _dbContext;
        public CreateProductImageCommandHandler(IDataBaseContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }

        public async Task<long> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            _fileService.UploadFile(request.FormFiles,
                new KnownFolder(KnownFolderType.Downloads).Path + @"\ShopImage");
            var productImage = new ProductImage
            {
                Image = request.FormFiles.FileName,
                SortOrder = request.SortOrder,
                Product = _dbContext.Product.Find(request.ProductId)
            };
            await _dbContext.ProductImage.AddAsync(productImage, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return productImage.Id;
        }
    }
}

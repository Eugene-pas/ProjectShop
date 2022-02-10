using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.ProductImages.Commands.DeleteProductImage
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

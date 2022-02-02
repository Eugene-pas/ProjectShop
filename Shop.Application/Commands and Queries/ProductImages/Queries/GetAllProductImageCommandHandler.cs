using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.ProductImages.Queries.GetAllProducImage
{
    public class GetAllProductImageCommandHandler
        : IRequestHandler<GetAllProductImageCommand, string[]>
    {
        private readonly IDataBaseContext _dbContext;
        public GetAllProductImageCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<string[]> Handle(GetAllProductImageCommand request
            , CancellationToken cancellationToken)
        {
            
            //var listProductImage = await _dbContext.ProductImage
            //    .Include(images => images.Product)
            //    .Where(images => images.Product.Id != request.IdProduct)
            //    .ToListAsync();

            var listProductImage = await _dbContext.ProductImage
                .Where(images => images.Product == null)
                .ToListAsync();

            _ = listProductImage ?? throw new NotFoundException(
                nameof(ProductImage), request.IdProduct);

            List<string> result = new List<string>();
            foreach (var image in listProductImage)
            {
                result.Add(image.Image);
            }
            return result.ToArray();  
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, ProductVm>
    {
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IDataBaseContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);


        private readonly IDataBaseContext _dbContext;
        public UpdateProductCommandHandler(IDataBaseContext dbContext) =>
            _dbContext = dbContext;
        public async Task<ProductVm> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Product
                .FirstOrDefaultAsync(product =>
            product.Id == request.Id, cancellationToken);

            _ = product ?? throw new NotFoundException(nameof(Product), request.Id);

            product.Name = request.Name;
            product.Price = request.Price;
            product.Description = request.Description;
            product.OnStorageCount = request.OnStorageCount;
            product.Category = await _dbContext.Category.FindAsync(request.CategoryId);
            product.Seller = await _dbContext.Seller.FindAsync(request.SellerId);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductVm>(product);
        }
    }
}

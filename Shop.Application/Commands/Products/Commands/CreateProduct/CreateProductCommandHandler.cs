﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler 
        : HandlersBase, IRequestHandler<CreateProductCommand, ProductVm>
    {
        public CreateProductCommandHandler(IDataBaseContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }
        public async Task<ProductVm> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                OnStorageCount = request.OnStorageCount,
                Category = await _dbContext.Category.FindAsync(request.CategoryId),
                Seller = await _dbContext.Seller.FindAsync(request.SellerId)
            };

            await _dbContext.Product.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductVm>(product);
        }
    }
}

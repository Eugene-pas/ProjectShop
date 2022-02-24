using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.Queries.GetProductsList
{
    public class ProductsLookupDto : IMapWith<Product>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int? OnStorageCount { get; set; }

        public List<Review> Review { get; set; }

        public long CategoryId { get; set; }

        public long SellerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductsLookupDto>()
                .ForMember(productDto => productDto.Id,
                   opt => opt.MapFrom(product => product.Id))
                .ForMember(productDto => productDto.Name,
                    opt => opt.MapFrom(product => product.Name))
                 .ForMember(productDto => productDto.Price,
                    opt => opt.MapFrom(product => product.Price))
                 .ForMember(productDto => productDto.Description,
                    opt => opt.MapFrom(product => product.Description))
                 .ForMember(productDto => productDto.OnStorageCount,
                    opt => opt.MapFrom(product => product.OnStorageCount))
                 .ForMember(productDto => productDto.Review,
                    opt => opt.MapFrom(product => product.Review.ToList()))
                .ForMember(productDto => productDto.CategoryId,
                    opt => opt.MapFrom(product => product.Category.Id))
                .ForMember(productDto => productDto.SellerId,
                    opt => opt.MapFrom(product => product.Seller.Id));
        }
    }
}

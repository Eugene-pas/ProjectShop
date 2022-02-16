using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Products.Queries.GetProductsList
{
    public class ProductsLookupDto : IMapWith<Product>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int? OnStorageCount { get; set; }

        public double? Rating { get; set; }

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
                    .ForMember(productDto => productDto.Rating,
                    opt => opt.MapFrom(product => product.Rating));
        }
    }
}

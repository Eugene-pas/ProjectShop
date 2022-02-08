using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.Products
{
    public class ProductVm : IMapWith<Product>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? OnStorageCount { get; set; }
        public double? Rating { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductVm>()
                .ForMember(ProductVm => ProductVm.Id,
                   opt => opt.MapFrom(Product => Product.Id))
                .ForMember(ProductVm => ProductVm.Name,
                   opt => opt.MapFrom(Product => Product.Name))
                .ForMember(ProductVm => ProductVm.Price,
                    opt => opt.MapFrom(Product => Product.Price))
                .ForMember(ProductVm => ProductVm.Description,
                    opt => opt.MapFrom(Product => Product.Description))
                .ForMember(ProductVm => ProductVm.OnStorageCount,
                    opt => opt.MapFrom(Product => Product.OnStorageCount))
                .ForMember(ProductVm => ProductVm.Rating,
                    opt => opt.MapFrom(Product => Product.Rating));


        }
    }
}

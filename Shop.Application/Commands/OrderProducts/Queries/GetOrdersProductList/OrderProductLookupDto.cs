using AutoMapper;
using Shop.Application.Commands.Products;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System.Linq;

namespace Shop.Application.Commands.OrderProducts.Queries.GetOrdersProductList
{
    public class OrderProductLookupDto
        :IMapWith<OrderProduct>
    {
        public long Id { get; set; }

        public long OrderId { get; set; }

        public ProductVm Product { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderProduct, OrderProductLookupDto>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Product,
                opt => opt.MapFrom(x => x.Product))
                .ForMember(x => x.OrderId,
                opt => opt.MapFrom(x => x.Order.Id));
        }
    }

    public class ProductLookupDto
    : IMapWith<Product>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ProductImage { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name,
                opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Price,
                opt => opt.MapFrom(x => x.Price))
                .ForMember(x => x.ProductImage,
                opt => opt.MapFrom(x => x.ProductImage.First(x => x.Image != null).Image));
        }
    }

}

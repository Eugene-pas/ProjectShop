using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.Commands.Baskets
{
    public class BasketItemVm : IMapWith<BasketItem>
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public BasketItemImageVm ProductImage { get; set; }
        public int ProductCount { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BasketItem, BasketItemVm>()
                .ForMember(BasketItemVm => BasketItemVm.Id,
                opt => opt.MapFrom(BasketItem => BasketItem.Id))
                .ForMember(BasketItemVm => BasketItemVm.ProductId,
                opt => opt.MapFrom(BasketItem => BasketItem.Product.Id))
                .ForMember(BasketItemVm => BasketItemVm.ProductName,
                opt => opt.MapFrom(BasketItem => BasketItem.Product.Name))
                .ForMember(BasketItemVm => BasketItemVm.ProductPrice,
                opt => opt.MapFrom(BasketItem => BasketItem.Product.Price))
                .ForMember(BasketItemVm => BasketItemVm.ProductImage,
                opt => opt.MapFrom(BasketItem => BasketItem.Product.ProductImage.First(x => x.Image != null)))
                .ForMember(BasketItemVm => BasketItemVm.ProductCount,
                opt => opt.MapFrom(BasketItem => BasketItem.Count));
        }
    }
}

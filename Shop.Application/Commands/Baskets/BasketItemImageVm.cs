using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System.Linq;

namespace Shop.Application.Commands.Baskets
{
    public class BasketItemImageVm : IMapWith<ProductImage>
    {
        public string Image { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductImage, BasketItemImageVm>()
                .ForMember(BasketImageVm => BasketImageVm.Image,
                opt => opt.MapFrom(ProductImage => ProductImage.Image));
        }
    }
}
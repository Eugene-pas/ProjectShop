using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System.Collections.Generic;

namespace Shop.Application.Commands.Baskets
{
    public class BasketVm : IMapWith<Basket>
    {
        public long Id { get; set; }
        public IList<BasketItemVm> Items { get; set; }
        public decimal TotalSum { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Basket, BasketVm>()
                .ForMember(BasketVm => BasketVm.Id,
                opt => opt.MapFrom(Basket => Basket.Id))                
                .ForMember(BasketVm => BasketVm.Items,
                opt => opt.MapFrom(Basket => Basket.Items))
                .ForMember(BasketVm => BasketVm.TotalSum,
                opt => opt.MapFrom(Basket => Basket.TotalSum));
        }
    }
}

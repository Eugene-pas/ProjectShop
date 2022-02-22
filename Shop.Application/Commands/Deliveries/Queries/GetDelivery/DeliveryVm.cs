using System.Collections.Generic;
using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Deliveries.Queries.GetDelivery
{
    public class DeliveryVm : IMapWith<Delivery>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Delivery, DeliveryVm>()
                .ForMember(deliveryVm => deliveryVm.Id,
                opt => opt.MapFrom(delivery => delivery.Id))
                .ForMember(deliveryVm => deliveryVm.Name,
                opt => opt.MapFrom(delivery => delivery.Name))
                .ForMember(deliveryVm => deliveryVm.Orders,
                opt => opt.MapFrom(delivery => delivery.Order));
        }
    }
}

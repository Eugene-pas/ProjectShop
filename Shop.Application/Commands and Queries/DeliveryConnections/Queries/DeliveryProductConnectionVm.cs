using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;

namespace Shop.Application.DeliveryConnections.Queries
{
    public class DeliveryProductConnectionVm : IMapWith<DeliveryProductConnection>
    {
        public long Id { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual Product Product { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeliveryProductConnection, DeliveryProductConnectionVm>()
                .ForMember(DeliveryProductConnectionVm => DeliveryProductConnectionVm.Id,
                opt => opt.MapFrom(DeliveryProductConnection => DeliveryProductConnection.Id))
                .ForMember(DeliveryProductConnectionVm => DeliveryProductConnectionVm.Delivery,
                opt => opt.MapFrom(DeliveryProductConnection => DeliveryProductConnection.Delivery))
                .ForMember(DeliveryProductConnectionVm => DeliveryProductConnectionVm.Product,
                opt => opt.MapFrom(DeliveryProductConnection => DeliveryProductConnection.Product));
                
        }
    }
}

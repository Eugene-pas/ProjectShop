using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.DeliveryConnections.Queries.GetDeliveryProductConnectionsList
{
    public class DeliveryProductConnectionsDto : IMapWith<DeliveryProductConnection>
    {
        public long Id { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual Product Product { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeliveryProductConnection, DeliveryProductConnectionsDto>()
                .ForMember(connectionDto => connectionDto.Id,
                opt => opt.MapFrom(connection => connection.Id))
                .ForMember(connectionDto => connectionDto.Delivery,
                opt => opt.MapFrom(connection => connection.Delivery))
                .ForMember(connectionDto => connectionDto.Product,
                opt => opt.MapFrom(connection => connection.Product));
        }
    }
}

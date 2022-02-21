using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.OrderProductConnections.Queries
{
    public class OrderProductConnectionVm
        :IMapWith<OrderProductConnection>
    {
        public long Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderProductConnection, OrderProductConnectionVm>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Product,
                opt => opt.MapFrom(x => x.Product))
                .ForMember(x => x.Order,
                opt => opt.MapFrom(x => x.Order));
        }
    }
    
}

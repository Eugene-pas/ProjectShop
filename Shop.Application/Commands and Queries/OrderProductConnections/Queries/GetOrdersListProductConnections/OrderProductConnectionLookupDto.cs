using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Queries.GetOrdersListProductConnections
{
    public class OrderProductConnectionLookupDto
        :IMapWith<OrderProductConnection>
    {
        public long Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderProductConnection, OrderProductConnectionLookupDto>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Product,
                opt => opt.MapFrom(x => x.Product))
                .ForMember(x => x.Order,
                opt => opt.MapFrom(x => x.Order));

            //profile.CreateMap<Order, OrderProductConnectionLookupDto>()
            //    .ForMember(orderDto => orderDto.Order.Id,
            //    opt => opt.MapFrom(order => order.Id))
            //    .ForMember(orderDto => orderDto.Order.Date,
            //    opt => opt.MapFrom(order => order.Date))
            //    .ForMember(orderDto => orderDto.Order.Customer,
            //    opt => opt.MapFrom(order => order.Customer))
            //    .ForMember(orderDto => orderDto.Order.Adress,
            //    opt => opt.MapFrom(order => order.Adress))
            //    .ForMember(orderDto => orderDto.Order.Delivery,
            //    opt => opt.MapFrom(order => order.Delivery));
        }
    }
    
}

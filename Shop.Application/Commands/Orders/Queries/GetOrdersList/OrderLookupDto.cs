using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;

namespace Shop.Application.Orders.Queries.GetAllOrder
{
    public class OrderLookupDto
        : IMapWith<Order>
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Adress { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Delivery Delivery { get; set; }

        public void Mapping(Profile profile)
        {            
           profile.CreateMap<Order, OrderLookupDto>()
               .ForMember(x => x.Id,
               opt => opt.MapFrom(x => x.Id))
               .ForMember(x => x.Date,
               opt => opt.MapFrom(x => x.Date))
               .ForMember(x => x.Adress,
               opt => opt.MapFrom(x => x.Adress))
               .ForMember(x => x.Customer,
               opt => opt.MapFrom(x => x.Customer))
               .ForMember(x => x.Delivery,
               opt => opt.MapFrom(x => x.Delivery));           
        }
    }
}

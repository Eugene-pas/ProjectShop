using System;
using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Orders.Queries.GetOrder
{
    public class OrderVm : IMapWith<Order>
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Adress { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Delivery Delivery { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderVm>()
                .ForMember(OrderVm => OrderVm.Id, 
                   opt => opt.MapFrom(Order => Order.Id))
                .ForMember(OrderVm => OrderVm.Date, 
                   opt => opt.MapFrom(Order => Order.Date))
                .ForMember(OrderVm => OrderVm.Adress, 
                   opt => opt.MapFrom(Order => Order.Adress))
                .ForMember(OrderVm => OrderVm.Customer, 
                   opt => opt.MapFrom(Order => Order.Customer))
                .ForMember(OrderVm => OrderVm.Delivery,
                   opt => opt.MapFrom(Order => Order.Delivery));
                
        }
    }
}

﻿using System;
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
                .ForMember(orderVm => orderVm.Id, 
                   opt => opt.MapFrom(order => order.Id))
                .ForMember(orderVm => orderVm.Date, 
                   opt => opt.MapFrom(order => order.Date))
                .ForMember(orderVm => orderVm.Adress, 
                   opt => opt.MapFrom(order => order.Adress))
                .ForMember(orderVm => orderVm.Customer, 
                   opt => opt.MapFrom(order => order.Customer))
                .ForMember(orderVm => orderVm.Delivery,
                   opt => opt.MapFrom(order => order.Delivery));
                
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Shop.Application.Commands.OrderProducts.Queries;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Orders.Queries.GetOrdersList
{
    public class OrdersLookupDto : IMapWith<Order>
    {
        public long Id { get; set; }

        public string Adress { get; set; }

        public DateTime? Date { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual IList<OrderProductVm> OrderProduct { get; set; }

        public decimal TotalPrice { get; set; }

        public long DeliveryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrdersLookupDto>()
                .ForMember(orderVm => orderVm.Id,
                   opt => opt.MapFrom(order => order.Id))
                .ForMember(orderVm => orderVm.Date,
                   opt => opt.MapFrom(order => order.Date))
                .ForMember(orderVm => orderVm.Adress,
                   opt => opt.MapFrom(order => order.Adress))
                .ForMember(orderVm => orderVm.Customer,
                   opt => opt.MapFrom(order => order.Customer))
                .ForMember(orderVm => orderVm.DeliveryId,
                   opt => opt.MapFrom(order => order.Delivery.Id))
                .ForMember(orderVm => orderVm.OrderProduct,
                   opt => opt.MapFrom(order => order.OrderProduct))
                .ForMember(orderVm => orderVm.TotalPrice,
                   opt => opt.MapFrom(order => order.OrderProduct.Sum(x => x.Product.Price)));
        }
    }
}

﻿using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Queries.GetProductsListbyOrder
{
    public class GetProductListOrderLookupDto 
        : IMapWith<OrderProductConnection>
    {
        public long Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderProductConnection, GetProductListOrderLookupDto>()
                .ForMember(x => x.Order,
                opt => opt.MapFrom(x => x.Order))
                .ForMember(x => x.Product,
                opt => opt.MapFrom(x => x.Product));
        }
    }
}
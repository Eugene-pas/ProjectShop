using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.OrderProductConnections.Queries.GetOrdersListProductConnections
{
    public class OrderProductConnectionListVm
    {
        public IList<OrderProductConnectionLookupDto> OrderProductConnection { get; set; }
    }
}

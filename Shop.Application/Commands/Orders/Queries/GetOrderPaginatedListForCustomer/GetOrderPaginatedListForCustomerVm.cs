﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Orders.Queries.GetOrderPaginatedListForCustomer
{
    public class GetOrderPaginatedListForCustomerVm
    {
        public IList<GetOrderPaginatedListForCustomerDto> ListOrders { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}
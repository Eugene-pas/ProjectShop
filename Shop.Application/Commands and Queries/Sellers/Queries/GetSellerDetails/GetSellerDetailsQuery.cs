﻿using MediatR;

namespace Shop.Application.Sellers.Queries.GetSellerDetails
{
    public class GetSellerDetailsQuery : IRequest<SellerDetailsVm>
    {
        public long Id { get; set; }
    }
}
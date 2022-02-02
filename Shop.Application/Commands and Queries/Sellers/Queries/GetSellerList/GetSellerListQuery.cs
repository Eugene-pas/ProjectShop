using System;
using MediatR;

namespace Shop.Application.Sellers.Queries.GetSellerList
{
    public class GetSellerListQuery : IRequest<SellerListVm>
    {
        public long Id { get; set; }
    }
}

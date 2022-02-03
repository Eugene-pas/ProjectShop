using System;
using MediatR;

namespace Shop.Application.Sellers.Queries.GetSellerList
{
    public class GetSellersListQuery : IRequest<SellersListVm>
    {
        public long Id { get; set; }
    }
}

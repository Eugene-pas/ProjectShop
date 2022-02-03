using System;
using MediatR;

namespace Shop.Application.Sellers.Queries.GetSellersList
{
    public class GetSellersListQuery : IRequest<SellersListVm>
    {
        public long Id { get; set; }
    }
}

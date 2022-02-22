using MediatR;

namespace Shop.Application.Commands.Sellers.Queries.GetSellersList
{
    public class GetSellersListQuery : IRequest<SellersListVm>
    {
        public long Id { get; set; }
    }
}

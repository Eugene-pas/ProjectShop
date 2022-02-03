using MediatR;

namespace Shop.Application.Sellers.Queries.GetSeller
{
    public class GetSeller : IRequest<SellerVm>
    {
        public long Id { get; set; }
    }
}
